using System;
using System.Threading.Tasks;
using AEAssist;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_Dot : IAIHandler
    {
        public int Check(SpellData lastSpell)
        {
            var tar = Core.Me.CurrentTarget as Character;
            if (!AEAssist.DataBinding.Instance.UseDot)
                return -1;
            if (TTKHelper.IsTargetTTK(tar))
                return -2;
            int dots = 0;
            if (BardSpellHelper.IsTargetHasAura_WindBite(tar))
            {
                dots++;
            }

            if (BardSpellHelper.IsTargetHasAura_VenomousBite(tar))
            {
                dots++;
            }

            if (dots >= 2)
            {
                if (BardSpellHelper.IsTargetNeedIronJaws(tar))
                    return 1;
                return -3;
            }

            return 0;
        }

        public async Task<SpellData> Run()
        {
            SpellData spell = null;
            var target = Core.Me.CurrentTarget as Character;
            if (!BardSpellHelper.IsTargetHasAura_WindBite(target))
            {
                spell = BardSpellHelper.GetWindBite();
            }
            else if (!BardSpellHelper.IsTargetHasAura_VenomousBite(target))
            {
                spell = BardSpellHelper.GetVenomousBite();
            }
            else if (BardSpellHelper.IsTargetNeedIronJaws(target))
            {
                spell = SpellsDefine.IronJaws;
            }

            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell, target);
            if (ret)
            {
                if (spell == SpellsDefine.IronJaws)
                {
                    BardSpellHelper.RecordIronJaw();
                }
                else
                {
                    BardSpellHelper.RemoveRecordIronJaw();
                }

                return spell;
            }

            return null;
        }
    }
}