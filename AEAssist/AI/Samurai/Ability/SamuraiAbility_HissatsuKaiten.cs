using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_HissatsuKaiten : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (Core.Me.HasMyAura(AurasDefine.Kaiten))
                return -99;
            var Ta=Core.Me.CurrentTarget as Character;
            var sen = SamuraiSpellHelper.SenCounts();
            if (sen == 1 && Ta.HasMyAura(AurasDefine.Higanbana) && Ta.GetAuraById(AurasDefine.Higanbana).TimespanLeft.TotalMilliseconds < 4000)
                return 1;

            if (sen == 3)
            {
                if (DataManager.GetSpellData(SpellsDefine.KaeshiSetsugekka).Cooldown.TotalMilliseconds > 64000 &&
                    DataManager.GetSpellData(SpellsDefine.KaeshiSetsugekka).Cooldown.TotalMilliseconds < 66000)
                    return -1;
                return 2;
            }

            if (Core.Me.HasMyAura(AurasDefine.OgiReady))
            {
                if (DataManager.GetSpellData(SpellsDefine.KaeshiSetsugekka).Cooldown.TotalMilliseconds < 70000)
                    return -2;
                if (SamuraiSpellHelper.SenCounts() == 0 && Ta.GetAuraById(AurasDefine.Higanbana).TimespanLeft.TotalMilliseconds < 11000)
                    return -3;
                return 3;
            }
            return -10;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.HissatsuKaiten;
            if (await spell.DoAbility())
                return spell.GetSpellEntity();
            return null;
        }
    }
}