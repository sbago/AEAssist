using System.Windows;
using System.Windows.Forms;
using AEAssist.DataBinding;
using AEAssist.Helper;
using MessageBox = System.Windows.MessageBox;

namespace AEAssist
{
    public static class GUIHelper
    {
        public static void OpenGUI()
        {
            // if (GUI == null || GUI.IsDisposed || GUI.Disposing)
            //     GUI = new GUI();
            // GUI.Show();
        }

        public static void Close()
        {
           // GUI.Close();
        }

        private static long targetShowTime;
        public static void ShowInfo(string msg,int time = 0,bool check = true)
        {
            if (check &&  TimeHelper.Now() < targetShowTime)
                return;
            if (time > 0)
                targetShowTime = TimeHelper.Now() + time;
            DebugCenter.Intance.ShowMsg(msg);
        }

        public static void ShowMessageBox(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}