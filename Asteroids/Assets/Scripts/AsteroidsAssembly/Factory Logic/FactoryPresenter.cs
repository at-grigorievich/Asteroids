using System;
using AsteroidsAssembly.Entities;
using AsteroidsAssembly.Interfaces;

namespace AsteroidsAssembly.FactoryLogic
{
    public class FactoryPresenter<T>: SimpleFactoryPresenter<T>,IUpdatablePresentor 
        where T: BehaviourEntity
    {
        private Action _updateModelTimer;

        public FactoryPresenter(IFactoryViewer<T> factoryViewer, FactoryModel<T> factoryModel) 
            : base(factoryViewer, factoryModel)
        {
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
        protected override void DoSpawn()
        {
            _factoryModel.ResetTimer();
            base.DoSpawn();
        }
        
        private void UpdateTimer() => _factoryModel.UpdateTimer();
        
    }
}