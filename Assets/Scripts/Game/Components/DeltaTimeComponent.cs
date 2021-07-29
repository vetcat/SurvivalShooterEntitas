using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Features.Game.Components
{
    [Game, Unique]
    public class DeltaTimeComponent : IComponent
    {
        public float Value;
    }
}