using Entitas;

namespace Libs.OpenCore.Ecs
{
    public interface IFixedSystem : ISystem
    {
        void Fixed();
    }
}