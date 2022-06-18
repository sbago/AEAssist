using System;
using AEAssist.Helper;
using AEAssist.View;
using ff14bot;
using ff14bot.Objects;
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

        public int TargetDistance { get; set; } = 0;
        
        public System.Windows.Media.Brush IsPositionCorrectColor { get; set; } = System.Windows.Media.Brushes.Green;
        public System.Windows.Media.Brush IsTargetDistanceSafe { get; set; } = System.Windows.Media.Brushes.Green;
        
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
            UIHelper.RfreshCurrOverlay();
        }

        private void SetDistance(GameObject CurrentTarget)
        {
            var distanceF = TargetHelper.GetTargetDistanceFromMeTest(CurrentTarget, Core.Me);
            var distanceI = (int)Math.Round(distanceF*100);
            TargetDistance = distanceI;
            if (distanceI > 300)
            {
                TargetDistance = 300;
            }

            if (distanceI > 300)
            {
                IsTargetDistanceSafe = System.Windows.Media.Brushes.DarkRed;
            }
            else if (200 < distanceI)
            {
                IsTargetDistanceSafe = System.Windows.Media.Brushes.Coral;
            }
            else
            {
                IsTargetDistanceSafe = System.Windows.Media.Brushes.Green;
            }
            
            
        }
        
        public void ShowMsg()
        {
            if (Core.Me.HasTarget)
            {
                var CurrentTarget = Core.Me.CurrentTarget;
                SetDistance(CurrentTarget);
                if (CurrentTarget.IsBehind)
                {
                    CurrentPosition = Position.Back;
                }
                else if (CurrentTarget.IsFlanking)
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