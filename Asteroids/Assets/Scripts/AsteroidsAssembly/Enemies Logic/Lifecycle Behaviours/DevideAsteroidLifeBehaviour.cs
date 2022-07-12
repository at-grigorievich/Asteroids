using System;
using AsteroidsAssembly.LifecycleLogic;
using AsteroidsAssembly.UserInterface;
using UnityEngine;

namespace AsteroidsAssembly.EnemiesLogic
{
    public class DevideAsteroidLifeBehaviour: ILifecycleBehaviour
    {
        private readonly int _partCount;
        
        private readonly PartAsteroidFactory _partAsteroidFactory;
        
        public event EventHandler<int> OnDie;
        
        
        public DevideAsteroidLifeBehaviour(UIScorePresentor scorePresentor,
            PartAsteroidFactory partAsteroidFactory, int partCount)
        {
            _partAsteroidFactory = partAsteroidFactory;
            _partCount = partCount;

            OnDie += scorePresentor.AddScore;
        }

        public void DoEndLifecycle(GameObject gameObject, int score)
        {
            OnDie?.Invoke(this, score);
            GameObject.Destroy(gameObject);
        }

        public void DoEndLifecycle(GameObject gameObject, Vector3 hitDirection, int score)
        {
            for (int i = 0; i < _partCount; i++)
            {
                _partAsteroidFactory.SpawnByPosition(hitDirection,hitDirection.normalized);
            }
            
            DoEndLifecycle(gameObject,score);
        }
    }
}