using JetBrains.Annotations;

namespace Assets.Scripts.Panels {
    public class MainMenuPanel : BasePanel {
        [UsedImplicitly]
        public void StartGame() {
            GridManager.Instance.GenerateGrid(6, 6);
            EnableSpawnerAndLine();
            PanelManager.Instance.DeactivatePanel(PanelManager.Instance.mainMenuPanel);
        }
    }
}