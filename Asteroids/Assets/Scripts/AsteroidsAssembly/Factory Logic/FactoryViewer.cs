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
        
        public void SetupObjectInWorld(T entity)
        {
            _setupBehaviour.Setup(entity);
        }
    }
}