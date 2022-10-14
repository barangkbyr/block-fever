using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class PointManager : MonoBehaviour {
        public static PointManager Instance { get; private set; }

        public TextMeshProUGUI scoreText;

        public int score;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            } else {
                Instance = this;
            }
        }

        private void Start() {
            score = 0;
        }

        private void Update() {
            scoreText.text = score.ToString();
        }
    }
}