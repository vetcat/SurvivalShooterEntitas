using Entitas;
using UnityEngine;

namespace Game.Components
{
    [Game]
    public class PlayerInputComponent : IComponent
    {
        public Vector2 Move;
        public Vector2 Lock;
        public bool Shot;
    }
}