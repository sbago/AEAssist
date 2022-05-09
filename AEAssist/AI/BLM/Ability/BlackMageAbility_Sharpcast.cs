using System.Threading.Tasks;
using AEAssist.AI.BLM;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.BLM.Ability
{
    public class BlackMageAblity_Sharpcast : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Sharpcast.IsReady())
            {
                return -1;
            }

            if (!Core.Me.HasAura(AurasDefine.Sharpcast))
            {
                return 1;
            }
            

            return -4;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Sharpcast.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}