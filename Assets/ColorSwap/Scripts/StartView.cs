using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleGames
{
    public class StartView : BaseView
    {
        [SerializeField] Button startButton;

        private void OnEnable()
        {
            startButton.onClick.AddListener(OnClickStartButton);
        }
        private void OnDisable()
        {
            startButton.onClick.RemoveListener(OnClickStartButton);
        }
        public void OnClickStartButton()
        {
            Manager.UIManager.SwitchToView(ViewType.GameView);
            LevelManager.OnLevelStarted?.Invoke();
        }
    }
}

