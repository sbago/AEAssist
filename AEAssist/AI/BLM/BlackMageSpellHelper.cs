using AEAssist.Define;
using AEAssist.Define.DataStruct;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.BLM
{


    public static class BlackMageHelper
    {
        public static bool CanCastFire4()
        {
            if (Core.Me.CurrentMana >= 2400 &&
                ActionResourceManager.BlackMage.AstralStacks == 3)
            {
                // not sure what numbders excatly to put here
                if (Core.Me.HasAura(AurasDefine.LeyLines) && ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 4500)
                {
                    return true;
                }
                else if (ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 5000)
                {
                    return true;
                }
            }

            return false;
        }
        public static ushort PolyglotTimer => ActionResourceManager.CostTypesStruct.timer;
        public static bool IsTargetHasThunder(Character target)
        {
            var id = AurasDefine.Thunder3;
            if (id == 0)
                return true; 

            return target.ContainMyAura((uint) id);
        }

        public static bool IsTargetNeedThunder(Character target, int timeLeft)
        {
            var id = AurasDefine.Thunder3;
            if (id == 0)
                return true; 
            
            if (!IsTargetHasThunder(target))
            {
                return true;
            }
            // if not enough time left
            if (!target.ContainMyAura((uint) id, timeLeft))
            {
                return true;
            }

            return false;
        }

        public static bool IsParadoxReady()
        {
            var spell = SpellsDefine.Paradox.GetSpellEntity().SpellData;
            if (ActionManager.CanCastOrQueue(spell, Core.Me.CurrentTarget))
            {
                return true;
            }
            return false;
        }

        public static bool IsGCDOpen(SpellEntity lastSpell)
        {
            if (Core.Me.HasAura(AurasDefine.Triplecast))
            {
                return true;
            }

            if (lastSpell == SpellsDefine.Fire3.GetSpellEntity() ||
                lastSpell == SpellsDefine.Blizzard3.GetSpellEntity())
            {
                return true;
            }
            return false;
        }

    }
}