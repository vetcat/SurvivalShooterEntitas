using Game.Installers;
using Game.Models.PlayerCharacter;
using Game.Providers;
using Game.Settings;
using Game.Systems;
using NSubstitute;
using NUnit.Framework;
using Tests.Editor.SetUp;
using Zenject;
using UnityEngine;

namespace Tests.Editor.Ecs.Game.Systems
{
    public class PlayerMoveSystemTests : EcsTestBase
    {
        private readonly IGameParametersSettings _gameParametersSettings = Substitute.For<IGameParametersSettings>();
        private readonly IInputProvider _inputProvider = Substitute.For<IInputProvider>();

        [Inject] private IPlayerCharacterEntityFactory _playerCharacterEntityFactory;
        [Inject] private IPlayerMoveSystem _playerMoveSystem;
        protected override void InstallBindings(DiContainer container)
        {
            container.Bind<IGameParametersSettings>().FromInstance(_gameParametersSettings);
            container.Bind<IInputProvider>().FromInstance(_inputProvider);
            
            var gamePrefabsInstaller = Resources.Load("Game/GamePrefabsInstaller") as GamePrefabsInstaller;
            container.BindFactory<PlayerCharacterView, PlayerCharacterView.Factory>()
                .FromComponentInNewPrefab(gamePrefabsInstaller.PlayerCharacterView.gameObject);
            
            container.BindInterfacesAndSelfTo<PlayerCharacterEntityFactory>().AsSingle().NonLazy();
            
            container.BindInterfacesAndSelfTo<PlayerMoveSystem>().AsSingle().NonLazy();
        }

        [Test]
        public void InputVector_NotZero_ChangeMovePosition()
        {
            var playerEntity = _playerCharacterEntityFactory.Create();
            var startPosition = playerEntity.playerCharacterView.Value.transform.position;
            
            _inputProvider.InputVector.Returns(Vector3.forward);
            _gameParametersSettings.PlayerMoveSpeed.Returns(10f);

            //run update fixed update and other
            NextFrame(0.1f);
            
            var movePosition = _playerMoveSystem.GetMovePosition(playerEntity.playerCharacterView.Value);
            Assert.AreNotEqual(startPosition, movePosition);
        }
        
        [Test]
        public void InputVector_IsZero_NoChangeMovePosition()
        {
            var playerEntity = _playerCharacterEntityFactory.Create();
            var startPosition = playerEntity.playerCharacterView.Value.transform.position;
            
            _inputProvider.InputVector.Returns(Vector3.zero);
            _gameParametersSettings.PlayerMoveSpeed.Returns(10f);

            //run update fixed update and other
            NextFrame(0.1f);
            
            var movePosition = _playerMoveSystem.GetMovePosition(playerEntity.playerCharacterView.Value);
            Assert.AreEqual(startPosition, movePosition);
        }
    }
}