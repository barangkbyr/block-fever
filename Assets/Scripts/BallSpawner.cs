using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class BallSpawner : MonoBehaviour {
        public GameObject ball;

        [SerializeField]
        private int ballCount;

        [SerializeField]
        private float speed;

        [SerializeField]
        private float downAmount;

        [SerializeField]
        private GameObject blocksParent;

        private Vector3 _mousePos;

        private Vector3 _mouseDir;

        public Vector3 mouseDirNorm;

        private Camera _camera;

        private bool _isShooting;

        [SerializeField]
        private GameObject spawnPosition;


        public List<GameObject> list = new List<GameObject>();

        private void Start() {
            _camera = Camera.main;
            _isShooting = false;
        }

        private void Update() {
            if (_isShooting == false) {
                if (Input.GetMouseButtonUp(0)) {
                    if (Line.Angle >= Line.minAngle && Line.Angle <= Line.maxAngle) {
                        StartCoroutine(ShootBall());
                    }
                }
            } else {
                Line.LineRenderer.enabled = false;
            }

            if (list.Count == 50) {
                _isShooting = false;
            }
        }

        IEnumerator ShootBall() {
            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _mouseDir = _mousePos - spawnPosition.transform.position;
            _mouseDir.z = 0;
            _mouseDir = _mouseDir.normalized;

            _isShooting = true;

            list.Clear();
            blocksParent.GetComponent<MoveBlocksDown>().newGridPos = new Vector2(blocksParent.transform.position.x, blocksParent.transform.position.y - downAmount);

            for (int i = 0; i < ballCount; i++) {
                yield return new WaitForSeconds(0.08f);
                GameObject myInst = Instantiate(ball, spawnPosition.transform.position, Quaternion.identity);
                list.Add(myInst);
                myInst.GetComponent<Rigidbody2D>().AddForce(_mouseDir * speed);
            }
        }
    }
}