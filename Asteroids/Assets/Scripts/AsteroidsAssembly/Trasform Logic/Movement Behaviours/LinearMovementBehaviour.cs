using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    public class LinearMovementBehaviour: IMovementBehaviour
    {
        private readonly MovementData _movementData;
        private readonly TransformDataContainer _transformDataContainer;

        private readonly Vector2 _direction;
        
        
        public LinearMovementBehaviour(MovementData movementData, 
            TransformDataContainer transformViewer, Vector2 direction)
        {
            _movementData = movementData;
            _transformDataContainer = transformViewer;
            
            _direction = direction;
        }
        
        public Vector2 GetNextPosition()
        {
            float speed = _movementData.DefaultMovementSpeed;

            Vector2 direction = _direction*speed* Time.deltaTime;

            return _transformDataContainer.GetTransformPosition(direction);
        }

        public Vector3 GetNextRotation(Vector3 curRotation) => 
            _transformDataContainer.CurrentRotation;
    }
}