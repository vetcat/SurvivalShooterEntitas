using Game.Installers;
using Game.Models.PlayerCharacter;
using Game.Providers;
using Game.Settings;
using Game.Systems;
using Libs.OpenCore.Providers;
using NSubstitute;
using NUnit.Framework;
using Tests.UnitTests.Editor.SetUp;
using UnityEngine;
using Zenject;

namespace Tests.UnitTests.Editor.Ecs.Game.Systems
{
    public class PlayerTurningSystemTests : EcsTestBase
    {
        private readonly IGameParametersSettings _gameParametersSettings = Substitute.For<IGameParametersSettings>();
        private readonly IInputProvider _inputProvider = Substitute.For<IInputProvider>();
        private readonly ICameraProvider _cameraProvider = Substitute.For<ICameraProvider>();

        [Inject] private IPlayerCharacterEntityFactory _playerCharacterEntityFactory;
        [Inject] private PlayerTurningSystem _playerTurningSystem;
        
        protected override void InstallBindings(DiContainer container)
        {
            container.Bind<IGameParametersSettings>().FromInstance(_gameParametersSettings);
            container.Bind<IInputProvider>().FromInstance(_inputProvider);
            container.Bind<ICameraProvider>().FromInstance(_cameraProvider);
            
            var gamePrefabsInstaller = Resources.Load("Game/GamePrefabsInstaller") as GamePrefabsInstaller;
            container.BindFactory<PlayerCharacterView, PlayerCharacterView.Factory>()
                .FromComponentInNewPrefab(gamePrefabsInstaller.PlayerCharacterView.gameObject);
            
            container.BindInterfacesAndSelfTo<PlayerCharacterEntityFactory>().AsSingle().NonLazy();
            
            container.BindInterfacesAndSelfTo<PlayerTurningSystem>().AsSingle().NonLazy();
        }

        //todo : late test physic rotation in Integration test
        [Test]
        public void ChangeTarget_RotateToTarget()
        {
            var playerEntity = _playerCharacterEntityFactory.Create();
            var startRotation = playerEntity.playerCharacterView.Value.transform.rotation;
            
            var targetPoint = new Vector3(1f, 1f, -1f);
            _cameraProvider.GetLayerHitPoint(Arg.Any<int>(), Arg.Any<Vector2>(), Arg.Any<float>()).Returns(targetPoint);
            
            NextFrame(0.1f);
            var direction =
                _playerTurningSystem.GetRotationDirection(playerEntity.playerCharacterView.Value, targetPoint);
            
            Assert.AreNotEqual(startRotation, direction);
        }
    }
}