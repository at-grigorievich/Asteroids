using System;
using System.Collections.Generic;
using AsteroidsAssembly.FactoryLogic;
using AsteroidsAssembly.Interfaces;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class AsteroidFactory: TimeFactory
    {
        private new void Awake()
        {
            base.Awake();
            
            _presentors = new List<IUpdatablePresentor>();
            
            CreateFactory();
        }

        private void CreateFactory()
        {
            if (_factoryData.Prefab is AsteroidEntity asteroidEntity)
            {
                var spawnerBehaviour =
                    new RandomDirectionSpawner<AsteroidEntity>(_camera);

                var factoryViewer =
                    new FactoryViewer<AsteroidEntity>(spawnerBehaviour);

                var factoryModel =
                    new FactoryModel<AsteroidEntity>(asteroidEntity, _factoryData.DelayTime);

                var factoryPresenter =
                    new FactoryPresenter<AsteroidEntity>(factoryViewer, factoryModel);
                
                _presentors.Add(factoryPresenter);
            }
            else throw new ArgumentException("Prefab not an Asteroid !");
        }
    }
}