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
        private readonly ITimeProvider _timeProvider;
        private readonly IGameParametersSettings _gameParametersSettings;
        private readonly IInputProvider _inputProvider;
        private readonly IGroup<GameEntity> _playersGroup;
        private readonly List<GameEntity> _playersBuffer = new List<GameEntity>();

        public PlayerMoveSystem(GameContext gameContext, IGameParametersSettings gameParametersSettings, IInputProvider inputProvider, ITimeProvider timeProvider)
        {
            _gameParametersSettings = gameParametersSettings;
            _inputProvider = inputProvider;
            _timeProvider = timeProvider;
            _playersGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerCharacterView)
                .NoneOf(GameMatcher.Death, GameMatcher.Destroyed));
        }

        public void Execute()
        {
            _playersGroup.GetEntities(_playersBuffer);
            
            for (var i = 0; i < _playersBuffer.Count; i++)
            {
                var playerView = _playersBuffer[i].playerCharacterView.Value;
                MovePlayer(playerView);
            }
        }
        
        public Vector3 GetNextMovePosition(PlayerCharacterView playerCharacterView)
        {
            var speed = _gameParametersSettings.PlayerMoveSpeed;
            var nextMovementPosition = _inputProvider.InputVector.normalized * _timeProvider.DeltaTime * speed;
            return playerCharacterView.transform.position + nextMovementPosition;
        }

        private void MovePlayer(PlayerCharacterView playerView)
        {
            var movePosition = GetNextMovePosition(playerView);
            playerView.Rigidbody.MovePosition(movePosition);
        }
    }
}