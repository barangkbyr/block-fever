using UnityEngine;

namespace Assets.Scripts {
    public class Ball : MonoBehaviour {
        public Rigidbody2D rigidBody;


        private void Awake() {
            rigidBody = GetComponent<Rigidbody2D>();
        }
    }
}