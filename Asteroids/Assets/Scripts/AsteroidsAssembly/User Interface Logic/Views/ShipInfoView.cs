using System;
using UnityEngine.UI;

namespace AsteroidsAssembly.UserInterface
{
    [Serializable]
    public class ShipInfoContainer
    {
        public Text CoordinatesInfo;
        public Text AngleInfo;
        public Text SpeedInfo;
        public Text LaserCountInfo;
        public Text LaserDelayInfo;

        public void UpdateData(ShipUIData data)
        {
            CoordinatesInfo.text = $"Coord: {data.Position}";
            AngleInfo.text = $"Angle: {data.Angle}";
            SpeedInfo.text = $"Speed: {data.MomentSpeed}";

            LaserCountInfo.text = $"Laser charges: {data.LaserCount}";
            LaserDelayInfo.text = $"Laser reloading: {data.LaserDelay}";
        }
    }
    
    public class ShipInfoView
    {
        private readonly ShipInfoContainer _shipInfoContainer;

        public ShipInfoView(ShipInfoContainer shipInfoContainer)
        {
            _shipInfoContainer = shipInfoContainer;
        }

        public void UpdateUI(ShipUIData data) => _shipInfoContainer.UpdateData(data);
    }
}