using AsteroidsAssembly.Entities;

namespace AsteroidsAssembly.FactoryLogic
{
    public class SimpleFactoryPresenter<T>
        where T: BehaviourEntity
    {
        protected readonly IFactoryViewer<T> _factoryViewer;
        protected readonly FactoryModel<T> _factoryModel;
        
        public SimpleFactoryPresenter(IFactoryViewer<T> factoryViewer,FactoryModel<T> factoryModel)
        {
            _factoryModel = factoryModel;
            _factoryViewer = factoryViewer;
        }
        
        protected virtual void DoSpawn() => 
            _factoryViewer.SetupObjectInWorld(_factoryModel.Instance);
    }
}