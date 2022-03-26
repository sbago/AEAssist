using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_Barrage : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {

            if (!Spells.Barrage.IsReady())
            {
                return false;
            }
            if (Core.Me.HasAura(AurasDefine.ShadowBiteReady)
            &&  TargetHelper.CheckNeedUseAOE(25, 5, ConstValue.BardAOECount))
                return true;

            if (Core.Me.HasAura(AurasDefine.StraighterShot))
                return false;
            if (BardSpellEx.UnlockBuffsCount() > 1 && BardSpellEx.HasBuffsCount() <= 1)
                return false;

            return true;
        }

        public async Task<SpellData> Run()
        {
            var spell = Spells.Barrage;
            if (spell == null)
                return null;
            var ret = await SpellHelper.CastAbility(spell, Core.Me);
            if (ret)
                return spell;
            return null;
        }
    }
}