using UnityEngine;
using System.Linq;
using TMPro;

namespace PuzzleGames
{
   public class Node : MonoBehaviour
    {
        #region Public Variables
        public Node[] connectedNodes;
        public Color occuppiedColor;
        #endregion

        #region Public Methods
        public bool IsColorRepeated()
        {
            if (connectedNodes.Length > 1)
            {
                return connectedNodes.Any(connectedNode => connectedNode.occuppiedColor.CompareRGB(occuppiedColor));
            }
            else
            {
                return false;
            }
        }
        public bool IsConnectedToNode(Node otherNode)
        {
            return connectedNodes.Any(connectedNode => connectedNode == otherNode);
        }
        #endregion

    }
}
