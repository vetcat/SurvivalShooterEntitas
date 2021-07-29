using System;
using Libs.OpenCore.Providers;
using UnityEngine;

namespace ProjectContext.Providers
{
    public class TimeProvider : ITimeProvider
    {
        public float DeltaTime => Time.deltaTime;
        public float FixedDeltaTime => Time.fixedDeltaTime;
        public DateTime GetUtcTime => DateTime.UtcNow;
    }
}