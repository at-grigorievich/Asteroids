using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class AsteroidSpawner: RandomDirectionSpawner<AsteroidEntity>
    {
        public AsteroidSpawner(Camera camera) : base(camera) {}

        public override void Setup(AsteroidEntity setupObject)
        {
            base.Setup(setupObject);
            
            _instance.transform.position = GenerateSpawnPosition(_camera);
            _instance.Init(GenerateRandomDirection(_camera,_instance.transform));
        }

        private Vector2 GenerateRandomDirection(Camera camera, Transform transform)
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