using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class RandomDirectionSpawner<T>: 
        IFactorySetupBehaviour<T> where T: BehaviourEntity
    {
        protected readonly Camera _camera;

        protected T _instance;
        
        public RandomDirectionSpawner(Camera camera)
        {
            _camera = camera;
        }
        
        public virtual void Setup(T setupObject)
        {
            _instance = GameObject.Instantiate(setupObject);
        }
        
        public static Vector2 GenerateSpawnPosition(Camera camera)
        {
            Vector3 rnd = (Vector3)Random.insideUnitCircle.normalized 
                          + new Vector3(0.5f, 0.5f,-10f);

            return camera.ViewportToWorldPoint(rnd);
        }
    }
}