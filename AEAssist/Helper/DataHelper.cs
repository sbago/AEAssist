using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AEAssist.Define;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using Newtonsoft.Json;

namespace AEAssist.Helper
{
    internal static class DataHelper
    {
        public static void Init()
        {
        }
        
        
        static DataHelper()
        {
            var bossFile = @"Routines\AEAssist\Resources\BossDictionary.json";
            
             var bosses = File.ReadAllText(bossFile);
             try
             {
                 BossDictionary = new Dictionary<uint, string>(JsonConvert.DeserializeObject<Dictionary<uint, string>>(bosses));
             }
             catch (Exception e)
             {
                LogHelper.Error(e.ToString());
                BossDictionary = new Dictionary<uint, string>();
             }
          

            LogHelper.Info("成功加载 Boss数据数目 " + BossDictionary?.Count);

        }
        
        public static Dictionary<uint, string> BossDictionary;
        
        public static bool IsBoss(this GameObject unit)
        {
            return unit != null && (DataHelper.BossDictionary.ContainsKey(unit.NpcId) || unit.EnglishName.Contains("Dummy"));
        }
    }
}