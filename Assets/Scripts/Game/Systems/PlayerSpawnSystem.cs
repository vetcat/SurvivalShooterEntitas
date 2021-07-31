using Entitas;
using Game.Models.PlayerCharacter;

namespace Game.Systems
{
    public class PlayerSpawnSystem : IInitializeSystem
    {
        private readonly IPlayerCharacterEntityFactory _playerCharacterEntityFactory;

        public PlayerSpawnSystem(IPlayerCharacterEntityFactory playerCharacterEntityFactory)
        {
            _playerCharacterEntityFactory = playerCharacterEntityFactory;
        }

        public void Initialize()
        {
            var entity = _playerCharacterEntityFactory.Create();
        }
    }
}