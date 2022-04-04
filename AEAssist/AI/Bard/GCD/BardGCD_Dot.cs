using System;
using System.Threading.Tasks;
using AEAssist.DataBinding;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_Dot : IAIHandler
    {
        
        public bool Check(SpellData lastSpell)
        {
            var tar = Core.Me.CurrentTarget as Character;
            if (!BaseSettings.Instance.UseDot)
                return false;
            if (TTKHelper.IsTargetTTK(tar))
                return false;
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
                    return true;
                return false;
            }
            
            return true;
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
            var ret = await SpellHelper.CastGCD(spell,target);
            if (ret)
            {
                if (spell == SpellsDefine.IronJaws)
                {
                    BardSpellHelper.RecordIronJaw();
                }

                return spell;
            }

            return null;
        }
    }
}