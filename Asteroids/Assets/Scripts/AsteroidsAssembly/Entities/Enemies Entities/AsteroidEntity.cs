﻿using System.Collections.Generic;
using AsteroidsAssembly.EnemiesLogic;
using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class AsteroidEntity : PhysicEntity
    {
        public void Init(Vector3 direction, PartAsteroidFactory _partAsteroidFactory)
        {
            _presentors = new List<IUpdatablePresentor>();
            
            CreateTransformView(direction);
            
            CreateLifecycle(new DevideAsteroidLifeBehaviour(_partAsteroidFactory,2));
            
            CallPresentors(p => p.Enable());
        }

        private void CreateTransformView(Vector3 direction)
        {
            ITransformViewer transformViewer = new TransformObjectView(_transform);
            TransformDataContainer transformContainer = new TransformDataContainer(_transform);

            IMovementBehaviour movementBehaviour = new LinearMovementBehaviour(
                _movementData,
                transformContainer,
                direction.normalized);

            TransformObjectModel transformModel = new TransformObjectModel(movementBehaviour,
                _transform.position, _transform.eulerAngles);
            
            _presentors.Add(new TransformObjectPresentor(transformViewer, transformModel));
        }
    }
}