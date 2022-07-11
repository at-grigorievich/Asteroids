using AsteroidsAssembly.Entities;
using AsteroidsAssembly.FactoryLogic;
using UnityEngine;

namespace AsteroidsAssembly.EnemiesLogic
{
    public class PartAsteroidFactory: SimpleFactoryPresenter<PartAsteroidEntity>
    {
        public PartAsteroidFactory(IFactoryViewer<PartAsteroidEntity> factoryViewer, 
            FactoryModel<PartAsteroidEntity> factoryModel) 
            : base(factoryViewer, factoryModel)
        {
        }

        public void SpawnByPosition(Vector3 position,Vector3 direction) =>
            _factoryViewer.SetupObjectInWorld(_factoryModel.Instance, position, direction);
    }
}