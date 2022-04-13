using System;
using System.Collections.Generic;
using AEAssist.Helper;

namespace AEAssist.AI
{
    public class CountDownHandler
    {
        private long CountDown = 5000;
        public static CountDownHandler Instance = new CountDownHandler();
        private long _lastTime;

        public bool Start { get; private set; }

        public bool CanDoAction { get; private set; }

        private Dictionary<long, Action> CountDownActions = new Dictionary<long, Action>();

        private HashSet<long> HasDone = new HashSet<long>();

        public void Update()
        {
            if (!Start)
                return;
            var restTime = CountDown - (TimeHelper.Now() - _lastTime);
            var msg = $"{Language.Instance.Content_CoolDown} {restTime} ms";


            foreach (var v in CountDownActions)
            {
                if(HasDone.Contains(v.Key))
                    continue;
                if (restTime <= v.Key)
                {
                    this.HasDone.Add(v.Key);
                    try
                    {
                        LogHelper.Info("DoCountDownAction: "+ v.Key);
                        v.Value.Invoke();
                    }
                    catch (Exception e)
                    {
                        LogHelper.Error(e.ToString());
                    }
                }
            }
            
            if (restTime < 100)
            {
                msg = $"{Language.Instance.Content_CoolDownFinish}";
                CanDoAction = true;
                Start = false;
            }

            GUIHelper.ShowInfo(msg, 100, false);
        }

        public void StartCountDown()
        {
            GUIHelper.ShowInfo("倒计时准备开始");
            _lastTime = TimeHelper.Now();
            CanDoAction = false;
            Start = true;
            HasDone.Clear();
        }

        public void SyncRestTime(int restTime)
        {
            if (!Start)
            {
                CountDown = restTime * 1000;
                StartCountDown();
            }
        }

        public void Close()
        {
            Start = false;
            CanDoAction = false;
            HasDone.Clear();
        }

        public void StartNow()
        {
            Start = false;
            CanDoAction = true;
            HasDone.Clear();
        }

        public void AddListener(int timeLeft, Action action, bool clearPre = true)
        {
            if(clearPre)
                this.CountDownActions.Clear();
            this.CountDownActions[timeLeft] = action;
        }
    }
}