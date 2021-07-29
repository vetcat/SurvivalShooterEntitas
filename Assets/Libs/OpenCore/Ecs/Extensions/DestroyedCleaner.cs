using System.Collections.Generic;
using Entitas;

namespace Libs.OpenCore.Ecs.Extensions
{
    public class DestroyedCleaner<TContext, TEntity> : ICleanupSystem
        where TEntity : class, IEntity
        where TContext : class, IContext<TEntity>
    {
        private IGroup<TEntity> _group;
        private List<TEntity> _list = new List<TEntity>();

        public DestroyedCleaner(TContext context, IMatcher<TEntity> matcher)
        {
            _group = context.GetGroup(matcher);
        }

        public void Cleanup()
        {
            _list = _group.GetEntities(_list);
            for (var i = 0; i < _list.Count; i++)
            {
                _list[i].Destroy();
            }
        }
    }
}