using System;
using AEAssist.Helper;

namespace AEAssist.AI
{
    public class CountDownHandler
    {
        private const long CountDown = 5000;
        public static CountDownHandler Instance = new CountDownHandler();
        private long _lastTime;

        private bool _start;

        public bool CanDoAction { get; private set; }

        public void Update()
        {
            if (!_start)
                return;
            var restTime = CountDown - (TimeHelper.Now() - _lastTime);
            var msg = $"倒计时{restTime / 1000}秒 {restTime % 1000}";

            if (Math.Abs(restTime - SettingMgr.GetSetting<GeneralSettings>().UsePotionCountDown) < 100)
            {
                msg += "->尝试特殊行为-1500";
                RotationManager.Instance.HandleInCountDown1500();
            }

            if (restTime < 100)
            {
                msg = "倒计时结束 开始战斗!";
                CanDoAction = true;
                _start = false;
            }

            GUIHelper.ShowInfo(msg, 100, false);
        }

        public void StartCountDown()
        {
            GUIHelper.ShowInfo("倒计时准备开始");
            _lastTime = TimeHelper.Now();
            CanDoAction = false;
            _start = true;
        }

        public void SyncRestTime(float restTime)
        {
        }

        public void Close()
        {
            _start = false;
            CanDoAction = false;
        }

        public void StartNow()
        {
            _start = false;
            CanDoAction = true;
        }
    }
}