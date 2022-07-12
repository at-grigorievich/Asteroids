using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    public interface IMovementParameters
    {
        public Vector2 CurrentCoordinates { get; }
        public float CurrentAngle { get; }
        
        public float AccelerationValue { get; }
        public float MomentSpeed { get; }
        
        
    }
}