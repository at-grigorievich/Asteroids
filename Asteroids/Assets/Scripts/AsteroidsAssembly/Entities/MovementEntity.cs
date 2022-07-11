using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public abstract class MovementEntity: BehaviourEntity
    {
        [SerializeField] protected MovementData _movementData;
    }
}