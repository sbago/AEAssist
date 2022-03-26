using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_MaxChargeBloodletter : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (lastSpell == Spells.Bloodletter)
                return false;
            if (Math.Abs(Spells.Bloodletter.Charges - Spells.Bloodletter.MaxCharges) < 0.1f)
                return true;
            return false;
        }

        public async Task<SpellData> Run()
        {
            var spellData = Spells.Bloodletter;
            if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
            {
                return spellData;
            }

            return null;
        }
    }
}