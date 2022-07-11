using System;
using AsteroidsAssembly.Entities;
using UnityEngine;

namespace AsteroidsAssembly.FactoryLogic
{
    public class CounterFactoryModel<T>: FactoryModel<T> where T: BehaviourEntity
    {
        private readonly float _counterDelay;
        private readonly Timer _counterTimer;

        private readonly int _maxCount;
        
        public float TimeLeft => _counterTimer.CurrentTime;
       
        public int Count { get; private set; }
        
        public CounterFactoryModel(T instance, float delay, float counterDelay, int maxCount) 
            : base(instance, delay)
        {
            _counterDelay = counterDelay;

            _counterTimer = new Timer();
            
            Count = _maxCount = maxCount;
        }

        public void ResetCounterTimer() => _counterTimer.SetupTimer(_counterDelay);

        public void AddCount() => Count = Mathf.Clamp(++Count,0,_maxCount);
        public void RemoveCount() => Count = Mathf.Clamp(--Count,0,_maxCount);

        public override void UpdateTimer()
        {
            base.UpdateTimer();

            Action onTimerLeft = AddCount;
            onTimerLeft += ResetCounterTimer;
            
            _counterTimer.UpdateTimer(onTimerLeft);
        }
    }
}