using AsteroidsAssembly.EnemiesLogic;
using AsteroidsAssembly.Entities;
using AsteroidsAssembly.UserInterface;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class AsteroidSpawner: EnemySpawner<AsteroidEntity>
    {
        private readonly PartAsteroidFactory _partOfAsteroidFactory;

        public AsteroidSpawner(PartAsteroidFactory paFactory,
            UIScorePresentor scorePresentor, Camera camera) 
            : base(scorePresentor,camera)
        {
            _partOfAsteroidFactory = paFactory;
        }

        public override void Setup(AsteroidEntity setupObject)
        {
            base.Setup(setupObject);
            
            _instance.transform.position = GenerateSpawnPosition(_camera);
            _instance.Init(GenerateRandomDirection(_camera,_instance.transform), 
                _partOfAsteroidFactory,_scorePresentor);
        }
    }
}