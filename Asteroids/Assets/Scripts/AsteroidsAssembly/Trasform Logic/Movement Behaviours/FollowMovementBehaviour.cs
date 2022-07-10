using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    public class FollowMovementBehaviour: IMovementBehaviour
    {
        private readonly MovementData _movementData;

        private readonly TransformDataContainer _transformDataContainer;
        private readonly TransformDataContainer _targetTransformDataContainer;
        
        public FollowMovementBehaviour(MovementData movementData, 
            TransformDataContainer transformViewer, TransformDataContainer targetTransforViewer)
        {
            _movementData = movementData;

            _transformDataContainer = transformViewer;
            _targetTransformDataContainer = targetTransforViewer;
        }
        
        public Vector2 GetNextPosition()
        {
            float speed = _movementData.DefaultMovementSpeed;

            Vector3 targetPos = _targetTransformDataContainer.CurrentPosition;
            Vector3 myPos = _transformDataContainer.CurrentPosition;

            Vector3 direction = (targetPos - myPos).normalized*speed*Time.deltaTime;

            return _transformDataContainer.GetTransformPosition(direction);
        }

        public Vector3 GetNextRotation(Vector3 curRotation) =>
            _transformDataContainer.CurrentRotation;
    }
}