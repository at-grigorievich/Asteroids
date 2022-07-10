using AsteroidsAssembly.Entities;

namespace AsteroidsAssembly.FactoryLogic
{
    public interface IFactoryViewer<T> where T: BehaviourEntity
    {
        void SetupObjectInWorld(T objTransform);
    }
}