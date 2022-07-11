using AsteroidsAssembly.LifecycleLogic;

namespace AsteroidsAssembly.Entities
{
    public class LaserEntity: GunEntity
    {
        protected override void CreateLifecycle(ILifecycleBehaviour behaviour = null)
        {
            behaviour = new ForeverLifeBehaviour();
            base.CreateLifecycle(behaviour);
        }
    }
}