using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

namespace PuzzleGames
{
    public class StartView : BaseView
    {
        #region Private Variables
        [SerializeField] Button startButton;
        [SerializeField] Text tapToStartText;
        #endregion

        #region Unity Callbacks
        private void OnEnable()
        {
            startButton.onClick.AddListener(OnClickStartButton);
            FadeColor(tapToStartText, 0.8f);
        }
        private void OnDisable()
        {
            startButton.onClick.RemoveListener(OnClickStartButton);
        }
        #endregion

        #region Unity GUI Callbacks
        public void OnClickStartButton()
        {
            Manager.UIManager.SwitchToView(ViewType.GameView);
            LevelManager.OnLevelStarted?.Invoke();
        }
        #endregion

        #region Private Methods
        private void FadeColor(Text text, float duration)
        {
            var fadeOutTween = text.DOFade(0, duration);
            var fadeInTween = text.DOFade(1, duration);

            Sequence sequence = DOTween.Sequence();
            sequence.Append(fadeOutTween).Append(fadeInTween);
            sequence.SetLoops(-1);
        }
        #endregion
    }
}

