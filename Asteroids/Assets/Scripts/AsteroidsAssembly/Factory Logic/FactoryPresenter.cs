using System;
using AsteroidsAssembly.Entities;
using AsteroidsAssembly.Interfaces;

namespace AsteroidsAssembly.FactoryLogic
{
    public class FactoryPresenter<T>: IUpdatablePresentor where T: BehaviourEntity
    {
        protected readonly IFactoryViewer<T> _factoryViewer;
        protected readonly FactoryModel<T> _factoryModel;

        private Action _updateModelTimer;
        
        public FactoryPresenter(IFactoryViewer<T> factoryViewer,FactoryModel<T> factoryModel)
        {
            _factoryModel = factoryModel;
            _factoryViewer = factoryViewer;
        }

        public virtual void Enable()
        {
            _updateModelTimer += UpdateTimer;
            _factoryModel.OnTimerExit += OnModelTimerExit;
        }
        
        public virtual void Disable()
        {
            _updateModelTimer -= UpdateTimer;
            _factoryModel.OnTimerExit -= OnModelTimerExit;
        }

        public void Update() => _updateModelTimer?.Invoke();
        

        protected virtual void OnModelTimerExit() => DoSpawn();
        protected void DoSpawn()
        {
            _factoryModel.ResetTimer();
            _factoryViewer.SetupObjectInWorld(_factoryModel.Instance);
        }
        
        private void UpdateTimer() => _factoryModel.UpdateTimer();

    }
}