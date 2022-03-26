using System;
using AEAssist.Helper;

namespace AEAssist.AI
{
    public class CountDownHandler
    {
        public static CountDownHandler Instance = new CountDownHandler();

        private bool _start;
        private long _lastTime;

        private const long CountDown = 5000;

        public bool CanDoAction { get; private set; }

        public void Update()
        {
            if (!_start)
                return;
            var restTime = CountDown - (TimeHelper.Now() - _lastTime);
            if (Math.Abs(restTime - 2000) < 100)
            {
                LogHelper.Info("倒计时2秒 准备使用爆发药!");
                //todo: 准备使用爆发药了
            }

            if (restTime < 100)
            {
                LogHelper.Info("倒计时结束 开始战斗!");
                CanDoAction = true;
                _start = false;
            }
        }

        public void StartCountDown()
        {
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