using DG.Tweening;
using System;
using System.Linq;

namespace PuzzleGames
{
   public class NodeManager : Manager
    {
        #region Public Variables
        public DraggableColoredCircle currentColor;
        public static Action<DraggableColoredCircle> OnCirclesCollided;
        public static Action OnSwappedCircle;
        #endregion

        #region Unity Callbacks
        private void OnEnable()
        {
            OnCirclesCollided += SwapColor;
        }
        private void OnDisable()
        {
            OnCirclesCollided -= SwapColor;
        }
        #endregion

        #region Private Methods
        private void SwapColor(DraggableColoredCircle arg2)
        {
            var currentNode = currentColor.nodeHolder;
            var color = currentColor.nodeHolder.occuppiedColor;

            currentColor.transform.DOMove(arg2.transform.position, 1);
            currentColor.transform.SetParent(arg2.nodeHolder.transform);
            currentColor.nodeHolder.occuppiedColor = arg2.nodeHolder.occuppiedColor;
            currentColor.nodeHolder = arg2.nodeHolder;

            arg2.nodeHolder.occuppiedColor = color;
            arg2.transform.DOMove(currentNode.transform.position, 1);
            arg2.transform.SetParent(currentNode.transform);

            arg2.nodeHolder = currentNode;

            OnSwappedCircle?.Invoke();
        }
        #endregion
    }
}
