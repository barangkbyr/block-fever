using System;
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

            GameManager.OnLevelSuccessfullyEnd += OnLevelSuccessfullyEnd;
        }

        private void Start() {
            currentScore = 0;
        }

        private void OnLevelSuccessfullyEnd() {
            AddScore();
        }

        private void Update() {
            scoreText.text = currentScore.ToString();
        }

        private void AddScore() {
            var saveHandler = SaveHandler.Instance.savedValues;
            saveHandler.totalScore += currentScore;
        }
    }
}