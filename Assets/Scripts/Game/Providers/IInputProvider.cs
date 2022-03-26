using UnityEngine;

namespace Game.Providers
{
    public interface IInputProvider
    {
        Vector3 InputVector { get; }
        Vector2 MousePosition { get; }
    }
}