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
    }
}
