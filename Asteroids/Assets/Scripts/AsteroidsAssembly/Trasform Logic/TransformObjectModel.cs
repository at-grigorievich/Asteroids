using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    public class TransformObjectModel
    {
        private readonly IMovementBehaviour _movementBehaviour;

        public Vector2 CurrentPosition { get; private set; }
        public Vector3 CurrentRotation { get; private set; }
        
        public TransformObjectModel(IMovementBehaviour movementBehaviour,
            Vector2 startPos, Vector3 startRot)
        {
            _movementBehaviour = movementBehaviour;

            CurrentPosition = startPos;
            CurrentRotation = startRot;
        }

        public void UpdateTransform()
        {
            CurrentPosition = _movementBehaviour.GetNextPosition();
            CurrentRotation = _movementBehaviour.GetNextRotation(CurrentRotation);
        }
    }
}