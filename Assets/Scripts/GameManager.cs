using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        public static int Score;

        public static TextMeshPro scoreText;


        private void Awake() {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start() {
            Score = 0;
        }
    }
}