using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AEAssist.AI;
using AEAssist.Define;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.Helper
{
    internal class PotionHelper
    {
        public static List<PotionData> DexPotions { get; set; } = new List<PotionData>();
        public static List<PotionData> StrPotions { get; set; } = new List<PotionData>();

        public string GetPotionName()
        {
            return DexPotions.FindLast(v => v.ID == SettingMgr.GetSetting<BardSettings>().UsePotionId).Name;
        }

        public static void Init()
        {
            if (DexPotions == null)
                DexPotions = new List<PotionData>();
            DexPotions.Clear();
            DexPotions.Add(new PotionData
            {
                ID = 36105,
                Name = "5级巧力之幻药"
            });

            DexPotions.Add(new PotionData
            {
                ID = 31894,
                Name = "4级巧力之幻药"
            });

            DexPotions.Add(new PotionData
            {
                ID = 29493,
                Name = "3级巧力之幻药"
            });


            if (StrPotions == null)
                StrPotions = new List<PotionData>();
            StrPotions.Add(new PotionData
            {
                ID = 36104,
                Name = "5级刚力之幻药"
            });
            StrPotions.Add(new PotionData
            {
                ID = 31893,
                Name = "4级刚力之幻药"
            });
            StrPotions.Add(new PotionData
            {
                ID = 29492,
                Name = "3级刚力之幻药"
            });
        }

        public static async Task<bool> UsePotion(int potionRawId)
        {
            if (!SettingMgr.GetSetting<GeneralSettings>().UsePotion)
                return false;
            if (AIRoot.Instance.CloseBuff)
                return false;
            if (TTKHelper.IsTargetTTK(Core.Me.CurrentTarget as Character))
                return false;
            return await ForceUsePotion(potionRawId);
        }

        public static async Task<bool> ForceUsePotion(int potionRawId)
        {
            var item = InventoryManager.FilledSlots.FirstOrDefault(s => s.RawItemId == potionRawId);
            if (item == null)
                return false;
            if (!item.CanUse(Core.Me)) return false;
            LogHelper.Info($@"Using Item >>> {item.Name}");
            for (var i = 0; i < 15; i++)
            {
                item.UseItem(Core.Me);
                await Coroutine.Sleep(100);
                if (item == null || !item.CanUse())
                    return true;
            }

            return false;
        }

        internal static bool CheckPotion(int potionRawId)
        {
            var item = InventoryManager.FilledSlots.FirstOrDefault(s => s.RawItemId == potionRawId);

            if (item == null || !item.CanUse(Core.Me)) return false;

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
            var num = 0;
            foreach (var v in InventoryManager.FilledSlots)
                if (v.RawItemId == potionId)
                    num = (int) (num + v.Item.ItemCount());

            return num;
        }
    }
}