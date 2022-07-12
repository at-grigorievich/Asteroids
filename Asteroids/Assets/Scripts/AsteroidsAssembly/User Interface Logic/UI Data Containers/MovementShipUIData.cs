using System;
using AsteroidsAssembly.GunLogic;
using AsteroidsAssembly.TransformLogic;

namespace AsteroidsAssembly.UserInterface
{
    public struct ShipUIData
    {
        public readonly string Position;
        public readonly string Angle;
        public readonly string MomentSpeed;
        public readonly string LaserCount;
        public readonly string LaserDelay;
        
        public ShipUIData(IMovementParameters mParameters, IGunParameters gParameters)
        {
            Position = mParameters.CurrentCoordinates.ToString();
            Angle = ((int)mParameters.CurrentAngle).ToString();
            MomentSpeed = Math.Round(mParameters.MomentSpeed,1).ToString();
            LaserCount = gParameters.Count.ToString();
            LaserDelay = Math.Round(gParameters.TimeLeft,1).ToString();
        }
    }
}