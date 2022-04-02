using System.Collections.Generic;
using Entitas;
using Game.Providers;

namespace Game.Systems
{
    public class PlayerInputSystem : IExecuteSystem
    {
        private readonly IInputProvider _inputProvider;
        private readonly IGroup<GameEntity> _playersGroup;
        private readonly List<GameEntity> _playersBuffer = new List<GameEntity>();
        
        public PlayerInputSystem(GameContext gameContext, IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
            _playersGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerCharacter)
                .NoneOf(GameMatcher.Death, GameMatcher.Destroyed));
        }

        public void Execute()
        {
            _playersGroup.GetEntities(_playersBuffer);

            for (var i = 0; i < _playersBuffer.Count; i++)
            {
                _playersBuffer[i].playerInput.InputVector = _inputProvider.InputVector;
                _playersBuffer[i].playerInput.MousePosition = _inputProvider.MousePosition;
            }
        }
    }
}