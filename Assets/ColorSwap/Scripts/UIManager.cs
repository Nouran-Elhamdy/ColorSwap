using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace PuzzleGames
{
    public class UIManager : Manager
    {
        public List<View> gameViews;
        private void Start()
        {
            SwitchToView(ViewType.StartView);
        }
        public void SwitchToView(ViewType view1)
        {
            gameViews.ForEach(x => x.viewGameObject.SetActive(false));

            var viewToEnable = gameViews.Find(x => x.viewType == view1);
            viewToEnable.viewGameObject.SetActive(true);
        }
    }
}

