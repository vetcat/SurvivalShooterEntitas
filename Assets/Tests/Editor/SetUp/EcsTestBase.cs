using Libs.OpenCore.Ecs;
using Libs.OpenCore.Ecs.Extensions;
using Zenject;

namespace Tests.Editor.SetUp
{
    public abstract class EcsTestBase : TestBase
    {
        [Inject] private MainBootstrap _bootstrap;
        [Inject] private TimeProviderForTest _timeProvider;

        protected override void Install(DiContainer container)
        {
            AutoInitialize = false;
            container.BindInterfacesAndSelfTo<TimeProviderForTest>().AsSingle().NonLazy();
            container.BindInterfacesAndSelfTo<MainBootstrap>().AsSingle().WithArguments("Test");

            var contexts = Contexts.sharedInstance;
            container.Bind<Contexts>().FromInstance(contexts).AsSingle();
            container.BindInterfacesAndSelfTo<GameContext>().FromInstance(contexts.game).AsSingle();
            //... add if there is more Contexts 

            InstallBindings(container);

            //todo later - after add events
            //container.BindInterfacesAndSelfTo<GameEventSystems>().AsSingle().NonLazy();
            container.BindDestroyedCleanup<GameContext, GameEntity>(GameMatcher.Destroyed);
            //... add if there is more Contexts 
        }

        protected abstract void InstallBindings(DiContainer container);

        protected void NextFrame(float deltaTime = 0f)
        {
            _timeProvider.SetDeltaTime(deltaTime);

            _bootstrap.FixedTick();
            _bootstrap.LateFixed();
            _bootstrap.Tick();
            _bootstrap.LateTick();
            _bootstrap.GuiRender();
            _bootstrap.GizmoRender();
        }
    }
}
