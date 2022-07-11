using System.Collections.Generic;
using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public abstract class GunEntity: MovementEntity
    {
        public void Init()
        {
            Vector3 direction = _transform.TransformDirection(Vector3.up);

#if  UNITY_EDITOR
            Debug.DrawRay(_transform.position,direction*10f,Color.blue,10f);
#endif           
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
                direction, true);

            TransformObjectModel transformModel = new TransformObjectModel(movementBehaviour,
                _transform.position, _transform.eulerAngles);
            
            
            _presentors.Add(new TransformObjectPresentor(transformViewer,transformModel));
        }

        protected abstract void CreatePhysicView();
    }
}