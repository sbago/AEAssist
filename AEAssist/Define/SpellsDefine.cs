using System.Collections.Generic;

namespace AEAssist.Define
{
    internal static class SpellsDefine
    {
        public static readonly SpellEntity Sprint = new SpellEntity(3,SpellTargetType.Self);
        // DPS Role

        #region DPS Role

        public static readonly SpellEntity SecondWind = new SpellEntity(7541,SpellTargetType.Self);
        public static readonly SpellEntity Bloodbath = new SpellEntity(7542,SpellTargetType.Self);
        public static readonly SpellEntity TrueNorth = new SpellEntity(7546,SpellTargetType.Self);
        public static readonly SpellEntity ArmsLength = new SpellEntity(7548,SpellTargetType.Self);
        public static readonly SpellEntity Feint = new SpellEntity(7549);
        public static readonly SpellEntity HeadGraze = new SpellEntity(7551);
        public static readonly SpellEntity FootGraze = new SpellEntity(7553);
        public static readonly SpellEntity LegGraze = new SpellEntity(7554);
        public static readonly SpellEntity Peloton = new SpellEntity(7557,SpellTargetType.Self);
        public static readonly SpellEntity LegSweep = new SpellEntity(7863);

        #endregion

        // Magic Role

        #region Magic Role

        public static readonly SpellEntity Surecast = new SpellEntity(7559);
        public static readonly SpellEntity Addle = new SpellEntity(7560);
        public static readonly SpellEntity Swiftcast = new SpellEntity(7561);
        public static readonly SpellEntity LucidDreaming = new SpellEntity(7562);
        public static readonly SpellEntity Esuna = new SpellEntity(7568);
        public static readonly SpellEntity Rescue = new SpellEntity(7571);
        public static readonly SpellEntity Repose = new SpellEntity(16560);

        #endregion

        // Tank Role

        #region Tank Role

        public static readonly SpellEntity Rampart = new SpellEntity(7531);
        public static readonly SpellEntity Provoke = new SpellEntity(7533);
        public static readonly SpellEntity Reprisal = new SpellEntity(7535);
        public static readonly SpellEntity Shirk = new SpellEntity(7537);
        public static readonly SpellEntity Interject = new SpellEntity(7538);
        public static readonly SpellEntity LowBlow = new SpellEntity(7540);

        #endregion

        // ACN

        #region ACN

        public static readonly SpellEntity Ruin = new SpellEntity(163);
        public static readonly SpellEntity SummonCarbuncle = new SpellEntity(25798);
        public static readonly SpellEntity RadiantAegis = new SpellEntity(25799);
        public static readonly SpellEntity Aethercharge = new SpellEntity(25800);
        public static readonly SpellEntity SummonRuby = new SpellEntity(25802);
        public static readonly SpellEntity Gemshine = new SpellEntity(25883);
        public static readonly SpellEntity RubyRuin = new SpellEntity(25808);
        public static readonly SpellEntity TopazRuin = new SpellEntity(25809);
        public static readonly SpellEntity EmeraldRuin = new SpellEntity(25810);
        public static readonly SpellEntity RubyRuinII = new SpellEntity(25811);
        public static readonly SpellEntity TopazRuinII = new SpellEntity(25812);
        public static readonly SpellEntity EmeraldRuinII = new SpellEntity(25813);
        public static readonly SpellEntity Fester = new SpellEntity(181);
        public static readonly SpellEntity EnergyDrain = new SpellEntity(16508);
        public static readonly SpellEntity Resurrection = new SpellEntity(173);
        public static readonly SpellEntity SummonTopaz = new SpellEntity(25803);
        public static readonly SpellEntity SummonEmerald = new SpellEntity(25804);
        public static readonly SpellEntity Outburst = new SpellEntity(16511);
        public static readonly SpellEntity PreciousBrilliance = new SpellEntity(25884);
        public static readonly SpellEntity RubyOutburst = new SpellEntity(25814);
        public static readonly SpellEntity TopazOutburst = new SpellEntity(25815);
        public static readonly SpellEntity EmeraldOutburst = new SpellEntity(25816);
        public static readonly SpellEntity Ruin2 = new SpellEntity(172);
        public static readonly SpellEntity SmnPhysick = new SpellEntity(16230);

        #endregion

        // AST

        #region AST

        public static readonly SpellEntity Draw = new SpellEntity(3590);
        public static readonly SpellEntity Redraw = new SpellEntity(3593);
        public static readonly SpellEntity Benefic = new SpellEntity(3594);
        public static readonly SpellEntity AspectedBenefic = new SpellEntity(3595);
        public static readonly SpellEntity Malefic = new SpellEntity(3596);
        public static readonly SpellEntity Malefic2 = new SpellEntity(3598);
        public static readonly SpellEntity Combust = new SpellEntity(3599);
        public static readonly SpellEntity Helios = new SpellEntity(3600);
        public static readonly SpellEntity AspectedHelios = new SpellEntity(3601);
        public static readonly SpellEntity Ascend = new SpellEntity(3603);
        public static readonly SpellEntity Lightspeed = new SpellEntity(3606);
        public static readonly SpellEntity Combust2 = new SpellEntity(3608);
        public static readonly SpellEntity Benefic2 = new SpellEntity(3610);
        public static readonly SpellEntity Synastry = new SpellEntity(3612);
        public static readonly SpellEntity CollectiveUnconscious = new SpellEntity(3613);
        public static readonly SpellEntity EssentialDignity = new SpellEntity(3614);
        public static readonly SpellEntity Gravity = new SpellEntity(3615);
        public static readonly SpellEntity Balance = new SpellEntity(4401);
        public static readonly SpellEntity Arrow = new SpellEntity(4402);
        public static readonly SpellEntity Spear = new SpellEntity(4403);
        public static readonly SpellEntity Bole = new SpellEntity(4404);
        public static readonly SpellEntity Ewer = new SpellEntity(4405);
        public static readonly SpellEntity Spire = new SpellEntity(4406);
        public static readonly SpellEntity EarthlyStar = new SpellEntity(7439);
        public static readonly SpellEntity Malefic3 = new SpellEntity(7442);
        public static readonly SpellEntity MinorArcana = new SpellEntity(7443);
        public static readonly SpellEntity LordofCrowns = new SpellEntity(7444);
        public static readonly SpellEntity LadyofCrowns = new SpellEntity(7445);
        public static readonly SpellEntity StellarDetonation = new SpellEntity(8324);
        public static readonly SpellEntity Undraw = new SpellEntity(9629);
        public static readonly SpellEntity Divination = new SpellEntity(16552);
        public static readonly SpellEntity CelestialOpposition = new SpellEntity(16553);
        public static readonly SpellEntity Combust3 = new SpellEntity(16554);
        public static readonly SpellEntity Malefic4 = new SpellEntity(16555);
        public static readonly SpellEntity CelestialIntersection = new SpellEntity(16556);
        public static readonly SpellEntity Horoscope = new SpellEntity(16557);
        public static readonly SpellEntity NeutralSect = new SpellEntity(16559);
        public static readonly SpellEntity Play = new SpellEntity(17055);
        public static readonly SpellEntity Astrodyne = new SpellEntity(25870);
        public static readonly SpellEntity CrownPlay = new SpellEntity(25869);
        public static readonly SpellEntity Exaltation = new SpellEntity(25873);
        public static readonly SpellEntity Macrocosmos = new SpellEntity(25874);
        public static readonly SpellEntity Microcosmos = new SpellEntity(25874);
        public static readonly SpellEntity FallMalefic = new SpellEntity(25871);
        public static readonly SpellEntity GravityII = new SpellEntity(25872);

        #endregion

        // BLM

        #region BLM

        public static readonly SpellEntity Fire = new SpellEntity(141);
        public static readonly SpellEntity Blizzard = new SpellEntity(142);
        public static readonly SpellEntity Thunder = new SpellEntity(144);
        public static readonly SpellEntity Fire2 = new SpellEntity(147);
        public static readonly SpellEntity Transpose = new SpellEntity(149);
        public static readonly SpellEntity Fire3 = new SpellEntity(152);
        public static readonly SpellEntity Thunder3 = new SpellEntity(153);
        public static readonly SpellEntity Blizzard3 = new SpellEntity(154);
        public static readonly SpellEntity Scathe = new SpellEntity(156);
        public static readonly SpellEntity ManaFont = new SpellEntity(158);
        public static readonly SpellEntity Flare = new SpellEntity(162);
        public static readonly SpellEntity Freeze = new SpellEntity(159);
        public static readonly SpellEntity LeyLines = new SpellEntity(3573);
        public static readonly SpellEntity Sharpcast = new SpellEntity(3574);
        public static readonly SpellEntity Enochian = new SpellEntity(3575);
        public static readonly SpellEntity Blizzard4 = new SpellEntity(3576);
        public static readonly SpellEntity Fire4 = new SpellEntity(3577);
        public static readonly SpellEntity Thunder2 = new SpellEntity(7447);
        public static readonly SpellEntity Thunder4 = new SpellEntity(7420);
        public static readonly SpellEntity Triplecast = new SpellEntity(7421);
        public static readonly SpellEntity Foul = new SpellEntity(7422);
        public static readonly SpellEntity Despair = new SpellEntity(16505);
        public static readonly SpellEntity UmbralSoul = new SpellEntity(16506);
        public static readonly SpellEntity Xenoglossy = new SpellEntity(16507);
        public static readonly SpellEntity Blizzard2 = new SpellEntity(25793);
        public static readonly SpellEntity HighFireII = new SpellEntity(25794);
        public static readonly SpellEntity HighBlizzardII = new SpellEntity(25795);
        public static readonly SpellEntity Amplifier = new SpellEntity(25796);
        public static readonly SpellEntity Paradox = new SpellEntity(25797);

        #endregion

        // BRD

        #region BRD

        //SingleTarget

        public static readonly SpellEntity HeavyShot = new SpellEntity(97);
        public static readonly SpellEntity StraightShot = new SpellEntity(98);
        public static readonly SpellEntity Bloodletter = new SpellEntity(110);
        public static readonly SpellEntity PitchPerfect = new SpellEntity(7404);
        public static readonly SpellEntity EmpyrealArrow = new SpellEntity(3558);
        public static readonly SpellEntity Sidewinder = new SpellEntity(3562);
        public static readonly SpellEntity RefulgentArrow = new SpellEntity(7409);
        public static readonly SpellEntity BurstShot = new SpellEntity(16495);

        //AoE

        public static readonly SpellEntity QuickNock = new SpellEntity(106);
        public static readonly SpellEntity RainofDeath = new SpellEntity(117);
        public static readonly SpellEntity Shadowbite = new SpellEntity(16494);
        public static readonly SpellEntity ApexArrow = new SpellEntity(16496);
        public static readonly SpellEntity Ladonsbite = new SpellEntity(25783);
        public static readonly SpellEntity BlastArrow = new SpellEntity(25784);

        //Dot

        public static readonly SpellEntity VenomousBite = new SpellEntity(100);
        public static readonly SpellEntity Windbite = new SpellEntity(113);
        public static readonly SpellEntity IronJaws = new SpellEntity(3560); //Not a DoT but will refresh both
        public static readonly SpellEntity CausticBite = new SpellEntity(7406);
        public static readonly SpellEntity Stormbite = new SpellEntity(7407);

        //Cooldowns - unsure about naming this :/

        public static readonly SpellEntity RagingStrikes = new SpellEntity(101,SpellTargetType.Self);
        public static readonly SpellEntity Barrage = new SpellEntity(107,SpellTargetType.Self);
        public static readonly SpellEntity BattleVoice = new SpellEntity(118,SpellTargetType.Self);
        public static readonly SpellEntity RadiantFinale = new SpellEntity(25785,SpellTargetType.Self);

        //Songs

        public static readonly SpellEntity MagesBallad = new SpellEntity(114);
        public static readonly SpellEntity ArmysPaeon = new SpellEntity(116);
        public static readonly SpellEntity TheWanderersMinuet = new SpellEntity(3559);

        //Utility/Movement

        public static readonly SpellEntity RepellingShot = new SpellEntity(112);
        public static readonly SpellEntity TheWardensPaean = new SpellEntity(3561,SpellTargetType.Self);
        public static readonly SpellEntity Troubadour = new SpellEntity(7405,SpellTargetType.Self);
        public static readonly SpellEntity NaturesMinne = new SpellEntity(7408,SpellTargetType.Self);

        #endregion

        // DNC

        #region DNC

        public static readonly SpellEntity Cascade = new SpellEntity(15989);
        public static readonly SpellEntity Fountain = new SpellEntity(15990);
        public static readonly SpellEntity ReverseCascade = new SpellEntity(15991);
        public static readonly SpellEntity Fountainfall = new SpellEntity(15992);
        public static readonly SpellEntity Windmill = new SpellEntity(15993);
        public static readonly SpellEntity Bladeshower = new SpellEntity(15994);
        public static readonly SpellEntity RisingWindmill = new SpellEntity(15995);
        public static readonly SpellEntity Bloodshower = new SpellEntity(15996);
        public static readonly SpellEntity StandardStep = new SpellEntity(15997);
        public static readonly SpellEntity Emboite = new SpellEntity(15999);
        public static readonly SpellEntity Entrechat = new SpellEntity(16000);
        public static readonly SpellEntity Jete = new SpellEntity(16001);
        public static readonly SpellEntity Pirouette = new SpellEntity(16002);
        public static readonly SpellEntity StandardFinish = new SpellEntity(16003);
        public static readonly SpellEntity SaberDance = new SpellEntity(16005);
        public static readonly SpellEntity ClosedPosition = new SpellEntity(16006);
        public static readonly SpellEntity FanDance = new SpellEntity(16007);
        public static readonly SpellEntity FanDance2 = new SpellEntity(16008);
        public static readonly SpellEntity FanDance3 = new SpellEntity(16009);
        public static readonly SpellEntity EnAvant = new SpellEntity(16010);
        public static readonly SpellEntity Devilment = new SpellEntity(16011);
        public static readonly SpellEntity ShieldSamba = new SpellEntity(16012);
        public static readonly SpellEntity Flourish = new SpellEntity(16013);
        public static readonly SpellEntity Improvisation = new SpellEntity(16014);
        public static readonly SpellEntity CuringWaltz = new SpellEntity(16015);
        public static readonly SpellEntity SingleStandardFinish = new SpellEntity(16191);
        public static readonly SpellEntity DoubleStandardFinish = new SpellEntity(16192);
        public static readonly SpellEntity Ending = new SpellEntity(18073);
        public static readonly SpellEntity TechnicalStep = new SpellEntity(15998);
        public static readonly SpellEntity SingleTechnicalFinish = new SpellEntity(16193);
        public static readonly SpellEntity DoubleTechnicalFinish = new SpellEntity(16194);
        public static readonly SpellEntity TripleTechnicalFinish = new SpellEntity(16195);
        public static readonly SpellEntity QuadrupleTechnicalFinish = new SpellEntity(16196);
        public static readonly SpellEntity FanDanceIV = new SpellEntity(25791);
        public static readonly SpellEntity StarfallDance = new SpellEntity(25792);
        public static readonly SpellEntity Tillana = new SpellEntity(25790);

        #endregion

        // DRG

        #region DRG

        public static readonly SpellEntity TrueThrust = new SpellEntity(75);
        public static readonly SpellEntity VorpalThrust = new SpellEntity(78);
        public static readonly SpellEntity LifeSurge = new SpellEntity(83);
        public static readonly SpellEntity DoomSpike = new SpellEntity(86);
        public static readonly SpellEntity Disembowel = new SpellEntity(87);
        public static readonly SpellEntity ChaosThrust = new SpellEntity(88);
        public static readonly SpellEntity Jump = new SpellEntity(92);
        public static readonly SpellEntity SpineshatterDive = new SpellEntity(95);
        public static readonly SpellEntity DragonfireDive = new SpellEntity(96);
        public static readonly SpellEntity BloodoftheDragon = new SpellEntity(3553);
        public static readonly SpellEntity FangAndClaw = new SpellEntity(3554);
        public static readonly SpellEntity Geirskogul = new SpellEntity(3555);
        public static readonly SpellEntity WheelingThrust = new SpellEntity(3556);
        public static readonly SpellEntity BattleLitany = new SpellEntity(3557);
        public static readonly SpellEntity MirageDive = new SpellEntity(7399);
        public static readonly SpellEntity Nastrond = new SpellEntity(7400);
        public static readonly SpellEntity LanceCharge = new SpellEntity(85);
        public static readonly SpellEntity FullThrust = new SpellEntity(84);
        public static readonly SpellEntity SonicThrust = new SpellEntity(7397);
        public static readonly SpellEntity DragonSight = new SpellEntity(7398);
        public static readonly SpellEntity CoerthanTorment = new SpellEntity(16477);
        public static readonly SpellEntity HighJump = new SpellEntity(16478);
        public static readonly SpellEntity RaidenThrust = new SpellEntity(16479);
        public static readonly SpellEntity Stardiver = new SpellEntity(16480);
        public static readonly SpellEntity HeavensThrust = new SpellEntity(25771);
        public static readonly SpellEntity ChaoticSpring = new SpellEntity(25772);
        public static readonly SpellEntity WyrmwindThrust = new SpellEntity(25773);
        public static readonly SpellEntity DraconianFury = new SpellEntity(25770);

        #endregion

        // DRK

        #region DRK

        public static readonly SpellEntity HardSlash = new SpellEntity(3617);
        public static readonly SpellEntity Unleash = new SpellEntity(3621);
        public static readonly SpellEntity SyphonStrike = new SpellEntity(3623);
        public static readonly SpellEntity Unmend = new SpellEntity(3624);
        public static readonly SpellEntity BloodWeapon = new SpellEntity(3625);
        public static readonly SpellEntity Grit = new SpellEntity(3629);
        public static readonly SpellEntity Souleater = new SpellEntity(3632);
        public static readonly SpellEntity DarkMind = new SpellEntity(3634);
        public static readonly SpellEntity ShadowWall = new SpellEntity(3636);
        public static readonly SpellEntity LivingDead = new SpellEntity(3638);
        public static readonly SpellEntity SaltedEarth = new SpellEntity(3639);
        public static readonly SpellEntity Plunge = new SpellEntity(3640);
        public static readonly SpellEntity AbyssalDrain = new SpellEntity(3641);
        public static readonly SpellEntity CarveandSpit = new SpellEntity(3643);
        public static readonly SpellEntity Delirium = new SpellEntity(7390);
        public static readonly SpellEntity Quietus = new SpellEntity(7391);
        public static readonly SpellEntity Bloodspiller = new SpellEntity(7392);
        public static readonly SpellEntity TheBlackestNight = new SpellEntity(7393);
        public static readonly SpellEntity FloodofDarkness = new SpellEntity(16466);
        public static readonly SpellEntity EdgeofDarkness = new SpellEntity(16467);
        public static readonly SpellEntity StalwartSoul = new SpellEntity(16468);
        public static readonly SpellEntity FloodofShadow = new SpellEntity(16469);
        public static readonly SpellEntity EdgeofShadow = new SpellEntity(16470);
        public static readonly SpellEntity DarkMissionary = new SpellEntity(16471);
        public static readonly SpellEntity LivingShadow = new SpellEntity(16472);
        public static readonly SpellEntity Oblation = new SpellEntity(25754);
        public static readonly SpellEntity Shadowbringer = new SpellEntity(25757);

        #endregion

        // GNB

        #region GNB

        public static readonly SpellEntity KeenEdge = new SpellEntity(16137);
        public static readonly SpellEntity NoMercy = new SpellEntity(16138);
        public static readonly SpellEntity BrutalShell = new SpellEntity(16139);
        public static readonly SpellEntity Camouflage = new SpellEntity(16140);
        public static readonly SpellEntity DemonSlice = new SpellEntity(16141);
        public static readonly SpellEntity RoyalGuard = new SpellEntity(16142);
        public static readonly SpellEntity LightningShot = new SpellEntity(16143);
        public static readonly SpellEntity DangerZone = new SpellEntity(16144);
        public static readonly SpellEntity SolidBarrel = new SpellEntity(16145);
        public static readonly SpellEntity GnashingFang = new SpellEntity(16146);
        public static readonly SpellEntity SavageClaw = new SpellEntity(16147);
        public static readonly SpellEntity Nebula = new SpellEntity(16148);
        public static readonly SpellEntity DemonSlaughter = new SpellEntity(16149);
        public static readonly SpellEntity WickedTalon = new SpellEntity(16150);
        public static readonly SpellEntity Aurora = new SpellEntity(16151);
        public static readonly SpellEntity Superbolide = new SpellEntity(16152);
        public static readonly SpellEntity SonicBreak = new SpellEntity(16153);
        public static readonly SpellEntity RoughDivide = new SpellEntity(16154);
        public static readonly SpellEntity Continuation = new SpellEntity(16155);
        public static readonly SpellEntity JugularRip = new SpellEntity(16156);
        public static readonly SpellEntity AbdomenTear = new SpellEntity(16157);
        public static readonly SpellEntity EyeGouge = new SpellEntity(16158);
        public static readonly SpellEntity BowShock = new SpellEntity(16159);
        public static readonly SpellEntity HeartofLight = new SpellEntity(16160);
        public static readonly SpellEntity HeartofStone = new SpellEntity(16161);
        public static readonly SpellEntity BurstStrike = new SpellEntity(16162);
        public static readonly SpellEntity FatedCircle = new SpellEntity(16163);
        public static readonly SpellEntity Bloodfest = new SpellEntity(16164);
        public static readonly SpellEntity BlastingZone = new SpellEntity(16165);
        public static readonly SpellEntity HeartOfCorundum = new SpellEntity(25758);
        public static readonly SpellEntity DoubleDown = new SpellEntity(25760);
        public static readonly SpellEntity Hypervelocity = new SpellEntity(25759);

        #endregion

        // MCH

        #region MCH

        public static readonly SpellEntity RookAutoturret = new SpellEntity(2864);
        public static readonly SpellEntity SplitShot = new SpellEntity(2866);
        public static readonly SpellEntity SlugShot = new SpellEntity(2868);
        public static readonly SpellEntity SpreadShot = new SpellEntity(2870);
        public static readonly SpellEntity HotShot = new SpellEntity(2872);
        public static readonly SpellEntity CleanShot = new SpellEntity(2873);
        public static readonly SpellEntity GaussRound = new SpellEntity(2874);
        public static readonly SpellEntity Reassemble = new SpellEntity(2876,SpellTargetType.Self);
        public static readonly SpellEntity Wildfire = new SpellEntity(2878);
        public static readonly SpellEntity Ricochet = new SpellEntity(2890);
        public static readonly SpellEntity HeatBlast = new SpellEntity(7410);
        public static readonly SpellEntity HeatedSplitShot = new SpellEntity(7411);
        public static readonly SpellEntity HeatedSlugShot = new SpellEntity(7412);
        public static readonly SpellEntity HeatedCleanShot = new SpellEntity(7413);
        public static readonly SpellEntity BarrelStabilizer = new SpellEntity(7414);
        public static readonly SpellEntity RookOverdrive = new SpellEntity(7415);
        public static readonly SpellEntity Flamethrower = new SpellEntity(7418);
        public static readonly SpellEntity AutoCrossbow = new SpellEntity(16497);
        public static readonly SpellEntity Drill = new SpellEntity(16498);
        public static readonly SpellEntity Bioblaster = new SpellEntity(16499);
        public static readonly SpellEntity AirAnchor = new SpellEntity(16500);
        public static readonly SpellEntity AutomationQueen = new SpellEntity(16501);
        public static readonly SpellEntity QueenOverdrive = new SpellEntity(16502);
        public static readonly SpellEntity Detonator = new SpellEntity(16766);
        public static readonly SpellEntity Tactician = new SpellEntity(16889,SpellTargetType.Self);
        public static readonly SpellEntity Hypercharge = new SpellEntity(17209,SpellTargetType.Self);
        public static readonly SpellEntity Scattergun = new SpellEntity(25786);
        public static readonly SpellEntity ChainSaw = new SpellEntity(25788);

        public static readonly SpellEntity PVPDrill = new SpellEntity(17749);
        public static readonly SpellEntity PVPRicochet = new SpellEntity(17753);
        public static readonly SpellEntity PVPGaussRound = new SpellEntity(18933);
        public static readonly SpellEntity PVPHypercharge = new SpellEntity(17754);
        public static readonly SpellEntity PVPWildfire = new SpellEntity(8855);
        public static readonly SpellEntity PVPAirAnchor = new SpellEntity(17750);
        public static readonly SpellEntity PVPSpreadShot = new SpellEntity(18932);

        #endregion

        // MNK

        #region MNK

        public static readonly SpellEntity ArmOfTheDestroyer = new SpellEntity(62);
        public static readonly SpellEntity Bootshine = new SpellEntity(53);
        public static readonly SpellEntity TrueStrike = new SpellEntity(54);

        public static readonly SpellEntity SnapPunch = new SpellEntity(56);

        //public static readonly SpellEntity FistsOfEarth = new SpellEntity(60);
        public static readonly SpellEntity TwinSnakes = new SpellEntity(61);
        public static readonly SpellEntity Demolish = new SpellEntity(66);

        public static readonly SpellEntity Rockbreaker = new SpellEntity(70);

        //public static readonly SpellEntity FistsOfWind = new SpellEntity(73);
        //public static readonly SpellEntity ShoulderTackle = new SpellEntity(71);
        //public static readonly SpellEntity FistsOfFire = new SpellEntity(63);
        public static readonly SpellEntity Mantra = new SpellEntity(65);
        public static readonly SpellEntity PerfectBalance = new SpellEntity(69);
        public static readonly SpellEntity DragonKick = new SpellEntity(74);
        public static readonly SpellEntity TheForbiddenChakra = new SpellEntity(3547);
        public static readonly SpellEntity ElixirField = new SpellEntity(3545);
        public static readonly SpellEntity RiddleofEarth = new SpellEntity(7394);
        public static readonly SpellEntity RiddleofFire = new SpellEntity(7395);
        public static readonly SpellEntity Brotherhood = new SpellEntity(7396);
        public static readonly SpellEntity FormShift = new SpellEntity(4262);
        public static readonly SpellEntity FourPointFury = new SpellEntity(16473);
        public static readonly SpellEntity Enlightenment = new SpellEntity(16474);
        public static readonly SpellEntity TornadoKick = new SpellEntity(3543);
        public static readonly SpellEntity MasterfulBlitz = new SpellEntity(25764);
        public static readonly SpellEntity ShadowOfTheDestroyer = new SpellEntity(25767);

        #endregion

        // NIN

        #region NIN

        public static readonly SpellEntity SpinningEdge = new SpellEntity(2240);
        public static readonly SpellEntity ShadeShift = new SpellEntity(2241);
        public static readonly SpellEntity GustSlash = new SpellEntity(2242);
        public static readonly SpellEntity Hide = new SpellEntity(2245);
        public static readonly SpellEntity Assassinate = new SpellEntity(2246);
        public static readonly SpellEntity ThrowingDagger = new SpellEntity(2247);
        public static readonly SpellEntity Mug = new SpellEntity(2248);
        public static readonly SpellEntity DeathBlossom = new SpellEntity(2254);
        public static readonly SpellEntity AeolianEdge = new SpellEntity(2255);
        public static readonly SpellEntity ShadowFang = new SpellEntity(2257);
        public static readonly SpellEntity TrickAttack = new SpellEntity(2258);
        public static readonly SpellEntity Ten = new SpellEntity(2259);
        public static readonly SpellEntity Ninjutsu = new SpellEntity(2260);
        public static readonly SpellEntity Chi = new SpellEntity(2261);
        public static readonly SpellEntity Shukuchi = new SpellEntity(2262);
        public static readonly SpellEntity Jin = new SpellEntity(2263);
        public static readonly SpellEntity Kassatsu = new SpellEntity(2264);
        public static readonly SpellEntity FumaShuriken = new SpellEntity(2265);
        public static readonly SpellEntity Katon = new SpellEntity(2266);
        public static readonly SpellEntity Raiton = new SpellEntity(2267);
        public static readonly SpellEntity Hyoton = new SpellEntity(2268);
        public static readonly SpellEntity Huton = new SpellEntity(2269);
        public static readonly SpellEntity Doton = new SpellEntity(2270);
        public static readonly SpellEntity Suiton = new SpellEntity(2271);
        public static readonly SpellEntity RabbitMedium = new SpellEntity(2272);
        public static readonly SpellEntity ArmorCrush = new SpellEntity(3563);
        public static readonly SpellEntity DreamWithinaDream = new SpellEntity(3566);
        public static readonly SpellEntity HellfrogMedium = new SpellEntity(7401);
        public static readonly SpellEntity Bhavacakra = new SpellEntity(7402);
        public static readonly SpellEntity TenChiJin = new SpellEntity(7403);
        public static readonly SpellEntity HakkeMujinsatsu = new SpellEntity(16488);
        public static readonly SpellEntity Meisui = new SpellEntity(16489);
        public static readonly SpellEntity GokaMekkyaku = new SpellEntity(16491);
        public static readonly SpellEntity HyoshoRanryu = new SpellEntity(16492);
        public static readonly SpellEntity Bunshin = new SpellEntity(16493);
        public static readonly SpellEntity PhantomKamaitachi = new SpellEntity(25774);
        public static readonly SpellEntity ForkedRaiju = new SpellEntity(25777);

        public static readonly SpellEntity LimitBreak = new SpellEntity(209);

        #endregion

        // PLD

        #region PLD

        public static readonly SpellEntity Sentinel = new SpellEntity(17);
        public static readonly SpellEntity FightorFlight = new SpellEntity(20);
        public static readonly SpellEntity Cover = new SpellEntity(27);
        public static readonly SpellEntity HallowedGround = new SpellEntity(30);
        public static readonly SpellEntity DivineVeil = new SpellEntity(3540);
        public static readonly SpellEntity Sheltron = new SpellEntity(3542);
        public static readonly SpellEntity CircleofScorn = new SpellEntity(23);
        public static readonly SpellEntity SpiritsWithin = new SpellEntity(29);
        public static readonly SpellEntity IronWill = new SpellEntity(28);
        public static readonly SpellEntity Clemency = new SpellEntity(3541);
        public static readonly SpellEntity FastBlade = new SpellEntity(9);
        public static readonly SpellEntity RiotBlade = new SpellEntity(15);
        public static readonly SpellEntity ShieldBash = new SpellEntity(16);
        public static readonly SpellEntity RageofHalone = new SpellEntity(21);
        public static readonly SpellEntity ShieldLob = new SpellEntity(24);
        public static readonly SpellEntity GoringBlade = new SpellEntity(3538);
        public static readonly SpellEntity RoyalAuthority = new SpellEntity(3539);
        public static readonly SpellEntity TotalEclipse = new SpellEntity(7381);
        public static readonly SpellEntity Intervention = new SpellEntity(7382);
        public static readonly SpellEntity HolySpirit = new SpellEntity(7384);
        public static readonly SpellEntity Requiescat = new SpellEntity(7383);
        public static readonly SpellEntity Prominance = new SpellEntity(16457);
        public static readonly SpellEntity HolyCircle = new SpellEntity(16458);
        public static readonly SpellEntity Intervene = new SpellEntity(16461);
        public static readonly SpellEntity Atonement = new SpellEntity(16460);
        public static readonly SpellEntity Confiteor = new SpellEntity(16459);
        public static readonly SpellEntity HolySheltron = new SpellEntity(25746);
        public static readonly SpellEntity Expiacion = new SpellEntity(25747);
        public static readonly SpellEntity BladeOfFaith = new SpellEntity(25748);
        public static readonly SpellEntity BladeOfTruth = new SpellEntity(25749);
        public static readonly SpellEntity BladeOfValor = new SpellEntity(25750);

        #endregion

        // RDM

        #region RDM

        public static readonly SpellEntity Jolt = new SpellEntity(7503);
        public static readonly SpellEntity Riposte = new SpellEntity(7504);
        public static readonly SpellEntity Verthunder = new SpellEntity(7505);
        public static readonly SpellEntity CorpsACorps = new SpellEntity(7506);
        public static readonly SpellEntity Veraero = new SpellEntity(7507);
        public static readonly SpellEntity Scatter = new SpellEntity(7509);
        public static readonly SpellEntity Verfire = new SpellEntity(7510);
        public static readonly SpellEntity Verstone = new SpellEntity(7511);
        public static readonly SpellEntity Zwerchhau = new SpellEntity(7512);
        public static readonly SpellEntity Moulinet = new SpellEntity(7530);
        public static readonly SpellEntity Vercure = new SpellEntity(7514);
        public static readonly SpellEntity Displacement = new SpellEntity(7515);
        public static readonly SpellEntity Redoublement = new SpellEntity(7516);
        public static readonly SpellEntity Fleche = new SpellEntity(7517);
        public static readonly SpellEntity Acceleration = new SpellEntity(7518);
        public static readonly SpellEntity ContreSixte = new SpellEntity(7519);
        public static readonly SpellEntity Embolden = new SpellEntity(7520);
        public static readonly SpellEntity Manafication = new SpellEntity(7521);
        public static readonly SpellEntity Verraise = new SpellEntity(7523);
        public static readonly SpellEntity Jolt2 = new SpellEntity(7524);
        public static readonly SpellEntity Verflare = new SpellEntity(7525);
        public static readonly SpellEntity Verholy = new SpellEntity(7526);
        public static readonly SpellEntity EnchantedRedoublement = new SpellEntity(7529);
        public static readonly SpellEntity Verthunder2 = new SpellEntity(16524);
        public static readonly SpellEntity Veraero2 = new SpellEntity(16525);
        public static readonly SpellEntity Impact = new SpellEntity(16526);
        public static readonly SpellEntity Engagement = new SpellEntity(16527);
        public static readonly SpellEntity Reprise = new SpellEntity(16528);
        public static readonly SpellEntity Scorch = new SpellEntity(16530);
        public static readonly SpellEntity Resolution = new SpellEntity(25858);
        public static readonly SpellEntity VerthunderIII = new SpellEntity(25855);
        public static readonly SpellEntity VeraeroIII = new SpellEntity(25856);
        public static readonly SpellEntity MagickBarrier = new SpellEntity(25857);

        #endregion

        // SAM

        #region SAM

        public static readonly SpellEntity Hakaze = new SpellEntity(7477);
        public static readonly SpellEntity Shoha = new SpellEntity(16487);
        public static readonly SpellEntity Jinpu = new SpellEntity(7478);
        public static readonly SpellEntity Shifu = new SpellEntity(7479);
        public static readonly SpellEntity Yukikaze = new SpellEntity(7480);
        public static readonly SpellEntity Gekko = new SpellEntity(7481);
        public static readonly SpellEntity Kasha = new SpellEntity(7482);
        public static readonly SpellEntity Fuga = new SpellEntity(7483);
        public static readonly SpellEntity Mangetsu = new SpellEntity(7484);
        public static readonly SpellEntity Oka = new SpellEntity(7485);
        public static readonly SpellEntity Enpi = new SpellEntity(7486);
        public static readonly SpellEntity MidareSetsugekka = new SpellEntity(7487);
        public static readonly SpellEntity KaeshiSetsugekka = new SpellEntity(16486);
        public static readonly SpellEntity TenkaGoken = new SpellEntity(7488);
        public static readonly SpellEntity KaeshiGoken = new SpellEntity(16485);
        public static readonly SpellEntity Higanbana = new SpellEntity(7489);
        public static readonly SpellEntity KaeshiHiganbana = new SpellEntity(16484);
        public static readonly SpellEntity HissatsuShinten = new SpellEntity(7490);
        public static readonly SpellEntity HissatsuKyuten = new SpellEntity(7491);
        public static readonly SpellEntity HissatsuKaiten = new SpellEntity(7494);
        public static readonly SpellEntity Ikishoten = new SpellEntity(16482);
        public static readonly SpellEntity HissatsuGuren = new SpellEntity(7496);
        public static readonly SpellEntity HissatsuSenei = new SpellEntity(16481);
        public static readonly SpellEntity Meditate = new SpellEntity(7497);
        public static readonly SpellEntity ThirdEye = new SpellEntity(7498,SpellTargetType.Self);

        public static readonly SpellEntity MeikyoShisui = new SpellEntity(7499);

        //public static readonly SpellEntity HissatsuSeigan = new SpellEntity(7501);
        public static readonly SpellEntity Meditation = new SpellEntity(3546,SpellTargetType.Self);
        public static readonly SpellEntity ShohaII = new SpellEntity(25779);
        public static readonly SpellEntity Fuko = new SpellEntity(25780);
        public static readonly SpellEntity OgiNamikiri = new SpellEntity(25781);
        public static readonly SpellEntity KaeshiNamikiri = new SpellEntity(25782);

        #endregion

        // SGE

        #region SGE

        public static readonly SpellEntity Dosis = new SpellEntity(24283);
        public static readonly SpellEntity Diagnosis = new SpellEntity(24284);
        public static readonly SpellEntity Kardia = new SpellEntity(24285);
        public static readonly SpellEntity Prognosis = new SpellEntity(24286);
        public static readonly SpellEntity Egeiro = new SpellEntity(24287);
        public static readonly SpellEntity Physis = new SpellEntity(24288);
        public static readonly SpellEntity PhysisII = new SpellEntity(24302);
        public static readonly SpellEntity Phlegma = new SpellEntity(24289);
        public static readonly SpellEntity PhlegmaII = new SpellEntity(24307);
        public static readonly SpellEntity PhlegmaIII = new SpellEntity(24313);
        public static readonly SpellEntity Eukrasia = new SpellEntity(24290);
        public static readonly SpellEntity EukrasianDiagnosis = new SpellEntity(24291);
        public static readonly SpellEntity EukrasianPrognosis = new SpellEntity(24292);
        public static readonly SpellEntity EukrasianDosis = new SpellEntity(24293);
        public static readonly SpellEntity Soteria = new SpellEntity(24294);
        public static readonly SpellEntity Druochole = new SpellEntity(24296);
        public static readonly SpellEntity Dyskrasia = new SpellEntity(24297);
        public static readonly SpellEntity Kerachole = new SpellEntity(24298);
        public static readonly SpellEntity Ixochole = new SpellEntity(24299);
        public static readonly SpellEntity Zoe = new SpellEntity(24300);
        public static readonly SpellEntity Pepsis = new SpellEntity(24301);
        public static readonly SpellEntity Taurochole = new SpellEntity(24303);
        public static readonly SpellEntity Toxikon = new SpellEntity(24304);
        public static readonly SpellEntity ToxikonII = new SpellEntity(24316);
        public static readonly SpellEntity Haima = new SpellEntity(24305);
        public static readonly SpellEntity DosisII = new SpellEntity(24306);
        public static readonly SpellEntity EukrasianDosisII = new SpellEntity(24308);
        public static readonly SpellEntity Rhizomata = new SpellEntity(24309);
        public static readonly SpellEntity Holos = new SpellEntity(24310);
        public static readonly SpellEntity Panhaima = new SpellEntity(24311);
        public static readonly SpellEntity DosisIII = new SpellEntity(24312);
        public static readonly SpellEntity EukrasianDosisIII = new SpellEntity(24314);
        public static readonly SpellEntity DyskrasiaII = new SpellEntity(24315);
        public static readonly SpellEntity Krasis = new SpellEntity(24317);
        public static readonly SpellEntity Pneuma = new SpellEntity(24318);

        #endregion

        // SCH

        #region SCH

        public static readonly SpellEntity Aetherflow = new SpellEntity(166);
        public static readonly SpellEntity EnergyDrain2 = new SpellEntity(167);
        public static readonly SpellEntity Adloquium = new SpellEntity(185);
        public static readonly SpellEntity Succor = new SpellEntity(186);
        public static readonly SpellEntity SacredSoil = new SpellEntity(188);
        public static readonly SpellEntity Lustrate = new SpellEntity(189);
        public static readonly SpellEntity Physick = new SpellEntity(190);
        public static readonly SpellEntity Indomitability = new SpellEntity(3583);
        public static readonly SpellEntity SchRuin = new SpellEntity(17869);
        public static readonly SpellEntity Broil = new SpellEntity(3584);
        public static readonly SpellEntity DeploymentTactics = new SpellEntity(3585);
        public static readonly SpellEntity EmergencyTactics = new SpellEntity(3586);
        public static readonly SpellEntity Dissipation = new SpellEntity(3587);
        public static readonly SpellEntity Excogitation = new SpellEntity(7434);
        public static readonly SpellEntity Broil2 = new SpellEntity(7435);
        public static readonly SpellEntity ChainStrategem = new SpellEntity(7436);
        public static readonly SpellEntity Aetherpact = new SpellEntity(7437);
        public static readonly SpellEntity DissolveUnion = new SpellEntity(7869);
        public static readonly SpellEntity WhisperingDawn = new SpellEntity(16537);
        public static readonly SpellEntity FeyIllumination = new SpellEntity(16538);
        public static readonly SpellEntity ArtOfWar = new SpellEntity(16539);
        public static readonly SpellEntity Biolysis = new SpellEntity(16540);
        public static readonly SpellEntity Broil3 = new SpellEntity(16541);
        public static readonly SpellEntity Recitation = new SpellEntity(16542);
        public static readonly SpellEntity FeyBlessing = new SpellEntity(16543);
        public static readonly SpellEntity SummonSeraph = new SpellEntity(16545);
        public static readonly SpellEntity Consolation = new SpellEntity(16546);
        public static readonly SpellEntity SummonEos = new SpellEntity(17215);
        public static readonly SpellEntity SummonSelene = new SpellEntity(17216);
        public static readonly SpellEntity BroilIV = new SpellEntity(25865);
        public static readonly SpellEntity ArtOfWarII = new SpellEntity(25866);
        public static readonly SpellEntity Protraction = new SpellEntity(25867);
        public static readonly SpellEntity Expedient = new SpellEntity(25868);
        public static readonly SpellEntity Bio = new SpellEntity(17864);
        public static readonly SpellEntity Enkindle = new SpellEntity(184);

        #endregion

        // SMN

        #region SMN

        public static readonly SpellEntity SummonIfrit = new SpellEntity(25805);
        public static readonly SpellEntity SummonTitan = new SpellEntity(25806);
        public static readonly SpellEntity Painflare = new SpellEntity(3578);
        public static readonly SpellEntity SummonGaruda = new SpellEntity(25807);
        public static readonly SpellEntity EnergySiphon = new SpellEntity(16510);
        public static readonly SpellEntity Ruin3 = new SpellEntity(3579);
        public static readonly SpellEntity RubyRuinIII = new SpellEntity(25817);
        public static readonly SpellEntity TopazRuinIII = new SpellEntity(25818);
        public static readonly SpellEntity EmeraldRuinIII = new SpellEntity(25819);
        public static readonly SpellEntity DreadwyrmTrance = new SpellEntity(3581);
        public static readonly SpellEntity AstralFlow = new SpellEntity(25822);
        public static readonly SpellEntity Ruin4 = new SpellEntity(7426);
        public static readonly SpellEntity SearingLight = new SpellEntity(25801);
        public static readonly SpellEntity SummonBahamut = new SpellEntity(7427);
        public static readonly SpellEntity EnkindleBahamut = new SpellEntity(7429);
        public static readonly SpellEntity TriDisaster = new SpellEntity(25826);
        public static readonly SpellEntity SummonIfrit2 = new SpellEntity(25838);
        public static readonly SpellEntity SummonTitan2 = new SpellEntity(25839);
        public static readonly SpellEntity SummonGaruda2 = new SpellEntity(25840);
        public static readonly SpellEntity AstralImpulse = new SpellEntity(25820);
        public static readonly SpellEntity AstralFlare = new SpellEntity(25821);
        public static readonly SpellEntity Deathflare = new SpellEntity(3582);
        public static readonly SpellEntity Wyrmwave = new SpellEntity(7428);
        public static readonly SpellEntity AkhMorn = new SpellEntity(3010);
        public static readonly SpellEntity RubyRite = new SpellEntity(25823);
        public static readonly SpellEntity TopazRite = new SpellEntity(25824);
        public static readonly SpellEntity EmeraldRite = new SpellEntity(25825);
        public static readonly SpellEntity FountainofFire = new SpellEntity(16514);
        public static readonly SpellEntity BrandofPurgatory = new SpellEntity(16515);
        public static readonly SpellEntity SummonPhoenix = new SpellEntity(25831);
        public static readonly SpellEntity EverlastingFlight = new SpellEntity(16517);
        public static readonly SpellEntity Rekindle = new SpellEntity(25830);
        public static readonly SpellEntity ScarletFlame = new SpellEntity(16508);
        public static readonly SpellEntity EnkindlePhoenix = new SpellEntity(16516);
        public static readonly SpellEntity Revelation = new SpellEntity(2951);
        public static readonly SpellEntity RubyDisaster = new SpellEntity(25827);
        public static readonly SpellEntity TopazDisaster = new SpellEntity(25828);
        public static readonly SpellEntity EmeraldDisaster = new SpellEntity(25829);
        public static readonly SpellEntity RubyCatastrophe = new SpellEntity(25832);
        public static readonly SpellEntity TopazCatastrophe = new SpellEntity(25833);
        public static readonly SpellEntity EmeraldCatastrophe = new SpellEntity(25834);
        public static readonly SpellEntity CrimsonCyclone = new SpellEntity(25835);
        public static readonly SpellEntity CrimsonStrike = new SpellEntity(25885);
        public static readonly SpellEntity MountainBuster = new SpellEntity(25836);
        public static readonly SpellEntity Slipstream = new SpellEntity(25837);

        #endregion

        // WAR

        #region WAR

        public static readonly SpellEntity HeavySwing = new SpellEntity(31);
        public static readonly SpellEntity Maim = new SpellEntity(37);
        public static readonly SpellEntity Berserk = new SpellEntity(38);
        public static readonly SpellEntity ThrillofBattle = new SpellEntity(40);
        public static readonly SpellEntity Overpower = new SpellEntity(41);
        public static readonly SpellEntity StormsPath = new SpellEntity(42);
        public static readonly SpellEntity Holmgang = new SpellEntity(43);
        public static readonly SpellEntity Vengeance = new SpellEntity(44);
        public static readonly SpellEntity StormsEye = new SpellEntity(45);
        public static readonly SpellEntity Tomahawk = new SpellEntity(46);
        public static readonly SpellEntity Defiance = new SpellEntity(48);
        public static readonly SpellEntity InnerBeast = new SpellEntity(49);
        public static readonly SpellEntity SteelCyclone = new SpellEntity(51);
        public static readonly SpellEntity Infuriate = new SpellEntity(52);
        public static readonly SpellEntity FellCleave = new SpellEntity(3549);
        public static readonly SpellEntity Decimate = new SpellEntity(3550);
        public static readonly SpellEntity RawIntuition = new SpellEntity(3551);
        public static readonly SpellEntity Equilibrium = new SpellEntity(3552);
        public static readonly SpellEntity Onslaught = new SpellEntity(7386);
        public static readonly SpellEntity Upheaval = new SpellEntity(7387);
        public static readonly SpellEntity ShakeItOff = new SpellEntity(7388);
        public static readonly SpellEntity InnerRelease = new SpellEntity(7389);
        public static readonly SpellEntity MythrilTempest = new SpellEntity(16462);
        public static readonly SpellEntity InnerChaos = new SpellEntity(16465);
        public static readonly SpellEntity ChaoticCyclone = new SpellEntity(16463);
        public static readonly SpellEntity Bloodwhetting = new SpellEntity(25751);
        public static readonly SpellEntity Orogeny = new SpellEntity(25752);
        public static readonly SpellEntity PrimalRend = new SpellEntity(25753);
        public static readonly SpellEntity NascentFlash = new SpellEntity(16464);

        #endregion

        // WHM

        #region WHM

        public static readonly SpellEntity Stone = new SpellEntity(119);
        public static readonly SpellEntity Cure = new SpellEntity(120);
        public static readonly SpellEntity Aero = new SpellEntity(121);
        public static readonly SpellEntity Medica = new SpellEntity(124);
        public static readonly SpellEntity Raise = new SpellEntity(125);
        public static readonly SpellEntity Stone2 = new SpellEntity(127);
        public static readonly SpellEntity Cure3 = new SpellEntity(131);
        public static readonly SpellEntity Aero2 = new SpellEntity(132);

        public static readonly SpellEntity Medica2 = new SpellEntity(133);

        //public static readonly SpellEntity FluidAura = new SpellEntity(134);
        public static readonly SpellEntity Cure2 = new SpellEntity(135);
        public static readonly SpellEntity PresenceofMind = new SpellEntity(136);
        public static readonly SpellEntity Regen = new SpellEntity(137);
        public static readonly SpellEntity Holy = new SpellEntity(139);
        public static readonly SpellEntity Benediction = new SpellEntity(140);
        public static readonly SpellEntity Stone3 = new SpellEntity(3568);
        public static readonly SpellEntity Asylum = new SpellEntity(3569);
        public static readonly SpellEntity Tetragrammaton = new SpellEntity(3570);
        public static readonly SpellEntity Assize = new SpellEntity(3571);
        public static readonly SpellEntity ThinAir = new SpellEntity(7430);
        public static readonly SpellEntity Stone4 = new SpellEntity(7431);
        public static readonly SpellEntity DivineBenison = new SpellEntity(7432);
        public static readonly SpellEntity PlenaryIndulgence = new SpellEntity(7433);
        public static readonly SpellEntity AfflatusSolace = new SpellEntity(16531);
        public static readonly SpellEntity Dia = new SpellEntity(16532);
        public static readonly SpellEntity Glare = new SpellEntity(16533);
        public static readonly SpellEntity AfflatusRapture = new SpellEntity(16534);
        public static readonly SpellEntity AfflatusMisery = new SpellEntity(16535);
        public static readonly SpellEntity Temperance = new SpellEntity(16536);
        public static readonly SpellEntity GlareIII = new SpellEntity(25859);
        public static readonly SpellEntity HolyIII = new SpellEntity(25860);
        public static readonly SpellEntity Aquaveil = new SpellEntity(25861);
        public static readonly SpellEntity LiturgyOfTheBell = new SpellEntity(25862);

        #endregion

        // BLU

        #region BLU

        public static readonly SpellEntity Snort = new SpellEntity(11383);
        public static readonly SpellEntity FourTonzWeight = new SpellEntity(11384);
        public static readonly SpellEntity WaterCannon = new SpellEntity(11385);
        public static readonly SpellEntity SongOfTorment = new SpellEntity(11386);
        public static readonly SpellEntity HighVoltage = new SpellEntity(11387);
        public static readonly SpellEntity BadBreath = new SpellEntity(11388);
        public static readonly SpellEntity FlyingFrenzy = new SpellEntity(11389);
        public static readonly SpellEntity AquaBreath = new SpellEntity(11390);
        public static readonly SpellEntity Plaincracker = new SpellEntity(11391);
        public static readonly SpellEntity AcornBomb = new SpellEntity(11392);
        public static readonly SpellEntity Bristle = new SpellEntity(11393);
        public static readonly SpellEntity MindBlast = new SpellEntity(11394);
        public static readonly SpellEntity BloodDrain = new SpellEntity(11395);
        public static readonly SpellEntity BombToss = new SpellEntity(11396);
        public static readonly SpellEntity ThousandNeedles = new SpellEntity(11397);
        public static readonly SpellEntity DrillCannons = new SpellEntity(11398);
        public static readonly SpellEntity TheLook = new SpellEntity(11399);
        public static readonly SpellEntity SharpKnife = new SpellEntity(11400);
        public static readonly SpellEntity Loom = new SpellEntity(11401);
        public static readonly SpellEntity FlameThrower = new SpellEntity(11402);
        public static readonly SpellEntity Faze = new SpellEntity(11403);
        public static readonly SpellEntity Glower = new SpellEntity(11404);
        public static readonly SpellEntity Missile = new SpellEntity(11405);
        public static readonly SpellEntity WhiteWind = new SpellEntity(11406);
        public static readonly SpellEntity FinalSting = new SpellEntity(11407);
        public static readonly SpellEntity SelfDestruct = new SpellEntity(11408);
        public static readonly SpellEntity Transfusion = new SpellEntity(11409);
        public static readonly SpellEntity ToadOil = new SpellEntity(11410);
        public static readonly SpellEntity OffGuard = new SpellEntity(11411);
        public static readonly SpellEntity StickyTong = new SpellEntity(11412);
        public static readonly SpellEntity TailScrew = new SpellEntity(11413);
        public static readonly SpellEntity LevelFivePetrify = new SpellEntity(11414);
        public static readonly SpellEntity MoonFlute = new SpellEntity(11415);
        public static readonly SpellEntity Doom = new SpellEntity(11416);
        public static readonly SpellEntity MightyGuard = new SpellEntity(11417);
        public static readonly SpellEntity IceSpikes = new SpellEntity(11418);
        public static readonly SpellEntity TheRamVoice = new SpellEntity(11419);
        public static readonly SpellEntity TheDragonVoice = new SpellEntity(11420);
        public static readonly SpellEntity PeculiarLight = new SpellEntity(11421);
        public static readonly SpellEntity InkJet = new SpellEntity(11422);
        public static readonly SpellEntity FlyingSardine = new SpellEntity(11423);
        public static readonly SpellEntity DiamondBack = new SpellEntity(11424);
        public static readonly SpellEntity FireAngon = new SpellEntity(11425);
        public static readonly SpellEntity FeatherRain = new SpellEntity(11426);
        public static readonly SpellEntity Eruption = new SpellEntity(11427);
        public static readonly SpellEntity BluMountainBuster = new SpellEntity(11428);
        public static readonly SpellEntity ShockStrike = new SpellEntity(11429);
        public static readonly SpellEntity GlassDance = new SpellEntity(11430);
        public static readonly SpellEntity VeilOfTheWhorl = new SpellEntity(11431);
        public static readonly SpellEntity AlpineDraft = new SpellEntity(18295);
        public static readonly SpellEntity ProteanWave = new SpellEntity(18296);
        public static readonly SpellEntity Northerlies = new SpellEntity(118297);
        public static readonly SpellEntity Electrogenesis = new SpellEntity(18298);
        public static readonly SpellEntity Kaltstrahl = new SpellEntity(18299);
        public static readonly SpellEntity AbyssalTransfixion = new SpellEntity(18300);
        public static readonly SpellEntity Chirp = new SpellEntity(18301);
        public static readonly SpellEntity EerieSoundwave = new SpellEntity(18302);
        public static readonly SpellEntity PomCure = new SpellEntity(18303);
        public static readonly SpellEntity GobSkin = new SpellEntity(18304);
        public static readonly SpellEntity MagicHammer = new SpellEntity(18305);
        public static readonly SpellEntity Avail = new SpellEntity(18306);
        public static readonly SpellEntity FrogLegs = new SpellEntity(18307);
        public static readonly SpellEntity SonicBoom = new SpellEntity(18308);
        public static readonly SpellEntity Whistle = new SpellEntity(18309);
        public static readonly SpellEntity WhiteKnightsTour = new SpellEntity(18310);
        public static readonly SpellEntity BlackKnightsTour = new SpellEntity(18311);
        public static readonly SpellEntity LevelFiveDeath = new SpellEntity(18312);
        public static readonly SpellEntity Launcher = new SpellEntity(18313);
        public static readonly SpellEntity PerpetualRay = new SpellEntity(18314);
        public static readonly SpellEntity Cactguard = new SpellEntity(18315);
        public static readonly SpellEntity RevengeBlast = new SpellEntity(18316);
        public static readonly SpellEntity AngelWhisper = new SpellEntity(18317);
        public static readonly SpellEntity Exuviation = new SpellEntity(18318);
        public static readonly SpellEntity Reflux = new SpellEntity(18319);
        public static readonly SpellEntity Devour = new SpellEntity(18320);
        public static readonly SpellEntity CondensedLibra = new SpellEntity(18321);
        public static readonly SpellEntity AetherialMimicry = new SpellEntity(18322);
        public static readonly SpellEntity Surpanakha = new SpellEntity(18323);
        public static readonly SpellEntity Quasar = new SpellEntity(18324);
        public static readonly SpellEntity JKick = new SpellEntity(18325);
        public static readonly SpellEntity TripleTrident = new SpellEntity(23264);
        public static readonly SpellEntity Tingle = new SpellEntity(23265);
        public static readonly SpellEntity TatamiGaeshi = new SpellEntity(23266);
        public static readonly SpellEntity ColdFog = new SpellEntity(23267);
        public static readonly SpellEntity WhiteDeath = new SpellEntity(23268);
        public static readonly SpellEntity SaintlyBeam = new SpellEntity(23270);
        public static readonly SpellEntity FeculentFlood = new SpellEntity(23271);
        public static readonly SpellEntity AngelsSnack = new SpellEntity(23272);
        public static readonly SpellEntity ChelonianGate = new SpellEntity(23273);
        public static readonly SpellEntity DivineCataract = new SpellEntity(23274);
        public static readonly SpellEntity TheRoseOfDestruction = new SpellEntity(23275);
        public static readonly SpellEntity BasicInstinct = new SpellEntity(23276);
        public static readonly SpellEntity Ultravibration = new SpellEntity(23277);
        public static readonly SpellEntity Blaze = new SpellEntity(23278);
        public static readonly SpellEntity MustardBomb = new SpellEntity(23279);
        public static readonly SpellEntity DragonForce = new SpellEntity(23280);
        public static readonly SpellEntity AetherialSpark = new SpellEntity(23281);
        public static readonly SpellEntity HydroPull = new SpellEntity(23282);
        public static readonly SpellEntity MaledictionOfWater = new SpellEntity(23283);
        public static readonly SpellEntity ChocoMeteor = new SpellEntity(23284);
        public static readonly SpellEntity MatraMagic = new SpellEntity(23285);
        public static readonly SpellEntity PeripheralSynthesis = new SpellEntity(23286);
        public static readonly SpellEntity BothEnds = new SpellEntity(23287);
        public static readonly SpellEntity PhantomFlurry = new SpellEntity(23288);
        public static readonly SpellEntity PhantomFlurryEnd = new SpellEntity(23289);
        public static readonly SpellEntity NightBloom = new SpellEntity(23290);
        public static readonly SpellEntity Stotram = new SpellEntity(23416);

        #endregion

        // RPR

        #region RPR

        public static readonly SpellEntity Slice = new SpellEntity(24373); // [24373, Slice]
        public static readonly SpellEntity WaxingSlice = new SpellEntity(24374); // [24374, Waxing Slice]
        public static readonly SpellEntity InfernalSlice = new SpellEntity(24375); // [24375, Infernal Slice]
        public static readonly SpellEntity SpinningScythe = new SpellEntity(24376); // [24376, Spinning Scythe]
        public static readonly SpellEntity NightmareScythe = new SpellEntity(24377); // [24377, Nightmare Scythe]
        public static readonly SpellEntity ShadowOfDeath = new SpellEntity(24378); // [24378, Shadow of Death]
        public static readonly SpellEntity WhorlOfDeath = new SpellEntity(24379); // [24379, Whorl of Death]
        public static readonly SpellEntity SoulSlice = new SpellEntity(24380); // [24380, Soul Slice]
        public static readonly SpellEntity SoulScythe = new SpellEntity(24381); // [24380, Soul Slice]
        public static readonly SpellEntity Gibbet = new SpellEntity(24382); // [24382, Gibbet]
        public static readonly SpellEntity Gallows = new SpellEntity(24383); // [24383, Gallows]
        public static readonly SpellEntity Guillotine = new SpellEntity(24384); // [24384, Guillotine]

        public static readonly SpellEntity
            PlentifulHarvest = new SpellEntity(24385); // [24385, Plentiful Harvest]

        public static readonly SpellEntity Harpe = new SpellEntity(24386); // [24386, Harpe]
        public static readonly SpellEntity Soulsow = new SpellEntity(24387,SpellTargetType.Self); // [24387, Soulsow]
        public static readonly SpellEntity HarvestMoon = new SpellEntity(24388); // [24388, Harvest Moon]
        public static readonly SpellEntity BloodStalk = new SpellEntity(24389); // [24389, Blood Stalk]
        public static readonly SpellEntity UnveiledGibbet = new SpellEntity(24390); // [24390, UnveiledGibbet]
        public static readonly SpellEntity UnveiledGallows = new SpellEntity(24391); // [24391, Unveiled Gallows]
        public static readonly SpellEntity GrimSwathe = new SpellEntity(24392); // [24392, Grim Swathe]
        public static readonly SpellEntity Gluttony = new SpellEntity(24393); // [24393, Gluttony]
        public static readonly SpellEntity Enshroud = new SpellEntity(24394,SpellTargetType.Self); // [24394, Enshroud]
        public static readonly SpellEntity VoidReaping = new SpellEntity(24395); // [24395, Void Reaping]
        public static readonly SpellEntity CrossReaping = new SpellEntity(24396); // [24396, Cross Reaping]
        public static readonly SpellEntity GrimReaping = new SpellEntity(24397); // [24397, Grim Reaping]
        public static readonly SpellEntity Communio = new SpellEntity(24398); // [24398, Communio]
        public static readonly SpellEntity LemuresSlice = new SpellEntity(24399); // [24399, Lemure's Slice]
        public static readonly SpellEntity LemuresScythe = new SpellEntity(24400); // [24400, Lemure's Scythe]
        public static readonly SpellEntity HellsIngress = new SpellEntity(24401); // [24401, Hell's Ingress]
        public static readonly SpellEntity HellsEgress = new SpellEntity(24402); // [24402, Hell's Egress]
        public static readonly SpellEntity Regress = new SpellEntity(24403); // [24403, Regress]
        public static readonly SpellEntity ArcaneCrest = new SpellEntity(24404,SpellTargetType.Self); // [24404, Arcane Crest]
        public static readonly SpellEntity ArcaneCircle = new SpellEntity(24405,SpellTargetType.Self); // [24405, Arcane Circle]

        #endregion

        //PVP

        #region PVP

        public static readonly SpellEntity Concentrate = new SpellEntity(1582);
        public static readonly SpellEntity Muse = new SpellEntity(1583);
        public static readonly SpellEntity Safeguard = new SpellEntity(1585);
        public static readonly SpellEntity Enliven = new SpellEntity(1580);
        public static readonly SpellEntity Recuperate = new SpellEntity(1590);
        public static readonly SpellEntity Testudo = new SpellEntity(1558);
        public static readonly SpellEntity GlorySlash = new SpellEntity(1559);
        public static readonly SpellEntity FullSwing = new SpellEntity(1562);
        public static readonly SpellEntity PushBack = new SpellEntity(1597);
        public static readonly SpellEntity EmpyreanRain = new SpellEntity(3362);

        public static readonly SpellEntity PvpMalefic3 = new SpellEntity(8912);
        public static readonly SpellEntity PvpEssentialDignity = new SpellEntity(8916);
        public static readonly SpellEntity PvpLightspeed = new SpellEntity(8917);
        public static readonly SpellEntity PvpSynastry = new SpellEntity(8918);
        public static readonly SpellEntity PvpBenefic = new SpellEntity(8913);
        public static readonly SpellEntity PvpBenefic2 = new SpellEntity(8914);
        public static readonly SpellEntity Deorbit = new SpellEntity(9466);
        public static readonly SpellEntity PvpDisable = new SpellEntity(9623);
        public static readonly SpellEntity PvpDraw = new SpellEntity(10026);
        public static readonly SpellEntity PvpPlayDrawn = new SpellEntity(10026);

        public static readonly SpellEntity StraightShotPvp = new SpellEntity(8835);
        public static readonly SpellEntity EmpyrealArrowPvp = new SpellEntity(8838);
        public static readonly SpellEntity RepellingShotPvp = new SpellEntity(8839);
        public static readonly SpellEntity BloodletterPvp = new SpellEntity(9624);
        public static readonly SpellEntity SidewinderPvp = new SpellEntity(8841);
        public static readonly SpellEntity BarragePvp = new SpellEntity(9625);
        public static readonly SpellEntity PitchPerfectPvp = new SpellEntity(8842);
        public static readonly SpellEntity TheWanderersMinuetPvp = new SpellEntity(8843);
        public static readonly SpellEntity ArmysPaeonPvp = new SpellEntity(8844);
        public static readonly SpellEntity TroubadourPvp = new SpellEntity(10023);

        public static readonly SpellEntity PVPMCH123 = new SpellEntity(17749);

        //WHM
        public static readonly SpellEntity Purify = new SpellEntity(1584);
        public static readonly SpellEntity Stone3Pvp = new SpellEntity(8894);
        public static readonly SpellEntity CurePvp = new SpellEntity(8895);
        public static readonly SpellEntity Cure2Pvp = new SpellEntity(8896);
        public static readonly SpellEntity RegenPvp = new SpellEntity(8898);
        public static readonly SpellEntity DivineBenisonPvp = new SpellEntity(9621);
        public static readonly SpellEntity AssizePvp = new SpellEntity(9620);
        public static readonly SpellEntity FluidAuraPvp = new SpellEntity(8900);

        #endregion


        public static HashSet<uint> IgnoreEarlyDecisionSet = new HashSet<uint>()
        {
            SpellsDefine.PlentifulHarvest.Id
        };
    }
}