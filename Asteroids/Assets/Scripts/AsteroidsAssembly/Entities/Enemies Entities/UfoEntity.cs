using System.Collections.Generic;
using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.LifecycleLogic;
using AsteroidsAssembly.TransformLogic;
using AsteroidsAssembly.UserInterface;

namespace AsteroidsAssembly.Entities
{
    public class UfoEntity: PhysicEntity,IDestroyable
    {
        public void Init(TransformDataContainer targetTransform, UIScorePresentor scorePresentor)
        {
            _presentors = new List<IUpdatablePresentor>();
            CreateTransformView(targetTransform);
            CreateLifecycle(new DieLifeBehaviour(scorePresentor));
            
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