using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AEAssist.AI;
using AEAssist.Define;

namespace AEAssist.View.Overlay
{
    /// <summary>
    /// BlackMage_Overlay2.xaml 的交互逻辑
    /// </summary>
    public partial class BlackMage_Overlay2 : UserControl
    {
        public BlackMage_Overlay2()
        {
            InitializeComponent();
        }

        private void UseAetherialPM1_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(SpellsDefine.AetherialManipulation,SpellTargetType.PM1);
        }
        private void UseAetherialPM2_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(SpellsDefine.AetherialManipulation,SpellTargetType.PM2);
        }
        private void UseAetherialPM3_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(SpellsDefine.AetherialManipulation,SpellTargetType.PM3);
        }
        private void UseAetherialPM4_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(SpellsDefine.AetherialManipulation,SpellTargetType.PM4);
        }
        private void UseAetherialPM5_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(SpellsDefine.AetherialManipulation,SpellTargetType.PM5);
        }
        private void UseAetherialPM6_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(SpellsDefine.AetherialManipulation,SpellTargetType.PM6);
        }
        private void UseAetherialPM7_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(SpellsDefine.AetherialManipulation,SpellTargetType.PM7);
        }
    }
}
