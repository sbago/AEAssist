using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media;
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

namespace AEAssist
{
    public class AEAssistLoader : CombatRoutine
    {
        private const string ProjectName = "AEAssist";
        private const string ProjectAssemblyName = "AEAssist.dll";
        public override string Name { get => ProjectName; }
        public override float PullRange { get => 25; }

        public override bool WantButton { get=>true; }
        
        private static readonly string ProjectAssembly = Path.Combine(Environment.CurrentDirectory, $@"Routines\{ProjectName}\{ProjectAssemblyName}");
        private static readonly string GreyMagicAssembly = Path.Combine(Environment.CurrentDirectory, @"GreyMagic.dll");

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
                        Logging.Write( Colors.Red,$@"[AEAssist] {ff14bot.Core.Me.CurrentJob} is not supported.");
                        return new[] { ff14bot.Core.Me.CurrentJob };
                    }
                }
            }
        }

        public Dictionary<string, PropertyInfo> Behaviors = new Dictionary<string, PropertyInfo>();
        public Dictionary<string, MethodInfo> Methods = new Dictionary<string, MethodInfo>();

        public object Entry;
        
        void LoadAsm()
        {
            RedirectAssembly();
            var path = ProjectAssembly;
            var asm = Assembly.Load(path);

            var entryType = asm.GetType("AEAssist.Entry");

            Entry = Activator.CreateInstance(entryType);


            AddBehavior(entryType,"RestBehavior");
            AddBehavior(entryType,"PreCombatBuffBehavior");
            AddBehavior(entryType,"PullBehavior");
            AddBehavior(entryType,"HealBehavior");
            AddBehavior(entryType,"CombatBuffBehavior");
            AddBehavior(entryType,"CombatBehavior");
            AddBehavior(entryType,"PullBuffBehavior");

            AddMethod(entryType,"Initialize");
            AddMethod(entryType,"Pulse");
            AddMethod(entryType,"Shutdown");
            AddMethod(entryType,"OnButtonPress");

        }
        
        public static void RedirectAssembly()
        {
            ResolveEventHandler handler = (sender, args) =>
            {
                string name = Assembly.GetEntryAssembly().GetName().Name;
                var requestedAssembly = new AssemblyName(args.Name);
                return requestedAssembly.Name != name ? null : Assembly.GetEntryAssembly();
            };

            AppDomain.CurrentDomain.AssemblyResolve += handler;

            ResolveEventHandler greyMagicHandler = (sender, args) =>
            {
                var requestedAssembly = new AssemblyName(args.Name);
                return requestedAssembly.Name != "GreyMagic" ? null : Assembly.LoadFrom(GreyMagicAssembly);
            };

            AppDomain.CurrentDomain.AssemblyResolve += greyMagicHandler;
        }

        void AddBehavior(Type type, string name)
        {
            Behaviors.Add(name,type.GetProperty(name));
        }

        void AddMethod(Type type, string name)
        {
            Methods.Add(name,type.GetMethod(name));
        }

        public override void Initialize()
        {
            base.Initialize();
            try
            {
                LoadAsm();
                Methods["Initialize"].Invoke(Entry, null);
            }
            catch (Exception e)
            {
               Logging.Write( Colors.Red,e.ToString());
            }
        }

        public override void OnButtonPress()
        {
            base.OnButtonPress();
            Methods["OnButtonPress"].Invoke(Entry, null);
        }

        public override void Pulse()
        {
            base.Pulse();
            Methods["Pulse"].Invoke(Entry, null);
        }

        public override void ShutDown()
        {
            base.ShutDown();
            Methods["Shutdown"].Invoke(Entry, null);
        }

        public override Composite RestBehavior => Behaviors["RestBehavior"].GetValue(Entry, null) as Composite;

        public override Composite PreCombatBuffBehavior => Behaviors["PreCombatBuffBehavior"].GetValue(Entry, null) as Composite;

        public override Composite PullBehavior => Behaviors["PullBehavior"].GetValue(Entry, null) as Composite;

        public override Composite HealBehavior => Behaviors["HealBehavior"].GetValue(Entry, null) as Composite;

        public override Composite CombatBuffBehavior => Behaviors["CombatBuffBehavior"].GetValue(Entry, null) as Composite;

        public override Composite CombatBehavior => Behaviors["CombatBehavior"].GetValue(Entry, null) as Composite;

        public override Composite PullBuffBehavior => Behaviors["PullBuffBehavior"].GetValue(Entry, null) as Composite;
    }
}