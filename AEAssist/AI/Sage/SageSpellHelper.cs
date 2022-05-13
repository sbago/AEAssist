using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Sage
{
    public class SageSpellHelper
    {
        public static SpellEntity GetEukrasianDosis()
        {   
            // If Eukrasian Dosis is not unlocked return early because nothing else will be unlocked.
            if (!SpellsDefine.EukrasianDosis.IsUnlock()) return null;

            if (!SpellsDefine.EukrasianDosisII.IsUnlock())
            {
                return !ActionManager.HasSpell(SpellsDefine.EukrasianDosis) ? null : SpellsDefine.EukrasianDosis.GetSpellEntity();
            }

            if (!SpellsDefine.EukrasianDosisIII.IsUnlock())
            {
                return !ActionManager.HasSpell(SpellsDefine.EukrasianDosisII) ? null : SpellsDefine.EukrasianDosisII.GetSpellEntity();
            }
            
            return !ActionManager.HasSpell(SpellsDefine.EukrasianDosisIII) ? null : SpellsDefine.EukrasianDosisIII.GetSpellEntity();
        }

        public static SpellEntity GetPhlegma()
        {
            if (!SpellsDefine.Phlegma.IsUnlock()) return null;

            if (!SpellsDefine.PhlegmaII.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.Phlegma)) return null;
                return (SpellsDefine.Phlegma.IsReady()) ? SpellsDefine.Physis.GetSpellEntity() : null;
            }
            
            if (!SpellsDefine.PhlegmaIII.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.PhlegmaII)) return null;
                return SpellsDefine.PhlegmaII.IsReady() ? SpellsDefine.PhlegmaII.GetSpellEntity() : null;
            }

            if (!ActionManager.HasSpell(SpellsDefine.PhlegmaIII)) return null;
            return SpellsDefine.PhlegmaIII.IsReady() ? SpellsDefine.PhlegmaIII.GetSpellEntity() : null;
        }

        public static SpellEntity GetPhysis()
        {
            if (!SpellsDefine.Physis.IsUnlock()) return null;

            if (!SpellsDefine.PhysisII.IsUnlock())
            {
                if (!ActionManager.HasSpell(SpellsDefine.Physis)) return null;
                return (SpellsDefine.Physis.IsReady()) ? SpellsDefine.Physis.GetSpellEntity() : null;
            }

            if (!ActionManager.HasSpell(SpellsDefine.PhysisII)) return null;
            return SpellsDefine.PhysisII.IsReady() ? SpellsDefine.PhysisII.GetSpellEntity() : null;
        }

        public static SpellEntity GetDosis()
        {
            if (!SpellsDefine.Dosis.IsUnlock()) return null;

            if (!SpellsDefine.DosisII.IsUnlock())
            {
                return !ActionManager.HasSpell(SpellsDefine.Dosis) ? null : SpellsDefine.Dosis.GetSpellEntity();
            }
            
            if (!SpellsDefine.DosisIII.IsUnlock())
            {
                return !ActionManager.HasSpell(SpellsDefine.DosisII) ? null : SpellsDefine.DosisII.GetSpellEntity();
            }
            
            return !ActionManager.HasSpell(SpellsDefine.DosisIII) ? null : SpellsDefine.DosisIII.GetSpellEntity();
        }

        public static SpellEntity GetDyskrasia()
        {
            if (!SpellsDefine.Dyskrasia.IsUnlock()) return null;

            if (!SpellsDefine.DyskrasiaII.IsUnlock())
            {
                return !ActionManager.HasSpell(SpellsDefine.Dyskrasia) ? null : SpellsDefine.Dyskrasia.GetSpellEntity();
            }
            return !ActionManager.HasSpell(SpellsDefine.DyskrasiaII) ? null : SpellsDefine.DyskrasiaII.GetSpellEntity();
        }

        public static SpellEntity GetToxikon()
        {
            if (!SpellsDefine.Toxikon.IsUnlock()) return null;

            if (ActionResourceManager.Sage.Addersting <= 0) return null;
            if (!SpellsDefine.ToxikonII.IsUnlock())
            { 
                return !ActionManager.HasSpell(SpellsDefine.Toxikon) ? null : SpellsDefine.Toxikon.GetSpellEntity();   
            }
            return !ActionManager.HasSpell(SpellsDefine.ToxikonII) ? null : SpellsDefine.ToxikonII.GetSpellEntity();
        }

        public static SpellEntity GetBaseGcd()
        {
            return GetDosis();
        }
        
        private static int GetEukrasianDosisAura()
        {
            if (!SpellsDefine.EukrasianDosis.IsUnlock()) return 0;
            if (!SpellsDefine.EukrasianDosisII.IsUnlock())
            {
                return !ActionManager.HasSpell(SpellsDefine.EukrasianDosis) ? 0 : AurasDefine.EukrasianDosis;
            }

            if (SpellsDefine.EukrasianDosisIII.IsUnlock()) return AurasDefine.EukrasianDosisIII;
            return !ActionManager.HasSpell(SpellsDefine.EukrasianDosisII) ? 0 : AurasDefine.EukrasianDosisII;
        }

        public static bool IsTargetHasAuraEukrasianDosis(Character target)
        {
            var id = GetEukrasianDosisAura();
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
            if (dosisId == 0) return false;

            var ttkEukrasianDosis = SettingMgr.GetSetting<SageSettings>().TTK_EukrasianDosis;
            
            bool NormalCheck()
            {
                if (DataBinding.Instance.EarlyDecisionMode)
                    timeLeft += SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;
                return !target.HasMyAuraWithTimeleft((uint) dosisId, timeLeft);
            }

            if (AIRoot.GetBattleData<SageBattleData>().IsTargetLastEukrasianDosis()) return NormalCheck();
            if (ttkEukrasianDosis > 0 && target.HasMyAuraWithTimeleft((uint) dosisId, ttkEukrasianDosis * 1000) &&
                TTKHelper.IsTargetTTK(target, ttkEukrasianDosis, false))
                return NormalCheck();

            return NormalCheck();
        }

        public static void CheckEukrasia()
        {
            if (Core.Me.HasMyAura(AurasDefine.Eukrasia)) return;
            AIRoot.GetBattleData<BattleData>().NextGcdSpellId = SpellsDefine.Eukrasia.GetSpellEntity();
        }
        
        public static SpellEntity GetEukrasianDiagnosis()
        {
            if (!SpellsDefine.EukrasianDiagnosis.IsUnlock()) return null;
            
            CheckEukrasia();
            return !ActionManager.HasSpell(SpellsDefine.EukrasianDiagnosis) ? null : SpellsDefine.EukrasianDiagnosis.GetSpellEntity();
        }
        
        
        public static SpellEntity GetEukrasianPrognosis()
        {   
            if (!SpellsDefine.EukrasianPrognosis.IsUnlock()) return null;
            
            CheckEukrasia();
            return !ActionManager.HasSpell(SpellsDefine.EukrasianPrognosis) ? null : SpellsDefine.EukrasianPrognosis.GetSpellEntity();
        }

        public static bool CanEukrasianDiagnosis(Character unit)
        {
            if (unit == null) return false;
            if (unit.HasMyAura(SpellsDefine.Eukrasia)) return false;
            if (unit.HasAura(SpellsDefine.Galvanize)) return false;
            return true;
        }

        public async void  PrePullEukrasianDiagnosisThreePeople()
        {
            // update allies? before casting? maybe?
            GroupHelper.UpdateAllies();

            var count = 0;
            foreach (var character in GroupHelper.CastableParty)
            {
                // break if count is 3 or greater.
                if (count >= 3) break;
                
                for (int i = 0; i < 3; i++)
                {
                    // check if character is Tank.
                    if (character.IsTank())
                    {
                        // check if we can EukrasianDiagnosis.
                        if (CanEukrasianDiagnosis(character))
                        {
                            // if it's us then cast it as well.
                            if (character.ObjectId == Core.Me.ObjectId)
                            {
                                // cast it.
                                AIRoot.GetBattleData<BattleData>().NextGcdSpellId = GetEukrasianDiagnosis();
                            }
                            else
                            {
                                // cast it to character.
                               // TODO: need work here.  
                            }
                            
                            i++;
                        }

                    }
                    if (i == 3) break;
                }
                count++;
            }
        }
        
        
        

    }
}