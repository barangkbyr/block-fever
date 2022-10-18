using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts {
    public class BallSpawner : MonoBehaviour {
        public static Action OnAllBallsDied;

        public GameObject ball;

        [SerializeField]
        private float speed;

        [SerializeField]
        private float blockDownSpeed;

        [SerializeField]
        private GameObject blocksParent;

        private Vector3 _mousePos;
        private Vector3 _mouseDir;

        private Camera _camera;

        private bool _isShooting;

        [SerializeField]
        private GameObject spawnPosition;

        private bool _isBallsAlive;

        private List<GameObject> list = new List<GameObject>();

        private void Start() {
            _camera = Camera.main;
            _isShooting = false;
        }

        private void Update() {
            list.RemoveAll(item => item == null);
            var isAlive = list.Any();

            if (isAlive == false && _isBallsAlive) {
                OnAllBallsDied?.Invoke();
            }

            _isBallsAlive = isAlive;

            if (_isShooting == false && isAlive == false) {
                if (Input.GetMouseButtonUp(0)) {
                    if (Line.Angle >= Line.minAngle && Line.Angle <= Line.maxAngle) {
                        StartCoroutine(ShootBall());
                    }
                }
            } else {
                Line.LineRenderer.enabled = false;
            }
        }

        private void MousePosAndDir() {
            _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _mouseDir = _mousePos - spawnPosition.transform.position;
            _mouseDir.z = 0;
            _mouseDir = _mouseDir.normalized;
        }

        private IEnumerator ShootBall() {
            var ballCount = SaveHandler.Instance.savedValues.ballCount;

            MousePosAndDir();

            _isShooting = true;

            list.Clear();

            for (int i = 0; i < ballCount; i++) {
                yield return new WaitForSeconds(0.08f);
                GameObject myInst = Instantiate(ball, spawnPosition.transform.position, Quaternion.identity);
                list.Add(myInst);
                myInst.GetComponent<Rigidbody2D>().AddForce(_mouseDir * speed);
            }

            _isShooting = false;
        }

        public void MoveBlocks() {
            var step = blockDownSpeed * Time.deltaTime;
            blocksParent.transform.position = Vector2.MoveTowards(blocksParent.transform.position, new Vector2(0, -1.3f), step);
        }
    }
}