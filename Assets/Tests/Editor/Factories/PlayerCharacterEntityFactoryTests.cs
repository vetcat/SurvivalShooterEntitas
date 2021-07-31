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
    }
}