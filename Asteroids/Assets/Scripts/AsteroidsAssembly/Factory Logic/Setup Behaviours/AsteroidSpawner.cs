using AsteroidsAssembly.EnemiesLogic;
using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class AsteroidSpawner: RandomDirectionSpawner<AsteroidEntity>
    {
        private readonly PartAsteroidFactory _partOfAsteroidFactory;

        public AsteroidSpawner(Camera camera, PartAsteroidFactory paFactory) 
            : base(camera)
        {
            _partOfAsteroidFactory = paFactory;
        }

        public override void Setup(AsteroidEntity setupObject)
        {
            base.Setup(setupObject);
            
            _instance.transform.position = GenerateSpawnPosition(_camera);
            _instance.Init(GenerateRandomDirection(_camera,_instance.transform), 
                _partOfAsteroidFactory);
        }
    }
}