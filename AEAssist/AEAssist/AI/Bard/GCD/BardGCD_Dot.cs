using System;
using System.Threading.Tasks;
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
            
            if (TTKHelper.IsTargetTTK(tar))
                return false;
            int dots = 0;
            if (BardSpellEx.IsTargetHasAura_WindBite(tar))
            {
                dots++;
            }
            if (BardSpellEx.IsTargetHasAura_VenomousBite(tar))
            {
                dots++;
            }

            if (dots >= 2)
            {
                if (BardSpellEx.IsTargetNeedIronJaws(tar))
                    return true;
                return false;
            }
            
            return true;
        }

        public async Task<SpellData> Run()
        {
            SpellData spell = null;
            var target = Core.Me.CurrentTarget as Character;
            if (!BardSpellEx.IsTargetHasAura_WindBite(target))
            {
                spell = BardSpellEx.GetWindBite();
            }
            else if (!BardSpellEx.IsTargetHasAura_VenomousBite(target))
            {
                spell = BardSpellEx.GetVenomousBite();
            }
            else if (BardSpellEx.IsTargetNeedIronJaws(target))
            {
                spell = Spells.IronJaws;
            }

            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell,target);
            if (ret)
                return spell;
            return null;
        }
    }
}