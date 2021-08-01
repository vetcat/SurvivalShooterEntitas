using System.Collections.Generic;
using Entitas;
using Game.Providers;
using Game.Settings;
using Libs.OpenCore.Ecs;
using Libs.OpenCore.Providers;
using UnityEngine;

namespace Game.Systems
{
    public class PlayerMoveSystem : IFixedSystem
    {
        private readonly ITimeProvider _timeProvider;
        private readonly IGameParametersSettings _gameParametersSettings;
        private readonly IInputProvider _inputProvider;
        private readonly IGroup<GameEntity> _playersGroup;
        private readonly List<GameEntity> _playersBuffer = new List<GameEntity>();

        public PlayerMoveSystem(GameContext gameContext, ITimeProvider timeProvider,
            IGameParametersSettings gameParametersSettings, IInputProvider inputProvider)
        {
            _timeProvider = timeProvider;
            _gameParametersSettings = gameParametersSettings;
            _inputProvider = inputProvider;
            _playersGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerCharacterView)
                .NoneOf(GameMatcher.Death, GameMatcher.Destroyed));
        }

        public void Fixed()
        {
            var inputVector = _inputProvider.InputVector;
            if (inputVector == Vector3.zero)
                return;
                
            _playersGroup.GetEntities(_playersBuffer);
            
            for (var i = 0; i < _playersBuffer.Count; i++)
            {
                var playerView = _playersBuffer[i].playerCharacterView.Value;
                var speed = _gameParametersSettings.PlayerMoveSpeed;
               
                var movePosition = playerView.GetRigidbody.position +  inputVector* _timeProvider.DeltaTime * speed;
                playerView.GetRigidbody.MovePosition(movePosition);
            }
        }
    }
}