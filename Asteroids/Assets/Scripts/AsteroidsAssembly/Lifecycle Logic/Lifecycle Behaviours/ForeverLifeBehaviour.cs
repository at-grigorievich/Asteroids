using System;
using UnityEngine;

namespace AsteroidsAssembly.LifecycleLogic
{
    public class ForeverLifeBehaviour: ILifecycleBehaviour
    {
        public event EventHandler<int> OnDie;

        public void DoEndLifecycle(GameObject gameObject, int score) =>
            OnDie?.Invoke(this, score);

        public void DoEndLifecycle(GameObject gameObject, Vector3 hitDirection, int score) =>
            DoEndLifecycle(gameObject,score);
        
    }
}