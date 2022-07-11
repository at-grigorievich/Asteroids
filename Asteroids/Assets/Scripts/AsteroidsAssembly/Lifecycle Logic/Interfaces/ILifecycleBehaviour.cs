using System;
using UnityEngine;

namespace AsteroidsAssembly.LifecycleLogic
{
    public interface ILifecycleBehaviour
    {
        event EventHandler<int> OnDie;
        
        void DoEndLifecycle(GameObject gameObject, int score);
    }
}