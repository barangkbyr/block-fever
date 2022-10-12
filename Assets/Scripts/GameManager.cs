using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        [HideInInspector]
        public static int score;

        [HideInInspector]
        public int currentLevel;

        public static TextMeshPro scoreText;

        private void Awake() {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start() {
            score = 0;
        }
    }
}