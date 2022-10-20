using System;
using Assets.Scripts.Panels;
using UnityEngine;

namespace Assets.Scripts {
    public class GameOverScript : MonoBehaviour {
        public static Action OnGameOver;

        public GameObject blocksParent;
        public GameObject warningTrigger;
        public GameObject warningImage;

        private void Awake() {
            BallSpawner.OnAllBallsDied += OnAllBallsDied;
            GameOverPanel.OnNewLevelStart += OnNewLevelStart;
        }

        private void OnNewLevelStart() {
            CheckIfTriggerIsClose();
        }

        private void OnAllBallsDied() {
            CheckIfTriggerIsClose();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag(TagsAndLayers.StoneTrigger)) {
                OnGameOver?.Invoke();
                PanelManager.Instance.ActivatePanel(PanelManager.Instance.gameOverPanel);
            }
        }

        private void CheckIfTriggerIsClose() {
            if (Vector2.Distance(blocksParent.transform.position, warningTrigger.transform.position) < 1f) {
                warningImage.gameObject.SetActive(true);
            } else {
                warningImage.gameObject.SetActive(false);
            }
        }
    }
}