using JetBrains.Annotations;

namespace Assets.Scripts.Panels {
    public class BallSkinPanel : BasePanel {
        [UsedImplicitly]
        public void CloseSkinPanel() {
            PanelManager.Instance.ActivatePanel(PanelManager.Instance.upgradePanel);
        }
    }
}