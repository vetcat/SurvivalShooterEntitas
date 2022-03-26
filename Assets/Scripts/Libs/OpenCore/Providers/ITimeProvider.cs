using System;

namespace Libs.OpenCore.Providers
{
    public interface ITimeProvider
    {
        float DeltaTime { get; }
        float FixedDeltaTime { get; }
        DateTime GetUtcTime { get; }
    }
}