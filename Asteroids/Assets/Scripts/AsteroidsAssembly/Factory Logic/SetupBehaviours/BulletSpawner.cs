using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class BulletSpawner: IFactorySetupBehaviour<BulletEntity>
    {
        private readonly Transform _spawnPoint;

        public BulletSpawner(Transform spawnPoint)
        {
            _spawnPoint = spawnPoint;
        }
        
        public void Setup(BulletEntity setupObject)
        {
            var instance = GameObject.Instantiate(setupObject, _spawnPoint);
            instance.transform.SetParent(null);
            
            instance.Init();
        }
    }
}