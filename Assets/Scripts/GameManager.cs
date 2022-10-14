using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        private void Awake() {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}