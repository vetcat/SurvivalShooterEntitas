using Entitas;

namespace Libs.OpenCore.Ecs.Common.Components
{
    [Game]
    public class EntityViewComponent : IComponent
    {
        public IEntityView Value;
    }
}