using UnityEngine;

namespace AsteroidsAssembly.LifecycleLogic
{
    public class LifecycleViewer: ILifecycleViewer
    {
        private readonly Collider2D _collider;
        private readonly ILifecycleBehaviour _lifecycleBehaviour;

        
        public LifecycleViewer(Collider2D collider,
            ILifecycleBehaviour behaviour)
        {
            _collider = collider;
            _lifecycleBehaviour = behaviour;
            
            SetEnable(false);
        }

        public void SetEnable(bool isEnabled) => _collider.enabled = isEnabled;

        public void EndLifecycle(int endScore)
        {
            _lifecycleBehaviour.DoEndLifecycle(_collider.gameObject,endScore);
        }

        public void EndLifecycle(int endScore, Vector3 hitDirection)
        {
            _lifecycleBehaviour.DoEndLifecycle(_collider.gameObject,hitDirection,endScore);
        }
    }
}