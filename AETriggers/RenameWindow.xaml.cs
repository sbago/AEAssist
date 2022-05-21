using System;
using System.Windows;

namespace AETriggers
{
    public partial class RenameWindow : Window
    {
        public RenameWindow()
        {
            InitializeComponent();
        }

        private Action<string> _action;
        public void Display(Point point, Action<string> action)
        {
            _action = action;
            this.Top = point.Y;
            this.Left = point.X;
            this.Show();
        }

        private void Confirm_OnClick(object sender, RoutedEventArgs e)
        {
            _action?.Invoke(Name.Text);
           this.Hide();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}