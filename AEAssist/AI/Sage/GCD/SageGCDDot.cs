using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Sage.GCD
{
    public class SageGCDDot : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var tar = Core.Me.CurrentTarget as Character;
            if (!AEAssist.DataBinding.Instance.UseDot)
                return -1;
            if (TTKHelper.IsTargetTTK(tar))
                return -2;

            if (DotBlacklistHelper.IsBlackList(Core.Me.CurrentTarget as Character))
                return -10;

            var dots = 0;
            if (SageSpellHelper.IsTargetHasAuraEukrasianDosis(tar)) dots++;
            if (dots < 1) return 0;
            var timeLeft = SettingMgr.GetSetting<SageSettings>().Dot_TimeLeft;
            if (SageSpellHelper.IsTargetNeedEukrasianDosis(tar, timeLeft)) return 1;
            return -3;

        }

        public async Task<SpellEntity> Run()
        {
            SpellEntity spell = null;
            var timeLeft = SettingMgr.GetSetting<SageSettings>().Dot_TimeLeft;
            var target = Core.Me.CurrentTarget as Character;
            if (!Core.Me.ContainMyAura(AurasDefine.Eukrasia))
            { 
                return AIRoot.GetBattleData<BattleData>().NextGcdSpellId = SpellsDefine.Eukrasia.GetSpellEntity();
            }
            if (!SageSpellHelper.IsTargetHasAuraEukrasianDosis(target))
                spell = SageSpellHelper.GetEukrasianDosis();
            else if (SageSpellHelper.IsTargetNeedEukrasianDosis(target, timeLeft))
                spell = SageSpellHelper.GetEukrasianDosis();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            return ret ? spell : null;
        }
    }
}