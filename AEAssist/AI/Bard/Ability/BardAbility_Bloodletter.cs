using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_Bloodletter : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (lastSpell == Spells.Bloodletter)
                return false;
            if (!Spells.Bloodletter.IsChargeReady())
                return false;
            if (Spells.Bloodletter.Charges < 1)
                return false;
            
            // 起手爆发期间, 失血箭尽量打进团辅

            if (BardSpellHelper.HasBuffsCount() >= BardSpellHelper.UnlockBuffsCount())
                return true;

            if (BardSpellHelper.Prepare2BurstBuffs())
                return false;
            
            return true;
        }

        public async Task<SpellData> Run()
        {
            SpellData spellData = null;
            if (Spells.RainofDeath.IsChargeReady() && TargetHelper.CheckNeedUseAOE(25, 8, ConstValue.BardAOECount))
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