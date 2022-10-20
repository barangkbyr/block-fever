using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts {
    public class BallSpawner : MonoBehaviour {
        public static Action OnAllBallsDied;

        public GameObject ball;

        [SerializeField]
        private float speed;

        private Vector3 _mousePos;
        private Vector3 _mouseDir;

        private Camera _camera;

        private bool _isShooting;

        [SerializeField]
        private GameObject spawnPosition;

        private bool _isBallsAlive;

        public Button recallButton;

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
                recallButton.interactable = false;
                if (Input.GetMouseButtonUp(0)) {
                    if (Line.Angle >= Line.MinAngle && Line.Angle <= Line.MaxAngle) {
                        StartCoroutine(ShootBall());
                    }
                }
            } else {
                recallButton.interactable = true;
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

        [UsedImplicitly]
        public void DestroyAllBalls() {
            GameObject[] balls = GameObject.FindGameObjectsWithTag(TagsAndLayers.BallTag);

            foreach (GameObject ball in balls) {
                Destroy(ball);
            }

            _isShooting = false;
            _isBallsAlive = false;
        }
    }
}