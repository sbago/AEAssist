using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace AEAssist
{
    public class SettingMgr
    {
        public static SettingMgr Instance = new SettingMgr();

        private Dictionary<Type, IBaseSetting> AllSetting = new Dictionary<Type, IBaseSetting>();

        private HashSet<Type> AllSettingsType = new HashSet<Type>();

        readonly string SettingPath =  @"Settings\AEAssists";
        public SettingMgr()
        {
            var baseType = typeof(IBaseSetting);
            foreach (var type in this.GetType().Assembly.GetTypes())
            {
                if(type.IsAbstract || type.IsInterface)
                    continue;
                if(!baseType.IsAssignableFrom(type))
                    continue;
                AllSettingsType.Add(type);

            }
            
            
            Directory.CreateDirectory(SettingPath);
            var versionSetting =  LoadSetting(typeof(VersionSetting)) as VersionSetting;
            if (versionSetting == null || versionSetting.SettingVersion != ConstValue.SettingVersion)
            {
                Reset();
                GUIHelper.ShowMessageBox("本地配置版本较低,已重置为新版本默认值");
                return;
            }

            foreach (var v in AllSettingsType)
            {
                var setting = LoadSetting(v);
                if (setting == null)
                {
                    setting = Activator.CreateInstance(v);
                }

                AllSetting[v] = setting as IBaseSetting;
            }
        }
        
        object LoadSetting(Type type)
        {
            var generalSettingFile =  $"{SettingPath}/{type.Name}.json";
            
            if (File.Exists(generalSettingFile))
            {
                try
                {
                    var generalSetting =
                        JsonConvert.DeserializeObject(File.ReadAllText(generalSettingFile),type);
                    LogHelper.Info("Loaded Setting: " + type.Name);
                    return generalSetting;
                }
                catch (Exception e)
                {
                    LogHelper.Error(e.ToString());
                }
              
            }

            return null;
        }
        
        void SaveSetting(object obj)
        {
            var type = obj.GetType();
            var generalSettingFile =  $"{SettingPath}/{type.Name}.json";
            File.WriteAllText(generalSettingFile,JsonConvert.SerializeObject(obj));
        }


        public void InitSetting()
        {

        }

        public void Reset()
        {
            AllSetting.Clear();

            VersionSetting versionSetting = new VersionSetting();
            SaveSetting(versionSetting);
            
            foreach (var v in AllSettingsType)
            {
                var setting = Activator.CreateInstance(v);

                AllSetting[v] = setting as IBaseSetting;
                AllSetting[v].Reset();
                
                SaveSetting(setting);
            }
        }

        public static T GetSetting<T>() where T : class, IBaseSetting,new()
        {
            var type = typeof(T);
            SettingMgr.Instance.AllSetting.TryGetValue(type, out var value);
            return value as T;
        }

        public void Save()
        {
            foreach (var v in AllSetting)
            {
                SaveSetting(v.Value);
            }
        }
        
        
    }
}