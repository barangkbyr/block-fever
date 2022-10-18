using System;
using UnityEngine;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        private GameObject _blockPrefab;

        public static Action OnLevelSuccessfullyEnd;

        private void Awake() {
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