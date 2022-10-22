using System;
using UnityEngine;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        private GameObject _blockPrefab;
        public SpriteRenderer ballSpriteRenderer;
        public SpriteRenderer currentBallSprite;

        public BallDatabase ballDb;

        public static Action OnLevelSuccessfullyEnd;

        private void Awake() {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            BallSpawner.OnAllBallsDied += OnAllBallsDied;
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start() {
            var saveHandler = SaveHandler.Instance.savedValues;
            Ball ball = ballDb.GetBall(saveHandler.currentBallSkinPreview);
            ballSpriteRenderer.sprite = ball.ballSprite;
            currentBallSprite.sprite = ballSpriteRenderer.sprite;
        }

        private void OnAllBallsDied() {
            CheckIfAllBlocksDestroyed();
        }

        private void CheckIfAllBlocksDestroyed() {
            _blockPrefab = GameObject.FindGameObjectWithTag(TagsAndLayers.StoneTag);
            if (_blockPrefab == null) {
                OnLevelSuccessfullyEnd?.Invoke();
                PanelManager.Instance.ActivatePanel(PanelManager.Instance.intermissionPanel);
            }
        }
    }
}