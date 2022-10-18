using System;
using UnityEngine;

namespace Assets.Scripts {
    public class Line : MonoBehaviour {
        private Vector3 _startPos;
        public Vector3 endPos;
        private Vector3 _mousePos;
        private Vector3 _mouseDir;

        public static float minAngle = 5;

        public static float maxAngle = 175;

        public static float Angle;

        private Camera _camera;

        public static LineRenderer LineRenderer;

        [SerializeField]
        private GameObject renderSpawnPosition;

        [SerializeField]
        private float max = 2;

        private void Awake() {
            GameOverScript.OnGameOver += OnGameOver;
        }

        private void OnGameOver() {
            LineRenderer.enabled = false;
            gameObject.SetActive(false);
        }

        private void Start() {
            LineRenderer = GetComponent<LineRenderer>();
            _camera = Camera.main;
        }

        private void Update() {
            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _mouseDir = _mousePos - renderSpawnPosition.transform.position;
            _mouseDir.z = 0;
            _mouseDir = _mouseDir.normalized;

            Angle = Mathf.Atan2(_mouseDir.y, _mouseDir.x) * Mathf.Rad2Deg;

            if (Angle >= minAngle && Angle <= maxAngle) {
                if (Input.GetMouseButtonDown(0)) {
                    LineRenderer.enabled = true;
                }

                if (Input.GetMouseButton(0)) {
                    _startPos = renderSpawnPosition.transform.position;
                    _startPos.z = 0;
                    LineRenderer.SetPosition(0, _startPos);
                    endPos = _mousePos;
                    endPos.z = 0;
                    float capLength = Mathf.Clamp(Vector2.Distance(_startPos, endPos), 0, max);
                    endPos = _startPos + (_mouseDir * capLength);
                    LineRenderer.SetPosition(1, endPos);
                }
            }

            if (Input.GetMouseButtonUp(0)) {
                LineRenderer.enabled = false;
            }
        }
    }
}