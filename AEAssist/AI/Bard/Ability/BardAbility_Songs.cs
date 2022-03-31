using System;
using System.Threading.Tasks;
using AEAssist.DataBinding;
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
            // 可能会发生短时间内rb的song的Timer还是上一首歌的 (rb的bug),导致连续的GCD内连续切换两次歌的情况
            if (TimeHelper.Now() - AIRoot.Instance.BardBattleData.lastCastSongTime < 3000)
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

            bool castPitch = false;
            
            if (ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.WanderersMinuet)
            {
                if (Spells.PitchPerfect.IsReady())
                {
                    if (await SpellHelper.CastAbility(Spells.PitchPerfect, Core.Me.CurrentTarget, 100))
                    {
                        castPitch = true;
                    }
                }
            }

            var ret = await SpellHelper.CastAbility(spell, Core.Me.CurrentTarget);
            if (ret)
            {
                AIRoot.Instance.BardBattleData.lastCastSongTime = TimeHelper.Now();
                if (castPitch)
                {
                    AIRoot.Instance.MuteAbilityTime();
                }

                return spell;
            }

            return null;
        }

        
        
        private SpellData CheckNeedChangeSong()
        {
            var currSong = ActionResourceManager.Bard.ActiveSong;
            var remainTime = ActionResourceManager.Bard.Timer.TotalMilliseconds;
            SpellData spell = null;

            if (AIRoot.Instance.CloseBuff)
            {
                // 关爆发的时候,让歌唱完
                if (currSong != ActionResourceManager.Bard.BardSong.None)
                    return null;
                else
                {
                    spell = GetSongsByOrder(null);
                }
            }
            else
            {
                switch (currSong)
                {
                    case ActionResourceManager.Bard.BardSong.None:
                        spell = GetSongsByOrder(null);
                        break;
                    case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                        // 关闭爆发的时候,我们让歌唱完
                        if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_WM_TimeLeftForSwitch)
                        {
                            spell = GetSongsByOrder(Spells.TheWanderersMinuet);
                        }
                        break;
                    case ActionResourceManager.Bard.BardSong.MagesBallad:
                        if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_MB_TimeLeftForSwitch)
                        {
                            spell = GetSongsByOrder(Spells.MagesBallad);
                        }
                        break;
                    case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                        if (remainTime <= SettingMgr.GetSetting<BardSettings>().Songs_AP_TimeLeftForSwitch)
                        {
                            spell = GetSongsByOrder(Spells.ArmysPaeon);
                        }

                        break;
                }   
            }

            if (spell != null)
            {
                GUIHelper.ShowInfo($"Song: {spell.LocalizedName} remainTime: {remainTime}", 1000, false);
            }

            return spell;
        }

        private SpellData GetSongsByOrder(SpellData passSpell)
        {
            SpellData spell = null;
            if (BaseSettings.Instance.nextSong != ActionResourceManager.Bard.BardSong.None)
            {
                switch (BaseSettings.Instance.nextSong)
                {
                    case ActionResourceManager.Bard.BardSong.MagesBallad:
                        spell = Spells.MagesBallad;
                        break;
                    case ActionResourceManager.Bard.BardSong.ArmysPaeon:
                        spell = Spells.ArmysPaeon;
                        break;
                    case ActionResourceManager.Bard.BardSong.WanderersMinuet:
                        spell = Spells.TheWanderersMinuet;
                        break;
                }
                if (spell != null && spell.IsReady())
                {
                    return spell;
                }
            }

            spell = NextSong(passSpell);
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
            int i = BardSpellHelper.Songs.Count;
            var origin = spellData;
            while (i>0)
            {
                spellData = BardSpellHelper.Songs.GetNext(spellData);
                i--;
                if (spellData == null || !spellData.IsReady())
                {
                    continue;
                }

                if (spellData == Spells.TheWanderersMinuet && AIRoot.Instance.CloseBuff)
                {
                    continue;
                }
                
                if(spellData == origin)
                    continue;
                return spellData;
            }

            return null;
        }
    }
}