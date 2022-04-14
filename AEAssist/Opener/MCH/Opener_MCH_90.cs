// -----------------------------------
// 
// 模块说明：机工 90级起手
// 
// 创建人员：AE
// 创建日期：2022-04-14
// -----------------------------------

using ff14bot.Enums;
using ff14bot.Objects;

namespace AEAssist.Opener
{
    [Opener(ClassJobType.Machinist,90)]
    public class Opener_MCH_90 : IOpener
    {
        public bool NextGCD(int currGCDIndex, out SpellData spellData)
        {
            throw new System.NotImplementedException();
        }

        public bool NextAbility(int currGCDIndex, int abilityIndex, out SpellData spellData)
        {
            throw new System.NotImplementedException();
        }
    }
}