using System;
using UnityEngine;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        private GameObject _blockPrefab;
        public SpriteRenderer ballSpriteRenderer;
        public SpriteRenderer currentBallSprite;

        public static Action OnLevelSuccessfullyEnd;

        private void Awake() {
            currentBallSprite.sprite = ballSpriteRenderer.sprite;
            BallSpawner.OnAllBallsDied += OnAllBallsDied;
            DontDestroyOnLoad(this.gameObject);
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