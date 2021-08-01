using Game.Providers;
using Zenject;

namespace Game.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindProviders();
        }

        private void BindProviders()
        {
            Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle().NonLazy();
        }
    }
}