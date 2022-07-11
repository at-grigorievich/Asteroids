using System;
using System.Collections.Generic;
using AsteroidsAssembly.EnemiesLogic;
using AsteroidsAssembly.FactoryLogic;
using AsteroidsAssembly.Interfaces;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class AsteroidFactory: TimeFactory
    {
        [SerializeField] protected FactoryData _asteroidPartFactoryData;

        private PartAsteroidFactory _asteroidPartFactory;

        private new void Awake()
        {
            base.Awake();
            
            _presentors = new List<IUpdatablePresentor>();

            CreateSubFactory();
            CreateFactory();
        }
        

        private void CreateFactory()
        {
            if (_factoryData.Prefab is AsteroidEntity asteroidEntity)
            {
                var asteroidSpawner = new AsteroidSpawner(_camera, _asteroidPartFactory);

                CreateFactory(asteroidEntity,asteroidSpawner);
            }
            else throw new ArgumentException("Prefab not an Asteroid !");
        }
        
        private void CreateSubFactory()
        {
            if (_asteroidPartFactoryData.Prefab is PartAsteroidEntity partAsteroid)
            {
                var partAsteroidSpawner = new PartAsteroidSpawner();
                var (viewer, model) = CreateMVP(partAsteroid,partAsteroidSpawner);

                _asteroidPartFactory = new PartAsteroidFactory(viewer, model);
            }
            else throw new ArgumentException("Prefab not an Asteroid Part!");
        }
    }
}