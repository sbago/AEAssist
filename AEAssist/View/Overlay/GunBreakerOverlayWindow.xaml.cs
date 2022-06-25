using System.Windows;
using System.Windows.Controls;
using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.View.Overlay
{
    public partial class GunBreakerOverlayWindow : UserControl
    {
        public GunBreakerOverlayWindow()
        {
            InitializeComponent();
        }
        private void UseSprint_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.Sprint.GetSpellEntity();
        }

        private void UsePotion_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilityUsePotion = true;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.OverlayManager.Instance.Close();
        }
    }
}
