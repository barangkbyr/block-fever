using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts {
    public class Blocks : MonoBehaviour {
        [SerializeField]
        private Color[] colors;

        [SerializeField]
        private int life;

        [SerializeField]
        private TextMeshPro lifeText;

        [SerializeField]
        private GameObject explosionEffect;

        private void Start() {
            lifeText = gameObject.GetComponentInChildren<TextMeshPro>();
            life = Random.Range(15, 50);
            lifeText.text = life.ToString();
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.transform.CompareTag(TagsAndLayers.BallTag)) {
                if (life > 1) {
                    life--;
                    lifeText.text = life.ToString();

                    gameObject.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
                } else {
                    Destroy(this.gameObject);
                }
            }
        }

        private void OnDestroy() {
            if (!this.gameObject.scene.isLoaded) return;
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            if (life == 1) {
                PointManager.Instance.currentScore += 10;
            }
        }
    }
}