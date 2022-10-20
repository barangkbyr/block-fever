using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class SkinManager : MonoBehaviour {
        public BallDatabase ballDb;

        public TextMeshProUGUI totalScore;

        [Header("Skin Preview Manager")]
        public Image imageRenderer;
        private int _selectedBallSkinPreview;

        [Header("Unlock/Apply Buttons")]
        public Button unlockButton;
        public Button applyButton;
        public TextMeshProUGUI ballPriceText;

        [Header("Ball Attributes")]
        [SerializeField]
        private int[] ballPrices;
        public SpriteRenderer ballSpriteRenderer;
        public SpriteRenderer spawnLocationBall;

        void Start() {
            var saveHandler = SaveHandler.Instance.savedValues;
            _selectedBallSkinPreview = saveHandler.currentBallSkinPreview;
            totalScore.text = "Total Score: " + saveHandler.totalScore;
            UpdateBall(_selectedBallSkinPreview);
        }

        private void Update() {
            if (unlockButton.gameObject.activeInHierarchy) {
                unlockButton.interactable = SaveHandler.Instance.savedValues.totalScore >= ballPrices[_selectedBallSkinPreview];
            }
        }

        [UsedImplicitly]
        public void NextButton() {
            _selectedBallSkinPreview++;
            if (_selectedBallSkinPreview >= ballDb.BallCount) {
                _selectedBallSkinPreview = 0;
            }

            UpdateBall(_selectedBallSkinPreview);
        }

        [UsedImplicitly]
        public void BackButton() {
            _selectedBallSkinPreview--;
            if (_selectedBallSkinPreview < 0) {
                _selectedBallSkinPreview = ballDb.BallCount - 1;
            }

            UpdateBall(_selectedBallSkinPreview);
        }

        private void UpdateBall(int selectedOption) {
            Ball ball = ballDb.GetBall(selectedOption);
            imageRenderer.sprite = ball.ballSprite;
            SaveHandler.Instance.Save();

            if (SaveHandler.Instance.savedValues.isBallsUnlocked[selectedOption]) {
                unlockButton.gameObject.SetActive(false);
                applyButton.gameObject.SetActive(true);
            } else {
                unlockButton.gameObject.SetActive(true);
                applyButton.gameObject.SetActive(false);
                ballPriceText.text = ballPrices[selectedOption].ToString();
            }
        }

        [UsedImplicitly]
        public void UnlockBall() {
            var saveHandler = SaveHandler.Instance.savedValues;
            saveHandler.totalScore -= ballPrices[_selectedBallSkinPreview];
            saveHandler.isBallsUnlocked[_selectedBallSkinPreview] = true;
            totalScore.text = "Total Score: " + saveHandler.totalScore;
            saveHandler.currentBallSkinPreview = _selectedBallSkinPreview;
            SaveHandler.Instance.Save();
            UpdateBall(_selectedBallSkinPreview);
        }

        [UsedImplicitly]
        public void ApplyBall() {
            Ball ball = ballDb.GetBall(_selectedBallSkinPreview);
            ballSpriteRenderer.sprite = ball.ballSprite;
            spawnLocationBall.sprite = ball.ballSprite;
            SaveHandler.Instance.savedValues.currentBallSkinPreview = _selectedBallSkinPreview;
            SaveHandler.Instance.Save();
        }

        private void OnDisable() {
            SaveHandler.Instance.Load();
        }
    }
}