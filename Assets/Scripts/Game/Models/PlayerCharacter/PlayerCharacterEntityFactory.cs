using Game.Settings;
using UnityEngine;

namespace Game.Models.PlayerCharacter
{
    public class PlayerCharacterEntityFactory : IPlayerCharacterEntityFactory
    {
        private readonly GameContext _gameContext;
        private readonly IGameParametersSettings _gameParametersSettings;
        private readonly PlayerCharacterView.Factory _viewFactory;

        public PlayerCharacterEntityFactory(GameContext gameContext, IGameParametersSettings gameParametersSettings,
            PlayerCharacterView.Factory viewFactory)
        {
            _gameContext = gameContext;
            _gameParametersSettings = gameParametersSettings;
            _viewFactory = viewFactory;
        }

        public GameEntity Create()
        {
            var entity = _gameContext.CreateEntity();
            entity.isPlayerCharacter = true;
            entity.AddHealth(_gameParametersSettings.StartingPlayerHealth);
            entity.AddPlayerInput(Vector3.zero, Vector2.zero);

            AddView(entity);

            return entity;
        }

        private void AddView(GameEntity entity)
        {
            var view = _viewFactory.Create();
            view.Link(entity);
            entity.AddEntityView(view);
            entity.AddPlayerCharacterView(view);
        }
    }
}