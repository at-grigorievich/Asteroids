using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class RandomDirectionSpawner<T>: 
        IFactorySetupBehaviour<T> where T: BehaviourEntity
    {
        protected readonly Camera _camera;

        protected T _instance;
        
        public RandomDirectionSpawner(Camera camera) => _camera = camera;
        
        
        public virtual void Setup(T setupObject) =>
            _instance = GameObject.Instantiate(setupObject);
        
        public virtual void Setup(T setupObject,Vector3 setupPosition, Vector3 setupDirection) =>
            Setup(setupObject);
        
        
        protected static Vector2 GenerateSpawnPosition(Camera camera)
        {
            Vector3 rnd = (Vector3)Random.insideUnitCircle.normalized 
                          + new Vector3(0.5f, 0.5f,-10f);

            return camera.ViewportToWorldPoint(rnd);
        }
        
        protected static Vector2 GenerateRandomDirection(Camera camera, Transform transform)
        {
            float xRnd = Mathf.Clamp(Random.value, 0.3f, 0.7f);
            float yRnd = Mathf.Clamp(Random.value, 0.3f, 0.7f);
            
            Vector3 rndVec = new Vector3(xRnd, yRnd,-10f);
            Vector2 worldRndVec = camera.ViewportToWorldPoint(rndVec);

            Vector2 res = (worldRndVec - (Vector2)transform.position);

#if UNITY_EDITOR
            Debug.DrawLine(transform.position,res,Color.black,10f);
#endif            
            return res;
        }
    }
}