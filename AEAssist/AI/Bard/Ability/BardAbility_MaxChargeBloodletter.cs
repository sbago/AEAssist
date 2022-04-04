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
            if (lastSpell == SpellsDefine.Bloodletter)
                return false;
            if (!SpellsDefine.Bloodletter.IsReady())
                return false;
            if (SpellsDefine.Bloodletter.Charges >= SpellsDefine.Bloodletter.MaxCharges)
                return true;
            return false;
        }

        public async Task<SpellData> Run()
        {
            SpellData spellData = null;
            if (SpellsDefine.RainofDeath.IsReady() && TargetHelper.CheckNeedUseAOE(25, 8, ConstValue.BardAOECount))
            {
                spellData = SpellsDefine.RainofDeath;
                if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
                {
                    return spellData;
                }
            }

            spellData = SpellsDefine.Bloodletter;
            if (await SpellHelper.CastAbility(spellData, Core.Me.CurrentTarget))
            {
                return spellData;
            }

            return null;
        }
    }
}