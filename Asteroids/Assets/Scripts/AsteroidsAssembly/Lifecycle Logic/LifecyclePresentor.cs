using AsteroidsAssembly.Interfaces;
using UnityEngine;

namespace AsteroidsAssembly.LifecycleLogic
{
    public class LifecyclePresentor: ICollisionablePresentor
    {
        private readonly ILifecycleViewer _lifecycleViewer;
        private readonly LifecycleModel _lifecycleModel;

        private readonly bool _isAllowDisable;
        
        public LifecyclePresentor(ILifecycleViewer viewer, LifecycleModel lifecycleModel, 
            bool isAllowDisable = false)
        {
            _lifecycleViewer = viewer;
            _lifecycleModel = lifecycleModel;

            _isAllowDisable = isAllowDisable;
        }

        public void Enable() => _lifecycleViewer.SetEnable(true);
        public void Disable() => _lifecycleViewer.SetEnable(false);
        

        public void StartCollision(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDestroyable destroyable))
            {
                if(_isAllowDisable)
                    Disable();
                
                _lifecycleViewer
                    .EndLifecycle(_lifecycleModel.Score,collision.contacts[0].point);
            }
        }
    }
}