using System;
using System.Linq;
using UnityEngine;

namespace PuzzleGames
{
   public class NodeManager : Manager
    {
        public DraggableColoredCircle currentColor;

        public static Action<DraggableColoredCircle> OnCirclesCollided;
        public static Action OnSwappedCircle;
        public bool IsConnectedToNode(Node node1, Node node2)
        {
            return node1.connectedNodes.Any(connectedNode => connectedNode == node2);
        }

        private void OnEnable()
        {
            OnCirclesCollided += SwapColor;
        }
        private void OnDisable()
        {
            OnCirclesCollided -= SwapColor;
        }
        private void SwapColor(DraggableColoredCircle arg2)
        {
            var currentNode = currentColor.nodeHolder;
            var color = currentColor.nodeHolder.occuppiedColor;

            currentColor.transform.position = arg2.transform.position;
            currentColor.transform.SetParent(arg2.nodeHolder.transform);
            currentColor.nodeHolder.occuppiedColor = arg2.nodeHolder.occuppiedColor;
            currentColor.nodeHolder = arg2.nodeHolder;

            arg2.nodeHolder.occuppiedColor = color;
            arg2.transform.position = currentNode.transform.position;
            arg2.transform.SetParent(currentNode.transform);

            arg2.nodeHolder = currentNode;

            OnSwappedCircle?.Invoke();
        }

    }

}
