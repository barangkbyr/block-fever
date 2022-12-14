using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Panels {
    public class IntermissionPanel : BasePanel {
        public TextMeshProUGUI currentScoreText;
        public TextMeshProUGUI totalScoreText;
        public TextMeshProUGUI levelText;

        public GameObject blocksParent;

        private void OnEnable() {
            currentScoreText.text = $"Won: {PointManager.Instance.currentScore}";
            totalScoreText.text = $"Total Score: {SaveHandler.Instance.savedValues.totalScore}";
            levelText.text = $"Level {SaveHandler.Instance.savedValues.playerLevel} Cleared";
            DisableSpawnerAndLine();
            DisableTopUi();
        }

        [UsedImplicitly]
        public void OpenUpgradePanel() {
            PanelManager.Instance.ActivatePanel(PanelManager.Instance.upgradePanel);
        }

        [UsedImplicitly]
        public void NextLevel() {
            PointManager.Instance.currentScore = 0;
            SaveHandler.Instance.savedValues.playerLevel++;
            blocksParent.transform.position = Vector3.zero;
            GridManager.Instance.GenerateGrid(6, 6);
            EnableSpawnerAndLine();
            EnableTopUi();
            PanelManager.Instance.DeactivatePanel(PanelManager.Instance.intermissionPanel);
            SaveHandler.Instance.Save();
        }
    }
}