using Game.Settings;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private GameParametersSettings _gameParametersSettings;
        [SerializeField] private GameSoundFxSettings _gameSoundFxSettings;
        
        public override void InstallBindings()
        {
            BindSettings();
        }
        
        private void BindSettings()
        {
            Container.Bind<IGameParametersSettings>().FromInstance(_gameParametersSettings);
            Container.Bind<IGameSoundFxSettings>().FromInstance(_gameSoundFxSettings);
        }
    }
}