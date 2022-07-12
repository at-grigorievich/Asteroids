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
               OutFromRectChecker.CheckOutFromRect(_transform,_camera,ref nextObjectPos);

            _transform.localPosition = nextObjectPos;
        }

        public void UpdateRotation(Vector3 nextRotation) => 
            _transform.rotation = Quaternion.Euler(nextRotation);
    }
}