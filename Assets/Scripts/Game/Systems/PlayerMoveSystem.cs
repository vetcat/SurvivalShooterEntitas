using System.Collections.Generic;
using Entitas;
using Game.Models.PlayerCharacter;
using Game.Providers;
using Game.Settings;
using Libs.OpenCore.Ecs;
using Libs.OpenCore.Providers;
using UnityEngine;

namespace Game.Systems
{
    public class PlayerMoveSystem : IFixedSystem, IPlayerMoveSystem
    {
        private readonly GameContext _gameContext;
        private readonly ITimeProvider _timeProvider;
        private readonly IGameParametersSettings _gameParametersSettings;
        private readonly IInputProvider _inputProvider;
        private readonly IGroup<GameEntity> _playersGroup;
        private readonly List<GameEntity> _playersBuffer = new List<GameEntity>();

        public PlayerMoveSystem(GameContext gameContext, IGameParametersSettings gameParametersSettings, IInputProvider inputProvider)
        {
            _gameContext = gameContext;
            _gameParametersSettings = gameParametersSettings;
            _inputProvider = inputProvider;
            _playersGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerCharacterView)
                .NoneOf(GameMatcher.Death, GameMatcher.Destroyed));
        }

        public Vector3 GetMovePosition(PlayerCharacterView playerCharacterView)
        {
            var speed = _gameParametersSettings.PlayerMoveSpeed;
            return playerCharacterView.GetRigidbody.position + _inputProvider.InputVector *  _gameContext.deltaTime.Value * speed; 
        }

        public void Execute()
        {
            _playersGroup.GetEntities(_playersBuffer);

            // for (var i = 0; i < _playersBuffer.Count; i++)
            // {
            //     var playerView = _playersBuffer[i].playerCharacterView.Value;
            //     MovePlayer(playerView);
            // }

            var playerView = _playersBuffer[0].playerCharacterView.Value;
            Vector3 movement = _inputProvider.InputVector;
            
            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement.normalized * _gameParametersSettings.PlayerMoveSpeed * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerView.GetRigidbody.MovePosition ( playerView.transform.position + movement);
        }

        private void MovePlayer(PlayerCharacterView playerView)
        {
            var movePosition = GetMovePosition(playerView);
            playerView.GetRigidbody.MovePosition(movePosition);
        }
    }
}