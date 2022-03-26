using Entitas;
using UnityEngine;

namespace Libs.OpenCore.Ecs
{
    public interface IEntityView
    {
        void Link(IEntity entity);
        GameObject GameObject { get; }
        GameEntity Entity { get; }
    }
}