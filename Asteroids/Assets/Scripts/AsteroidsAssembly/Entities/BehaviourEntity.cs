using System;
using System.Collections.Generic;
using AsteroidsAssembly.Interfaces;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public abstract class BehaviourEntity : MonoBehaviour
    {
        protected List<IUpdatablePresentor> _presentors;

        protected Transform _transform;
        
        protected void Awake() => _transform = transform;
        private void Update() => CallPresentors(p => p.Update());
       
        private void OnEnable() => CallPresentors(p => p.Enable());
        private void OnDisable() => CallPresentors(p => p.Disable());

        private void CallPresentors(Action<IUpdatablePresentor> method) =>
            _presentors?.ForEach(e => method?.Invoke(e));
    }
}