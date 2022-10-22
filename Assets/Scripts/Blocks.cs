using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts {
    public class Blocks : MonoBehaviour {
        [SerializeField]
        private Color[] colors;

        private int _life;

        [SerializeField]
        private TextMeshPro lifeText;

        [SerializeField]
        private GameObject explosionEffect;

        private int _currentLevel;

        private void Start() {
            lifeText = gameObject.GetComponentInChildren<TextMeshPro>();
            _currentLevel = SaveHandler.Instance.savedValues.playerLevel;
            _life = GenerateLevelBasedOnDifficulty();
            lifeText.text = _life.ToString();
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.transform.CompareTag(TagsAndLayers.BallTag)) {
                if (_life > 1) {
                    _life--;
                    lifeText.text = _life.ToString();

                    gameObject.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
                } else {
                    Destroy(this.gameObject);
                }
            }
        }

        private void OnDestroy() {
            if (!this.gameObject.scene.isLoaded) return;
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            if (_life == 1) {
                PointManager.Instance.currentScore += 10;
            }
        }

        private int GenerateLevelBasedOnDifficulty() {
            switch (_currentLevel) {
                case < 10 and >= 1:
                    return Random.Range(5, 10);

                case < 20 and >= 10:
                    return Random.Range(10, 15);

                case < 30 and >= 20:
                    return Random.Range(15, 25);

                case < 40 and >= 30:
                    return Random.Range(25, 35);

                case < 50 and >= 40:
                    return Random.Range(35, 45);

                case < 100 and >= 50:
                    return Random.Range(45, 60);

                case < 200 and >= 100:
                    return Random.Range(60, 75);

                case < 300 and >= 200:
                    return Random.Range(75, 90);

                default:
                    return Random.Range(90, 110);
            }
        }
    }
}