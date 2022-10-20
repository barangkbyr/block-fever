using Assets.Scripts.Panels;
using UnityEngine;

namespace Assets.Scripts {
    public class PanelManager : MonoBehaviour {
        public static PanelManager Instance { get; private set; }

        public GameOverPanel gameOverPanel;
        public IntermissionPanel intermissionPanel;
        public MainMenuPanel mainMenuPanel;
        public UpgradePanel upgradePanel;
        public BallSkinPanel ballSkinPanel;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            } else {
                Instance = this;
            }
        }

        public void ActivatePanel(BasePanel panel) {
            CloseAllPanels();
            panel.gameObject.SetActive(true);
        }

        public void DeactivatePanel(BasePanel panel) {
            panel.gameObject.SetActive(false);
        }

        private void CloseAllPanels() {
            gameOverPanel.gameObject.SetActive(false);
            intermissionPanel.gameObject.SetActive(false);
            mainMenuPanel.gameObject.SetActive(false);
            upgradePanel.gameObject.SetActive(false);
            ballSkinPanel.gameObject.SetActive(false);
        }
    }
}