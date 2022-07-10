using AsteroidsAssembly.FactoryLogic;
using UnityEditor.Build.Content;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class TimeFactory: BehaviourEntity
    {
        [SerializeField] protected FactoryData _factoryData;

        protected Camera _camera;

        protected new void Awake()
        {
            _camera = Camera.main;
        }
    }
}