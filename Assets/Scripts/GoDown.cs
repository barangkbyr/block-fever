using UnityEngine;

namespace Assets.Scripts {
    public class GoDown : MonoBehaviour {
        [SerializeField]
        private float blockDownSpeed;

        private void Awake() {
            BallSpawner.OnAllBallsDied += OnAllBallsDied;
        }

        private void OnAllBallsDied() {
            MoveBlocks();
        }

        private void MoveBlocks() {
            var step = blockDownSpeed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(0, -3.65f), step);
        }
    }
}