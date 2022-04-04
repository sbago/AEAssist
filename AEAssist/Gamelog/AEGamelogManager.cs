using System;
using AEAssist.AI;
using AEAssist;
using ff14bot.Enums;
using ff14bot.Managers;
using QuickGraph.Collections;

namespace AEAssist.Gamelog
{
    public class AEGamelogManager
    {
        public static AEGamelogManager Instance = new AEGamelogManager();
        
        public struct GameLog
        {
            public int MsgType;
            public string Content;
        }

        public readonly Queue<GameLog> GameLogBuffers = new Queue<GameLog>();

        public void Init()
        {
            GamelogManager.MessageRecevied += MessageRecevied;
        }

        void AddBuffers(int msgType, string content)
        {
            if (msgType >= 10 && msgType < (int) MessageType.Echo)
                return;
            GameLogBuffers.Enqueue(new GameLog
            {
                MsgType = msgType,
                Content = content
            });
            LogHelper.Debug($"GameLog==> MessageType:{msgType.ToString()} Content:{content}");
            if (this.GameLogBuffers.Count >= 15)
                this.GameLogBuffers.Dequeue();
        }

        private void MessageRecevied(object sender, ChatEventArgs e)
        {
            AddBuffers((int) e.ChatLogEntry.MessageType, e.ChatLogEntry.Contents);
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