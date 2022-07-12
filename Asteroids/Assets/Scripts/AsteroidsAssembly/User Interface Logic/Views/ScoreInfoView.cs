using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsAssembly.UserInterface
{
    public class ScoreInfoView
    {
        private readonly Canvas _canvas;
        private readonly Text _scoreInfo;
        private readonly Button _replayBtn;

        public ScoreInfoView(Canvas canvas,Text text)
        {
            _canvas = canvas;
            _scoreInfo = text;

            _canvas.enabled = false;
        }

        public void ShowScore(int score)
        {
            _scoreInfo.text = $"Score:{score}";
            _canvas.enabled = true;
        }
    }
}