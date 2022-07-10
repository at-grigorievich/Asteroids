using System;
using AsteroidsAssembly.Entities;

namespace AsteroidsAssembly.FactoryLogic
{
    public class CounterFactoryModel<T>: FactoryModel<T> where T: BehaviourEntity
    {
        private readonly float _counterDelay;
        private readonly Timer _counterTimer;

        public float TimeLeft => _counterTimer.CurrentTime;
       
        public int Count { get; private set; }
        
        public CounterFactoryModel(T instance, float delay, float counterDelay) 
            : base(instance, delay)
        {
            _counterDelay = counterDelay;

            _counterTimer = new Timer();
        }

        public void ResetCounterTimer() => _counterTimer.SetupTimer(_counterDelay);

        public void AddCount() => Count++;
        public void RemoveCount() => Count--;

        public override void UpdateTimer()
        {
            base.UpdateTimer();

            Action onTimerLeft = AddCount;
            onTimerLeft += ResetCounterTimer;
            
            _counterTimer.UpdateTimer(onTimerLeft);
        }
    }
}