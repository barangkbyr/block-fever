using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        public int score;
        public int numberOfBalls = 3;
        public int level;

        private void Awake() {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start() {
            NewGame();
        }

        private void NewGame() {
            score = 0;
            numberOfBalls = 3;
            LoadLevel(1);
        }

        private void LoadLevel(int level) {
            this.level = level;

            SceneManager.LoadScene("Level" + level);
        }
    }
}