using UnityEngine;

namespace Assets.Scripts {
    public class MoveBlocksDown : MonoBehaviour {
        public Vector2 newGridPos;

        [SerializeField]
        private float speed;

        [SerializeField]
        private float step;

        public void GoDownTest() {
            step = speed * Time.deltaTime;

            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, newGridPos, step);
        }
    }
}
