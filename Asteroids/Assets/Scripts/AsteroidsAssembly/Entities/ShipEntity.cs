using System;
using System.Collections.Generic;
using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class ShipEntity: BehaviourEntity
    {
        [SerializeField] private MovementData _movementData;
        
        private PlayerInput _inputService;
        
        private new void Awake()
        {
            base.Awake();

            _inputService = new PlayerInput();

            _presentors = new List<IUpdatablePresentor>();
            
            CreateTransformView();
            //CreatePhysicView();
        }

        private void CreateTransformView()
        {
            ITransformViewer transformViewer = new TransformObjectView(_transform);

            TransformDataContainer transformContainer = new TransformDataContainer(_transform);
            
            IMovementBehaviour movementBehaviour = new ShipMovementBehaviour(
                    _inputService.Player.Move,
                    _inputService.Player.Rotate,
                    _movementData,
                    transformContainer);

            TransformObjectModel transformModel = new TransformObjectModel(movementBehaviour,
                    _transform.position, _transform.eulerAngles);
            
            _presentors.Add(new TransformObjectPresentor(transformViewer,transformModel));
        }

        private void CreatePhysicView()
        {
            throw new NotImplementedException();
        }
    }
}