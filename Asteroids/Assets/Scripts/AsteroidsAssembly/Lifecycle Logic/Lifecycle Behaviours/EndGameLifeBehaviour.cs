using System;
using AsteroidsAssembly.UserInterface;
using UnityEngine;

namespace AsteroidsAssembly.LifecycleLogic
{
    public class EndGameLifeBehaviour: ILifecycleBehaviour
    {
        public event EventHandler<int> OnDie;

        private readonly UIScorePresentor _scorePresentor;
        
        public EndGameLifeBehaviour(UIScorePresentor scorePresentor)
        {
            _scorePresentor = scorePresentor;
        }

        public void DoEndLifecycle(GameObject gameObject, int score) =>
            _scorePresentor.ShowReplayView();

        public void DoEndLifecycle(GameObject gameObject, Vector3 hitDirection, int score) =>
            DoEndLifecycle(gameObject, score);
    }
}