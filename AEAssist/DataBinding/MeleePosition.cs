using System;
using AEAssist.View;
using ff14bot;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class MeleePosition
    {
        public static MeleePosition Intance = new MeleePosition();

        public enum Position
        {
            Back,
            Side,
            None
        }
        public Position CurrentPosition { get; set; } = Position.None;
        public Position RequiredPosition { get; set; } = Position.None;
        public String RequiredPositionString { get; set; } = "";
        public bool IsPositionCorrect { get; set; } = true;
        public System.Windows.Media.Brush IsPositionCorrectColor { get; set; } = System.Windows.Media.Brushes.DarkSeaGreen;
        
        public void SetString()
        {
            switch (RequiredPosition)
            {
                case Position.Back:
                    RequiredPositionString = "▲▲▲";
                    break;
                case Position.Side:
                    RequiredPositionString = "▶◎◀";
                    break;
                default:
                    RequiredPositionString = "◎";
                    break;
            }
            switch (IsPositionCorrect)
            {
                case false:
                    IsPositionCorrectColor = System.Windows.Media.Brushes.DarkRed;
                    break;
                default:
                    IsPositionCorrectColor = System.Windows.Media.Brushes.Green;
                    break;
            }
        }
        public void ShowMsg()
        {
            if (Core.Me.HasTarget)
            {
                if (Core.Me.CurrentTarget.IsBehind)
                {
                    CurrentPosition = Position.Back;
                }
                else if (Core.Me.CurrentTarget.IsFlanking)
                {
                    CurrentPosition = Position.Side;
                }
                else
                {
                    CurrentPosition = Position.None;
                }
                if (RequiredPosition != Position.None && CurrentPosition != RequiredPosition)
                {
                    IsPositionCorrect = false;
                }
                else
                {
                    IsPositionCorrect = true;
                }
                SetString();
            }
            // if (!check)
            //     UIHelper.RfreshCurrOverlay();
        }
    }
}