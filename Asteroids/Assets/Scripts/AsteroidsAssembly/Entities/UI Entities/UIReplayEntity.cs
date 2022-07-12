using System;
using AsteroidsAssembly.UserInterface;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsAssembly.Entities
{
    [RequireComponent(typeof(Canvas))]
    public class UIReplayEntity : MonoBehaviour
    {
        [SerializeField] private Button _replayBtn;
        [SerializeField] private Text _scoreInfo;
        
        private Canvas _canvas;

        private UIScorePresentor _scorePresentor;

        public UIScorePresentor ScorePresentor => _scorePresentor ?? CreatePresentor();
        
        private void Awake()
        {
            _scorePresentor = CreatePresentor();
        }

        private UIScorePresentor CreatePresentor()
        {
            _canvas = GetComponent<Canvas>();

            var view = new ScoreInfoView(_canvas, _scoreInfo);
            var model = new GameScoreModel();
            
            _scorePresentor = new UIScorePresentor(view, model, _replayBtn);
            _scorePresentor.Enable();

            return _scorePresentor;
        }
        
        private void OnDisable()
        {
            ScorePresentor.Disable();
        }
    }
}