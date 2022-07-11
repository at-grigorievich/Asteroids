using System;
using System.Collections.Generic;
using AsteroidsAssembly.FactoryLogic;
using AsteroidsAssembly.Gun_Logic.Gun_Data;
using AsteroidsAssembly.GunLogic;
using AsteroidsAssembly.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AsteroidsAssembly.Entities
{
    public class GunFactory: TimeFactory
    {
        [SerializeField] private GunReloadingData _reloadingData;
        [SerializeField] private Transform _spawnPoint;

        private GunSpawner _gunSpawner;

        private void Awake()
        {
            _gunSpawner = new GunSpawner(_spawnPoint);
        }
        
        public (FactoryViewer<GunEntity>,FactoryModel<GunEntity>) CreateFactory()
        {
            if (_factoryData.Prefab is GunEntity bulletEntity)
                return CreateMVP(bulletEntity, _gunSpawner ?? new GunSpawner(_spawnPoint));
            
            throw new ArgumentException("Prefab not an Bullet !");
        }
        
        public (FactoryViewer<GunEntity>,CounterFactoryModel<GunEntity>) CreateCounterFactory()
        {
            if (_factoryData.Prefab is GunEntity bulletEntity)
            {
                var factoryViewer = 
                    new FactoryViewer<GunEntity>(_gunSpawner ?? new GunSpawner(_spawnPoint));

                var factoryModel = new CounterFactoryModel<GunEntity>(
                    bulletEntity,
                    _factoryData.DelayTime,
                    _reloadingData.ReloadingDelay,
                    _reloadingData.MaxCount
                );
                return (factoryViewer, factoryModel);
            }
            throw new ArgumentException("Prefab not an Bullet !");
        }
    }
}