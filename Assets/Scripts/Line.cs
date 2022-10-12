using UnityEngine;

namespace Assets.Scripts {
    public class Line : MonoBehaviour {
        private Vector3 _startPos;
        public Vector3 _endPos;
        private Vector3 _mousePos;
        private Vector3 _mouseDir;

        private Camera _camera;

        public static LineRenderer lineRenderer;

        [SerializeField]
        private GameObject renderSpawnPosition;

        [SerializeField]
        private float max = 2;

        private void Start() {
            lineRenderer = GetComponent<LineRenderer>();
            _camera = Camera.main;
        }

        private void Update() {
            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _mouseDir = _mousePos - renderSpawnPosition.transform.position;
            _mouseDir.z = 0;
            _mouseDir = _mouseDir.normalized;

            if (Input.GetMouseButtonDown(0)) {
                lineRenderer.enabled = true;
            }

            if (Input.GetMouseButton(0)) {
                _startPos = renderSpawnPosition.transform.position;
                _startPos.z = 0;
                lineRenderer.SetPosition(0, _startPos);
                _endPos = _mousePos;
                _endPos.z = 0;
                float capLength = Mathf.Clamp(Vector2.Distance(_startPos, _endPos), 0, max);
                _endPos = _startPos + (_mouseDir * capLength);
                lineRenderer.SetPosition(1, _endPos);
            }

            if (Input.GetMouseButtonUp(0)) {
                lineRenderer.enabled = false;
            }
        }
    }
}