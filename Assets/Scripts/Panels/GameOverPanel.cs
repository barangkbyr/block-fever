using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Panels {
    public class GameOverPanel : BasePanel {
        public static Action OnNewLevelStart;

        public TextMeshProUGUI totalScoreText;
        public GameObject blocksParent;

        private void OnEnable() {
            totalScoreText.text = "Total Score: " + SaveHandler.Instance.savedValues.totalScore;
            DisableSpawnerAndLine();
        }

        [UsedImplicitly]
        public void ReplayLevel() {
            ClearAllBlocks();
            blocksParent.transform.position = Vector3.zero;
            GridManager.Instance.GenerateGrid(6, 6);
            EnableSpawnerAndLine();
            PanelManager.Instance.DeactivatePanel(PanelManager.Instance.gameOverPanel);
            OnNewLevelStart?.Invoke();
        }

        private void ClearAllBlocks() {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag(TagsAndLayers.StoneTag);

            foreach (GameObject block in blocks) {
                Destroy(block);
            }
        }
    }
}