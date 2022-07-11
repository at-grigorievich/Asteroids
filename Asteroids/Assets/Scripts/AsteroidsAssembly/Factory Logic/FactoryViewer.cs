using UnityEngine;
using AsteroidsAssembly.Entities;

namespace AsteroidsAssembly.FactoryLogic
{
    public class FactoryViewer<T>: IFactoryViewer<T> where T : BehaviourEntity
    {
        private readonly IFactorySetupBehaviour<T> _setupBehaviour;

        public FactoryViewer(IFactorySetupBehaviour<T> setupBehaviour)
        {
            _setupBehaviour = setupBehaviour;
        }
        
        public void SetupObjectInWorld(T entity, 
            Vector3? setupPosition = null, Vector3? setupDirection = null)
        {
            if(setupPosition == null)
                _setupBehaviour.Setup(entity);
            else if (setupDirection != null) 
                _setupBehaviour.Setup(entity, setupPosition.Value, setupDirection.Value);
        }
    }
}