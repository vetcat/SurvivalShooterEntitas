using System;
using Libs.OpenCore.Ecs;
using UnityEngine;
using Zenject;

namespace Game.Models.PlayerCharacter
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerCharacterView : EntityView
    {
        [SerializeField] private Transform _gunPivot;
        private Rigidbody _rigidbody;
        private Transform _transform;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public Rigidbody GetRigidbody
        {
            get
            {
                if (_rigidbody == null)
                    _rigidbody = GetComponent<Rigidbody>();

                return _rigidbody;
            }
        }

        public class Factory : PlaceholderFactory<PlayerCharacterView>
        {
        }
        
        //
        private void FixedUpdate()
        {
            var movement = new Vector3(Input.GetAxisRaw("Horizontal"),  0f, Input.GetAxisRaw("Vertical"));

            movement = movement.normalized * 6 * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            GetRigidbody.MovePosition (transform.position + movement);
        }
        //
    }
}
