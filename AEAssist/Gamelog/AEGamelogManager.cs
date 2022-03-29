using System;
using AEAssist.AI;
using AEAssist.DataBinding;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.Gamelog
{
    public class AEGamelogManager
    {
        public static AEGamelogManager Instance = new AEGamelogManager();

        public void Init()
        {
            GamelogManager.MessageRecevied += MessageRecevied;
        }

        private void MessageRecevied(object sender, ChatEventArgs e)
        {
            //LogHelper.Debug($"{e.ChatLogEntry.MessageType} {e.ChatLogEntry.Contents}");
            if ((ushort)e.ChatLogEntry.MessageType == 185)
            {
                if (e.ChatLogEntry.Contents.Contains("战斗开始"))
                {
                    GUIHelper.ShowInfo(e.ChatLogEntry.Contents,1000,false);
                }
            }
            if (e.ChatLogEntry.MessageType == MessageType.SystemMessages)
            {
                if (e.ChatLogEntry.Contents.Contains("距离战斗开始还有5秒"))
                {
                    CountDownHandler.Instance.StartCountDown();
                }
                else if (e.ChatLogEntry.Contents.Contains("距离战斗开始"))
                {
                    GUIHelper.ShowInfo(e.ChatLogEntry.Contents,1000,false);
                }
                else if (e.ChatLogEntry.Contents.Contains("取消了战斗开始"))
                {
                    CountDownHandler.Instance.Close();
                    GUIHelper.ShowInfo(e.ChatLogEntry.Contents,1000,false);
                }
            }   
        }

        public void Close()
        {
            GamelogManager.MessageRecevied -= MessageRecevied;
        }
    }
}