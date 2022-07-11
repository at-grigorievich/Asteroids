using System;
using System.Collections.Generic;
using AsteroidsAssembly.FactoryLogic;
using AsteroidsAssembly.GunLogic;
using AsteroidsAssembly.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AsteroidsAssembly.Entities
{
    public class BulletFactory: TimeFactory
    {
        [SerializeField] private Transform _spawnPoint;

        public void CreateFactory(InputAction inputAction)
        {
            if (_factoryData.Prefab is GunEntity bulletEntity)
            {
                var bulletSpawner = new BulletSpawner(_spawnPoint);

                var factoryViewer = new FactoryViewer<GunEntity>(bulletSpawner);
                var factoryModel =
                    new FactoryModel<GunEntity>(bulletEntity, _factoryData.DelayTime);

                BulletFactoryPresenter factoryPresenter =
                    new BulletFactoryPresenter(inputAction, factoryViewer, factoryModel);
                
                _presentors = new List<IUpdatablePresentor>();
                _presentors.Add(factoryPresenter);
                
                CallPresentors(p => p.Enable());
            }
            else throw new ArgumentException("Prefab not an Bullet !");
        }
    }
}