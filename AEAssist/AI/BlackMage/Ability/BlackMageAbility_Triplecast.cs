using System;
using System.Threading.Tasks;
using AEAssist.AI.BlackMage;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.BlackMage.Ability
{
    public class BlackMageAblity_Triplecast : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Triplecast.IsUnlock())
            {
                return -1;
            }
            if (!SpellsDefine.Triplecast.IsReady())
            {
                return -1;
            }

            if (Core.Me.HasAura(AurasDefine.Triplecast))
            {
                return -3;
            }
            var BattleData = AIRoot.GetBattleData<BattleData>();
            if (BlackMageHelper.UmbralHeatsReady() &&
                BattleData.lastGCDSpell == SpellsDefine.Fire3.GetSpellEntity() &&
                SpellsDefine.Triplecast.GetSpellEntity().SpellData.Cooldown < TimeSpan.FromSeconds(15))
            {
                return 1;
            }
            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Triplecast.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}