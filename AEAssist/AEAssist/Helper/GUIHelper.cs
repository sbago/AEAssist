using System.Windows.Forms;

namespace AEAssist
{
    public static class GUIHelper
    {
        private static GUI GUI = new GUI();
        public static Overlay Overlay = new Overlay();
        
        public static void OpenGUI()
        {
            if (GUI == null || GUI.IsDisposed || GUI.Disposing)
                GUI = new GUI();
            GUI.Show();
        }

        public static void Close()
        {
            GUI.Close();
        }
        
        public static void OpenOverlay()
        {
            if (Overlay == null || Overlay.IsDisposed || Overlay.Disposing)
                Overlay = new Overlay();
            Overlay.Show();
        }
        
        public static void CloseOverlay()
        {
            Overlay.Close();
        }

        public static void ShowInfo(string msg)
        {
            Overlay.ShowDebug(msg);
        }
    }
}