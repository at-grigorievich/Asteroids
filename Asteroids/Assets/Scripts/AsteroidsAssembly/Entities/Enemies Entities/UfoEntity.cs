using System.Collections.Generic;
using AsteroidsAssembly.EnemyLogic;
using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class UfoEntity: BehaviourEntity, IEnemy
    {
        [SerializeField] private MovementData _movementData;
        
        public void Init(TransformDataContainer targetTransform)
        {
            _presentors = new List<IUpdatablePresentor>();
            CreateTransformView(targetTransform);
            
            CallPresentors(p => p.Enable());
        }

        private void CreateTransformView(TransformDataContainer _targetTransformDataContainer)
        {
            ITransformViewer transformViewer = new TransformObjectView(_transform);
            TransformDataContainer transformContainer = new TransformDataContainer(_transform);

            IMovementBehaviour movementBehaviour = new FollowMovementBehaviour(
                _movementData, transformContainer, _targetTransformDataContainer);

            TransformObjectModel transformModel = new TransformObjectModel(movementBehaviour,
                _transform.position, _transform.eulerAngles);
            
            _presentors.Add(new TransformObjectPresentor(transformViewer,transformModel));
        }
    }
}