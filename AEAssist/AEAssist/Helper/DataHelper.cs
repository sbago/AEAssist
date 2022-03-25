using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
            var assembly = Assembly.GetExecutingAssembly();

            const string bossFile = "Magitek.Resources.BossDictionary.json";

            string bosses;

            using (var stream = assembly.GetManifestResourceStream(bossFile))

            using (var reader = new StreamReader(stream))
            {
                bosses = reader.ReadToEnd();
            }

            BossDictionary = new Dictionary<uint, string>(JsonConvert.DeserializeObject<Dictionary<uint, string>>(bosses));

            LogHelper.Info("成功加载 Boss数据数目 " + BossDictionary.Count);
        }
            
        public static Dictionary<uint, string> BossDictionary;
        
        public static bool IsBoss(this GameObject unit)
        {
            return unit != null && (DataHelper.BossDictionary.ContainsKey(unit.NpcId) || unit.EnglishName.Contains("Dummy"));
        }
    }
}