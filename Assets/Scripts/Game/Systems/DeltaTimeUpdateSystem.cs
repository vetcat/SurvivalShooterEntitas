using Entitas;
using Libs.OpenCore.Providers;

namespace Game.Systems
{
    public class DeltaTimeUpdateSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly ITimeProvider _timeProvider;

        public DeltaTimeUpdateSystem(GameContext gameContext, ITimeProvider timeProvider)
        {
            _gameContext = gameContext;
            _timeProvider = timeProvider;
        }

        public void Execute()
        {
            _gameContext.ReplaceDeltaTime(_timeProvider.DeltaTime);
        }
    }
}