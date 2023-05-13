using System;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleGames
{
    public class LevelCompletedView : BaseView
    {
        [SerializeField] Button nextLevelButton;
        [SerializeField] Button quitGameButton;

        [SerializeField] GameObject gameCompletedRect;
        [SerializeField] GameObject nextLevelRect;

        private void OnEnable()
        {
            nextLevelButton.onClick.AddListener(OnClickNextLevelButton);
            quitGameButton.onClick.AddListener(OnClicQuitGameButton);
        }

        private void OnClicQuitGameButton()
        {
            Application.Quit();
            Debug.Log("Quit Game.");
        }

        private void OnDisable()
        {
            nextLevelButton.onClick.RemoveListener(OnClickNextLevelButton);
            quitGameButton.onClick.RemoveListener(OnClicQuitGameButton);
        }
        public void OnClickNextLevelButton()
        {
            if(Manager.LevelManager.IsGameCompleted())
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
    }
}

