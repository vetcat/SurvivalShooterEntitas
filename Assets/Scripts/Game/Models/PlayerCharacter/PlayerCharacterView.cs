using UnityEngine;
using Zenject;

namespace Game.Models.PlayerCharacter
{
    public class PlayerCharacterView : MonoBehaviour
    {
        [SerializeField] private Transform _gunPivot; 
        
        public class Factory : PlaceholderFactory<PlayerCharacterView>
        {
        }
    }
}
