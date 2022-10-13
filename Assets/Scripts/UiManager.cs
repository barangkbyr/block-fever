using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class UiManager : MonoBehaviour {
        public static int Score;

        [SerializeField]
        private TextMeshProUGUI scoreText;

        private void Start() {
            Score = 0;
        }

        private void Update() {
            scoreText.text = Score.ToString();
        }
    }
}
