using AsteroidsAssembly.Entities;
using AsteroidsAssembly.UserInterface;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class PartAsteroidSpawner: EnemySpawner<PartAsteroidEntity>
    {
        public PartAsteroidSpawner(UIScorePresentor scorePresentor, Camera camera) 
            : base(scorePresentor, camera) {}
        
        public override void Setup(PartAsteroidEntity setupObject, 
            Vector3 setupPosition, Vector3 setupDirection)
        {
            base.Setup(setupObject);
            
            _instance.transform.position =setupPosition + 1.5f*(Vector3)Random.insideUnitCircle;
            
            _instance.Init(
                RotateTowardsUp(setupDirection,90f*Random.value),
                _scorePresentor);
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