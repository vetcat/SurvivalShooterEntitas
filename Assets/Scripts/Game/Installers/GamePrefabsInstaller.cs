using Game.Models.PlayerCharacter;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    [CreateAssetMenu(fileName = "GamePrefabsInstaller", menuName = "Installers/GamePrefabsInstaller")]
    public class GamePrefabsInstaller : ScriptableObjectInstaller<GamePrefabsInstaller>
    {
        public PlayerCharacterView PlayerCharacterView;
    
        public override void InstallBindings()
        {
            BindPrefabs();
        }

        private void BindPrefabs()
        {
            Container.BindFactory<PlayerCharacterView, PlayerCharacterView.Factory>()
                .FromComponentInNewPrefab(PlayerCharacterView.gameObject);
        }
    }
}