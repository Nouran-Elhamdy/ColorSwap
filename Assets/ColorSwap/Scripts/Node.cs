using UnityEngine;
using System.Linq;

namespace PuzzleGames
{
   public class Node : MonoBehaviour
    {
        #region Public Variables

        public Node[] connectedNodes;
        public Color occuppiedColor;
        #endregion

        public bool IsColorRepeated()
        {
            Debug.Log(connectedNodes.Any(connectedNode => connectedNode.occuppiedColor == occuppiedColor));
           return connectedNodes.Any(connectedNode => connectedNode.occuppiedColor == occuppiedColor);
        }
    }
}
