using Game.Settings;
using UnityEngine;

namespace Game.Models.PlayerCharacter
{
    public class PlayerCharacterEntityFactory : IPlayerCharacterEntityFactory
    {
        private readonly GameContext _gameContext;
        private readonly IGameParametersSettings _gameParametersSettings;

        public PlayerCharacterEntityFactory(GameContext gameContext, IGameParametersSettings gameParametersSettings)
        {
            _gameContext = gameContext;
            _gameParametersSettings = gameParametersSettings;
        }

        public GameEntity Create()
        {
            var entity = _gameContext.CreateEntity();
            entity.isPlayerCharacter = true;
            entity.AddHealth(_gameParametersSettings.StartingPlayerHealth);
            entity.AddPlayerInput(Vector2.zero, Vector2.zero, false);

            return entity;
        }
    }
}