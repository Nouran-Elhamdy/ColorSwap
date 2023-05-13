using DG.Tweening;
using UnityEngine;

namespace PuzzleGames
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class DraggableColoredCircle : MonoBehaviour
    {
        #region Public Variables
        public Node nodeHolder;
        public bool isDragging;
        public bool canSwap;
        #endregion

        #region Private Variables
        Color circleColor;
        DraggableColoredCircle other;
        [SerializeField] SpriteRenderer effect;
        #endregion


        #region Unity Callbacks
        private void Start()
        {
            circleColor = GetComponent<SpriteRenderer>().color;
            nodeHolder.occuppiedColor = circleColor;
            circleColor.a = 0.2f;
        }
        private void Update()
        {
            if (!Manager.LevelManager.isGameRunning) return;

            UpdateCirclePosition();
        }
        private void OnMouseDown()
        {
            if (!Manager.LevelManager.isGameRunning) return;

            DragCircle();
        }
        private void OnMouseUp()
        {
            if (!Manager.LevelManager.isGameRunning) return;

            ReleaseCircle();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out other) && Manager.NodeManager.currentColor == this)
            {
                canSwap = nodeHolder.IsConnectedToNode(other.nodeHolder);
            }
        }
        #endregion

        #region PrivateMethods      
            
        private void DragCircle()
        {
            isDragging = true;
            effect.color = circleColor;
            effect.gameObject.SetActive(true);
        }

        private void ReleaseCircle()
        {
            isDragging = false;

            if (!canSwap)
            {
                transform.DOMove(nodeHolder.transform.position, 0.3f);
            }
            else
            {
                NodeManager.OnCirclesCollided.Invoke(other);
                canSwap = false;
            }
            effect.gameObject.SetActive(false);
        }

        private void UpdateCirclePosition()
        {
            if (isDragging)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
                Manager.NodeManager.currentColor = this;
            }
        }
        #endregion
    }
}
