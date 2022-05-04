using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Samurai
{
    public class SamuraiSpellHelper
    {
        public static async Task<SpellEntity> GetBaseSpell()
        {
            if (Core.Me.HasAura(AurasDefine.Kaiten))
                return null;
            if (!Core.Me.HasAura(AurasDefine.MeikyoShisui))
            {
                if (ActionManager.LastSpell == SpellsDefine.Hakaze.GetSpellEntity().SpellData)
                {
                    if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                        if (await SpellsDefine.Yukikaze.DoGCD())
                            return SpellsDefine.Yukikaze.GetSpellEntity();
                    //if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                    if (Core.Me.GetAuraById(AurasDefine.Shifu)?.TimeLeft <
                        Core.Me.GetAuraById(AurasDefine.Jinpu)?.TimeLeft ||
                        !Core.Me.HasAura(AurasDefine.Shifu))
                        if (await SpellsDefine.Shifu.DoGCD())
                            return SpellsDefine.Shifu.GetSpellEntity();
                    // if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                    if (await SpellsDefine.Jinpu.DoGCD())
                        return SpellsDefine.Jinpu.GetSpellEntity();
                }

                if (ActionManager.LastSpell == SpellsDefine.Shifu.GetSpellEntity().SpellData)
                    if (await SpellsDefine.Kasha.DoGCD())
                        return SpellsDefine.Kasha.GetSpellEntity();
                if (ActionManager.LastSpell == SpellsDefine.Jinpu.GetSpellEntity().SpellData)
                    if (await SpellsDefine.Gekko.DoGCD())
                        return SpellsDefine.Gekko.GetSpellEntity();
                if (await SpellsDefine.Hakaze.DoGCD())
                    return SpellsDefine.Hakaze.GetSpellEntity();
            }

            if (Core.Me.HasAura(AurasDefine.MeikyoShisui))
            {
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                    if (await SpellsDefine.Kasha.DoGCD())
                        return SpellsDefine.Kasha.GetSpellEntity();
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                    if (await SpellsDefine.Gekko.DoGCD())
                        return SpellsDefine.Gekko.GetSpellEntity();
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                    if (await SpellsDefine.Yukikaze.DoGCD())
                        return SpellsDefine.Yukikaze.GetSpellEntity();
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
            var Sen = SenCounts();
            var ta = Core.Me.CurrentTarget as Character;
            // if (spell.Cooldown.TotalSeconds != 0 && Core.Me.HasAura(AurasDefine.OgiReady) && ta.HasMyAura(AurasDefine.Higanbana))
            //     return SpellsDefine.OgiNamikiri;
            if (Sen == 0) return null;
            if (Sen == 1) spell = SpellsDefine.Higanbana;
            if (Sen == 2)
            {
                if (TargetHelper.CheckNeedUseAOE(Core.Me.CurrentTarget, 5, 5))
                    return SpellsDefine.TenkaGoken.GetSpellEntity();
                return null;
            }

            return spell.GetSpellEntity();
        }

        public static SpellEntity KaeshiCanSpell()
        {
            if (AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell == KaeshiSpell.MidareSetsugekka)
                return SpellsDefine.KaeshiSetsugekka.GetSpellEntity();
            if (AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell == KaeshiSpell.OgiNamikiri)
                return SpellsDefine.KaeshiNamikiri.GetSpellEntity();
            return null;
        }

        public static bool OnCombo()
        {
            return false;
        }
    }
}