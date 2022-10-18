using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Panels {
    public class GameOverPanel : BasePanel {
        public TextMeshProUGUI totalScoreText;

        private void OnEnable() {
            totalScoreText.text = "Total Score: " + SaveHandler.Instance.savedValues.totalScore;
            DisableSpawnerAndLine();
        }

        [UsedImplicitly]
        public void ReplayLevel() {
            ClearAllBlocks();
            PointManager.Instance.currentScore = 0;
            GridManager.Instance.GenerateGrid(6, 6);
            EnableSpawnerAndLine();
            PanelManager.Instance.DeactivatePanel(PanelManager.Instance.gameOverPanel);
        }

        private void ClearAllBlocks() {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag(TagsAndLayers.StoneTag);

            foreach (GameObject block in blocks) {
                Destroy(block);
            }
        }
    }
}