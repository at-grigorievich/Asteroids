using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class RandomDirectionSpawner<T>: IFactorySetupBehaviour<T> where T: BehaviourEntity
    {
        private readonly Camera _camera;
        
        public RandomDirectionSpawner(Camera camera)
        {
            _camera = camera;
        }
        
        public void Setup(T setupObject)
        {
            var instance = GameObject.Instantiate(setupObject);
            instance.transform.position = GenerateSpawnPosition(_camera);
        }

        private static Vector2 GenerateSpawnPosition(Camera camera)
        {
            Vector3 rnd = (Vector3)Random.insideUnitCircle.normalized 
                          + new Vector3(0.5f, 0.5f,-10f);

            return camera.ViewportToWorldPoint(rnd);
        }
    }
}