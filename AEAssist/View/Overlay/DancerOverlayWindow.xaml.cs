using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AEAssist.AI;
using AEAssist.Define;

namespace AEAssist.View
{
    public partial class DancerOverlayWindow : UserControl
    {
        public DancerOverlayWindow()
        {
            InitializeComponent();
        }

        private void BardOverlayWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
            }
        }

        private void UseTactician_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.ShieldSamba.Id;
        }

        private void UseArmsLength_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.ArmsLength.Id;
        }

        private void UseSprint_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.Sprint.Id;
            AIRoot.GetBattleData<BattleData>().NextAbilityUsePotion = false;
        }

        private void UsePotion_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilityUsePotion = true;
        }
        

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
            }
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.Instance.Close();
        }
    }
}