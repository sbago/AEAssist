using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AEAssist.AI;
using AEAssist.Define;
using AEAssist.Helper;
using PropertyChanged;

namespace AEAssist.View.Overlay
{
    [AddINotifyPropertyChangedInterface]
    public partial class SageOverlayWindow : UserControl
    {
        public Action DragMove;
        
        public SageOverlayWindow()
        {
            InitializeComponent();
        }
        
        private void SageOverlayWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // this.DragMove();
            }
        }
        
        // surecast
        private void UseSureCast_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.Surecast.GetSpellEntity();
        }
        
        private void UseSprint_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = SpellsDefine.Sprint.GetSpellEntity();
            AIRoot.GetBattleData<BattleData>().NextAbilityUsePotion = false;
        }
        
        private void UsePotion_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilityUsePotion = true;
        }
        
        private void Expander_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove?.Invoke();
        }
        
        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.OverlayManager.Instance.Close();
        }
        
        
    }
}