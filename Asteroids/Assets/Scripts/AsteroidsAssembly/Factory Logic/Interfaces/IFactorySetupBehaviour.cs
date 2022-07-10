using AsteroidsAssembly.Entities;
using AsteroidsAssembly.Interfaces;

namespace AsteroidsAssembly.FactoryLogic
{
    public interface IFactorySetupBehaviour<T> where T: BehaviourEntity
    {
        void Setup(T setupObject);
    }
}