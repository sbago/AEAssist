using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Objects;

namespace AEAssist.AI.Monk.GCD
{
    public class MonkGCD_BaseGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            MonkSpellHelper.SetPostion();
            var target = Core.Me.CurrentTarget as Character;
            return await MonkSpellHelper.BaseGCDCombo(target);
        }
    }
}