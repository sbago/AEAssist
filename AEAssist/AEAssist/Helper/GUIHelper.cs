using System.Windows.Forms;

namespace AEAssist
{
    public static class GUIHelper
    {
        private static Form GUI = new GUI();
        
        public static void OpenGUI()
        {
            if (GUI == null || GUI.IsDisposed)
                GUI = new GUI();
            GUI.Show();
        }

        public static void Close()
        {
            GUI.Close();
        }
    }
}