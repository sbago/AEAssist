using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper
{
    public class ReaperAbility_Lemure : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.LemuresSlice.IsUnlock())
                return -1;
            if (ActionResourceManager.Reaper.VoidShroud < 2)
                return -2;
            if (!Core.Me.HasAura(AurasDefine.Enshrouded))
                return -3;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.LemuresSlice;
            if (TargetHelper.CheckNeedUseAOE(8, 8)) spell = SpellsDefine.LemuresScythe;

            if (await spell.DoAbility())
            {
                AIRoot.Instance.MuteAbilityTime();
                return spell;
            }

            return null;
        }
    }
}