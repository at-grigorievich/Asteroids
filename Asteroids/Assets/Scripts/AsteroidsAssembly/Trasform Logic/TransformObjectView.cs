using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    public class TransformObjectView :  ITransformViewer
    {
        private Transform _transform;
        private Camera _camera;

        private readonly bool _isCheckRect;
        
        public TransformObjectView(Transform transform, bool isCheckRect = false)
        {
            _transform = transform;
            _camera = Camera.main;

            _isCheckRect = isCheckRect;
        }

        public void UpdatePosition(Vector2 nextPosition)
        {
            Vector3 nextObjectPos = nextPosition;
            
            if(_isCheckRect)
                CheckOutFromRect(ref nextObjectPos);

            _transform.localPosition = nextObjectPos;
        }

        public void UpdateRotation(Vector3 nextRotation) => 
            _transform.rotation = Quaternion.Euler(nextRotation);


        private void CheckOutFromRect(ref Vector3 nextPosition)
        {
            Vector2 viewportPoint = _camera.WorldToViewportPoint(_transform.position+_transform.up*_transform.localScale.y/2f);

            bool isFlippedX = NeedToFlip(viewportPoint.x);
            bool isFlippedY = NeedToFlip(viewportPoint.y);
            
            if (isFlippedX)
                nextPosition.x *= -1f;

            if (isFlippedY)
                nextPosition.y *= -1f;

            bool NeedToFlip(float value) => value > 1f || value < -0f;
        }
    }
}