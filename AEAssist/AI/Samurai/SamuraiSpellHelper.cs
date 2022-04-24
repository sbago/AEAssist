using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class SamuraiSpellHelper
    {
        public static async Task<SpellEntity> GetBaseSpell()
        {
            if (Core.Me.HasAura(AurasDefine.Kaiten))
                return null;
            if (!Core.Me.HasAura(AurasDefine.MeikyoShisui))
            {
                if (ActionManager.LastSpell == SpellsDefine.Hakaze.SpellData)
                {
                    if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                        if(await SpellsDefine.Yukikaze.DoGCD())
                            return SpellsDefine.Yukikaze;
                    //if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                    if ((Core.Me.GetAuraById(AurasDefine.Shifu)?.TimeLeft < (Core.Me.GetAuraById(AurasDefine.Jinpu)?.TimeLeft))||
                        !Core.Me.HasAura(AurasDefine.Shifu))
                        if (await SpellsDefine.Shifu.DoGCD())
                            return SpellsDefine.Shifu;
                    // if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                    if (await SpellsDefine.Jinpu.DoGCD())
                        return SpellsDefine.Jinpu;
                }
                if (ActionManager.LastSpell == SpellsDefine.Shifu.SpellData)
                    if (await SpellsDefine.Kasha.DoGCD())
                        return SpellsDefine.Kasha;
                if (ActionManager.LastSpell == SpellsDefine.Jinpu.SpellData)
                    if (await SpellsDefine.Gekko.DoGCD())
                        return SpellsDefine.Gekko;
                if (await SpellsDefine.Hakaze.DoGCD())
                    return SpellsDefine.Hakaze;
            }
            if(Core.Me.HasAura(AurasDefine.MeikyoShisui))
            {         
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                    if (await SpellsDefine.Kasha.DoGCD())
                        return SpellsDefine.Kasha;
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                    if (await SpellsDefine.Gekko.DoGCD())
                        return SpellsDefine.Gekko;
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                    if (await SpellsDefine.Yukikaze.DoGCD())
                        return SpellsDefine.Yukikaze;
            }
            return null;
        }
        public static SpellEntity IaijutsuCanSpell()
        {
            if (!Core.Me.HasAura(AurasDefine.Kaiten))
                return null;
            if (!Core.Me.HasAura(AurasDefine.Kaiten))
                return null;
            return null;
        }
        public static uint SenCounts()
        {
            uint counts = 0;
            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                counts++;
                
            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                counts++;

            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                counts++;
            return counts;
        }

        public static bool IaijutsuCanSpellTime()
        {
            var target = Core.Me as GameObject;
            if (Core.Me.HasAura(AurasDefine.MeikyoShisui))
                return false;
            return true;
        }
        public static SpellEntity GetIaijutsuSpell()
        {
            var spell = SpellsDefine.MidareSetsugekka;
            var Sen = SamuraiSpellHelper.SenCounts();
            var ta = Core.Me.CurrentTarget as Character;
           // if (spell.Cooldown.TotalSeconds != 0 && Core.Me.HasAura(AurasDefine.OgiReady) && ta.HasMyAura(AurasDefine.Higanbana))
           //     return SpellsDefine.OgiNamikiri;
            if (Sen == 0) return null;
            if (Sen == 1) spell = SpellsDefine.Higanbana;
            if (Sen == 2)
            {
                if (TargetHelper.CheckNeedUseAOE(Core.Me.CurrentTarget, 5, 5))
                    return SpellsDefine.TenkaGoken;
                else return null;
                
            }
            return spell;
        }

        public static SpellEntity KaeshiCanSpell()
        {
            if (AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell == KaeshiSpell.MidareSetsugekka)
                return SpellsDefine.KaeshiSetsugekka;
            if (AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell == KaeshiSpell.OgiNamikiri)
                return SpellsDefine.KaeshiNamikiri;
            return null;
        }

        public static bool OnCombo()
        {
            return false;
        }
                
    }
}
