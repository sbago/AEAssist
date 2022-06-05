using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;


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
            AEAssist.View.OverlayManager.OverlayManager.Instance.RefreshOverlay();
        }

        private static bool hasDown = false;
        
        public static void SetToolTipDuration(int time = 60000)
        {
            if (hasDown)
                return;
            hasDown = true;
            ToolTipService.ShowDurationProperty.OverrideMetadata(typeof(DependencyObject),new FrameworkPropertyMetadata((object) time));
        }
    }
}