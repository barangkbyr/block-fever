using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts {
    public class SaveHandler : MonoBehaviour {
        public static SaveHandler Instance { get; private set; }

        private const string Filename = "SaveFile";
        public string path;

        public SavedValues savedValues;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            } else {
                Instance = this;
            }

            path = Application.persistentDataPath + "/" + Filename;
            Load();
        }

        [UsedImplicitly]
        public void Save() {
            SaveManager.Instance.Save(savedValues, path, SaveComplete, false);
        }

        private void SaveComplete(SaveResult result, string message) {
            if (result == SaveResult.Error) {
                Debug.LogError("Save error" + message);
            }
        }

        [UsedImplicitly]
        public void ClearSave() {
            SaveManager.Instance.ClearAllData(path);
        }

        [UsedImplicitly]
        public void Load() {
            SaveManager.Instance.Load<SavedValues>(path, LoadComplete, false);
        }

        private void LoadComplete(SavedValues data, SaveResult result, string message) {
            if (result is SaveResult.Success) {
                savedValues = data;
            }

            if (result is SaveResult.Error or SaveResult.EmptyData) {
                savedValues = new SavedValues();
            }
        }
    }
}