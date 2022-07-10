using AsteroidsAssembly.Entities;
using AsteroidsAssembly.FactoryLogic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AsteroidsAssembly.GunLogic
{
    public class BulletFactoryPresenter: InputFactoryPresenter<BulletEntity>
    {
        public BulletFactoryPresenter(InputAction inputAction, 
            IFactoryViewer<BulletEntity> factoryViewer, FactoryModel<BulletEntity> factoryModel) 
            : base(inputAction, factoryViewer, factoryModel)
        {
        }
    }
}