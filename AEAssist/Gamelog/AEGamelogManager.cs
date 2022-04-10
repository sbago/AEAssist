using AEAssist.AI;
using ff14bot.Enums;
using ff14bot.Managers;
using QuickGraph.Collections;

namespace AEAssist.Gamelog
{
    public class AEGamelogManager
    {
        public static AEGamelogManager Instance = new AEGamelogManager();

        public readonly Queue<GameLog> GameLogBuffers =
            new Queue<GameLog>();

        // private HashSet<int> MuteType = new HashSet<int>()
        // {
        //     4139,4400,4777,4905,4398,10283,
        // }

        public void Init()
        {
            GamelogManager.MessageRecevied += MessageRecevied;
        }

        public void CheckLog()
        {
            while (GameLogBuffers.Count >= 20) GameLogBuffers.Dequeue();
        }

        private void AddBuffers(int msgType, string content)
        {
            if (msgType >= 10 && msgType < (int) MessageType.Echo)
                return;
            if (msgType > 1000)
                return;
            GameLogBuffers.Enqueue(new GameLog
            {
                MsgType = msgType,
                Content = content
            });
            if (SettingMgr.GetSetting<GeneralSettings>().ShowGameLog)
                LogHelper.Info($"GameLog==> MessageType:{msgType.ToString()} Content:{content}");
        }

        private void MessageRecevied(object sender, ChatEventArgs e)
        {
            AddBuffers((int) e.ChatLogEntry.MessageType, e.ChatLogEntry.Contents);
            if ((ushort) e.ChatLogEntry.MessageType == 185)
                if (e.ChatLogEntry.Contents.Contains(Language.Instance.MessageLog_CountDown_BattleStart))
                    GUIHelper.ShowInfo(e.ChatLogEntry.Contents, 1000, false);

            if (e.ChatLogEntry.MessageType == MessageType.SystemMessages)
            {
                if (e.ChatLogEntry.Contents.Contains(Language.Instance.MessageLog_CountDown_BattleStartIn5sec))
                {
                    CountDownHandler.Instance.StartCountDown();
                }
                else if (e.ChatLogEntry.Contents.Contains(Language.Instance.MessageLog_CountDown_CancelBattleStart))
                {
                    CountDownHandler.Instance.Close();
                    GUIHelper.ShowInfo(e.ChatLogEntry.Contents, 1000, false);
                }
            }
        }

        public void Close()
        {
            GamelogManager.MessageRecevied -= MessageRecevied;
        }

        public struct GameLog
        {
            public int MsgType;
            public string Content;
        }
    }
}