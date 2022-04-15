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
        public int Check(SpellData lastSpell)
        {
            if (lastSpell == SpellsDefine.TheWanderersMinuet || lastSpell == SpellsDefine.MagesBallad ||
                lastSpell == SpellsDefine.ArmysPaeon)
                return -1;
            // 可能会发生短时间内rb的song的Timer还是上一首歌的 (rb的bug),导致连续的GCD内连续切换两次歌的情况
            if (TimeHelper.Now() - AIRoot.Instance.BardBattleData.lastCastSongTime < 3000)
                return -2;

            if (!SpellsDefine.TheWanderersMinuet.IsReady()
                && !SpellsDefine.MagesBallad.IsReady()
                && !SpellsDefine.ArmysPaeon.IsReady())
                return -3;

            var spell = CheckNeedChangeSong(out var forceNextSong);
            if (spell == null)
                return -4;
            return 0;
        }

        public async Task<SpellData> Run()
        {
            var spell = CheckNeedChangeSong(out var forceNextSong);
            if (spell == null)
                return null;

            var castPitch = false;

            if (ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.WanderersMinuet)
                if (SpellsDefine.PitchPerfect.IsReady())
                    if (await SpellHelper.CastAbility(SpellsDefine.PitchPerfect, Core.Me.CurrentTarget, 100))
                        castPitch = true;

            var ret = await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget);
            if (ret)
            {
                if (forceNextSong)
                {
                    AIRoot.Instance.BardBattleData.nextSongQueue.Dequeue();
                    AIRoot.Instance.BardBattleData.nextSongDuration.Dequeue();
                }

                AIRoot.Instance.BardBattleData.lastCastSongTime = TimeHelper.Now();
                if (castPitch) AIRoot.Instance.MuteAbilityTime();

                return spell;
            }

            return null;
        }


        private SpellData CheckNeedChangeSong(out bool forceNextSong)
        {
            var currSong = ActionResourceManager.Bard.ActiveSong;
            var remainTime = ActionResourceManager.Bard.Timer.TotalMilliseconds;
            SpellData spell = null;
            forceNextSong = false;
            if (AIRoot.Instance.BurstOff)
            {
                // 关爆发的时候,让歌唱完
                if (currSong != ActionResourceManager.Bard.BardSong.None)
                {
                    var nextSongQueue = AIRoot.Instance.BardBattleData.nextSongQueue;
                    if (nextSongQueue.Count >0
                        && nextSongQueue.Peek() == (int)ActionResourceManager.Bard.ActiveSong)
                    {
                        if (remainTime <= 45000 - AIRoot.Instance.BardBattleData.nextSongDuration.Peek())
                        {
                            spell = GetSongsByOrder(null, out forceNextSong);
                        }

                        return spell;
                    }

                    if (remainTime <= ConstValue.SongsTimeLeftCheckWhenCloseBuff)
                    {
                        spell = GetSongsByOrder(null, out forceNextSong);
                        return spell;
                    }

                    return null;
                }

                spell = GetSongsByOrder(null, out forceNextSong);
            }
            else
            {
                var nextSongQueue = AIRoot.Instance.BardBattleData.nextSongQueue;
                if (nextSongQueue.Count>0 && nextSongQueue.Peek() == (int) ActionResourceManager.Bard.ActiveSong)
                {
                    if (remainTime <= 45000 - AIRoot.Instance.BardBattleData.nextSongDuration.Peek())
                    {
                        spell = GetSongsByOrder(null, out forceNextSong);
                    }
                }
                else
                {
                    switch (currSong)
                    {
                        case ActionResourceManager.Bard.BardSong.None:
                            spell = GetSongsByOrder(null, out forceNextSong);
                            break;
                        case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                            // 关闭爆发的时候,我们让歌唱完
                            if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_WM_TimeLeftForSwitch)
                                spell = GetSongsByOrder(SpellsDefine.TheWanderersMinuet, out forceNextSong);

                            break;
                        case ActionResourceManager.Bard.BardSong.MagesBallad:
                            if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_MB_TimeLeftForSwitch)
                                spell = GetSongsByOrder(SpellsDefine.MagesBallad, out forceNextSong);

                            break;
                        case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                            if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_AP_TimeLeftForSwitch)
                                spell = GetSongsByOrder(SpellsDefine.ArmysPaeon, out forceNextSong);

                            break;
                    }
                }
            }

            if (spell != null) GUIHelper.ShowInfo($"Song: {spell.LocalizedName} remainTime: {remainTime}", 1000, false);

            return spell;
        }

        private SpellData GetSongsByOrder(SpellData passSpell, out bool forceNextSong)
        {
            SpellData spell = null;
            forceNextSong = false;
            if (AIRoot.Instance.BardBattleData.nextSongQueue.Count>0 &&
                (int)ActionResourceManager.Bard.ActiveSong == AIRoot.Instance.BardBattleData.nextSongQueue.Peek())
            {
                switch ((ActionResourceManager.Bard.BardSong)AIRoot.Instance.BardBattleData.nextSongQueue.Peek())
                {
                    case ActionResourceManager.Bard.BardSong.MagesBallad:
                        spell = SpellsDefine.MagesBallad;
                        break;
                    case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                        spell = SpellsDefine.ArmysPaeon;
                        break;
                    case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                        spell = SpellsDefine.TheWanderersMinuet;
                        break;
                }

                forceNextSong = true;
                if (spell != null && spell.IsReady()) return spell;
            }

            spell = NextSong(passSpell);
            if (spell != null && spell.IsReady()) return spell;

            spell = NextSong(spell);
            if (spell != null && spell.IsReady())
                return spell;
            return null;
        }

        private SpellData NextSong(SpellData spellData)
        {
            var i = BardSpellHelper.Songs.Count;
            var origin = spellData;
            while (i > 0)
            {
                spellData = BardSpellHelper.Songs.GetNext(spellData);
                i--;
                if (spellData == null || !spellData.IsReady()) continue;

                if (spellData == SpellsDefine.TheWanderersMinuet && AIRoot.Instance.BurstOff) continue;

                if (spellData == origin)
                    continue;
                return spellData;
            }

            return null;
        }
    }
}