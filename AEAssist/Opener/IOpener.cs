// -----------------------------------
// 
// 模块说明：IOpener.cs
// 
// 创建人员：AE
// 创建日期：2022-04-14
// -----------------------------------

using ff14bot.Objects;

namespace AEAssist.Opener
{
    public interface IOpener
    {
        bool NextGCD(int currGCDIndex,out  SpellData spellData);
        bool NextAbility(int currGCDIndex,int abilityIndex,out  SpellData spellData);
    }
}