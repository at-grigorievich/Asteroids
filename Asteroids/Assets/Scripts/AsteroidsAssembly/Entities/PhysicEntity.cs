using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.LifecycleLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class PhysicEntity: MovementEntity, IDestroyable
    {
        protected Collider2D _collider;
        
        protected ICollisionablePresentor _collisionPresentor;

        protected virtual void CreateLifecycle(ILifecycleBehaviour behaviour = null)
        {
            _collider = GetComponent<Collider2D>();
            
            ILifecycleBehaviour lifecycleBehaviour = behaviour ?? new DieLifeBehaviour();
            
            ILifecycleViewer _viewer = new LifecycleViewer(_collider, lifecycleBehaviour);
            LifecycleModel model = new LifecycleModel(10);

            _collisionPresentor = new LifecyclePresentor(_viewer, model);
            _collisionPresentor.Enable();
        }

        private void OnCollisionEnter2D(Collision2D col) => 
            _collisionPresentor.StartCollision(col);
    }
}