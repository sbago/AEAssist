// -----------------------------------
//  Copyright(C) kuro Co.Ltd
// 
//  模块说明：
// 
//  创建人员：luzongren
//  创建日期：2022-05-20
// -----------------------------------

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AETriggers
{
    public partial class ChooseTriggerWindow : Window
    {
        public class TestData
        {
            public string Name { get; set; }
            
        }
        public ChooseTriggerWindow()
        {
            InitializeComponent();
            
            var list1 = new List<TestData>()
            {
                new TestData() {Name = "Cond 1111111"},
                new TestData() {Name = "Cond 222222"},
                new TestData() {Name = "Cond 333333333"},
            };
            
            var list2 = new List<TestData>()
            {
                new TestData() {Name = "Action 11111"},
                new TestData() {Name = "Action 2222"},
                new TestData() {Name = "Action 333"},
            };

            
            CondTreeViews.ItemsSource = list1;
            ActionTreeViews.ItemsSource = list2;

         //   this.ChooseTriggerTreeView.Visibility = Visibility.Hidden;
        }

        private void TreeViewBtnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            MessageBox.Show(button.Content.ToString());
            this.Hide();
        }
        
        public void Show(Point mousePos)
        {
            this.Show();
            this.Top = mousePos.Y;
            this.Left = mousePos.X;
            // Canvas.SetTop(this.ChooseTriggerTreeView,mousePos.Y);
            // Canvas.SetLeft(this.ChooseTriggerTreeView,mousePos.X);
        }


    }
}