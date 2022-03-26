using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BardAbility_Songs : IAIHandler
    {
        public bool Check(SpellData lastSpell)
        {
            if (lastSpell == Spells.TheWanderersMinuet || lastSpell == Spells.MagesBallad || lastSpell == Spells.ArmysPaeon)
                return false;
            // 可能会发生短时间内rb的song的Timer还是上一首歌的,导致连续的GCD内连续切换两次歌的情况
            if (TimeHelper.Now() - AIRoot.Instance.lastCastSongTime < 10000)
                return false;

            if (!Spells.TheWanderersMinuet.IsReady()
                && !Spells.MagesBallad.IsReady()
                && !Spells.ArmysPaeon.IsReady())
                return false;
            
            var spell = CheckNeedChangeSong();
            if (spell == null)
                return false;
            return true;
        }

        public async Task<SpellData> Run()
        {
            var spell = CheckNeedChangeSong();
            if (spell == null)
                return null;

            if (ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.WanderersMinuet)
            {
                if (Spells.PitchPerfect.IsReady())
                {
                    await SpellHelper.CastAbility(Spells.PitchPerfect, Core.Me.CurrentTarget, 100);
                }
            }

            var ret = await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget);
            if (ret)
            {
                AIRoot.Instance.lastCastSongTime = TimeHelper.Now();
                return spell;
            }

            return null;
        }

        private SpellData CheckNeedChangeSong()
        {
            var currSong = ActionResourceManager.Bard.ActiveSong;
            var remainTime = ActionResourceManager.Bard.Timer.TotalMilliseconds;
            SpellData spell = null;
            switch (currSong)
            {
                case ActionResourceManager.Bard.BardSong.None:
                    spell = GetSongsByOrder(null);
                    break;
                case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                    // 关闭爆发的时候,我们让歌唱完
                    if (!AIRoot.Instance.CloseBuff && remainTime <= BardSettings.Instance.Songs_WM_TimeLeftForSwitch)
                    {
                        spell = GetSongsByOrder(Spells.TheWanderersMinuet);
                    }
                    break;
                case ActionResourceManager.Bard.BardSong.MagesBallad:
                    // 关闭爆发的时候,我们让歌唱完
                    if (!AIRoot.Instance.CloseBuff && remainTime <= BardSettings.Instance.Songs_MB_TimeLeftForSwitch)
                    {
                        spell = GetSongsByOrder(Spells.MagesBallad);
                    }
                    break;
                case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                    // 关闭爆发的时候,我们让歌唱完
                    if (!AIRoot.Instance.CloseBuff && remainTime <= BardSettings.Instance.Songs_AP_TimeLeftForSwitch)
                    {
                        spell = GetSongsByOrder(Spells.ArmysPaeon);
                    }

                    break;
            }

            if (spell != null)
            {
                GUIHelper.ShowInfo($"Song: {spell.LocalizedName} remainTime: {remainTime}", 5000, false);
            }

            return spell;
        }

        private SpellData GetSongsByOrder(SpellData passSpell)
        {
            SpellData spell = NextSong(passSpell);
            if (spell != null && spell.IsReady())
            {
                return spell;
            }
            spell = NextSong(spell);
            if (spell != null && spell.IsReady())
                return spell;
            return null;
        }

        private SpellData NextSong(SpellData spellData)
        {
            if (spellData == Spells.TheWanderersMinuet)
                return Spells.MagesBallad;
            if (spellData == Spells.MagesBallad)
                return Spells.ArmysPaeon;
            if (AIRoot.Instance.CloseBuff)
                return null;
            return Spells.TheWanderersMinuet;
        }
    }
}