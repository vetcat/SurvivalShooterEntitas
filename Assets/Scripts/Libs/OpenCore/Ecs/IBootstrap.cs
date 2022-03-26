using System;
using Zenject;

namespace Libs.OpenCore.Ecs
{
    public interface IBootstrap : IInitializable, IDisposable
    {
        void Pause(bool isPaused);
        void Reset();
    }
}