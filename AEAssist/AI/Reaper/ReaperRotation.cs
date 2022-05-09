using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot;
using ff14bot.Enums;
using Language = AEAssist.Language;

namespace AEAssist.AI.Reaper
{
    [Job(ClassJobType.Reaper)]
    public class ReaperRotation : IRotation
    {
        private readonly AIRoot AiRoot = AIRoot.Instance;
        private long _lastTime;

        private long randomTime;

        public void Init()
        {
            CountDownHandler.Instance.AddListener(1500, () =>
            {
                if (Core.Me.HasTarget && Core.Me.CurrentTarget.CanAttack)
                    return SpellsDefine.Harpe.DoGCD();
                return Task.FromResult(false);
            });
            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<ReaperSettings>().EarlyDecisionMode;
            LogHelper.Info("EarlyDecisionMode: " + AEAssist.DataBinding.Instance.EarlyDecisionMode);
        }

        public async Task<bool> PreCombatBuff()
        {
            if (Core.Me.HasAura(AurasDefine.Soulsow))
                return true;
            if (await SpellsDefine.Soulsow.DoGCD())
            {
                GUIHelper.ShowInfo(Language.Instance.Content_Reaper_PreCombat2, 500, false);
                randomTime = 0;
                return true;
            }

            return false;
        }

        public SpellEntity GetBaseGCDSpell()
        {
            return SpellsDefine.Slice.GetSpellEntity();
        }
    }
}