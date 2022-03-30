using System.Threading.Tasks;
using AEAssist.DataBinding;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardGCD_ApexArrow : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (!BaseSettings.Instance.UseApex)
                return false;
            if (ActionResourceManager.Bard.SoulVoice >= SettingMgr.GetSetting<BardSettings>().ApexArrowValue)
                return true;

            if (ActionResourceManager.Bard.SoulVoice >= 80 &&
                (BardSpellHelper.HasBuffsCountInEnd() >= 1 || TargetHelper.CheckNeedUseAOE(ConstValue.BardAOETargetRange,
                    2, ConstValue.BardAOECount)))
            {
                return true;
            }

            return false;
        }

        public async Task<SpellData> Run()
        {
            var spell = Spells.ApexArrow;
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastGCD(spell, Core.Me.CurrentTarget);
            if (ret)
                return spell;
            return null;
        }
    }
}