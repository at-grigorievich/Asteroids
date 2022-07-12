using System.Collections.Generic;
using AsteroidsAssembly.GunLogic;
using AsteroidsAssembly.Interfaces;
using AsteroidsAssembly.LifecycleLogic;
using AsteroidsAssembly.TransformLogic;
using AsteroidsAssembly.UserInterface;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    [RequireComponent(typeof(Collider2D))]
    public class ShipEntity: PhysicEntity
    {
        [Space(15)] 
        [SerializeField] private GunFactory _bulletFactory;
        [SerializeField] private GunFactory _laserFactory;
        [Space(15)]
        [SerializeField] private UIShipEntity _uiShip;
        [SerializeField] private UIReplayEntity _uiReplay;
        
        private PlayerInput _inputService;

        private IMovementParameters _movementParameters;
        private IGunParameters _gunParameters;
        
        private new void Awake()
        {
            base.Awake();

            _inputService = new PlayerInput();

            _presentors = new List<IUpdatablePresentor>();
            
            CreateTransformView();
            
            CreateBulletFactory();
            CreateLaserFactory();

            CreateShipUI();
            
            CreateLifecycle();
        }

        private void CreateTransformView()
        {
            ITransformViewer transformViewer = new TransformObjectView(_transform,true);

            TransformDataContainer transformContainer = new TransformDataContainer(_transform);
            
            ShipMovementBehaviour movementBehaviour = new ShipMovementBehaviour(
                    _inputService.Player.Move,
                    _inputService.Player.Rotate,
                    _movementData,
                    transformContainer);

            TransformObjectModel transformModel = new TransformObjectModel(movementBehaviour,
                    _transform.position, _transform.eulerAngles);
            
            _presentors.Add(new TransformObjectPresentor(transformViewer,transformModel));

            _movementParameters = movementBehaviour;
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
            
            _gunParameters = model;
        }

        protected override void CreateLifecycle(ILifecycleBehaviour behaviour = null)
        {
            _collider = GetComponent<Collider2D>();
            
            ILifecycleBehaviour lifecycleBehaviour = 
                new EndGameLifeBehaviour(_uiReplay.ScorePresentor);
            ILifecycleViewer _viewer = 
                new LifecycleViewer(_collider, lifecycleBehaviour);
            LifecycleModel model = 
                new LifecycleModel(10);

            _collisionPresentor = new LifecyclePresentor(_viewer, model,true);
            _collisionPresentor.Enable();
        }

        private void CreateShipUI()
        {
            ShipInfoView view = new ShipInfoView(_uiShip._shipInfoContainer);
            ShipUIModel model = new ShipUIModel(_movementParameters, _gunParameters);

            UIShipPresentor presentor = new UIShipPresentor(view, model);
            
            _presentors.Add(presentor);
        }
    }
}