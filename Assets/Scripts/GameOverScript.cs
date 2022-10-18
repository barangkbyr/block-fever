using System;
using UnityEngine;

namespace Assets.Scripts {
    public class GameOverScript : MonoBehaviour {
        public static Action OnGameOver;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag(TagsAndLayers.TargetTag)) {
                OnGameOver?.Invoke();
                PanelManager.Instance.ActivatePanel(PanelManager.Instance.gameOverPanel);
            }
        }
    }
}