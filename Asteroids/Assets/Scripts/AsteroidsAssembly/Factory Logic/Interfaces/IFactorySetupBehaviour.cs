using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public interface IFactorySetupBehaviour<T> where T: BehaviourEntity
    {
        void Setup(T setupObject);
        void Setup(T setupObject, Vector3 setupPosition, Vector3 setupDirection);
    }
}