using System;
using System.Windows;
using System.Windows.Threading;
using AEAssist.Helper;

namespace AEAssist.View
{
    public static class UiRefresh
    {
        private static readonly Action EmptyDelegate = delegate { };


        public static void Refresh(this UIElement uiElement)
        {
            try
            {
                uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
            }
            catch (Exception)
            {
                
            }
        }
    }

    public static class UIHelper
    {
        public static void RfreshCurrOverlay()
        {
            if (OverlayManager.OverlayManager.Instance.lastOverlay == null)
                return;
            foreach (var v in OverlayManager.OverlayManager.Instance.lastOverlay)
            {
                v.Control.Refresh();
            }
        }
    }
}