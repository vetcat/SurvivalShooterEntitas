using Entitas;

namespace Libs.OpenCore.Ecs
{
    public interface ILateSystem : ISystem
    {
        void Late();
    }
}