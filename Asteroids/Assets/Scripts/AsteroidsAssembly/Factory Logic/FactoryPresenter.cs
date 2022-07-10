using System;
using AsteroidsAssembly.Entities;
using AsteroidsAssembly.Interfaces;

namespace AsteroidsAssembly.FactoryLogic
{
    public class FactoryPresenter<T>: IUpdatablePresentor where T: BehaviourEntity
    {
        private readonly IFactoryViewer<T> _factoryViewer;
        private readonly FactoryModel<T> _factoryModel;

        private Action _updateModelTimer;
        
        public FactoryPresenter(IFactoryViewer<T> factoryViewer,FactoryModel<T> factoryModel)
        {
            _factoryModel = factoryModel;
            _factoryViewer = factoryViewer;
        }

        public void Enable()
        {
            _updateModelTimer += UpdateModelTimer;
            _factoryModel.OnTimerExit += OnModelTimerExit;
        }
        
        public void Disable()
        {
            _updateModelTimer -= UpdateModelTimer;
            _factoryModel.OnTimerExit -= OnModelTimerExit;
        }

        public void Update()
        {
            _updateModelTimer?.Invoke();
        }

        private void OnModelTimerExit()
        {
            _factoryViewer.SetupObjectInWorld(_factoryModel.Instance);
        }
        
        private void UpdateModelTimer() => _factoryModel.UpdateTimer();
    }
}