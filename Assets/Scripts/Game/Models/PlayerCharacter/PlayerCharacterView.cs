using Libs.OpenCore.Ecs;
using UnityEngine;
using Zenject;

namespace Game.Models.PlayerCharacter
{
    public class PlayerCharacterView : EntityView
    {
        [SerializeField] private Transform _gunPivot; 
        
        public class Factory : PlaceholderFactory<PlayerCharacterView>
        {
        }
    }
}
