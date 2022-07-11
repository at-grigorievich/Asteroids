﻿using System;
using UnityEngine;

namespace AsteroidsAssembly.LifecycleLogic
{
    public class DieLifeBehaviour: ILifecycleBehaviour
    {
        public event EventHandler<int> OnDie;
        
        public virtual void DoEndLifecycle(GameObject gameObject, int score)
        {
            OnDie?.Invoke(this,score);
            
            GameObject.Destroy(gameObject);
        }

        public void DoEndLifecycle(GameObject gameObject, Vector3 hitDirection, int score) =>
            DoEndLifecycle(gameObject,score);
        
    }
}