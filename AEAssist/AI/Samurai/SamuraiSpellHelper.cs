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
        public static SpellEntity GetBaseSpell()
        {
            if (!Core.Me.HasAura(AurasDefine.MeikyoShisui))
            {
                if (ActionManager.LastSpell == SpellsDefine.Hakaze.GetSpellEntity().SpellData)
                {
                    if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                        return SpellsDefine.Yukikaze.GetSpellEntity();
                    if (Core.Me.GetAuraById(AurasDefine.Shifu)?.TimeLeft <
                        Core.Me.GetAuraById(AurasDefine.Jinpu)?.TimeLeft ||
                        !Core.Me.HasAura(AurasDefine.Shifu))
                        return SpellsDefine.Shifu.GetSpellEntity();
                    return SpellsDefine.Jinpu.GetSpellEntity();
                }

                if (ActionManager.LastSpell == SpellsDefine.Shifu.GetSpellEntity().SpellData)
                    return SpellsDefine.Kasha.GetSpellEntity();
                if (ActionManager.LastSpell == SpellsDefine.Jinpu.GetSpellEntity().SpellData)
                    return SpellsDefine.Gekko.GetSpellEntity();
                return SpellsDefine.Hakaze.GetSpellEntity();
            }

            if (Core.Me.HasAura(AurasDefine.MeikyoShisui))
            {
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                    return SpellsDefine.Kasha.GetSpellEntity();
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                    return SpellsDefine.Gekko.GetSpellEntity();
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
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

        public static bool NeedUseKaiten()
        {
            if (false) ;
            return false;
        }
    }
}