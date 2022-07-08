using AsteroidsAssembly.Interfaces;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public abstract class PhysicEntity : MonoBehaviour
    {
        protected IUpdatable _updatePresentor;
        protected IPhysicable _physicPresentor;

        protected Transform _transform;
        
        protected abstract void CreateTransformView();
        protected abstract void CreatePhysicView();

        protected void Awake() => _transform = transform;
        private void Update() => _updatePresentor.Update();

        private void OnEnable()
        {
            _updatePresentor.Enable();
            //_physicPresentor.Enable();
        }
        private void OnDisable()
        {
            _updatePresentor.Disable();
            //_physicPresentor.Disable();
        }
    }
}