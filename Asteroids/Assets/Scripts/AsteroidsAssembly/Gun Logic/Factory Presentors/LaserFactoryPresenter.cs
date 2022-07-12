using AsteroidsAssembly.Entities;
using AsteroidsAssembly.FactoryLogic;
using UnityEngine.InputSystem;

namespace AsteroidsAssembly.GunLogic
{
    public class LaserFactoryPresenter: InputFactoryPresenter<GunEntity>
    {
        private readonly CounterFactoryModel<GunEntity> _counterModel;

        public LaserFactoryPresenter(InputAction inputAction, 
            IFactoryViewer<GunEntity> factoryViewer, 
            CounterFactoryModel<GunEntity> factoryModel) 
            : base(inputAction, factoryViewer, factoryModel)
        {
            _counterModel = factoryModel;
        }

        protected override void OnModelTimerExit() =>
            _isSpawnAvailable = _counterModel.Count > 0;
        
        protected override void DoSpawn()
        {
            base.DoSpawn();
            _counterModel.RemoveCount();
        }
    }
}