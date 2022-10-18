using UnityEngine;

namespace Assets.Scripts {
    public class Wall : MonoBehaviour {
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.transform.CompareTag(TagsAndLayers.BallTag)) {
                Destroy(other.gameObject);
            }
        }
    }
}