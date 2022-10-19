using UnityEngine;

namespace Assets.Scripts {
    public class GoDown : MonoBehaviour {
        [SerializeField]
        private float blockDownSpeed;

        public GameObject block;

        private void Awake() {
            BallSpawner.OnAllBallsDied += OnAllBallsDied;
        }

        private void OnAllBallsDied() {
            MoveBlocks();
        }

        private void MoveBlocks() {
            block = GameObject.FindGameObjectWithTag(TagsAndLayers.StoneTag);
            if (block.gameObject.activeInHierarchy) {
                var step = blockDownSpeed * Time.deltaTime;
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(0, -3.65f), step);
            }
        }
    }
}