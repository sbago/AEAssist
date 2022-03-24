using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AEAssist;
using Clio.Utilities;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Navigation;
using TreeSharp;

using Core = ff14bot.Core;

namespace AEAssistLoader
{
    public class AEAssistLoader : CombatRoutine
    {
        private const string ProjectName = "AEAssist";
        public override string Name { get => ProjectName; }
        public override float PullRange { get => 25; }

        public override bool WantButton { get=>true; }

        public override ClassJobType[] Class
        {
            get
            {
                switch (ff14bot.Core.Me.CurrentJob)
                {
                    case ClassJobType.Bard:
                        return new[] { ff14bot.Core.Me.CurrentJob };
                    default:
                    {
                        Logging.Write($@"[AEAssist] {ff14bot.Core.Me.CurrentJob} is not supported.");
                        return default;
                    }
                }
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            AEAssist.AECore.Instance.Initialize();
        }

        public override void OnButtonPress()
        {
            base.OnButtonPress();
            AEAssist.AECore.Instance.OnButtonPress();
        }

        public override void Pulse()
        {
            base.Pulse();
            AEAssist.AECore.Instance.Pulse();
        }

        public override void ShutDown()
        {
            base.ShutDown();
            LogHelper.Debug("ShutDown");
        }

        public override Composite RestBehavior
        {
            get
            {
                return
                    new ActionRunCoroutine(ctx => RotationManager.Instance.Rest());
            }
        }

        public override Composite PreCombatBuffBehavior
        {
            get
            {
                return
                    new ActionRunCoroutine(ctx => RotationManager.Instance.PreCombatBuff());
            }
        }

        public override Composite PullBehavior
        {
            get { return new ActionRunCoroutine(ctx => RotationManager.Instance.Pull()); }
        }

        public override Composite HealBehavior
        {
            get { return new ActionRunCoroutine(ctx => RotationManager.Instance.Heal()); }
        }

        public override Composite CombatBuffBehavior
        {
            get { return new ActionRunCoroutine(ctx => RotationManager.Instance.CombatBuff()); }
        }

        public override Composite CombatBehavior
        {
            get { return new ActionRunCoroutine(ctx => RotationManager.Instance.Combat()); }
        }

        public override Composite PullBuffBehavior
        {
            get { return new ActionRunCoroutine(ctx => RotationManager.Instance.PullBuff()); }
        }
        

    }
}