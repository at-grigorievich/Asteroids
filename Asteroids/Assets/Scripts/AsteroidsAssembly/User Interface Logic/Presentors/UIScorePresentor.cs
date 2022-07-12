using AsteroidsAssembly.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AsteroidsAssembly.UserInterface
{
    public class UIScorePresentor: IEnable
    {
        private readonly ScoreInfoView _view;
        private readonly GameScoreModel _model;

        private readonly Button _replayBtn;
        
        public UIScorePresentor(ScoreInfoView view, GameScoreModel model, Button btn)
        {
            _view = view;
            _model = model;

            _replayBtn = btn;
        }
        
        public void Enable() =>_replayBtn.onClick.AddListener(() => RestartGame());

        public void Disable()
        {
            _replayBtn.onClick.RemoveAllListeners();
            Time.timeScale = 1f;
        }

        
        public void AddScore(object sender,int add) => _model.AddScore(add);
        
        public void ShowReplayView()
        {
            Time.timeScale = 0f;
            _view.ShowScore(_model.Score);
        }
        
        private void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}