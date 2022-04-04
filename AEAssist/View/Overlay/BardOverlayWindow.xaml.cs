using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AEAssist.DataBinding;
using AEAssist.Define;
using ff14bot.Managers;

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

        private void BardOverlayWindow_OnGotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        // private void ChooseNextSong_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        // {
        //     BaseSettings.Instance.nextSong = (ActionResourceManager.Bard.BardSong) ChooseNextSong.SelectedValue;
        // }

        private void ChangeTriggerLine_OnClick(object sender, RoutedEventArgs e)
        {
            Entry.TriggerLineWindow.OnTriggerLineLoad = 
                s =>
                this.CurrTriggerLine.Content = $"当前加载时间轴: {s}";
            
            Entry.TriggerLineWindow.OnTriggerLineClear=()=>
                this.CurrTriggerLine.Content="当前加载时间轴: 无";
            
            Entry.TriggerLineWindow.Show();
        }

        private void Reset_OnClick(object sender, RoutedEventArgs e)
        {
            BaseSettings.Instance.Reset();
        }
    }
}