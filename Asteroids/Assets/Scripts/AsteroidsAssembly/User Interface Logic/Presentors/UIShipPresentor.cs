using System;
using AsteroidsAssembly.Interfaces;

namespace AsteroidsAssembly.UserInterface
{
    public class UIShipPresentor: IUpdatablePresentor
    {
        private readonly ShipInfoView _viewer;
        private readonly ShipUIModel _model;

        private Action _updateUI;
        
        public UIShipPresentor(ShipInfoView viewer, ShipUIModel model)
        {
            _viewer = viewer;
            _model = model;
        }
        
        public void Enable() => _updateUI += UpdateUI;
        public void Disable() => _updateUI -= UpdateUI;
        
        public void Update() => _updateUI?.Invoke();
        
        private void UpdateUI()
        {
            _model.UpdateData();
            _viewer.UpdateUI(_model.Data);
        }
    }
}