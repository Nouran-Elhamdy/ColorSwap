using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace PuzzleGames
{
    public class LevelCompletedView : BaseView
    {
        #region Private Variables
        [SerializeField] Button nextLevelButton;
        [SerializeField] Button quitGameButton;

        [SerializeField] GameObject gameCompletedRect;
        [SerializeField] GameObject nextLevelRect;

        [SerializeField] GameObject confetti;
        #endregion

        #region Unity Callbacks
        private void OnEnable()
        {
            Manager.LevelManager.isGameRunning = false;

            PushInYAxis(nextLevelRect,1, 2);
            EnableConfetti(true);
            nextLevelButton.onClick.AddListener(OnClickNextLevelButton);
            quitGameButton.onClick.AddListener(OnClicQuitGameButton);
        }
        private void OnDisable()
        {
            PushInYAxis(nextLevelRect, -1, 2);
            EnableConfetti(false);
            nextLevelButton.onClick.RemoveListener(OnClickNextLevelButton);
            quitGameButton.onClick.RemoveListener(OnClicQuitGameButton);
        }
        #endregion

        #region Unity GUI Callbacks
        public void OnClickNextLevelButton()
        {
            if (Manager.LevelManager.IsGameCompleted())
            {
                nextLevelRect.SetActive(false);
                gameCompletedRect.SetActive(true);
            }
            else
            {
                Manager.UIManager.SwitchToView(ViewType.GameView);
                LevelManager.OnLevelCompleted?.Invoke();
            }
        }
        #endregion

        #region Private Methods
        private void PushInYAxis(GameObject obj,int direction, float duration)
        {
            obj.transform.DOMoveY(295 * direction, duration);
        }
        private void EnableConfetti(bool enable)
        {
            if (confetti) confetti.gameObject.SetActive(enable);
        }
        private void OnClicQuitGameButton()
        {
            Application.Quit();
            Debug.Log("Quit Game.");
        }
        #endregion
    }
}

