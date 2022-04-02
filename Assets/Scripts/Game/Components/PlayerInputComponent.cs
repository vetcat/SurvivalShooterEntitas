using Entitas;
using UnityEngine;

namespace Game.Components
{
    [Game]
    public class PlayerInputComponent : IComponent
    {
        public Vector3 InputVector;
        public Vector2 MousePosition;
    }
}