namespace Game.Models.PlayerCharacter
{
    public class PlayerCharacterEntityFactory : IPlayerCharacterEntityFactory
    {
        private readonly GameContext _gameContext;

        public PlayerCharacterEntityFactory(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public GameEntity Create()
        {
            var entity = _gameContext.CreateEntity();

            return entity;
        }
    }
}