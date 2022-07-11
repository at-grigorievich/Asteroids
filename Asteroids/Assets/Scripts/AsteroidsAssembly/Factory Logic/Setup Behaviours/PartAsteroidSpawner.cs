using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class PartAsteroidSpawner: IFactorySetupBehaviour<PartAsteroidEntity>
    {
        public void Setup(PartAsteroidEntity setupObject){}

        public void Setup(PartAsteroidEntity setupObject, 
            Vector3 setupPosition, Vector3 setupDirection)
        {
            var instance = GameObject.Instantiate(setupObject);
            
            instance.transform.position = setupPosition + 1.5f*(Vector3)Random.insideUnitCircle;
            
            instance.Init(RotateTowardsUp(setupDirection,180f*Random.value));
        }
        
        Vector3 RotateTowardsUp(Vector3 start, float angle)
        {
            start.Normalize();

            Vector3 axis = Vector3.Cross(start, Vector3.up);

            if (axis == Vector3.zero) axis = Vector3.right;

            return Quaternion.AngleAxis(angle, axis) * start;
        }
    }
}