using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    public class TransformObjectView :  ITransformViewer
    {
        private Transform _transform;
        
        public TransformObjectView(Transform transform)
        {
            _transform = transform;
        }

        public void UpdatePosition(Vector2 nextPosition) => 
            _transform.Translate(nextPosition);

        public void UpdateRotation(Vector3 nextRotation) => 
            _transform.rotation = Quaternion.Euler(nextRotation);

    }
}