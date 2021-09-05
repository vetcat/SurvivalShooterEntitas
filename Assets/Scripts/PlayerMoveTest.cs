using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var movement = new Vector3(Input.GetAxisRaw("Horizontal"),  0f, Input.GetAxisRaw("Vertical"));
        movement = movement.normalized * 6 * Time.deltaTime;
        _rigidbody.MovePosition (transform.position + movement);
    }
}
