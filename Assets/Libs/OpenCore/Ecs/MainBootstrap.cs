using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Zenject;

namespace Libs.OpenCore.Ecs
{
    public class MainBootstrap : IBootstrap, ITickable, ILateTickable, IFixedTickable
    {
        private readonly Contexts _contexts;
        
        private readonly Feature _featureMain;
        private readonly Feature _featureFixedSystems;
        private readonly Feature _featureLateFixedSystems;

        private readonly List<IResetable> _resetables;
        
        private bool _isInitialized;
        private bool _isPaused;

        public MainBootstrap(Contexts contexts, List<ISystem> systems, List<IResetable> resetables)
        {
            _contexts = contexts;
            _resetables = resetables;

            _featureMain = new Feature("Main Systems");
            _featureFixedSystems = new Feature("Fixed Systems");
            _featureLateFixedSystems = new Feature("LateFixed Systems");

            foreach (var system in systems)
            {
                switch (system)
                {
                    case IFixedSystem fixedSystem:
                        _featureFixedSystems.Add(fixedSystem);
                        break;
                    case ILateFixedSystem lateFixedSystem:
                        _featureLateFixedSystems.Add(lateFixedSystem);
                        break;
                    default:
                        _featureMain.Add(system);
                        break;
                }
            }
        }

        public void Initialize()
        {
            if (_isInitialized)
                throw new Exception("[MainBootstrap] Bootstrap already is initialized");

            _featureMain.Initialize();
            _featureFixedSystems.Initialize();
            _featureLateFixedSystems.Initialize();
            _isInitialized = true;
        }

        public void Tick()
        {
            if (_isPaused)
                return;

            _featureMain.Execute();
        }

        public void FixedTick()
        {
            if (_isPaused)
                return;

            _featureFixedSystems.Execute();
        }

        public void LateFixed()
        {
            if (_isPaused)
                return;
            
            _featureLateFixedSystems.Execute();
        }

        public void LateTick()
        {
            if (_isPaused)
                return;

            _featureMain.Cleanup();
            _featureFixedSystems.Cleanup();
            _featureLateFixedSystems.Cleanup();
        }
        
        public void Pause(bool isPaused) => _isPaused = isPaused;

        public void Reset()
        {
            Pause(true);

            _featureMain.DeactivateReactiveSystems();
            _featureMain.ClearReactiveSystems();
            try
            {
                foreach (var context in _contexts.allContexts)
                {
                    context.DestroyAllEntities();
                    context.ResetCreationIndex();
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }


            foreach (var resetable in _resetables)
                resetable.Reset();

            _featureMain.ActivateReactiveSystems();
            _isInitialized = false;
            Initialize();

            Pause(false);
        }

        public void Dispose()
        {
            _featureMain.DeactivateReactiveSystems();
            _featureMain.ClearReactiveSystems();
            _contexts.Reset();
        }
    }
}