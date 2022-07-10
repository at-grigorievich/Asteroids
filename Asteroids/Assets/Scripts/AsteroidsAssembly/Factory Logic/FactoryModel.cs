using System;
using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class FactoryModel<T> where T: BehaviourEntity
    {
        private readonly float _delay;
        private float _currentTime;
        
        public readonly T Instance;
        
        public event Action OnTimerExit;

        public FactoryModel(T instance, float delay)
        {
            _delay = delay;
            Instance = instance;
        }
        
        public void UpdateTimer()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _delay)
            {
                _currentTime = default;
                OnTimerExit?.Invoke();
            }
        }
    }
}