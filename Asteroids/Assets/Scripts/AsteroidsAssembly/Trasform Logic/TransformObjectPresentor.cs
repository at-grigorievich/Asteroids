using System;
using AsteroidsAssembly.Interfaces;
using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    public class TransformObjectPresentor: IUpdatablePresentor
    {
        private readonly ITransformViewer _transformViewer;
        private readonly TransformObjectModel _transformModel;

        private Action _updateObjectTransform;
        
        public TransformObjectPresentor(ITransformViewer transformViewer,
            TransformObjectModel transformModel)
        {
            _transformModel = transformModel;
            _transformViewer = transformViewer;
        }
        
        public void Enable()
        {
            _updateObjectTransform += UpdateObjectTransform;
        }

        public void Disable()
        {
            _updateObjectTransform -= UpdateObjectTransform;
        }

        public void Update()
        {
            _updateObjectTransform?.Invoke();
        }
        
        private void UpdateObjectTransform()
        {
            _transformModel.UpdateTransform();

            
            _transformViewer.UpdatePosition(_transformModel.CurrentPosition);
            
            
            _transformViewer.UpdateRotation(_transformModel.CurrentRotation);
        }
    }
}