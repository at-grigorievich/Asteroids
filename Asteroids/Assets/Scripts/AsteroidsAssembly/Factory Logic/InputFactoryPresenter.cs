using AsteroidsAssembly.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AsteroidsAssembly.FactoryLogic
{
    public class InputFactoryPresenter<T>: FactoryPresenter<T>
        where T: BehaviourEntity
    {
        protected InputAction _inputAction;
        protected bool _isSpawnAvailable;
        
        public InputFactoryPresenter(InputAction inputAction,
            IFactoryViewer<T> factoryViewer, FactoryModel<T> factoryModel)
            : base(factoryViewer, factoryModel)
        {
            _inputAction = inputAction;
        }

        public override void Enable()
        {
            _inputAction.Enable();
            _inputAction.performed += TryInput;
            base.Enable();
        }
        
        public override void Disable()
        {
            _inputAction.Disable();
            _inputAction.performed -= TryInput;
            
            base.Disable();
        }

        protected override void OnModelTimerExit() => _isSpawnAvailable = true;
        
        protected void TryInput(InputAction.CallbackContext obj)
        {
            if (_isSpawnAvailable)
            {
                _isSpawnAvailable = false;
                DoSpawn();
            }
        }
    }
}