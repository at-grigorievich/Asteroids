using AsteroidsAssembly.Entities;
using AsteroidsAssembly.TransformLogic;
using AsteroidsAssembly.UserInterface;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class UfoSpawner: EnemySpawner<UfoEntity>
    {
        private readonly TransformDataContainer _targetDataContainer;

        public UfoSpawner(TransformDataContainer targetDataContainer,
            UIScorePresentor scorePresentor, Camera camera) 
            : base(scorePresentor,camera)
        {
            _targetDataContainer = targetDataContainer;
        }
        
        public override void Setup(UfoEntity setupObject)
        {
            base.Setup(setupObject);
            
            _instance.transform.position = GenerateSpawnPosition(_camera);
            _instance.Init(_targetDataContainer, _scorePresentor);
        }
    }
}