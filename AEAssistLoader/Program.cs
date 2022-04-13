using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AEAssist
{
    public static class Program
    {
        public static void Main(string[] args)
        { 
            var path = $"Lan_" + Language.Instance.LanType + ".json";
            File.WriteAllText(path,MongoHelper.ToJson(Language.Instance));
        }
    }
}