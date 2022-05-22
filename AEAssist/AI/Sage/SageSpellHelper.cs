using System;
using System.Linq;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Sage
{
    public class SageSpellHelper
    {
        public static SpellEntity GetEukrasianDosis()
        {
            // If Eukrasian Dosis is not unlocked return early because nothing else will be unlocked.
            if (!SpellsDefine.EukrasianDosis.IsUnlock())
            {
                LogHelper.Debug("EukrasianDosis not unlocked. skipping.");
                return null;
            }

            if (!SpellsDefine.EukrasianDosisII.IsUnlock())
            {
                LogHelper.Debug("EukrasianDosisII not unlocked trying to use EukrasianDosis instead.");
                if (!ActionManager.HasSpell(SpellsDefine.EukrasianDosis))
                {
                    LogHelper.Debug("EukrasianDosis not found. skipping.");
                    return null;
                }

                LogHelper.Debug("EukrasianDosis found trying to use..");
                return SpellsDefine.EukrasianDosis.GetSpellEntity();
            }

            if (!SpellsDefine.EukrasianDosisIII.IsUnlock())
            {
                LogHelper.Debug("EukrasianDosisIII not unlocked trying to use EukrasianDosisII instead.");
                if (!ActionManager.HasSpell(SpellsDefine.EukrasianDosisII))
                {
                    LogHelper.Debug("EukrasianDosisII not found. skipping.");
                    return null;
                }

                LogHelper.Debug("EukrasianDosisII found trying to use..");
                return SpellsDefine.EukrasianDosisII.GetSpellEntity();
            }

            if (!ActionManager.HasSpell(SpellsDefine.EukrasianDosisIII))
            {
                LogHelper.Debug("EukrasianDosisIII not found. skipping.");
                return null;
            }

            LogHelper.Debug("EukrasianDosisIII found trying to use..");
            return SpellsDefine.EukrasianDosisIII.GetSpellEntity();
        }

        public static SpellEntity GetPhlegma()
        {
            if (!SpellsDefine.Phlegma.IsUnlock())
            {
                LogHelper.Debug("Phlegma not unlocked. skipping.");
                return null;
            }

            if (!SpellsDefine.PhlegmaII.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.Phlegma))
                {
                    LogHelper.Debug("Phlegma not found. skipping.");
                    return null;
                }

                if (SpellsDefine.Phlegma.IsReady())
                {
                    LogHelper.Debug("Phlegma is ready. using.");
                    return SpellsDefine.Phlegma.GetSpellEntity();
                }

                LogHelper.Debug("Phlegma not ready. skipping.");
                return null;
            }

            if (!SpellsDefine.PhlegmaIII.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.PhlegmaII))
                {
                    LogHelper.Debug("PhlegmaII not found. skipping.");
                    return null;
                }

                if (SpellsDefine.PhlegmaII.IsReady())
                {
                    LogHelper.Debug("PhlegmaII is ready. using.");
                    return SpellsDefine.PhlegmaII.GetSpellEntity();
                }

                LogHelper.Debug("PhlegmaII not ready. skipping.");
                return null;
            }

            if (!ActionManager.HasSpell(SpellsDefine.PhlegmaIII))
            {
                LogHelper.Debug("PhlegmaIII not found. skipping.");
                return null;
            }

            if (SpellsDefine.PhlegmaIII.IsReady())
            {
                LogHelper.Debug("PhlegmaIII ready. using.");
                return SpellsDefine.PhlegmaIII.GetSpellEntity();
            }

            LogHelper.Debug("PhlegmaIII not ready. skipping.");
            return null;
        }

        public static SpellEntity GetPhysis()
        {
            if (!SpellsDefine.Physis.IsUnlock())
            {
                LogHelper.Debug("Physis not unlocked. skipping.");
                return null;
            }

            if (!SpellsDefine.PhysisII.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.Physis))
                {
                    LogHelper.Debug("Physis not found. skipping.");
                    return null;
                }

                LogHelper.Debug("Using Physis.");
                return SpellsDefine.Physis.IsReady() ? SpellsDefine.Physis.GetSpellEntity() : null;
            }

            if (!ActionManager.HasSpell(SpellsDefine.PhysisII))
            {
                LogHelper.Debug("PhysisII not found. skipping.");
                return null;
            }

            if (SpellsDefine.PhysisII.IsReady())
            {
                LogHelper.Debug("PhysisII ready using.");
                return SpellsDefine.PhysisII.GetSpellEntity();
            }

            LogHelper.Debug("PhysisII not ready. skipping.");
            return null;
        }

        public static SpellEntity GetDosis()
        {
            if (!SpellsDefine.Dosis.IsUnlock())
            {
                LogHelper.Debug("Dosis not unlocked. skipping.");
                return null;
            }

            if (!SpellsDefine.DosisII.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.Dosis))
                {
                    LogHelper.Debug("Dosis not found. skipping.");
                    return null;
                }

                LogHelper.Debug("Using Dosis. ");
                return SpellsDefine.Dosis.GetSpellEntity();
            }

            if (!SpellsDefine.DosisIII.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.DosisII))
                {
                    LogHelper.Debug("DosisII not found. skipping.");
                    return null;
                }

                LogHelper.Debug("Using DosisII. ");
                return SpellsDefine.DosisII.GetSpellEntity();
            }

            if (ActionManager.HasSpell(SpellsDefine.DosisIII)) return SpellsDefine.DosisIII.GetSpellEntity();
            LogHelper.Debug("DosisIII not found: unlocked?");
            return null;
        }

        public static SpellEntity GetDyskrasia()
        {
            if (!SpellsDefine.Dyskrasia.IsUnlock())
            {
                LogHelper.Debug("Dyskrasia not unlocked. skipping.");
                return null;
            }

            if (!SpellsDefine.DyskrasiaII.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.Dyskrasia))
                {
                    LogHelper.Debug("Dyskrasia not found: unlocked?");
                    return null;
                }

                LogHelper.Debug("Using Dykrasia");
                return SpellsDefine.Dyskrasia.GetSpellEntity();
            }

            if (ActionManager.HasSpell(SpellsDefine.DyskrasiaII)) return SpellsDefine.DyskrasiaII.GetSpellEntity();
            LogHelper.Debug("DyskrasiaII not found: unlocked?");
            return null;
        }

        public static SpellEntity GetToxikon()
        {
            if (!SpellsDefine.Toxikon.IsUnlock())
            {
                LogHelper.Debug("Toxikon not unlocked. skipping.");
                return null;
            }

            if (ActionResourceManager.Sage.Addersting <= 0)
            {
                LogHelper.Debug("Toxikon didn't pass: 0 Addersting");
                return null;
            }

            if (!SpellsDefine.ToxikonII.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.Toxikon))
                {
                    LogHelper.Debug("Toxikon couldn't be found: unlocked?");
                    return null;
                }

                LogHelper.Debug("Using Toxikon");
                return SpellsDefine.Toxikon.GetSpellEntity();
            }

            if (ActionManager.HasSpell(SpellsDefine.ToxikonII)) return SpellsDefine.ToxikonII.GetSpellEntity();
            LogHelper.Debug("ToxikonII couldn't be found: unlocked? ");
            return null;
        }

        public static SpellEntity GetBaseGcd()
        {
            return GetDosis();
        }

        private static int GetEukrasianDosisAura()
        {
            LogHelper.Debug("Checking if EukrasianDosis is unlocked...");
            if (!SpellsDefine.EukrasianDosis.IsUnlock())
            {
                LogHelper.Debug("EukrasianDosis not unlocked...");
                return 0;
            }

            LogHelper.Debug("Checking if EukrasianDosisII is unlocked...");
            if (!SpellsDefine.EukrasianDosisII.IsUnlock())
            {
                LogHelper.Debug("EukrasianDosisII not unlocked.. trying to use EukrasianDosis instead.. ");
                if (!ActionManager.HasSpell(SpellsDefine.EukrasianDosis))
                {
                    LogHelper.Debug("Failed to use EukrasianDosis...");
                    return 0;
                }

                LogHelper.Debug("EukrasianDosis found using...");
                return AurasDefine.EukrasianDosis;
            }

            LogHelper.Debug("Checking if EukrasianDosisIII is unlocked...");
            if (SpellsDefine.EukrasianDosisIII.IsUnlock())
            {
                LogHelper.Debug("Using EukrasianDosisIII...");
                return AurasDefine.EukrasianDosisIII;
            }

            LogHelper.Debug("Checking if EukrasianDosisII is unlocked...");
            if (!ActionManager.HasSpell(SpellsDefine.EukrasianDosisII))
            {
                LogHelper.Debug("EukrasianDosisII not found...skipping?");
                return 0;
            }

            LogHelper.Debug("EukrasianDosisII found...using?");
            return AurasDefine.EukrasianDosisII;
        }

        public static bool IsTargetHasAuraEukrasianDosis(Character target)
        {
            var id = GetEukrasianDosisAura();
            LogHelper.Debug("Checking if target has EukrasianDosis: " + target.EnglishName);
            return id == 0 || target.HasMyAuraWithTimeleft((uint)id);
        }

        public static void RecordEukrasianDosis()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            AIRoot.GetBattleData<SageBattleData>().lastEukrasianDosisWithObj[targetId] = true;
        }

        public static void RemoveRecordEukrasianDosis()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            AIRoot.GetBattleData<SageBattleData>().lastEukrasianDosisWithObj[targetId] = false;
        }

        public static bool IsTargetNeedEukrasianDosis(Character target, int timeLeft)
        {
            var dosisId = GetEukrasianDosisAura();
            LogHelper.Debug("Checking if target need EukrasianDosis id: " + dosisId);
            if (dosisId == 0) return false;

            var ttkEukrasianDosis = SettingMgr.GetSetting<SageSettings>().TTK_EukrasianDosis;

            bool NormalCheck()
            {
                if (DataBinding.Instance.EarlyDecisionMode)
                    timeLeft += SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;
                return !target.HasMyAuraWithTimeleft((uint)dosisId, timeLeft);
            }

            if (AIRoot.GetBattleData<SageBattleData>().IsTargetLastEukrasianDosis()) return NormalCheck();
            if (ttkEukrasianDosis > 0 && target.HasMyAuraWithTimeleft((uint)dosisId, ttkEukrasianDosis * 1000) &&
                TTKHelper.IsTargetTTK(target, ttkEukrasianDosis, false))
                return NormalCheck();

            return NormalCheck();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>ret == true : Successful use</returns>
        public static async Task<(bool ret, SpellEntity Eukrasia)> CastEukrasia()
        {
            if (Core.Me.HasMyAura(AurasDefine.Eukrasia) || SpellsDefine.Eukrasia.RecentlyUsed()) return (false, null);
            var spell = SpellsDefine.Eukrasia.GetSpellEntity();
            var ret = await spell.DoGCD();
            return (ret, spell);
        }

        public static async Task CastSwiftCast()
        {
            LogHelper.Debug("Checking if we have swiftcast aura or Swiftcast recentlyUsed");
            if (Core.Me.HasAura(AurasDefine.Swiftcast) || SpellsDefine.Swiftcast.RecentlyUsed()) return;
            LogHelper.Debug("Swiftcast can be used: using.");
            var spell = SpellsDefine.Swiftcast.GetSpellEntity();
            var ret = await spell.DoAbility();
        }
        
        public static async Task CastEgeiroToTarget(Character target)
        {
            if (!SpellsDefine.Egeiro.IsUnlock()) return;
            await CastSwiftCast();
            var spell = new SpellEntity(SpellsDefine.Egeiro, target as BattleCharacter);
            await spell.DoGCD();
        }
        
        public static async Task<SpellEntity> CastResPriority()
        {
            var priority = SettingMgr.GetSetting<SageSettings>().SageResPriority;
            var deadAllies = GroupHelper.DeadAllies;

            switch (priority)
            {
                // Healer>Tanks>DPS
                case 0:
                    LogHelper.Debug("Healer>Tanks>DPS-RESSING");
                    foreach (var deadAlly in deadAllies)
                    {
                        if (deadAlly.IsHealer())
                        {
                            LogHelper.Debug("Trying to swift res the healer.");
                            await CastEgeiroToTarget(deadAlly);
                            break;
                        }
                        
                        if (deadAlly.IsTank())
                        {
                            LogHelper.Debug("Trying to swift res the tank.");
                            await CastEgeiroToTarget(deadAlly);
                            break;
                        }
                        LogHelper.Debug("Trying to swift res the dps.");
                        await CastEgeiroToTarget(deadAlly);
                        break;
                    }
                    return null;
                // Tanks>Healer>DPS
                case 1:
                    LogHelper.Debug("Tanks>Healer>DPS-RESSING");
                    foreach (var deadAlly in deadAllies)
                    {
                        if (deadAlly.IsTank())
                        {
                            LogHelper.Debug("Trying to swift res the Tanks.");
                            await CastEgeiroToTarget(deadAlly);
                            break;
                        }
                        
                        if (deadAlly.IsHealer())
                        {
                            LogHelper.Debug("Trying to swift res the healer.");
                            await CastEgeiroToTarget(deadAlly);
                            break;
                        }
                        LogHelper.Debug("Trying to swift res the dps.");
                        await CastEgeiroToTarget(deadAlly);
                        break;
                    }
                    return null;
                // DPS>Healer>Tanks
                case 2:
                    foreach (var deadAlly in deadAllies)
                    {
                        if (deadAlly.IsDps())
                        {
                            LogHelper.Debug("Trying to swift res the dps.");
                            LogHelper.Debug("DPS>Healer>Tanks-RESSING");
                            await CastEgeiroToTarget(deadAlly);
                            break;
                        }
                        
                        if (deadAlly.IsHealer())
                        {
                            LogHelper.Debug("Trying to swift res the healer.");
                            await CastEgeiroToTarget(deadAlly);
                            break;
                        }
                        LogHelper.Debug("Trying to swift res the Tanks.");
                        await CastEgeiroToTarget(deadAlly);
                        break;
                    }
                    return null;
            }
            return null;
        }

        public static async Task<bool> CastEukrasianDiagnosis(Character target)
        {
            if (!SpellsDefine.EukrasianDiagnosis.IsUnlock()) return false;
            await CastEukrasia();
            var spell = new SpellEntity(SpellsDefine.EukrasianDiagnosis, target as BattleCharacter);
            return await spell.DoGCD();
        }
        
        
        public static async Task<bool> CastEukrasianPrognosis(Character target)
        {   
            if (!SpellsDefine.EukrasianPrognosis.IsUnlock()) return false;
            await SageSpellHelper.CastEukrasia();
            var spell = new SpellEntity(SpellsDefine.EukrasianPrognosis, target as BattleCharacter);
            return await spell.DoGCD();
        }

        public static bool CanEukrasianDiagnosis(Character unit)
        {
            if (unit == null) return false;
            if (unit.HasMyAura(AurasDefine.EukrasianDiagnosis)) return false;
            if (unit.HasAura(AurasDefine.Galvanize)) return false;
            return true;
        }

        public static async Task PrePullEukrasianDiagnosisThreePeople()
        {
            if (GroupHelper.CastableParty.Count <= 3) return;
            
            var count = 0;
            const int need = 3;
            const int retryTime = 25;
            const int retryInterval = 100; // 25* 100 = GCD CoolDown

            if (GroupHelper.CastableTanks.Count > 0)
            {
                foreach (var character in GroupHelper.CastableTanks)
                {
                    // check if we can EukrasianDiagnosis.
                    if (CanEukrasianDiagnosis(character))
                    {
                        int time = 0;
                        while (time < retryTime && !await CastEukrasianDiagnosis(character))
                        {
                            await Coroutine.Sleep(retryInterval);
                            time++;
                        }
                        LogHelper.Info($"{character.Name} {time} {count}");
                        if (time < retryTime)
                            count++;
                    }

                }
            }
            
            foreach (var character in GroupHelper.CastableParty)
            {
                // check if we can EukrasianDiagnosis.
                if (character.IsTank())
                    continue;
                // if healer skip
                if(character.IsHealer())
                    continue;
                if (count >= need)
                    return;
                if (CanEukrasianDiagnosis(character))
                {
                    int time = 0;
                    // wait for success, but retry time need < 25
                    while (time < retryTime && !await CastEukrasianDiagnosis(character))
                    {
                        await Coroutine.Sleep(retryInterval);
                        time++;
                    }
                    LogHelper.Debug($"{character.Name} {time} {count}");
                    if (time < retryTime)
                        count++;
                }
            }
        }
    }
}