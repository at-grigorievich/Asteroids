using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    public class TransformDataContainer
    {
        private readonly Transform _transform;

        public Vector2 CurrentPosition => _transform.position;
        public Vector3 CurrentRotation => _transform.eulerAngles;
        
        public TransformDataContainer(Transform transform) => _transform = transform;

        public Vector2 GetTransformPosition(Vector2 direction) =>
            _transform.localPosition + _transform.TransformDirection(direction);
    }
}