using Game.Systems;
using NUnit.Framework;
using Tests.Editor.SetUp;
using Zenject;

namespace Tests.Editor.Ecs.Game.Systems
{
    public class DeltaTimeUpdateSystemTest : EcsTestBase
    {
        [Inject] private GameContext _gameContext;
        protected override void InstallBindings(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<DeltaTimeUpdateSystem>().AsSingle();
        }

        [Test]
        public void GameContext_SetDeltaTime_InFrame()
        {
            var dt = 0.1f;
            NextFrame(dt);
            Assert.AreEqual(dt, _gameContext.deltaTime.Value);

            dt = 0.2f;
            NextFrame(dt);
            Assert.AreEqual(dt, _gameContext.deltaTime.Value);
        }
    }
}