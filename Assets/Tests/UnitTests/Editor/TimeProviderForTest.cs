using System;
using Game.Providers;
using Libs.OpenCore.Providers;

namespace Tests.Editor
{
    public class TimeProviderForTest : ITimeProvider
    {
        public float DeltaTime { get; private set; }
        public float FixedDeltaTime { get; private set; }
        public DateTime GetUtcTime { get; private set; }
        public DateTime GetDestroyDateTimeFromSeconds(int lifeTimeSeconds)
        {
            throw new NotImplementedException();
        }

        public void SetDeltaTime(float dt) => DeltaTime = dt;

        public void SetFixedDeltaTime(float fixedDeltaTime) => FixedDeltaTime = fixedDeltaTime;

        public void SetUtcTime(DateTime utcTime) => GetUtcTime = utcTime;
    }
}