using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace AEAssist.AI.BlackMage.GCD
{
    public class BlackMageGCD_Fire4 : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var minmana = 1600;
            if (SpellsDefine.Despair.IsUnlock())
            {
                minmana = 2400;
            }
            
            if (!SpellsDefine.Fire4.IsUnlock())
            {
                if (ActionResourceManager.BlackMage.AstralStacks > 0 && ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 5000)
                {
                    return 3;
                }
            }
            
            if (Core.Me.CurrentMana >= minmana &&
                BlackMageHelper.IsMaxAstralStacks(lastSpell))
            {
                // not sure what numbders excatly to put here
                if (Core.Me.HasAura(AurasDefine.LeyLines) && ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 4500)
                {
                    return 1;
                }
                if (ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 5000)
                {
                    return 2;
                }
            }
            
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = BlackMageHelper.GetFire4();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}