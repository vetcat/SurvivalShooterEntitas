using Libs.OpenCore.Ecs;
using UnityEngine;
using Zenject;

namespace Game.Models.PlayerCharacter
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerCharacterView : EntityView
    {
        [SerializeField] private Transform _gunPivot;
        private Transform _transform;

        public Rigidbody Rigidbody { get; private set; }

        [Inject]
        public void Construct()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        public class Factory : PlaceholderFactory<PlayerCharacterView>
        {
        }
    }
}
