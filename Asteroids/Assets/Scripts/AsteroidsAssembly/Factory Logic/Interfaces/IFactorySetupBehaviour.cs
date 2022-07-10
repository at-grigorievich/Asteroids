using AsteroidsAssembly.Entities;

namespace AsteroidsAssembly.FactoryLogic
{
    public interface IFactorySetupBehaviour<T> where T: BehaviourEntity
    {
        void Setup(T setupObject);
    }
}