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
            if (!Spells.Bloodletter.IsReady())
                return false;
            if (Spells.Bloodletter.Charges >= Spells.Bloodletter.MaxCharges)
                return true;
            return false;
        }

        public async Task<SpellData> Run()
        {
            SpellData spellData = null;
            if (Spells.RainofDeath.IsReady() && TargetHelper.CheckNeedUseAOE(25, 8, ConstValue.BardAOECount))
            {
                spellData = Spells.RainofDeath;
                if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
                {
                    return spellData;
                }
            }

            spellData = Spells.Bloodletter;
            if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
            {
                return spellData;
            }

            return null;
        }
    }
}