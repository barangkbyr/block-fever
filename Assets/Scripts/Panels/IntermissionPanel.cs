using JetBrains.Annotations;
using TMPro;

namespace Assets.Scripts.Panels {
    public class IntermissionPanel : BasePanel {
        public TextMeshProUGUI currentScoreText;
        public TextMeshProUGUI totalScoreText;

        private void OnEnable() {
            currentScoreText.text = "Won: " + PointManager.Instance.currentScore;
            totalScoreText.text = "Total Score: " + SaveHandler.Instance.savedValues.totalScore;
            DisableSpawnerAndLine();
        }

        [UsedImplicitly]
        public void OpenUpgradePanel() {
            PanelManager.Instance.ActivatePanel(PanelManager.Instance.upgradePanel);
        }

        [UsedImplicitly]
        public void NextLevel() {
            PointManager.Instance.currentScore = 0;
            GridManager.Instance.GenerateGrid(6, 6);
            EnableSpawnerAndLine();
            PanelManager.Instance.DeactivatePanel(PanelManager.Instance.intermissionPanel);
        }
    }
}