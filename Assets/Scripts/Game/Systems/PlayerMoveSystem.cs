using System.Collections.Generic;
using Entitas;
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
        private readonly IGroup<GameEntity> _playersGroup;
        private readonly List<GameEntity> _playersBuffer = new List<GameEntity>();

        public PlayerMoveSystem(GameContext gameContext, IGameParametersSettings gameParametersSettings, ITimeProvider timeProvider)
        {
            _gameParametersSettings = gameParametersSettings;
            _timeProvider = timeProvider;
            _playersGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerCharacter)
                .NoneOf(GameMatcher.Death, GameMatcher.Destroyed));
        }

        public void Execute()
        {
            _playersGroup.GetEntities(_playersBuffer);
            
            for (var i = 0; i < _playersBuffer.Count; i++)
            {
                MovePlayer(_playersBuffer[i]);
            }
        }
        
        public Vector3 GetNextMovePosition(GameEntity player)
        {
            var speed = _gameParametersSettings.PlayerMoveSpeed;
            var nextMovementPosition = player.playerInput.InputVector.normalized * _timeProvider.DeltaTime * speed;
            return player.playerCharacterView.Value.transform.position + nextMovementPosition;
        }

        private void MovePlayer(GameEntity player)
        {
            var movePosition = GetNextMovePosition(player);
            player.playerCharacterView.Value.Rigidbody.MovePosition(movePosition);
        }
    }
}