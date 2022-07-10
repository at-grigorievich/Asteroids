using AsteroidsAssembly.FactoryLogic;
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

        protected void CreateFactory<T>(T instance,
            IFactorySetupBehaviour<T> spawner)
            where T: BehaviourEntity
        {
            var factoryViewer =
                new FactoryViewer<T>(spawner);

            var factoryModel =
                new FactoryModel<T>(instance, _factoryData.DelayTime);

            var factoryPresenter = new FactoryPresenter<T>(factoryViewer, factoryModel);
            
            _presentors.Add(factoryPresenter);
        }
    }
}