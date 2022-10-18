using Assets.Extensions;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Panels {
    public class UpgradePanel : BasePanel {
        public TextMeshProUGUI totalBallNumber;
        public TextMeshProUGUI ballUpgradeCost;

        public Button ballUpgradeButton;

        public Sprite onSprite;
        public Sprite offSprite;

        private void OnEnable() {
            RefreshUi();
            CheckIfValuesEnough();
        }

        [UsedImplicitly]
        public void CloseUpgradePanel() {
            PanelManager.Instance.ActivatePanel(PanelManager.Instance.intermissionPanel);
        }

        [UsedImplicitly]
        public void UpgradeBallNumber() {
            var savedValues = SaveHandler.Instance.savedValues;
            if (savedValues.ballUpgradeCost <= savedValues.totalScore) {
                savedValues.totalScore -= savedValues.ballUpgradeCost;
                savedValues.ballCount += 1;
                savedValues.ballUpgradeCost *= 2;
                RefreshUi();
            } else {
                ballUpgradeCost.text = "+1 Ball Upgrade Cost: " + savedValues.ballUpgradeCost.StrikeThrough();
            }
        }

        private void RefreshUi() {
            var saveHandler = SaveHandler.Instance.savedValues;
            totalBallNumber.text = "Total Number of Balls: " + saveHandler.ballCount.Bold();
            ballUpgradeCost.text = "+1 Ball Upgrade Cost: " + saveHandler.ballUpgradeCost.Bold();
        }

        private void CheckIfValuesEnough() {
            var savedValues = SaveHandler.Instance.savedValues;
            SetUpgradeButtonSprite(savedValues.totalScore, savedValues.ballUpgradeCost, ballUpgradeButton, ballUpgradeCost);
        }

        private void SetUpgradeButtonSprite(int totalScore, int upgradeCost, Button upgradeButton, TextMeshProUGUI upgradeCostText) {
            upgradeButton.image.sprite = totalScore >= upgradeCost ? onSprite : offSprite;
            upgradeCostText.text = totalScore >= upgradeCost ? upgradeCost.ToString() : "+1 Ball Upgrade Cost: " + upgradeCost.StrikeThrough();
        }

        private void OnDisable() {
            SaveHandler.Instance.Save();
        }
    }
}