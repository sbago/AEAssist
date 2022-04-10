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

        private bool _1500Action;

        public void Update()
        {
            if (!_start)
                return;
            var restTime = CountDown - (TimeHelper.Now() - _lastTime);
            var msg = $"{Language.Instance.Content_CoolDown} {restTime / 1000}秒";

            if (!_1500Action &&restTime <= SettingMgr.GetSetting<GeneralSettings>().UsePotionCountDown)
            {
                msg += $"->{Language.Instance.Content_CoolDown_1500}";
                _1500Action = true;
                RotationManager.Instance.HandleInCountDown1500();
            }

            if (restTime < 100)
            {
                msg = $"{Language.Instance.Content_CoolDownFinish}";
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
            _1500Action = false;
        }

        public void SyncRestTime(float restTime)
        {
        }

        public void Close()
        {
            _start = false;
            CanDoAction = false;
            _1500Action = false;
        }

        public void StartNow()
        {
            _start = false;
            CanDoAction = true;
            _1500Action = false;
        }
    }
}