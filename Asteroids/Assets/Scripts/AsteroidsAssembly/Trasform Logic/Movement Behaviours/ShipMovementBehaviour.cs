using UnityEngine;
using UnityEngine.InputSystem;

namespace AsteroidsAssembly.TransformLogic
{
    public class ShipMovementBehaviour: IMovementBehaviour, IMovementParameters
    {
        private readonly InputAction _moveInput;
        private readonly InputAction _rotateInput;

        private readonly MovementData _movementData;
        private readonly TransformDataContainer _transformDataContainer;
        
        private float _accelerationValue;

        public Vector2 CurrentCoordinates => _transformDataContainer.CurrentPosition;
        public float CurrentAngle => _transformDataContainer.CurrentRotation.z;
        public float AccelerationValue => _accelerationValue;
        public float MomentSpeed => _movementData.DefaultMovementSpeed * _accelerationValue;
        
        
        public ShipMovementBehaviour(InputAction moveInput,InputAction rotateInput, 
            MovementData movementData, TransformDataContainer transformViewer)
        {
            _moveInput = moveInput;
            _rotateInput = rotateInput;

            _movementData = movementData;
            _transformDataContainer = transformViewer;
            
            _moveInput.Enable();
            _rotateInput.Enable();
        }

        public Vector2 GetNextPosition()
        {
            UpdateAcceleration();
            
            Vector2 direction = Vector2.up * MomentSpeed * Time.deltaTime;
            
            return _transformDataContainer.GetTransformPosition(direction);
        }

        public Vector3 GetNextRotation(Vector3 curRotation)
        {
            float defaultSpeed = _movementData.DefaultRotateSpeed;
            
            float axis = _rotateInput.ReadValue<Vector2>().x;
            Vector3 dirRotation = -axis * Vector3.forward*defaultSpeed*Time.deltaTime;

            return curRotation + dirRotation;
        }

        private void UpdateAcceleration()
        {
            _accelerationValue += _moveInput.phase == InputActionPhase.Performed
                ? _movementData.AccelerationCoef * Time.deltaTime
                : -_movementData.SlowdownCoef * Time.deltaTime;

            _accelerationValue = Mathf.Clamp01(_accelerationValue);
        }
    }
}