using Assets.Scripts.Panels;
using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class PointManager : MonoBehaviour {
        public static PointManager Instance { get; private set; }

        public TextMeshProUGUI scoreText;

        public int currentScore;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            } else {
                Instance = this;
            }

            GameOverPanel.OnNewLevelStart += OnNewLevelStart;
            GameManager.OnLevelSuccessfullyEnd += OnLevelSuccessfullyEnd;
        }

        private void OnNewLevelStart() {
            currentScore = 0;
        }

        private void OnLevelSuccessfullyEnd() {
            AddScore();
        }

        private void Update() {
            scoreText.text = "Current Points: " + currentScore;
        }

        private void AddScore() {
            var saveHandler = SaveHandler.Instance;
            saveHandler.savedValues.totalScore += currentScore;
            saveHandler.Save();
        }
    }
}