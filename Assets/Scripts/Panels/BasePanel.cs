using UnityEngine;

namespace Assets.Scripts.Panels {
    public abstract class BasePanel : MonoBehaviour {
        [Header("Base Panel")]
        public BallSpawner ballSpawner;

        public Line line;
        public GameObject topUi;

        protected void EnableTopUi() {
            topUi.gameObject.SetActive(true);
        }

        protected void DisableTopUi() {
            topUi.gameObject.SetActive(false);
        }


        protected void EnableSpawnerAndLine() {
            ballSpawner.gameObject.SetActive(true);
            line.gameObject.SetActive(true);
        }

        protected void DisableSpawnerAndLine() {
            ballSpawner.gameObject.SetActive(false);
            line.gameObject.SetActive(false);
        }
    }
}