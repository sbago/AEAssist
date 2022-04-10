using System.Windows;
using System.Windows.Controls;
using AEAssist;
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

        private void Reset_OnClick(object sender, RoutedEventArgs e)
        {
            AEAssist.DataBinding.Instance.Reset();
        }

        private void ChangeTriggerLine_OnClick(object sender, RoutedEventArgs e)
        {
            Entry.TriggerLineWindow.OnTriggerLineLoad = 
                s =>
                    this.CurrTriggerLine.Content = $"当前加载时间轴: {s}";
            
            Entry.TriggerLineWindow.OnTriggerLineClear=()=>
                this.CurrTriggerLine.Content="当前加载时间轴: 无";
            
            Entry.TriggerLineWindow.Show();
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