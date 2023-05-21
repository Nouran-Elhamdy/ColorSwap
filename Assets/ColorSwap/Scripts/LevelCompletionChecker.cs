using UnityEngine;
using System.Linq;

namespace PuzzleGames
{
   public class LevelCompletionChecker : MonoBehaviour
    {
        #region Public Variables
        [SerializeField] public Node[] allLevelNodes;
        #endregion

        #region Unity Callbacks
        private void OnEnable()
        {
            NodeManager.OnSwappedCircle += CheckLevelCompletion;
        }
        private void OnDisable()
        {
            NodeManager.OnSwappedCircle -= CheckLevelCompletion;
        }
        #endregion

        #region Event Callbacks
        private void CheckLevelCompletion()
        {
            if(IsLevelCompleted())
            {
                Debug.Log("Level Is Completed");
                Manager.UIManager.SwitchToView(ViewType.LevelCompletedView);
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
