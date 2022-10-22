using System;

namespace Assets.Scripts {
    [Serializable]
    public class SavedValues {
        public int ballCount = 5;
        public int totalScore = 0;
        public int currentBallSkinPreview = 0;
        public int playerLevel = 1;

        public int ballUpgradeCost = 100;
        public int currentUpgradeLevel = 1;

        public bool[] isBallsUnlocked = new bool[35] {
            true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false
        };
    }
}