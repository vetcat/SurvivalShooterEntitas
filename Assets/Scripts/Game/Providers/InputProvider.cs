using UnityEngine;

namespace Game.Providers
{
    public class InputProvider : IInputProvider
    {
        public Vector3 InputVector => new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }
}