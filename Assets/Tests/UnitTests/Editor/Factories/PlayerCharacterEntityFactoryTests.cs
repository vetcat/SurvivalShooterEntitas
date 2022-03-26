using Game.Installers;
using Game.Models.PlayerCharacter;
using Game.Settings;
using NUnit.Framework;
using Tests.Editor.SetUp;
using UnityEngine;
using Zenject;

namespace Tests.Editor.Factories
{
    public class PlayerCharacterEntityFactoryTests : EcsTestBase
    {
        [Inject] private IPlayerCharacterEntityFactory _playerCharacterEntityFactory;
        protected override void InstallBindings(DiContainer container)
        {
            var parametersSettings = Resources.Load("Game/Settings/GameParametersSettings") as GameParametersSettings;
            container.Bind<IGameParametersSettings>().FromInstance(parametersSettings);
            
            var gamePrefabsInstaller = Resources.Load("Game/GamePrefabsInstaller") as GamePrefabsInstaller;
            container.BindFactory<PlayerCharacterView, PlayerCharacterView.Factory>()
                .FromComponentInNewPrefab(gamePrefabsInstaller.PlayerCharacterView.gameObject);
            
            container.BindInterfacesAndSelfTo<PlayerCharacterEntityFactory>().AsSingle().NonLazy();
        }

        [Test]
        public void Factory_Create_EntityIsNotNull()
        {
            var entity = _playerCharacterEntityFactory.Create();
            Assert.IsNotNull(entity);
        }
        
        [Test]
        public void Factory_CreateEntity_HasGameObjectOnScene()
        {
            var entity = _playerCharacterEntityFactory.Create();

            var playerCharacter = Object.FindObjectOfType<PlayerCharacterView>();
            Assert.IsNotNull(playerCharacter);
        }
        
        [Test]
        public void Factory_CreateEntity_HasRigidbody()
        {
            var entity = _playerCharacterEntityFactory.Create();

            var playerCharacter = entity.playerCharacterView.Value;
            Assert.IsNotNull(playerCharacter.Rigidbody);
        }
        
        [Test]
        public void Factory_CreateEntity_HasRigidbodyComponent()
        {
            var entity = _playerCharacterEntityFactory.Create();

            var playerCharacter = entity.playerCharacterView.Value;
            var rigidbodyComponent = playerCharacter.GetComponent<Rigidbody>();
            Assert.AreEqual(true, rigidbodyComponent != null);
        }
    }
}