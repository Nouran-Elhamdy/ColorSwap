using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleGames
{
    public class GameView : BaseView
    {
        [SerializeField] Button resetLevelButton;
        [SerializeField] Text levelNumberText;


        private void Start()
        {
            UpdateLevelNumber();
        }
        private void OnEnable()
        {
            resetLevelButton.onClick.AddListener(OnClickResetLevelButton);
            LevelManager.OnLevelCompleted += UpdateLevelNumber;
        }
        private void UpdateLevelNumber()
        {
           levelNumberText.text = Manager.LevelManager.currentLevelNumber.ToString() + " / " + Manager.LevelManager.gameLevels.Count;
        }
        private void OnDisable()
        {
            resetLevelButton.onClick.RemoveListener(OnClickResetLevelButton);
            LevelManager.OnLevelCompleted -= UpdateLevelNumber;
        }
        public void OnClickResetLevelButton()
        {
        }
    }
}

