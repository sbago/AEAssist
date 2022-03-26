using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AEAssist.Define;
using ff14bot.Objects;
using Newtonsoft.Json;

namespace AEAssist.Helper
{
    internal static class DataHelper
    {
        public static void Init()
        {
        }

        
        static readonly string SettingPath =  @"Settings\AEAssists";
        
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
            
            Directory.CreateDirectory(SettingPath);
            
            GeneralSettings.Instance = LoadSetting(GeneralSettings.Instance);
            BardSettings.Instance = LoadSetting(BardSettings.Instance);

        }

        static T LoadSetting<T>(T defaultObj) where  T: class
        {
            var type = typeof(T);
            var generalSettingFile =  $"{SettingPath}/{type.Name}.json";

            void Wirte()
            {
                File.WriteAllText(generalSettingFile,JsonConvert.SerializeObject(defaultObj));
            }

            if (!File.Exists(generalSettingFile))
            {
                Wirte();
            }
            else
            {
                try
                {
                    var generalSetting =
                        JsonConvert.DeserializeObject<T>(File.ReadAllText(generalSettingFile));
                    LogHelper.Info("Loaded Setting: " + type.Name);
                    return generalSetting;
                }
                catch (Exception e)
                {
                    Wirte();
                    LogHelper.Error(e.ToString());
                }
              
            }

            return defaultObj;
        }

        public static void Save()
        {
            SaveSetting(GeneralSettings.Instance);
            SaveSetting(BardSettings.Instance);
            LogHelper.Info("Save Settings!");
        }

        static void SaveSetting<T>(T obj) where T : class
        {
            var type = typeof(T);
            var generalSettingFile =  $"{SettingPath}/{type.Name}.json";
            File.WriteAllText(generalSettingFile,JsonConvert.SerializeObject(obj));
        }


        public static Dictionary<uint, string> BossDictionary;
        
        public static bool IsBoss(this GameObject unit)
        {
            return unit != null && (DataHelper.BossDictionary.ContainsKey(unit.NpcId) || unit.EnglishName.Contains("Dummy"));
        }
    }
}