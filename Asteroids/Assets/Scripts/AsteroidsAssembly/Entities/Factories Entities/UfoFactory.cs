using System;
using System.Collections.Generic;
using AsteroidsAssembly.FactoryLogic;
using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class UfoFactory: TimeFactory
    {
        [SerializeField] private ShipEntity _playerShip;
        
        private new void Awake()
        {
            base.Awake();

            _presentors = new List<IUpdatablePresentor>();
            
            CreateFactory();
        }

        private void CreateFactory()
        {
            if (_factoryData.Prefab is UfoEntity asteroidEntity)
            {
                TransformDataContainer targetContainer =
                    new TransformDataContainer(_playerShip.transform);
                var ufoSpawner = new UfoSpawner(_camera,targetContainer);

                CreateFactory(asteroidEntity,ufoSpawner);
            }
            else throw new ArgumentException("Prefab not an Asteroid !");
        }
    }
}