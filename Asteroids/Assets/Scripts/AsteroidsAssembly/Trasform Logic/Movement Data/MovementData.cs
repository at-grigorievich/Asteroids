using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    [CreateAssetMenu(fileName = "Movement Data", menuName = "Movement/New Movement Data", order = 0)]
    public class MovementData : ScriptableObject
    {
        [field: SerializeField] public float DefaultMovementSpeed { get; private set; }
        [field: SerializeField] public float DefaultRotateSpeed { get; private set; }
        
        [field: Space(15)]
        
        [field: SerializeField, Range(0f,1f)] public float AccelerationCoef { get; private set; }
        [field: SerializeField, Range(0f,1f)] public float SlowdownCoef { get; private set; }
    }
}