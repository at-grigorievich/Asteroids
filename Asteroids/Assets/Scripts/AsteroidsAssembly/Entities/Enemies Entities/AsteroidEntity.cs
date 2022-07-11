using System.Collections.Generic;
using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.LifecycleLogic;
using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class AsteroidEntity : MovementEntity, IDestroyable
    {
        public void Init(Vector3 direction)
        {
            _presentors = new List<IUpdatablePresentor>();
            CreateTransformView(direction);
            
            CallPresentors(p => p.Enable());
        }

        private void CreateTransformView(Vector3 direction)
        {
            ITransformViewer transformViewer = new TransformObjectView(_transform);
            TransformDataContainer transformContainer = new TransformDataContainer(_transform);

            IMovementBehaviour movementBehaviour = new LinearMovementBehaviour(
                _movementData,
                transformContainer,
                direction);

            TransformObjectModel transformModel = new TransformObjectModel(movementBehaviour,
                _transform.position, _transform.eulerAngles);
            
            _presentors.Add(new TransformObjectPresentor(transformViewer, transformModel));
        }
    }
}