using AsteroidsAssembly.Entities;
using AsteroidsAssembly.UserInterface;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class EnemySpawner<T>: RandomDirectionSpawner<T>
        where T: BehaviourEntity
    {
        protected readonly UIScorePresentor _scorePresentor;
        
        public EnemySpawner(UIScorePresentor scorePresentor, Camera camera) : base(camera)
        {
            _scorePresentor = scorePresentor;
        }
    }
}