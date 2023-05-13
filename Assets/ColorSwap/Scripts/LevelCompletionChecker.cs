using UnityEngine;
using System.Linq;
using System;

namespace PuzzleGames
{
   public class LevelCompletionChecker : MonoBehaviour
    {
        #region Public Variables
        public Node[] allLevelNodes;
        #endregion

        #region Unity Callbacks
        private void OnEnable()
        {
            NodeManager.OnSwappedCircle += CheckLevel;
        }
        private void OnDisable()
        {
            NodeManager.OnSwappedCircle -= CheckLevel;
        }
        #endregion

        #region Event Callbacks
        private void CheckLevel()
        {
            if(IsLevelCompleted())
            {
                Debug.Log("Level Is Completed");
            }
            else
            {
                Debug.Log("Not Yet");
            }
        }
        #endregion

        #region Public Methods
        public bool IsLevelCompleted()
        {
            return !allLevelNodes.Any(node => node.IsColorRepeated());
        }
        #endregion
    }
}
