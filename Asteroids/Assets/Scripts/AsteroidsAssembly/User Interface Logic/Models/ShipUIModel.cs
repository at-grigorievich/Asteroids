using AsteroidsAssembly.GunLogic;
using AsteroidsAssembly.TransformLogic;

namespace AsteroidsAssembly.UserInterface
{
    public class ShipUIModel
    {
        private readonly IMovementParameters _movementParameters;
        private readonly IGunParameters _gunParameters;
        
        public ShipUIData Data { get; private set; }

        public ShipUIModel(IMovementParameters movementParameters, 
            IGunParameters gunParameters)
        {
            _movementParameters = movementParameters;
            _gunParameters = gunParameters;
        }
        
        public void UpdateData() => Data = new ShipUIData(_movementParameters,_gunParameters);
    }
}