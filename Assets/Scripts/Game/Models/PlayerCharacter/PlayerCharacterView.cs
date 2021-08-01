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
    }
}
