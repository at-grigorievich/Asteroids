using AsteroidsAssembly.Interfaces;
using UnityEngine;

namespace AsteroidsAssembly.LifecycleLogic
{
    public class LifecyclePresentor: ICollisionablePresentor
    {
        private readonly ILifecycleViewer _lifecycleViewer;
        private readonly LifecycleModel _lifecycleModel;

        public LifecyclePresentor(ILifecycleViewer viewer, LifecycleModel lifecycleModel)
        {
            _lifecycleViewer = viewer;
            _lifecycleModel = lifecycleModel;
        }

        public void Enable() => _lifecycleViewer.SetEnable(true);
        public void Disable() => _lifecycleViewer.SetEnable(false);
        

        public void StartCollision(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDestroyable destroyable))
            {
                _lifecycleViewer
                    .EndLifecycle(_lifecycleModel.Score,collision.contacts[0].normal);
            }
        }
    }
}