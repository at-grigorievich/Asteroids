using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    [CreateAssetMenu(fileName = "Factory Data", menuName = "Factories/New Factory Data", order = 0)]
    public class FactoryData : ScriptableObject
    {
        [field: SerializeField] public BehaviourEntity Prefab { get; private set; }
        [field: Space(20)]
        [field: SerializeField] public float DelayTime { get; private set; }
    }
}