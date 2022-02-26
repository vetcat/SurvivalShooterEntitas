using Game.Models.PlayerCharacter;
using Game.Systems;
using Libs.OpenCore.Ecs;
using Libs.OpenCore.Ecs.Extensions;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class GameEcsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("[GameEcsInstaller] InstallBindings");
            var contexts = Contexts.sharedInstance;

            Container.BindInstance(contexts).WithId(gameObject.name);
            //todo later - after add events
            //Container.BindInstance(contexts).WhenInjectedInto<GameEventSystems>();

            foreach (var context in contexts.allContexts)
                Container.Bind(context.GetType()).FromInstance(context).AsSingle();

            BindEntityFactories();
            BindSystems();
            
            // Cleanup destroyed entity
            Container.BindDestroyedCleanup<GameContext, GameEntity>(GameMatcher.Destroyed);
            //... add if there is more Contexts 
            
            // Main Bootstrap
            Container.BindInstance(contexts).WhenInjectedInto<MainBootstrap>();
            Container.BindInterfacesTo<MainBootstrap>().AsSingle().NonLazy();
        }

        //the order of work of the systems depends on the order of binding 
        private void BindSystems()
        {
            //-- Hi priority 
            Container.BindInterfacesAndSelfTo<PlayerSpawnSystem>().AsSingle();
            
            //-- Medium 
            Container.BindInterfacesAndSelfTo<PlayerMoveSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraFollowSystem>().AsSingle();
            
            //-- Low priority (CleanUp systems)
        }

        private void BindEntityFactories()
        {
            Container.BindInterfacesTo<PlayerCharacterEntityFactory>().AsSingle().NonLazy();
        }
    }
}