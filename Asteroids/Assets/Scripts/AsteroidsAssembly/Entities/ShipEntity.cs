﻿using System;
using System.Collections.Generic;
using AsteroidsAssembly.GunLogic;
using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.LifecycleLogic;
using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    [RequireComponent(typeof(Collider2D))]
    public class ShipEntity: MovementEntity
    {
        [Space(15)] 
        [SerializeField] private GunFactory _bulletFactory;
        [SerializeField] private GunFactory _laserFactory;

        private Collider2D _collider;
        private PlayerInput _inputService;

        private ICollisionablePresentor _collisionPresentor;
        
        private new void Awake()
        {
            base.Awake();

            _inputService = new PlayerInput();

            _presentors = new List<IUpdatablePresentor>();
            
            CreateTransformView();
            
            CreateBulletFactory();
            CreateLaserFactory();
            
            CreateLifecycle();
            //CreatePhysicView();
        }

        private void CreateTransformView()
        {
            ITransformViewer transformViewer = new TransformObjectView(_transform);

            TransformDataContainer transformContainer = new TransformDataContainer(_transform);
            
            IMovementBehaviour movementBehaviour = new ShipMovementBehaviour(
                    _inputService.Player.Move,
                    _inputService.Player.Rotate,
                    _movementData,
                    transformContainer);

            TransformObjectModel transformModel = new TransformObjectModel(movementBehaviour,
                    _transform.position, _transform.eulerAngles);
            
            _presentors.Add(new TransformObjectPresentor(transformViewer,transformModel));
        }

        private void CreateBulletFactory()
        {
            var (view,model) = 
                _bulletFactory.CreateFactory();

            var bulletPresentor =
                new BulletFactoryPresenter(_inputService.Player.LeftShoot,view,model);
            
            _presentors.Add(bulletPresentor);
        }
        private void CreateLaserFactory()
        {
            var (view,model) = 
                _laserFactory.CreateCounterFactory();

            var laserPresentor =
                new LaserFactoryPresenter(_inputService.Player.RightShoot,view,model);
            
            _presentors.Add(laserPresentor);
        }

        private void CreateLifecycle()
        {
            _collider = GetComponent<Collider2D>();
            
            ILifecycleBehaviour lifecycleBehaviour = new DieLifeBehaviour();
            ILifecycleViewer _viewer = new LifecycleViewer(_collider, lifecycleBehaviour);
            LifecycleModel model = new LifecycleModel(10);

            _collisionPresentor = new LifecyclePresentor(_viewer, model);
            _collisionPresentor.Enable();
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log("Afasfsf");
            _collisionPresentor.StartCollision(col);
        }
    }
}