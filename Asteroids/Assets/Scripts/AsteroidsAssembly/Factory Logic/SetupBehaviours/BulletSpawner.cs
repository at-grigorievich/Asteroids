using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class BulletSpawner: IFactorySetupBehaviour<GunEntity>
    {
        private readonly Transform _spawnPoint;

        public BulletSpawner(Transform spawnPoint)
        {
            _spawnPoint = spawnPoint;
        }
        
        public void Setup(GunEntity setupObject)
        {
            var instance = GameObject.Instantiate(setupObject, _spawnPoint);
            instance.transform.SetParent(null);
            
            instance.Init();
        }
    }
}