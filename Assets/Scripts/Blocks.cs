using System;
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

        private void Start() {
            lifeText = gameObject.GetComponentInChildren<TextMeshPro>();
            life = Random.Range(50, 200);
            lifeText.text = life.ToString();
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.transform.tag == "Ball") {
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
            PointManager.Instance.score += 10;
        }
    }
}