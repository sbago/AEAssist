using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using AEAssist.AI;
using AEAssist.Define;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.Helper
{
    internal class PotionHelper
    {
        public static List<PotionData> AllPotions { get; set; } = new List<PotionData>();

        public string GetPotionName()
        {
            return AllPotions.FindLast(v=>v.ID == SettingMgr.GetSetting<BardSettings>().UsePotionId).Name;
        }
        public static void Init()
        {
            if (AllPotions == null)
                AllPotions = new List<PotionData>();
            AllPotions.Clear();
            AllPotions.Add(new PotionData()
            {
                ID = 36105,
                Name = "5级巧力之幻药"
            });
            
            AllPotions.Add(new PotionData()
            {
                ID = 31894,
                Name = "4级巧力之幻药"
            });
            
            AllPotions.Add(new PotionData()
            {
                ID = 29493,
                Name = "3级巧力之幻药"
            });
            
            AllPotions.Add(new PotionData()
            {
                ID = 27996,
                Name = "2级巧力之幻药"
            });
            
            AllPotions.Add(new PotionData()
            {
                ID = 27787,
                Name = "巧力之幻药"
            });
        }
        
        
        internal static async Task<bool> UsePotion(int potionRawId)
        {
            if (!SettingMgr.GetSetting<GeneralSettings>().UsePotion)
                return false;
            if (AIRoot.Instance.CloseBuff)
                return false;
            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return false;
            var item = InventoryManager.FilledSlots.FirstOrDefault(s => s.RawItemId == potionRawId);

            if (item == null || !item.CanUse()) return false;

            item.UseItem(); 
            await Coroutine.Wait(1000, () => !item.CanUse());
            LogHelper.Info($@"Using Item >>> {item.Name}");
            return true;
        }
        
        internal static bool CheckPotion(int potionRawId)
        {
            var item = InventoryManager.FilledSlots.FirstOrDefault(s => s.RawItemId == potionRawId);

            if (item == null || !item.CanUse()) return false;

            return true;
        }

        // public static void DebugAllItems()
        // {
        //     foreach (var v in InventoryManager.FilledSlots)
        //     {
        //         LogHelper.Info($"道具 {v.RawItemId} {v.Name} {v.Item.ChnName}");
        //     }
        // }
        
        public static int CheckNum(int potionId)
        {
            int num = 0;
            foreach (var v in InventoryManager.FilledSlots)
            {
                if (v.RawItemId == potionId)
                    num = (int) (num + v.Item.ItemCount());
            }

            return num;
        }
    }
}