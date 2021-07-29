using Entitas;
using Zenject;

namespace Libs.OpenCore.Ecs.Extensions
{
    public static class ContextExtension
    {
        public static void BindDestroyedCleanup<TContext, TEntity>(this DiContainer container,
            IMatcher<TEntity> matcher)
            where TEntity : class, IEntity
            where TContext : class, IContext<TEntity>
        {
            container.Bind<IMatcher<TEntity>>().FromInstance(matcher)
                .WhenInjectedInto<DestroyedCleaner<TContext, TEntity>>();
            container.BindInterfacesAndSelfTo<DestroyedCleaner<TContext, TEntity>>().AsSingle().NonLazy();
        }
    }
}