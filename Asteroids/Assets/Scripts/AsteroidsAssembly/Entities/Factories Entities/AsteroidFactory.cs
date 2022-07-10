using System;
using System.Collections.Generic;
using AsteroidsAssembly.FactoryLogic;
using AsteroidsAssembly.Interfaces;

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

                CreateFactory(asteroidEntity,spawnerBehaviour);
            }
            else throw new ArgumentException("Prefab not an Asteroid !");
        }
    }
}