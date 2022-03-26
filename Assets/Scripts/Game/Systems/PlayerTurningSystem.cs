using System.Collections.Generic;
using Entitas;
using Libs.OpenCore.Ecs;
using UnityEngine;

namespace Game.Systems
{
    public class PlayerTurningSystem : IFixedSystem
    {
        private readonly IGroup<GameEntity> _playersGroup;
        private readonly List<GameEntity> _playersBuffer = new List<GameEntity>();
        
        public PlayerTurningSystem(GameContext gameContext)
        {
            _playersGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerCharacterView)
                .NoneOf(GameMatcher.Death, GameMatcher.Destroyed));
        }

        public void Execute()
        {
            _playersGroup.GetEntities(_playersBuffer);
            
            for (var i = 0; i < _playersBuffer.Count; i++)
            {
               
            }
        }
    }
}