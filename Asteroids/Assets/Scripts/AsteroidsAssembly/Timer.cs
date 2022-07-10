using System;
using UnityEngine;

namespace AsteroidsAssembly
{
    public class Timer
    {
        public float CurrentTime { get; private set; }

        public void SetupTimer(float startTime) => CurrentTime = startTime;

        public void UpdateTimer(Action timerExit)
        {
            CurrentTime -= Time.deltaTime;

            if (CurrentTime <= 0)
            {
                CurrentTime = 0f;
                
                timerExit?.Invoke();
            }
        }
    }
}