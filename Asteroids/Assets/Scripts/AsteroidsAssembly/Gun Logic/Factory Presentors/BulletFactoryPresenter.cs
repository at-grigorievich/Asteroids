using AsteroidsAssembly.Entities;
using AsteroidsAssembly.FactoryLogic;
using UnityEngine.InputSystem;

namespace AsteroidsAssembly.GunLogic
{
    public class BulletFactoryPresenter: InputFactoryPresenter<GunEntity>
    {
        public BulletFactoryPresenter(InputAction inputAction, 
            IFactoryViewer<GunEntity> factoryViewer, FactoryModel<GunEntity> factoryModel) 
            : base(inputAction, factoryViewer, factoryModel) {}
    }
}