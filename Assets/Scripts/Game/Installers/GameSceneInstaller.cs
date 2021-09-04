using Game.Models.CameraModel;
using Game.Providers;
using Libs.OpenCore.Providers;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private CameraView _cameraView;
        
        public override void InstallBindings()
        {
            BindProviders();
        }

        private void BindProviders()
        {
            Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle().WithArguments(_cameraView).NonLazy();
        }
    }
}