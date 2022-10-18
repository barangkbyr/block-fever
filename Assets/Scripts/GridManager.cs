using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts {
    public class GridManager : MonoBehaviour {
        public static GridManager Instance { get; private set; }

        [SerializeField]
        private float spawnOffsetX;

        [SerializeField]
        private float spawnOffsetY;

        [SerializeField]
        private float gridOffsetX;

        [SerializeField]
        private float gridOffsetY;

        public GameObject blockParent;

        [SerializeField]
        private GameObject block;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            } else {
                Instance = this;
            }
        }

        public void GenerateGrid(int gridWidth, int gridHeight) {
            for (int x = 0; x < gridWidth; x++) {
                for (int y = 0; y < gridHeight; y++) {
                    var randomNumber = Random.Range(0, 2);
                    if (randomNumber == 1) {
                        var spawnedBlock = Instantiate(block, new Vector3(gridOffsetX + (spawnOffsetX * x), gridOffsetY + (spawnOffsetY * -y)), Quaternion.identity);
                        spawnedBlock.transform.SetParent(blockParent.transform);
                    }
                }
            }
        }
    }
}