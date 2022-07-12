using System;
using AsteroidsAssembly.Entities;

namespace AsteroidsAssembly.FactoryLogic
{
    public class FactoryModel<T> where T: BehaviourEntity
    {
        private readonly float _delay;
        private readonly Timer _timer;
        
        public readonly T Instance;
        
        public event Action OnTimerExit;

        public FactoryModel(T instance, float delay)
        {
            _delay = delay;
            Instance = instance;

            _timer = new Timer();
            
            ResetTimer();
        }
        
        public void ResetTimer() => _timer.SetupTimer(_delay);
        public virtual void UpdateTimer() => _timer.UpdateTimer(() => OnTimerExit?.Invoke());
    }
}