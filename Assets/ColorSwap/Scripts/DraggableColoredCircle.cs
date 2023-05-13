using UnityEngine;

namespace PuzzleGames
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DraggableColoredCircle : MonoBehaviour
    {
        #region Public Variables

        public Node nodeHolder;
        public bool isDragging;
        public bool canSwap;
        DraggableColoredCircle other;
        Color circleColor;
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
            if(isDragging)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
                Manager.NodeManager.currentColor = this;
            }
        }
        private void OnMouseDown()
        {
            isDragging = true;
            effect.color = circleColor;
            effect.gameObject.SetActive(true);
        }
        private void OnMouseUp()
        {
            isDragging = false;

            if (!canSwap)
            {
                transform.position = nodeHolder.transform.position;

            }
            else
            {
                NodeManager.OnCirclesCollided.Invoke(other);
                canSwap = false;
            }
            effect.gameObject.SetActive(false);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out other) && Manager.NodeManager.currentColor == this)
            {
                canSwap = Manager.NodeManager.IsConnectedToNode(this.nodeHolder, other.nodeHolder);
            }
        }
        #endregion
    }
}
