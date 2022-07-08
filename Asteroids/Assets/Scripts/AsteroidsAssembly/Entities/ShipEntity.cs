using System;
using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class ShipEntity: PhysicEntity
    {
        [SerializeField] private MovementData _movementData;
        
        private PlayerInput _inputService;
        
        private new void Awake()
        {
            base.Awake();

            _inputService = new PlayerInput();

            CreateTransformView();
            //CreatePhysicView();
        }

        protected override void CreateTransformView()
        {
            ITransformViewer transformViewer = new TransformObjectView(_transform);

            IMovementBehaviour movementBehaviour = new ShipMovementBehaviour(
                    _inputService.Player.Move,
                    _inputService.Player.Rotate,
                    _movementData);

            TransformObjectModel transformModel = new TransformObjectModel(movementBehaviour,
                    _transform.position, _transform.eulerAngles);
            
            _updatePresentor = new TransformObjectPresentor(transformViewer,transformModel);
        }

        protected override void CreatePhysicView()
        {
            throw new NotImplementedException();
        }
    }
}