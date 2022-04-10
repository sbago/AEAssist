using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AEAssist.AI;
using AEAssist.Define;

namespace AEAssist.View
{
    public partial class BardOverlayWindow : UserControl
    {
        public List<SongData> SongDatas;

        public BardOverlayWindow()
        {
            InitializeComponent();
            //
            // SongDatas = new List<SongData>();
            // SongDatas.Add(new SongData
            // {
            //     Name = "不指定",
            //     Song = ActionResourceManager.Bard.BardSong.None
            // });
            // SongDatas.Add(new SongData
            // {
            //     Name = "旅神小步舞",
            //     Song = ActionResourceManager.Bard.BardSong.WanderersMinuet
            // });
            // SongDatas.Add(new SongData
            // {
            //     Name = "贤者叙事谣",
            //     Song = ActionResourceManager.Bard.BardSong.MagesBallad
            // });
            // SongDatas.Add(new SongData
            // {
            //     Name = "军神赞美歌",
            //     Song = ActionResourceManager.Bard.BardSong.ArmysPaeon
            // });
            //
            // this.ChooseNextSong.ItemsSource = SongDatas;
            //
            // this.ChooseNextSong.SelectedValue = BaseSettings.Instance.nextSong;
        }

        private void BardOverlayWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // this.DragMove();
            }
        }

        private void UseTroubadour_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.Troubadour.Id;
        }

        private void UseArmsLength_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.ArmsLength.Id;
        }

        private void UseSprint_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.Instance.BattleData.NextAbilitySpellId = SpellsDefine.Sprint.Id;
            AIRoot.Instance.BattleData.NextAbilityUsePotion = false;
        }

        private void UsePotion_OnClick(object sender, RoutedEventArgs e)
        {
            AIRoot.Instance.BattleData.NextAbilityUsePotion = true;
        }
    }
}