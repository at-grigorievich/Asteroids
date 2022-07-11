using System;
using System.Collections.Generic;
using AsteroidsAssembly.GunLogic;
using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.TransformLogic;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class ShipEntity: MovementEntity
    {
        [Space(15)] 
        [SerializeField] private GunFactory _bulletFactory;
        [SerializeField] private GunFactory _laserFactory;

        private PlayerInput _inputService;
        
        private new void Awake()
        {
            base.Awake();

            _inputService = new PlayerInput();

            _presentors = new List<IUpdatablePresentor>();
            
            CreateTransformView();
            CreateBulletFactory();
            CreateLaserFactory();
            
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
        
        
        private void CreatePhysicView()
        {
            throw new NotImplementedException();
        }
    }
}