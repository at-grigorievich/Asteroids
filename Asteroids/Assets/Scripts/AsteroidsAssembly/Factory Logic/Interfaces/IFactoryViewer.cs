using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public interface IFactoryViewer<T> where T: BehaviourEntity
    {
        void SetupObjectInWorld(T objTransform, 
            Vector3? setupPosition = null,
            Vector3? setupDirection= null);
    }
}