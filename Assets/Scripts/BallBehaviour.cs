using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts {
    public class BallBehaviour : MonoBehaviour {
        private float _previousFrameYLevel;

        private Rigidbody2D _rb;

        private void Start() {
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update() {
            if (_previousFrameYLevel == transform.position.y) {
                StartCoroutine(AddForceAfterSeconds());
            }

            _previousFrameYLevel = transform.position.y;
        }

        IEnumerator AddForceAfterSeconds() {
            yield return new WaitForSeconds(3f);

            var newVector = new Vector2(0, Random.Range(-1, 1));
            
            _rb.AddForce(newVector);
        }
    }
}