using System.Windows;
using System.Windows.Controls;
using AEAssist.AI;
using AEAssist.Define;

namespace AEAssist.View.Overlay
{
    public partial class ReaperOverlay : UserControl
    {
        public ReaperOverlay()
        {
            InitializeComponent();
        }

        private void UseArcaneCrest_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.ArcaneCrest.Id;
        }

        private void UseArmsLength_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.ArmsLength.Id;
        }

        private void UseFeint_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.Feint.Id;
        }

        private void UseSprint_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.Sprint.Id;
        }

        private void UseTrueNorth_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.TrueNorth.Id;
            AIRoot.Instance.BattleData.NextAbilityUsePotion = false;
        }

        private void UsePotion_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.Instance.BattleData.NextAbilityUsePotion = true;
        }
    }
}