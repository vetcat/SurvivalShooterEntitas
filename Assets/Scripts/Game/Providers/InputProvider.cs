using UnityEngine;

namespace Game.Providers
{
    public class InputProvider : IInputProvider
    {
        //public Vector3 InputVector => new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        public Vector3 InputVector => new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }
}