using System;
using System.Windows;
using System.Windows.Threading;

namespace AEAssist.View
{
    public static class UiRefresh
    {

        private static Action EmptyDelegate = delegate () { };


        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }

    public static class UIHelper
    {
        public static void RfreshCurrOverlay()
        {
            if (OverlayManager.Instance.lastOverlay == null)
                return;
            OverlayManager.Instance.lastOverlay.Control.Refresh();
        }
    }
}