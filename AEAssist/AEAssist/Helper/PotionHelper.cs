using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using AEAssist.AI;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace AEAssist.Helper
{
    internal class PotionHelper
    {

        public static readonly HashSet<uint> Str = new HashSet<uint>
        {
            36104, // 5级 刚力幻药
        };

        public static readonly HashSet<uint> Dex = new HashSet<uint>
        {
            36105, // 5级 巧力幻药
        };

        public static readonly HashSet<uint> Int = new HashSet<uint>
        {
            36107, // 5级 智力幻药
        };
        
        
        internal static async Task<bool> UsePotion(int potionRawId)
        {
            if (!GeneralSettings.Instance.UsePotion)
                return false;
            if (AIRoot.Instance.CloseBuff)
                return false;
            var item = InventoryManager.FilledSlots.FirstOrDefault(s => s.RawItemId == potionRawId);

            if (item == null || !item.CanUse()) return false;

            item.UseItem(); 
            await Coroutine.Wait(1000, () => !item.CanUse());
            LogHelper.Info($@"[AEAssist] Using >>> {item.Name} {item.Item.ChnName}");
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