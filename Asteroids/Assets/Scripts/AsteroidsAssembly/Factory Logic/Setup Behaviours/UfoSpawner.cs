using AsteroidsAssembly.Entities;
using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class UfoSpawner: RandomDirectionSpawner<UfoEntity>
    {
        private readonly TransformDataContainer _targetDataContainer;

        public UfoSpawner(Camera camera, TransformDataContainer targetDataContainer)
            : base(camera)
        {
            _targetDataContainer = targetDataContainer;
        }
        
        public override void Setup(UfoEntity setupObject)
        {
            base.Setup(setupObject);
            
            _instance.transform.position = GenerateSpawnPosition(_camera);
            _instance.Init(_targetDataContainer);
        }
    }
}