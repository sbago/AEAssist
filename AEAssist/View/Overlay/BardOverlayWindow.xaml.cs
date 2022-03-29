using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AEAssist.View
{
    public partial class BardOverlayWindow : Window
    {
        public BardOverlayWindow()
        {
            InitializeComponent();
        }
        
        private void BardOverlayWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}