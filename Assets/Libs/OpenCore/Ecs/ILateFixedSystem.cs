using Entitas;

namespace Libs.OpenCore.Ecs
{
    public interface ILateFixedSystem : ISystem
    {
        void LateFixed();
    }
}