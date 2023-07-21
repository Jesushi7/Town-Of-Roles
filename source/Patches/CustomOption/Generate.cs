using System;

namespace TownOfRoles.CustomOption
{
    public class Generate
    {
        public static CustomHeaderOption CrewRoles;     
        public static CustomNumberOption MysticOn;
        public static CustomNumberOption SnitchOn; 
        public static CustomNumberOption CamouflagerOn;        
        public static CustomNumberOption InformantOn;
        public static CustomNumberOption TrackerOn;
        public static CustomNumberOption TrapperOn;
        public static CustomNumberOption AltruistOn;
        public static CustomNumberOption MedicOn;
        public static CustomNumberOption SheriffOn;
        public static CustomNumberOption VeteranOn;
        public static CustomNumberOption EngineerOn;
        public static CustomNumberOption ImitatorOn;
        public static CustomNumberOption MayorOn;
        public static CustomNumberOption MediumOn;
        public static CustomNumberOption SwapperOn;
        public static CustomNumberOption TransporterOn;

        public static CustomHeaderOption NeutralRolesMinMax;
        public static CustomHeaderOption NeutralRoles;
        public static CustomNumberOption AmnesiacOn;        
        public static CustomNumberOption GuardianOn;
        public static CustomNumberOption ExecutionerOn;  
        public static CustomNumberOption JesterOn;


        public static CustomHeaderOption NeutralKillingRoles;
        public static CustomNumberOption PyromaniacOn;
        public static CustomNumberOption PlaguebearerOn;
        public static CustomNumberOption GlitchOn;
        public static CustomNumberOption WerewolfOn;
        public static CustomNumberOption JuggernautOn;
        public static CustomNumberOption SerialKillerOn;        

        public static CustomHeaderOption ImpostorRoles;
        public static CustomNumberOption EscapistOn;
        public static CustomNumberOption MorphlingOn;
        public static CustomNumberOption SwooperOn;
        public static CustomNumberOption GrenadierOn;      
        public static CustomNumberOption BomberOn;
        public static CustomNumberOption SilencerOn;
        public static CustomNumberOption JanitorOn;
        public static CustomNumberOption MinerOn;
        public static CustomNumberOption UndertakerOn;

        public static CustomToggleOption MorphlingVent;
            
        public static CustomHeaderOption CrewmateModifiers;
        public static CustomNumberOption BaitOn;
        public static CustomNumberOption BlindOn;
        public static CustomNumberOption DiseasedOn;
        public static CustomNumberOption MultitaskerOn;
        public static CustomNumberOption LighterOn;    
        public static CustomNumberOption ObliviousOn;           
        public static CustomNumberOption NightowlOn;
        public static CustomNumberOption WatcherOn;


        public static CustomHeaderOption GlobalModifiers;
        public static CustomNumberOption ButtonBarryOn;
        public static CustomNumberOption DrunkOn;         
        public static CustomNumberOption ChameleonModifierOn;               
        public static CustomNumberOption FlashOn;
        public static CustomNumberOption GiantOn;
        public static CustomNumberOption LoversOn;
        public static CustomNumberOption ParanoiacOn;
        public static CustomNumberOption MiniOn;                 
        public static CustomNumberOption SleuthOn;
        public static CustomNumberOption SpyOn;        
        public static CustomNumberOption TiebreakerOn;

        public static CustomHeaderOption ImpostorModifiers;
        public static CustomNumberOption DisperserOn;
        public static CustomNumberOption DoubleShotOn;
        public static CustomNumberOption UnderdogOn;

        public static CustomHeaderOption MapSettings;
        public static CustomToggleOption RandomMapEnabled;
        public static CustomNumberOption RandomMapSkeld;
        public static CustomNumberOption RandomMapMira;
        public static CustomNumberOption RandomMapPolus;
        public static CustomNumberOption RandomMapAirship;
        public static CustomNumberOption RandomMapSubmerged;
        public static CustomToggleOption AutoAdjustSettings;
        public static CustomToggleOption SmallMapHalfVision;
        public static CustomNumberOption SmallMapDecreasedCooldown;
        public static CustomNumberOption LargeMapIncreasedCooldown;
        public static CustomNumberOption SmallMapIncreasedShortTasks;
        public static CustomNumberOption SmallMapIncreasedLongTasks;
        public static CustomNumberOption LargeMapDecreasedShortTasks;
        public static CustomNumberOption LargeMapDecreasedLongTasks;

        public static CustomHeaderOption CustomGameSettings;      
        public static CustomNumberOption ChatCooldown;               
        public static CustomToggleOption AppearanceAnimation;        
        public static CustomToggleOption OxySlow;
        public static CustomToggleOption NoNames;        
        public static CustomNumberOption ReactorShake;           
        public static CustomToggleOption EveryoneVent;        
        public static CustomToggleOption RandomSpawns;               
        public static CustomToggleOption DeadSeesEverything;
        public static CustomNumberOption VanillaGame;
   
        public static CustomNumberOption InitialCooldowns;
        public static CustomToggleOption ParallelMedScans;
        public static CustomStringOption SkipButtonDisable;
        public static CustomHeaderOption QualitySettings;  
        public static CustomHeaderOption BetterMapSettings;
        public static CustomToggleOption SkeldVentImprovements;        
        public static CustomToggleOption VentImprovements;
        public static CustomToggleOption VitalsLab;
        public static CustomToggleOption ColdTempDeathValley;
        public static CustomToggleOption WifiChartCourseSwap;     

        public static CustomHeaderOption mainettings;
        public static CustomStringOption GameMode;

        public static CustomHeaderOption ClassicSettings;
        public static CustomNumberOption MinNeutralNonKillingRoles;
        public static CustomNumberOption MaxNeutralNonKillingRoles;
        public static CustomNumberOption MinNeutralKillingRoles;
        public static CustomNumberOption MaxNeutralKillingRoles;

        public static CustomHeaderOption AllAnySettings;
        public static CustomToggleOption RandomNumberImps;

        public static CustomHeaderOption KillingOnlySettings;
        public static CustomNumberOption NeutralRoles2;
        public static CustomNumberOption VeteranCount;
        public static CustomToggleOption AddPyromaniac;
        public static CustomToggleOption AddPlaguebearer;

        public static CustomHeaderOption CultistSettings;
        public static CustomNumberOption MayorCultistOn;
        public static CustomNumberOption SnitchCultistOn;
        public static CustomNumberOption SheriffCultistOn;
        public static CustomNumberOption NumberOfSpecialRoles;
        public static CustomNumberOption MaxChameleons;
        public static CustomNumberOption MaxEngineers;
        public static CustomNumberOption MaxMystics;

        public static CustomNumberOption MaxTransporters;
        public static CustomNumberOption WhisperCooldown;
        public static CustomNumberOption IncreasedCooldownPerWhisper;
        public static CustomNumberOption WhisperRadius;
        public static CustomNumberOption ConversionPercentage;
        public static CustomNumberOption DecreasedPercentagePerConversion;
        public static CustomNumberOption ReviveCooldown;
        public static CustomNumberOption IncreasedCooldownPerRevive;
        public static CustomNumberOption MaxReveals;

        public static CustomHeaderOption TaskTrackingSettings;
        public static CustomToggleOption SeeTasksDuringRound;
        public static CustomToggleOption SeeTasksDuringMeeting;
        public static CustomToggleOption SeeTasksWhenDead;

        public static CustomHeaderOption Mayor;
        public static CustomNumberOption MayorVoteBank;
        public static CustomToggleOption MayorAnonymous;



        public static CustomHeaderOption Sheriff;
        public static CustomToggleOption SheriffKillOther;  
        public static CustomToggleOption SheriffKillsExecutioner;
        public static CustomToggleOption SheriffKillsLovers;        
        public static CustomToggleOption SheriffKillsJester;
        public static CustomToggleOption SheriffKillsPyromaniac;

        public static CustomToggleOption SheriffKillsSerialKiller;
        public static CustomToggleOption SheriffKillsJuggernaut;
        public static CustomToggleOption SheriffKillsPlaguebearer;
        public static CustomToggleOption SheriffKillsGlitch;
        public static CustomToggleOption SheriffKillsWerewolf;
        public static CustomToggleOption SheriffBodyReport;

        public static CustomHeaderOption Engineer;
        public static CustomStringOption EngineerPer;
        public static CustomNumberOption EngiFixPerRound;
        public static CustomNumberOption EngiFixPerGame;


        public static CustomHeaderOption Medic;
        public static CustomStringOption ShowShielded;
        public static CustomStringOption WhoGetsNotification;
        public static CustomToggleOption ShieldBreaks;
        public static CustomToggleOption MedicReportSwitch;
        public static CustomToggleOption MedicFlashReport;        
        public static CustomNumberOption MedicReportNameDuration;
        public static CustomNumberOption MedicReportColorDuration;

        public static CustomHeaderOption Snitch;
        public static CustomNumberOption SnitchCooldown;
        public static CustomToggleOption CrewKillingRed;
        public static CustomToggleOption NeutralNNK;
        public static CustomToggleOption NeutKillingRed;

        public static CustomHeaderOption Swapper;
        public static CustomToggleOption SwapperButton;
        public static CustomToggleOption SwapAfterVoting;

        public static CustomHeaderOption Transporter;
        public static CustomNumberOption TransportCooldown;
        public static CustomNumberOption TransportMaxUses;
        public static CustomToggleOption TransporterVitals;
        public static CustomToggleOption MayorButton;

        public static CustomHeaderOption Jester;
        public static CustomToggleOption JesterButton;
        public static CustomToggleOption JesterVent;
        public static CustomToggleOption JesterKill;        
        public static CustomToggleOption JesterSwitchVent;        
        public static CustomToggleOption JesterImpVision;
     

        public static CustomHeaderOption TheGlitch;
        public static CustomNumberOption MimicCooldownOption;
        public static CustomNumberOption MimicDurationOption;
        public static CustomNumberOption HackCooldownOption;
        public static CustomNumberOption HackDurationOption;
        public static CustomStringOption GlitchHackDistanceOption;
        public static CustomToggleOption GlitchVent;

        public static CustomHeaderOption Juggernaut;
        public static CustomNumberOption JuggKillCooldown;
        public static CustomNumberOption ReducedKCdPerKill;
        public static CustomToggleOption JuggVent;

        public static CustomHeaderOption Camouflager;
        public static CustomNumberOption ChameleonSwoopCd;
        public static CustomNumberOption ChameleonSwoopDuration;

        public static CustomHeaderOption Morphling;
        public static CustomNumberOption MorphlingCooldown;
        public static CustomNumberOption MorphlingDuration;

        public static CustomHeaderOption Executioner;
        public static CustomStringOption OnTargetDead;
        public static CustomToggleOption ExecutionerButton;
     

        public static CustomHeaderOption Phantom;
        public static CustomNumberOption PhantomTasksRemaining;


        public static CustomHeaderOption Informant;
        public static CustomToggleOption InformantSeesNeutrals;
        public static CustomNumberOption InformantTasksRemaining;
        public static CustomToggleOption InformantSeesImpInMeeting;

        public static CustomHeaderOption Mini;
        public static CustomNumberOption MiniSize;     
        public static CustomNumberOption MiniSpeed;

        public static CustomHeaderOption Altruist;
        public static CustomNumberOption ReviveDuration;
        public static CustomToggleOption AltruistTargetBody;

        public static CustomHeaderOption PostMortalRoles;
        public static CustomNumberOption PhantomOn;
        public static CustomNumberOption AvengerOn;

        public static CustomHeaderOption Miner;
        public static CustomNumberOption MineCooldown;

        public static CustomHeaderOption Swooper;
        public static CustomNumberOption SwoopCooldown;
        public static CustomNumberOption SwoopDuration;
        public static CustomToggleOption SwooperVent;
        public static CustomToggleOption SwooperPolusVent;


        public static CustomHeaderOption Pyromaniac;
        public static CustomNumberOption DouseCooldown;
        public static CustomNumberOption MaxDoused;
        public static CustomToggleOption ArsoImpVision;     
        public static CustomToggleOption ArsoVent;        
        public static CustomToggleOption IgniteCdRemoved;

        public static CustomHeaderOption Undertaker;
        public static CustomNumberOption DragCooldown;
        public static CustomNumberOption UndertakerDragSpeed;

        public static CustomHeaderOption Assassin;
        public static CustomToggleOption ImpostorsVent;        
        public static CustomStringOption WhoSeesFailedFlash;        
        public static CustomNumberOption NumberOfImpostorAssassins;
        public static CustomNumberOption NumberOfNeutralKillingAssassins;
        public static CustomNumberOption NumberOfNeutralNonKillingAssassins;        
        public static CustomNumberOption NumberOfCrewAssassins;        
        public static CustomToggleOption AmneTurnImpAssassin;
        public static CustomToggleOption AmneTurnNeutAssassin;
        public static CustomNumberOption AssassinKills;
        public static CustomToggleOption AssassinMultiKill;
        public static CustomNumberOption VIPOn;

        public static CustomToggleOption AssassinCrewmateGuess;
        public static CustomToggleOption AssassinGuessButtonBarry;
        public static CustomToggleOption AssassinGuessSpy;
        public static CustomToggleOption AssassinGuessModifiers;
        public static CustomToggleOption AssassinGuessLovers;
        public static CustomToggleOption AssassinateAfterVoting;

        public static CustomNumberOption CultistOn;
        public static CustomHeaderOption Cultist;     
        public static CustomNumberOption ReviveCooldown2;
        public static CustomNumberOption IncreasedCooldownPerRevive2;     

        public static CustomNumberOption VampireOn;
        public static CustomHeaderOption Vampire;
        public static CustomNumberOption BiteDuration;
        public static CustomToggleOption VampireVent;

        public static CustomHeaderOption Underdog;
        public static CustomNumberOption UnderdogKillBonus;
        public static CustomToggleOption UnderdogIncreasedKC;


        public static CustomHeaderOption Avenger;
        public static CustomNumberOption AvengerTasksRemainingClicked;
        public static CustomNumberOption AvengerTasksRemainingAlert;
        public static CustomToggleOption AvengerRevealsNeutrals;
        public static CustomStringOption AvengerCanBeClickedBy;

        public static CustomHeaderOption Grenadier;
        public static CustomNumberOption GrenadeCooldown;
        public static CustomNumberOption GrenadeDuration;
        public static CustomToggleOption GrenadierIndicators;
        public static CustomToggleOption GrenadierVent;
        public static CustomNumberOption FlashRadius;

        public static CustomNumberOption DisguiserOn;
        public static CustomHeaderOption Disguiser;
        public static CustomNumberOption DisguiserCooldown;
        public static CustomNumberOption DisguiserDuration;

		public static CustomNumberOption OracleOn;
		public static CustomHeaderOption Oracle;
		public static CustomNumberOption ConfessCooldown;
		public static CustomNumberOption RevealAccuracy;
		public static CustomToggleOption NeutralBenignShowsEvil;
		public static CustomToggleOption NeutralNonKillersShowsEvil;
		public static CustomToggleOption NeutralKillingShowsEvil;

        public static CustomHeaderOption Veteran;
        public static CustomToggleOption KilledOnAlert;
        public static CustomNumberOption AlertCooldown;
        public static CustomNumberOption AlertDuration;
        public static CustomNumberOption MaxAlerts;

        public static CustomHeaderOption Tracker;
        public static CustomNumberOption UpdateInterval;
        public static CustomNumberOption TrackCooldown;
        public static CustomToggleOption ResetOnNewRound;
        public static CustomNumberOption MaxTracks;

        public static CustomHeaderOption Trapper;
        public static CustomNumberOption TrapCooldown;
        public static CustomToggleOption TrapsRemoveOnNewRound;
        public static CustomNumberOption MaxTraps;
        public static CustomNumberOption MinAmountOfTimeInTrap;
        public static CustomNumberOption TrapSize;
        public static CustomNumberOption MinAmountOfPlayersInTrap;

        public static CustomHeaderOption Spy;
        public static CustomStringOption WhoSeesDead;        


        public static CustomHeaderOption Amnesiac;
        public static CustomToggleOption RememberArrows;
        public static CustomNumberOption RememberArrowDelay;
        public static CustomToggleOption BegninNeutralHasTasks;

        public static CustomHeaderOption Medium;
        public static CustomNumberOption MediateCooldown;
        public static CustomToggleOption ShowMediatePlayer;
        public static CustomToggleOption ShowMediumToDead;
        public static CustomStringOption DeadRevealed;

        public static CustomNumberOption VultureOn;
        public static CustomHeaderOption Vulture;
        public static CustomNumberOption EatNeeded;
        public static CustomToggleOption VultureVent;
        public static CustomToggleOption VultureCdOn;
        public static CustomNumberOption VultureCd;
        public static CustomToggleOption SheriffKillsVulture;


        public static CustomHeaderOption Guardian;
        public static CustomNumberOption ProtectCd;
        public static CustomNumberOption ProtectDuration;
        public static CustomNumberOption ProtectKCReset;
        public static CustomNumberOption MaxProtects;
        public static CustomStringOption ShowProtect;
        public static CustomStringOption GaOnTargetDeath;
        public static CustomToggleOption GATargetKnows;
        public static CustomToggleOption GAKnowsTargetRole;
        public static CustomNumberOption MaxPlayers;

        public static CustomHeaderOption Mystic;
        public static CustomNumberOption InitialExamineCooldown;
        public static CustomNumberOption ExamineCooldown;
        public static CustomNumberOption RecentKill;
        public static CustomToggleOption MysticReportOn;
        public static CustomNumberOption MysticRoleDuration;
        public static CustomNumberOption MysticFactionDuration;
        public static CustomToggleOption ExamineReportOn;        
        public static CustomNumberOption MysticArrowDuration;

        public static CustomHeaderOption Silencer;
        public static CustomNumberOption SilenceCooldown;


        public static CustomHeaderOption SerialKiller;
        public static CustomToggleOption SerialKillerVent;

        public static CustomHeaderOption Plaguebearer;
        public static CustomNumberOption InfectCooldown;
         public static CustomToggleOption PlaguebearerVent;       
        public static CustomToggleOption PestVent;
        public static CustomHeaderOption Werewolf;
        public static CustomNumberOption RampageCooldown;
        public static CustomNumberOption RampageDuration;
        public static CustomNumberOption RampageKillCooldown;
        public static CustomToggleOption WerewolfVent;

        public static CustomHeaderOption Escapist;
        public static CustomNumberOption EscapeCooldown;
        public static CustomToggleOption EscapistVent;

        public static CustomHeaderOption Bomber;
        public static CustomNumberOption MaxKillsInDetonation;
        public static CustomNumberOption DetonateDelay;
        public static CustomNumberOption DetonateRadius;
        public static CustomToggleOption BomberVent;

        public static CustomHeaderOption Giant;
        public static CustomNumberOption GiantSize;          
        public static CustomNumberOption GiantSlow;

        public static CustomHeaderOption Flash;
        public static CustomNumberOption FlashSpeed;

        public static CustomHeaderOption Diseased;
        public static CustomNumberOption DiseasedKillMultiplier;

        public static CustomHeaderOption ButtonBarry;
     
        public static CustomHeaderOption Bait;
        public static CustomNumberOption NumberOfBaits;        
        public static CustomNumberOption BaitMinDelay;
        public static CustomNumberOption BaitMaxDelay;

        public static CustomHeaderOption Lovers;
        public static CustomToggleOption BothLoversDie;
        public static CustomNumberOption LovingImpPercent;
        public static CustomToggleOption NeutralLovers;      
        
        public static CustomToggleOption VentTargetting;
        public static Func<object, string> PercentFormat { get; } = value => $"{value:0}%";
        public static object Multimenu { get; private set; }
        private static Func<object, string> CooldownFormat { get; } = value => $"{value:0.0#}s";
        private static Func<object, string> MultiplierFormat { get; } = value => $"{value:0.0#}x";



        public static void GenerateAll()
        {
            var num = 0;

            Patches.ExportButton = new Export(num++);
            Patches.ImportButton = new Import(num++);


            AltruistOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#660000FF>Altruist</color>", 0f, 0f, 100f, 10f,
                PercentFormat); 
            AvengerOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#D3D3D3FF>Avenger</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                   
            CamouflagerOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#708eef>Camouflager</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                  
            EngineerOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#FFA60AFF>Engineer</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                  
            ImitatorOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#B3D94DFF>Imitator</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                   
            InformantOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#D4AF37FF>Informant</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                                                                                                                   
            MayorOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#704FA8FF>Mayor</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            MedicOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#7efbc2>Medic</color>", 0f, 0f, 100f, 10f,
                PercentFormat);   
            MediumOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#A680FFFF>Medium</color>", 0f, 0f, 100f, 10f,
                PercentFormat);  
            MysticOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#4D4DFFFF>Mystic</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                                    
            OracleOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#2f1f73>Oracle</color>", 0f, 0f, 100f, 10f, 
                PercentFormat);                                  
            SheriffOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            SnitchOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#61b26c>Snitch</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            SwapperOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#863756>Swapper</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                
            TrackerOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#009900FF>Tracker</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            TransporterOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#00EEFFFF>Transporter</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                
            TrapperOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#75fa4c>Trapper</color>", 0f, 0f, 100f, 10f,
                PercentFormat);              
            VeteranOn = new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#998040FF>Veteran</color>", 0f, 0f, 100f, 10f,
                PercentFormat);


           NeutralRoles = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#80797c>Neutrals</color>");
            AmnesiacOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#80B2FFFF>Amnesiac</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            ExecutionerOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#2d4222>Executioner</color>", 0f, 0f, 100f, 10f,
                PercentFormat);      
            GuardianOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#B3FFFFFF>Guardian</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                                        
            JesterOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#cb81c0>Jester</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                              
            PhantomOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#662962FF>Phantom</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                                     
            VultureOn = new CustomNumberOption(num++, MultiMenu.neutral,"<color=#8C4005FF>Vulture</color>", 40f, 0f, 100f, 10f,
                PercentFormat);

            NeutralKillingRoles = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#80797c>Neutral</color> <color=#FF0000FF>Killers</color>");                   
            JuggernautOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#8C004DFF>Juggernaut</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                
            GlitchOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#00FF00FF>The Glitch</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                              
            PlaguebearerOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#E6FFB3FF>Plaguebearer</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            PyromaniacOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#e89d51>Pyromaniac</color>", 0f, 0f, 100f, 10f,
                PercentFormat);              
            SerialKillerOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#642DEAFF>Serial Killer</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                   
            WerewolfOn = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#A86629FF>Werewolf</color>", 0f, 0f, 100f, 10f,
                PercentFormat);


            BomberOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Bomber</color>", 0f, 0f, 100f, 10f,
                PercentFormat);           
            DisguiserOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Disguiser</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                
            CultistOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Cultist</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                      
            EscapistOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Escapist</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            GrenadierOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Grenadier</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            JanitorOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Janitor</color>", 0f, 0f, 100f, 10f,
                PercentFormat);   
            MinerOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Miner</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                                          
            MorphlingOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Morphling</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            UndertakerOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Undertaker</color>", 0f, 0f, 100f, 10f,
                PercentFormat);        
            SilencerOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Silencer</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            SwooperOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Swooper</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            VampireOn = new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Vampire</color>", 0f, 0f, 100f, 10f,
                PercentFormat);   

            CrewmateModifiers = new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#8cffff>Crewmate</color> <color=#9cbee4>Modifiers</color>");
            BlindOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#AAAAAAFF>Blind</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            LighterOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#e1c849>Lighter</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                   
            MultitaskerOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FF804DFF>Multitasker</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            NightowlOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FFFF99FF>Nightowl</color>", 0f, 0f, 100f, 10f,
                PercentFormat);


            GlobalModifiers = new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#9cbee4>Global Modifiers</color>");
            BaitOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#00B3B3FF>Bait</color>", 0f, 0f, 100f, 10f,
                PercentFormat);            
            ButtonBarryOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#E600FFFF>Button Barry</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            ChameleonModifierOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#9cbee4>Chameleon</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            DiseasedOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#808080FF>Diseased</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                
            DoubleShotOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FF0000FF>Double Shot</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                                
            DrunkOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#758000>Drunk</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                
            FlashOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FF8080FF>Flash</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            GiantOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FFB34DFF>Giant</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            LoversOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FF66CCFF>Lovers</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            MiniOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#a938d6>Mini</color>", 0f, 0f, 100f, 10f,
                PercentFormat);   
            ObliviousOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#85AA5BFF>Oblivious</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                                 
            ParanoiacOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FF0080FF>Paranoiac</color>", 0f, 0f, 100f, 10f,
                PercentFormat);            
            SleuthOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#803333FF>Sleuth</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            SpyOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#CCA3CCFF>Spy</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                
            TiebreakerOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#99E699FF>Tiebreaker</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            VIPOn = new(num++, MultiMenu.modifiers, "<color=#ffff00>VIP</color>", 0, 0, 100, 10, PercentFormat);                
            WatcherOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#8c00ff>Watcher</color>", 0f, 0f, 100f, 10f,
                PercentFormat);                

            ImpostorModifiers = new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#FF0000FF>Impostor</color> <color=#9cbee4>Modifiers</color>");
            DisperserOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FF0000FF>Disperser</color>", 0f, 0f, 100f, 10f,
                PercentFormat);
            UnderdogOn = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FF0000FF>Underdog</color>", 0f, 0f, 100f, 10f,
                PercentFormat);


            mainettings =
                new CustomHeaderOption(num++, MultiMenu.main, "Game Mode Settings");
            GameMode = new CustomStringOption(num++, MultiMenu.main, "Game Mode", new[] {"Classic", "All Any", "Killing Only", "Cultist" });

            AllAnySettings =
                new CustomHeaderOption(num++, MultiMenu.main, "All Any Settings");
            RandomNumberImps = new CustomToggleOption(num++, MultiMenu.main, "Random Number Of Impostors", true);

            KillingOnlySettings =
                new CustomHeaderOption(num++, MultiMenu.main, "Killing Only Settings");
            NeutralRoles2 =
                new CustomNumberOption(num++, MultiMenu.main, "Neutral Roles", 1, 0, 5, 1);
            VeteranCount =
                new CustomNumberOption(num++, MultiMenu.main, "<color=#998040FF>Veteran</color> Count", 1, 0, 5, 1);
            AddPyromaniac = new CustomToggleOption(num++, MultiMenu.main, "Add <color=#e89d51>Pyromaniac</color>", true);

            AddPlaguebearer = new CustomToggleOption(num++, MultiMenu.main, "Add <color=#E6FFB3FF>Plaguebearer</color>", true);

            CultistSettings =
                new CustomHeaderOption(num++, MultiMenu.main, "Cultist Settings");
            MayorCultistOn = new CustomNumberOption(num++, MultiMenu.main, "<color=#704FA8FF>Mayor</color> (Cultist Mode)", 100f, 0f, 100f, 10f,
                PercentFormat);
            SnitchCultistOn = new CustomNumberOption(num++, MultiMenu.main, "<color=#61b26c>Snitch</color> (Cultist Mode)", 100f, 0f, 100f, 10f,
                PercentFormat);
            SheriffCultistOn = new CustomNumberOption(num++, MultiMenu.main, "<color=#f8cd46>Sheriff</color> (Cultist Mode)", 100f, 0f, 100f, 10f,
                PercentFormat);
            NumberOfSpecialRoles =
                new CustomNumberOption(num++, MultiMenu.main, "Number Of Special Roles", 4, 0, 4, 1);
            MaxChameleons =
                new CustomNumberOption(num++, MultiMenu.main, "Max <color=#708eef>Chameleons</color>", 3, 0, 5, 1);
            MaxEngineers =
                new CustomNumberOption(num++, MultiMenu.main, "Max <color=#FFA60AFF>Engineers</color>", 3, 0, 5, 1);
            MaxMystics =
                new CustomNumberOption(num++, MultiMenu.main, "Max <color=#4D4DFFFF>Mystics</color>", 3, 0, 5, 1);
            MaxTransporters =
                new CustomNumberOption(num++, MultiMenu.main, "Max <color=#00EEFFFF>Transporters</color>", 3, 0, 5, 1);
            WhisperCooldown =
                new CustomNumberOption(num++, MultiMenu.main, "Initial Whisper Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            IncreasedCooldownPerWhisper =
                new CustomNumberOption(num++, MultiMenu.main, "Increased Cooldown Per Whisper", 5f, 0f, 15f, 0.5f, CooldownFormat);
            WhisperRadius =
                new CustomNumberOption(num++, MultiMenu.main, "Whisper Radius", 1f, 0.25f, 5f, 0.25f, MultiplierFormat);
            ConversionPercentage = new CustomNumberOption(num++, MultiMenu.main, "Conversion Percentage", 25f, 0f, 100f, 5f,
                PercentFormat);
            DecreasedPercentagePerConversion = new CustomNumberOption(num++, MultiMenu.main, "Decreased Conversion Percentage Per Conversion", 5f, 0f, 15f, 1f,
                PercentFormat);
            ReviveCooldown =
                new CustomNumberOption(num++, MultiMenu.main, "Initial Revive Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            IncreasedCooldownPerRevive =
                new CustomNumberOption(num++, MultiMenu.main, "Increased Cooldown Per Revive", 25f, 10f, 60f, 2.5f, CooldownFormat);
            MaxReveals = new CustomNumberOption(num++, MultiMenu.main, "Maximum Number Of Reveals", 5, 1, 15, 1);

            CustomGameSettings =
                new CustomHeaderOption(num++, MultiMenu.main, "Custom Game Settings");
           // MaxPlayers = new CustomNumberOption(num++, MultiMenu.main, "Max Players", 12, 4, 15, 1);               
            ChatCooldown = new CustomNumberOption(num++, MultiMenu.main, "Chat Cooldown", 3, 0, 3, 0.1f, CooldownFormat);
            RandomSpawns = new CustomToggleOption(num++, MultiMenu.main, "Enable Random Spawns", false);                   
            NoNames = new(num++, MultiMenu.main, "No Player Names", false);
            OxySlow = new CustomToggleOption(num++, MultiMenu.main, "Oxygen Sabotage Slows Down Players", false);         
            EveryoneVent = new CustomToggleOption(num++, MultiMenu.main, "Everyone Vent Mode", false);
            DeadSeesEverything =
                new CustomToggleOption(num++, MultiMenu.main, "Dead Can See Everyone's Roles/Votes", false);
            VanillaGame = new CustomNumberOption(num++, MultiMenu.main, "Probability Of A Completely Vanilla Game", 0f, 0f, 100f, 5f,
                PercentFormat);
            InitialCooldowns =
                new CustomNumberOption(num++, MultiMenu.main, "Game Start Cooldowns", 10f, 10f, 30f, 2.5f, CooldownFormat);


            QualitySettings =
                new CustomHeaderOption(num++, MultiMenu.main, "Player Quality Settings");
            AppearanceAnimation = new CustomToggleOption(num++, MultiMenu.main, "Kill Animations Show Morphed Player");                    
            ParallelMedScans = new CustomToggleOption(num++, MultiMenu.main, "Parallel Medbay Scans", false);
            SkipButtonDisable = new CustomStringOption(num++, MultiMenu.main, "Disable Meeting Skip Button", new[] { "No", "Emergency", "Always" });
            SeeTasksDuringRound = new CustomToggleOption(num++, MultiMenu.main, "See Tasks During Round", false);
            SeeTasksDuringMeeting = new CustomToggleOption(num++, MultiMenu.main, "See Tasks During Meetings", true);
            SeeTasksWhenDead = new CustomToggleOption(num++, MultiMenu.main, "See Tasks When Dead", true);

            BetterMapSettings =
                new CustomHeaderOption(num++, MultiMenu.main, "Better Map Settings");
            SkeldVentImprovements = new CustomToggleOption(num++, MultiMenu.main, "Better Skeld Vent Layout", false);                
            VentImprovements = new CustomToggleOption(num++, MultiMenu.main, "Better Polus Vent Layout", false);
            VitalsLab = new CustomToggleOption(num++, MultiMenu.main, "Vitals Moved To Lab On Polus", false);
            ColdTempDeathValley = new CustomToggleOption(num++, MultiMenu.main, "Cold Temp Moved To Death Valley On Polus", false);
            WifiChartCourseSwap =
                new CustomToggleOption(num++, MultiMenu.main, "Reboot Wifi And Chart Course Swapped On Polus", false);
            

            MapSettings = new CustomHeaderOption(num++, MultiMenu.main, "Map Settings");
            RandomMapEnabled = new CustomToggleOption(num++, MultiMenu.main, "Choose Random Map", false);
            RandomMapSkeld = new CustomNumberOption(num++, MultiMenu.main, "Skeld Chance", 0f, 0f, 100f, 10f, PercentFormat);
            RandomMapMira = new CustomNumberOption(num++, MultiMenu.main, "Mira Chance", 0f, 0f, 100f, 10f, PercentFormat);
            RandomMapPolus = new CustomNumberOption(num++, MultiMenu.main, "Polus Chance", 0f, 0f, 100f, 10f, PercentFormat);
            RandomMapAirship = new CustomNumberOption(num++, MultiMenu.main, "Airship Chance", 0f, 0f, 100f, 10f, PercentFormat);
            RandomMapSubmerged = new CustomNumberOption(num++, MultiMenu.main, "Submerged Chance", 0f, 0f, 100f, 10f, PercentFormat);
            AutoAdjustSettings = new CustomToggleOption(num++, MultiMenu.main, "Auto Adjust Settings", false);
            SmallMapHalfVision = new CustomToggleOption(num++, MultiMenu.main, "Half Vision On Skeld/Mira HQ", false);
            SmallMapDecreasedCooldown =
                new CustomNumberOption(num++, MultiMenu.main, "Mira HQ Decreased Cooldowns", 0f, 0f, 15f, 2.5f, CooldownFormat);
            LargeMapIncreasedCooldown =
                new CustomNumberOption(num++, MultiMenu.main, "Airship/Submerged Increased Cooldowns", 0f, 0f, 15f, 2.5f, CooldownFormat);
            SmallMapIncreasedShortTasks =
                 new CustomNumberOption(num++, MultiMenu.main, "Skeld/Mira HQ Increased Short Tasks", 0, 0, 5, 1);
            SmallMapIncreasedLongTasks =
                 new CustomNumberOption(num++, MultiMenu.main, "Skeld/Mira HQ Increased Long Tasks", 0, 0, 3, 1);
            LargeMapDecreasedShortTasks =
                 new CustomNumberOption(num++, MultiMenu.main, "Airship/Submerged Decreased Short Tasks", 0, 0, 5, 1);
            LargeMapDecreasedLongTasks =
                 new CustomNumberOption(num++, MultiMenu.main, "Airship/Submerged Decreased Long Tasks", 0, 0, 3, 1);

            Assassin = new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Assassin Ability</color>");
            WhoSeesFailedFlash = new CustomStringOption(num++, MultiMenu.imposter, "Who Sees <color=#FF0000FF>Assassins</color> Failed Notification", new[] { "Everyone","<color=#FF0000FF>Impostors</color>","Target + <color=#FF0000FF>Impostors</color>", "Target + <color=#FF0000FF>Assassins</color>","<color=#FF0000FF>Assassins</color>"});            
            NumberOfImpostorAssassins = new CustomNumberOption(num++, MultiMenu.imposter, "Number Of <color=#FF0000FF>Impostor</color> <color=#FF0000FF>Assassins</color>", 1, 0, 4, 1);
            NumberOfNeutralKillingAssassins = new CustomNumberOption(num++, MultiMenu.imposter, "Number Of <color=#80797c>Neutral</color> <color=#FF0000FF>Killers</color> <color=#FF0000FF>Assassins</color>", 1, 0, 5, 1);
            NumberOfNeutralNonKillingAssassins = new CustomNumberOption(num++, MultiMenu.imposter, "Number Of <color=#80797c>Neutral</color> Non-Killer <color=#FF0000FF>Assassins</color>", 1, 0, 5, 1);            
            NumberOfCrewAssassins = new CustomNumberOption(num++, MultiMenu.imposter, "Number Of <color=#8cffff>Crewmate</color> <color=#FF0000FF>Assassins</color>", 1, 0, 5, 1);
            AmneTurnImpAssassin = new CustomToggleOption(num++, MultiMenu.imposter, "<color=#80B2FFFF>Amnesiac</color> Turned <color=#FF0000FF>Impostor</color> Gets Ability", false);
            AmneTurnNeutAssassin = new CustomToggleOption(num++, MultiMenu.imposter, "<color=#80B2FFFF>Amnesiac</color> Turned <color=#80797c>Neutral</color> <color=#FF0000FF>Killing</color> Gets Ability", false);
            AssassinKills = new CustomNumberOption(num++, MultiMenu.imposter, "Number Of Shots", 1, 1, 15, 1);
            AssassinMultiKill = new CustomToggleOption(num++, MultiMenu.imposter, "Can Shoot More Than One Per Meeting", false);
            AssassinCrewmateGuess = new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Assassins</color> Can Guess \"<color=#8cffff>Crewmate</color>\"", false);
            AssassinGuessButtonBarry = new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Assassins</color> Can Guess <color=#E600FFFF>Button Barry</color>", false);
            AssassinGuessSpy = new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Assassins</color> Can Guess <color=#CCA3CCFF>Spy</color>", false);
            AssassinGuessModifiers = new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Assassins</color> Can Guess Crewmate Modifiers", false);
            AssassinateAfterVoting = new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Assassins</color> Can Guess After Voting", false);
            
            Altruist = new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#660000FF>Altruist</color>");
            ReviveDuration =
                new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#660000FF>Altruist</color> Revive Duration", 10f, 1f, 15f, 1f, CooldownFormat);
            AltruistTargetBody =
                new CustomToggleOption(num++, MultiMenu.crewmate, "Target's Body Disappears On Beginning Of Revive", false);

            Avenger =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#d3d3d3FF>Avenger</color>");
            AvengerTasksRemainingClicked =
                 new CustomNumberOption(num++, MultiMenu.crewmate, "Tasks Remaining When <color=#d3d3d3FF>Avenger</color> Can Be Clicked", 5, 1, 15, 1);
            AvengerTasksRemainingAlert =
                 new CustomNumberOption(num++, MultiMenu.crewmate, "Tasks Remaining When Alert Is Sent", 1, 1, 5, 1);
            AvengerRevealsNeutrals = new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#d3d3d3FF>Avenger</color> Reveals <color=#80797c>Neutral</color> <color=#FF0000FF>Killers</color>", false);
            AvengerCanBeClickedBy = new CustomStringOption(num++, MultiMenu.crewmate, "Who Can Click <color=#d3d3d3FF>Avenger</color>", new[] { "All", "Non-Crew", "Imps Only" });

            Camouflager = new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#708eef>Camouflager</color>");
            ChameleonSwoopCd =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Swoop Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            ChameleonSwoopDuration =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Swoop Duration", 10f, 5f, 15f, 1f, CooldownFormat);            


            Engineer =
                new CustomHeaderOption(num++, MultiMenu.crewmate,  "<color=#FFA60AFF>Engineer</color>");
            EngineerPer =
                new CustomStringOption(num++, MultiMenu.crewmate,  "<color=#FFA60AFF>Engineer</color> Fix Per", new[] { "Custom", "Round", "Game" });
            EngiFixPerRound = 
                new CustomNumberOption(num++, MultiMenu.crewmate,  "<color=#FFA60AFF>Engineer</color> Max Fix Per Round", 1, 0, 10, 1);
            EngiFixPerGame =
                new CustomNumberOption(num++, MultiMenu.crewmate,  "<color=#FFA60AFF>Engineer</color> Max Fix Per Game", 2, 0, 100, 1);


            Informant = new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#D4AF37FF>Informant</color>");

            InformantSeesNeutrals = new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#D4AF37FF>Informant</color> Sees Neutral Roles", false);
            InformantTasksRemaining =
                 new CustomNumberOption(num++, MultiMenu.crewmate, "Tasks Remaining When Revealed", 1, 1, 5, 1);
            InformantSeesImpInMeeting = new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#D4AF37FF>Informant</color> Sees Impostors In Meetings", true);

            Mayor =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#704FA8FF>Mayor</color>");
            MayorVoteBank =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Initial <color=#704FA8FF>Mayor</color> Vote Bank", 1, 1, 15, 1);
            MayorAnonymous =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#704FA8FF>Mayor</color> Votes Show Anonymous", false);
            MayorButton =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#704FA8FF>Mayor</color> Can Button", false);

            Medic =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#7efbc2>Medic</color>");
            ShowShielded =
                new CustomStringOption(num++, MultiMenu.crewmate, "Show Shielded Player",
                    new[] { "Self", "<color=#7efbc2>Medic</color>", "Self+<color=#7efbc2>Medic</color>", "Everyone" });
            WhoGetsNotification =
                new CustomStringOption(num++, MultiMenu.crewmate, "Who Gets Murder Attempt Indicator",
                    new[] { "<color=#7efbc2>Medic</color>", "Shielded", "Everyone", "Nobody" });
            ShieldBreaks = new CustomToggleOption(num++, MultiMenu.crewmate, "Shield Breaks On Murder Attempt", false);
            MedicReportSwitch = new CustomToggleOption(num++, MultiMenu.crewmate, "Show <color=#7efbc2>Medic</color> Reports");
            MedicFlashReport = new CustomToggleOption(num++, MultiMenu.crewmate,  "<color=#7efbc2>Medic</color> Report Can't Have Name If Flashed By <color=#FF0000FF>Grenadier</color>", true);
            MedicReportNameDuration =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Time Where <color=#7efbc2>Medic</color> Will Have Name", 0f, 0f, 60f, 2.5f,
                    CooldownFormat);
            MedicReportColorDuration =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Time Where <color=#7efbc2>Medic</color> Will Have Color Type", 15f, 0f, 60f, 2.5f,
                    CooldownFormat);

            Medium =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#A680FFFF>Medium</color>");
            MediateCooldown =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Mediate Cooldown", 10f, 1f, 15f, 1f, CooldownFormat);
            ShowMediatePlayer =
                new CustomToggleOption(num++, MultiMenu.crewmate, "Reveal Appearance Of Mediate Target", true);
            ShowMediumToDead =
                new CustomToggleOption(num++, MultiMenu.crewmate, "Reveal The Medium To The Mediate Target", true);
            DeadRevealed =
                new CustomStringOption(num++, MultiMenu.crewmate, "Who Is Revealed With Mediate", new[] { "Oldest Dead", "Newest Dead", "All Dead" });

            Mystic =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#4D4DFFFF>Mystic</color>");
            InitialExamineCooldown =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Initial Examine Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            ExamineCooldown =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Examine Cooldown", 10f, 1f, 15f, 1f, CooldownFormat);
            RecentKill =
                new CustomNumberOption(num++, MultiMenu.crewmate, "How Long Players Stay Bloody For", 25f, 10f, 60f, 2.5f, CooldownFormat);
            MysticReportOn = new CustomToggleOption(num++, MultiMenu.crewmate, "Show <color=#4D4DFFFF>Mystic</color> Reports", true);
            MysticRoleDuration =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Time Where <color=#4D4DFFFF>Mystic</color> Will Have Role", 15f, 0f, 60f, 2.5f,
                    CooldownFormat);
            MysticFactionDuration =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Time Where <color=#4D4DFFFF>Mystic</color> Will Have Faction", 30f, 0f, 60f, 2.5f,
                    CooldownFormat);
            ExamineReportOn = new CustomToggleOption(num++, MultiMenu.crewmate, "Show Examine Reports", true);
            MysticArrowDuration =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Dead Body Arrow Duration", 5f, 0f, 15f, 1f, CooldownFormat);

			Oracle = new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#2f1f73>Oracle</color>");
			ConfessCooldown = new CustomNumberOption(num++, MultiMenu.crewmate, "Confess Cooldown", 25f, 10f, 60f, 2.5f, 
            CooldownFormat);
			RevealAccuracy = new CustomNumberOption(num++, MultiMenu.crewmate, "Reveal Accuracy", 80f, 0f, 100f, 10f, 
            PercentFormat);
			NeutralNonKillersShowsEvil = new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#80797c>Neutral</color> Non-<color=#FF0000FF>Killing</color> Roles Show Evil", false);
			NeutralKillingShowsEvil = new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#80797c>Neutral</color> <color=#FF0000FF>Killing</color> Roles Show Evil", true);

            Sheriff =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color>");
            SheriffKillOther =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Miskill Kills <color=#8cffff>Crewmate</color>", false);
            SheriffKillsVulture =
                new CustomToggleOption(num++, MultiMenu.crewmate,  "<color=#f8cd46>Sheriff</color> Kills <color=#8C4005FF>Vulture</color>", true);
           SheriffKillsExecutioner =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Kills <color=#2d4222>Executioner</color>", false);
            SheriffKillsJester =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Kills <color=#cb81c0>Jester</color>", false);
            SheriffKillsPyromaniac =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Kills <color=#e89d51>Pyromaniac</color>", false);                
            SheriffKillsSerialKiller =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Kills <color=#642DEAFF>Serial Killer</color>", false);
            SheriffKillsGlitch =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Kills <color=#00FF00FF>The Glitch</color>", false);
            SheriffKillsLovers =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Kills <color=#FF66CCFF>Lovers</color>", false);                
            SheriffKillsJuggernaut =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Kills <color=#8C004DFF>Juggernaut</color>", false);
            SheriffKillsPlaguebearer =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Kills <color=#E6FFB3FF>Plaguebearer</color>", false);
            SheriffKillsWerewolf =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Kills <color=#A86629FF>Werewolf</color>", false);
            SheriffBodyReport = new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#f8cd46>Sheriff</color> Can Report Who They've Killed");

            Snitch =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#61b26c>Snitch</color>");
            SnitchCooldown =
                new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#61b26c>Snitch</color> Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            CrewKillingRed =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#8cffff>Crewmate</color> <color=#FF0000FF>Killing</color> Roles Show Evil", false);
            NeutralNNK =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#80797c>Neutral</color> Non-<color=#FF0000FF>Killing</color> Roles Show Evil", false);
            NeutKillingRed =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#80797c>Neutral</color> <color=#FF0000FF>Killing</color> Roles Show Evil", false);

            Swapper =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#863756>Swapper</color>");
            SwapperButton =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#863756>Swapper</color> Can Button", true);
            SwapAfterVoting =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#863756>Swapper</color> Can Swap After Voting", false);

            Tracker =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#009900FF>Tracker</color>");
            UpdateInterval =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Arrow Update Interval", 5f, 0.5f, 15f, 0.5f, CooldownFormat);
            TrackCooldown =
                new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#009900FF>Tracker</color> Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            ResetOnNewRound = new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#009900FF>Tracker</color> Arrows Reset After Each Round", false);
            MaxTracks = new CustomNumberOption(num++, MultiMenu.crewmate, "Maximum Number Of Tracks Per Round", 5, 1, 15, 1);

            Transporter =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#00EEFFFF>Transporter</color>");
            TransportCooldown =
                new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#00EEFFFF>Transporter</color> Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            TransportMaxUses =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Maximum Number Of Transports", 5, 1, 15, 1);
            TransporterVitals =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#00EEFFFF>Transporter</color> Can Use Vitals", false);

            Trapper =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#75fa4c>Trapper</color>");
            MinAmountOfTimeInTrap =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Min Amount Of Time In Trap To Register", 1f, 0f, 15f, 0.5f, CooldownFormat);
            TrapCooldown =
                new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#75fa4c>Trapper</color> Cooldown", 25f, 10f, 40f, 2.5f, CooldownFormat);
            TrapsRemoveOnNewRound =
                new CustomToggleOption(num++, MultiMenu.crewmate, "<color=#75fa4c>Traps</color> Removed After Each Round", true);
            MaxTraps =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Maximum Number Of <color=#75fa4c>Traps</color> Per Game", 5, 1, 15, 1);
            TrapSize =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Trap Size", 0.25f, 0.05f, 1f, 0.05f, MultiplierFormat);
            MinAmountOfPlayersInTrap =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Minimum Number Of Roles Required To Trigger Trap", 3, 1, 5, 1);


            Veteran =
                new CustomHeaderOption(num++, MultiMenu.crewmate, "<color=#998040FF>Veteran</color>");
            KilledOnAlert =
                new CustomToggleOption(num++, MultiMenu.crewmate, "Can Be Killed On Alert", false);
            AlertCooldown =
                new CustomNumberOption(num++, MultiMenu.crewmate, "<color=#998040FF>Veteran</color> Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            AlertDuration =
                new CustomNumberOption(num++, MultiMenu.crewmate, "Alert Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            MaxAlerts = new CustomNumberOption(num++, MultiMenu.crewmate, "Maximum Number Of Alerts", 5, 1, 15, 1);
        

            NeutralRolesMinMax = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#80797c>Neutral</color> Roles Settings");
            MinNeutralNonKillingRoles =
                new CustomNumberOption(num++, MultiMenu.neutral, "Min <color=#80797c>Neutral</color> Non-<color=#FF0000FF>Killing</color> Roles", 1, 0, 5, 1);
            MaxNeutralNonKillingRoles =
                new CustomNumberOption(num++, MultiMenu.neutral, "Max <color=#80797c>Neutral</color> Non-<color=#FF0000FF>Killing</color> Roles", 1, 0, 5, 1);
            MinNeutralKillingRoles =
                new CustomNumberOption(num++, MultiMenu.neutral, "Min <color=#80797c>Neutral</color> <color=#FF0000FF>Killing</color> Roles", 1, 0, 4, 1);
            MaxNeutralKillingRoles =
                new CustomNumberOption(num++, MultiMenu.neutral, "Max <color=#80797c>Neutral</color> <color=#FF0000FF>Killing</color> Roles", 1, 0, 4, 1);
            BegninNeutralHasTasks =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#80797c>Neutral</color> Benign Can Do Tasks", false);

            Amnesiac = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#80B2FFFF>Amnesiac</color>");
            RememberArrows =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#80B2FFFF>Amnesiac</color> Gets Arrows Pointing To Dead Bodies", false);
            RememberArrowDelay =
                new CustomNumberOption(num++, MultiMenu.neutral, "Time After Death Arrow Appears", 5f, 0f, 15f, 1f, CooldownFormat);
            
            Executioner =
                new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#2d4222>Executioner</color>");
            OnTargetDead = new CustomStringOption(num++, MultiMenu.neutral, "<color=#2d4222>Executioner</color> Becomes On Target Dead",
                new[] { "<color=#8cffff>Crewmate</color>", "<color=#80B2FFFF>Amnesiac</color>", "<color=#cb81c0>Jester</color>" });
            ExecutionerButton =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#2d4222>Executioner</color> Can Button", true);

            Guardian =
                new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#B3FFFFFF>Guardian</color>");
            ProtectCd =
                new CustomNumberOption(num++, MultiMenu.neutral, "Protect Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            ProtectDuration =
                new CustomNumberOption(num++, MultiMenu.neutral, "Protect Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            ProtectKCReset =
                new CustomNumberOption(num++, MultiMenu.neutral, "Kill Cooldown Reset When Protected", 2.5f, 0f, 15f, 0.5f, CooldownFormat);
            MaxProtects =
                new CustomNumberOption(num++, MultiMenu.neutral, "Maximum Number Of Protects", 5, 1, 15, 1);
            ShowProtect =
                new CustomStringOption(num++, MultiMenu.neutral, "Show Protected Player",
                    new[] { "Self", "<color=#B3FFFFFF>Guardian</color>", "Self+<color=#B3FFFFFF>Guardian</color>", "Everyone" });
            GaOnTargetDeath = new CustomStringOption(num++, MultiMenu.neutral, "<color=#B3FFFFFF>Guardian</color> Becomes On Target Dead",
                new[] { "<color=#8cffff>Crewmate</color>", "<color=#80B2FFFF>Amnesiac</color>", "<color=#cb81c0>Jester</color>" });
            GATargetKnows =
                new CustomToggleOption(num++, MultiMenu.neutral, "Target Knows <color=#B3FFFFFF>Guardian</color> Exists", false);
            GAKnowsTargetRole =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#B3FFFFFF>Guardian</color> Knows Targets Role", false);

            Jester =
                new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#cb81c0>Jester</color>");
            JesterKill =
                new CustomToggleOption(num++, MultiMenu.neutral, "Enable One Use Kill Button", false);                 
            JesterButton =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#cb81c0>Jester</color> Can Button", true);
            JesterVent =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#cb81c0>Jester</color> Can Hide In Vents", false);               
            JesterSwitchVent =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#cb81c0>Jester</color> Can Switch Between Vents", false);                
            JesterImpVision =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#cb81c0>Jester</color> Has Impostor Vision", false);

            Phantom =
                new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#662962FF>Phantom</color>");
            PhantomTasksRemaining =
                 new CustomNumberOption(num++, MultiMenu.neutral, "Tasks Remaining When <color=#662962FF>Phantom</color> Can Be Clicked", 5, 1, 15, 1);

            Vulture =
                new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#8C4005FF>Vulture</color>");
            EatNeeded =
                new CustomNumberOption(num++, MultiMenu.neutral, "Number Of Bodies To Win", 5, 1, 15, 1);
            VultureCdOn =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#8C4005FF>Vulture</color> Have A Cooldown", true);
            VultureVent =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#8C4005FF>Vulture</color> Can Vent", true);
            VultureCd =
                new CustomNumberOption(num++,MultiMenu.neutral,  "<color=#8C4005FF>Vulture</color> Cooldown", 15, 10, 60, 2.5f, CooldownFormat);


           
            Juggernaut =
                new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#8C004DFF>Juggernaut</color>");
            JuggKillCooldown = new CustomNumberOption(num++, MultiMenu.neutral, "<color=#8C004DFF>Juggernaut</color> Initial Kill Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            ReducedKCdPerKill = new CustomNumberOption(num++, MultiMenu.neutral, "Reduced Kill Cooldown Per Kill", 5f, 2.5f, 10f, 2.5f, CooldownFormat);
            JuggVent =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#8C004DFF>Juggernaut</color> Can Vent", false);

            TheGlitch =
                new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#00FF00FF>The Glitch</color>");
            MimicCooldownOption = new CustomNumberOption(num++, MultiMenu.neutral, "Mimic Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            MimicDurationOption = new CustomNumberOption(num++, MultiMenu.neutral, "Mimic Duration", 10f, 1f, 15f, 1f, CooldownFormat);
            HackCooldownOption = new CustomNumberOption(num++, MultiMenu.neutral, "Hack Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            HackDurationOption = new CustomNumberOption(num++, MultiMenu.neutral, "Hack Duration", 10f, 1f, 15f, 1f, CooldownFormat);
            GlitchHackDistanceOption =
                new CustomStringOption(num++, MultiMenu.neutral, "<color=#00FF00FF>The Glitch</color> Hack Distance", new[] { "Short", "Normal", "Long" });
            GlitchVent =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#00FF00FF>The Glitch</color> Can Vent", false);


            Plaguebearer = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#E6FFB3FF>Plaguebearer</color>");
            InfectCooldown =
                new CustomNumberOption(num++, MultiMenu.neutral, "<color=#E6FFB3FF>Plaguebearer</color> Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            PlaguebearerVent =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#E6FFB3FF>Plaguebearer</color> Can Vent", false);           
            PestVent =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#424242FF>Pestilence</color> Can Vent", false);

 Pyromaniac = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#e89d51>Pyromaniac</color>");
            DouseCooldown =
                new CustomNumberOption(num++, MultiMenu.neutral, "Douse Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            MaxDoused =
                new CustomNumberOption(num++, MultiMenu.neutral, "Maximum Alive Players Doused", 5, 1, 15, 1);
            ArsoImpVision =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#e89d51>Pyromaniac</color> Has Impostor Vision", false);               
           ArsoVent =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#e89d51>Pyromaniac</color> Can Vent", false);                
            IgniteCdRemoved =
                new CustomToggleOption(num++, MultiMenu.neutral, "Ignite Cooldown Removed When <color=#e89d51>Pyromaniac</color> Is Last Killer", false);


            SerialKiller = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#642DEAFF>Serial Killer</color>");
            SerialKillerVent =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#642DEAFF>Serial Killer</color> Can Vent", false);


            Werewolf = new CustomHeaderOption(num++, MultiMenu.neutral, "<color=#A86629FF>Werewolf</color>");
            RampageCooldown =
                new CustomNumberOption(num++, MultiMenu.neutral, "Rampage Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            RampageDuration =
                new CustomNumberOption(num++, MultiMenu.neutral, "Rampage Duration", 25f, 10f, 60f, 2.5f, CooldownFormat);
            RampageKillCooldown =
                new CustomNumberOption(num++, MultiMenu.neutral, "<color=#A86629FF>Werewolf</color> Kill Cooldown", 10f, 0.5f, 15f, 0.5f, CooldownFormat);
            WerewolfVent =
                new CustomToggleOption(num++, MultiMenu.neutral, "<color=#A86629FF>Werewolf</color> Can Vent", false);


            Bomber =
                new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Bomber</color>");
            DetonateDelay =
                new CustomNumberOption(num++, MultiMenu.imposter, "Bomb Delay", 5f, 1f, 15f, 1f, CooldownFormat);
            MaxKillsInDetonation =
                new CustomNumberOption(num++, MultiMenu.imposter, "Max Kills In Detonation", 5, 1, 15, 1);
            DetonateRadius =
                new CustomNumberOption(num++, MultiMenu.imposter, "Detonate Radius", 0.25f, 0.05f, 1f, 0.05f, MultiplierFormat);
            BomberVent =
                new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Bomber</color> Can Vent", false);

            Disguiser =
                new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Disguiser</color>");
            DisguiserCooldown =
                new CustomNumberOption(num++,MultiMenu.imposter,  "<color=#FF0000FF>Disguise</color> Cooldown", 25, 10, 40, 2.5f, CooldownFormat);
            DisguiserDuration =
                new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Disguise</color> Duration", 10, 5, 15, 1f, CooldownFormat);

            Cultist =
                new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Cultist</color>"); 
            ReviveCooldown2 =
                new CustomNumberOption(num++, MultiMenu.imposter, "Initial Convert Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            IncreasedCooldownPerRevive2 =
                new CustomNumberOption(num++, MultiMenu.imposter, "Increased Cooldown Per Convertion", 25f, 10f, 60f, 2.5f, CooldownFormat);

            Escapist =
                new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Escapist</color>");
            EscapeCooldown =
                new CustomNumberOption(num++, MultiMenu.imposter, "Recall Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            EscapistVent =
                new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Escapist</color> Can Vent", false);

            Grenadier =
                new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Grenadier</color>");
            GrenadeCooldown =
                new CustomNumberOption(num++, MultiMenu.imposter, "Flash Grenade Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            GrenadeDuration =
                new CustomNumberOption(num++, MultiMenu.imposter, "Flash Grenade Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            FlashRadius =
                new CustomNumberOption(num++, MultiMenu.imposter, "Flash Radius", 1f, 0.25f, 5f, 0.25f, MultiplierFormat);
            GrenadierIndicators =
                new CustomToggleOption(num++, MultiMenu.imposter, "Indicate Flashed <color=#8cffff>Crewmates</color>", false);
            GrenadierVent = new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Grenadier</color> Can Vent", false);                

            Miner = new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Miner</color>");
            MineCooldown =
                new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Miner</color> Cooldown", 10f, 1f, 15f, 1f, CooldownFormat);

            Morphling =
                new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Morphling</color>");
            MorphlingCooldown =
                new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Morphling</color> Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            MorphlingDuration =
                new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Morphling</color> Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            MorphlingVent =
                new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Morphling</color> Can Vent", false);

            Undertaker = new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Undertaker</color>");
            DragCooldown = new CustomNumberOption(num++, MultiMenu.imposter, "Drag Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            UndertakerDragSpeed =
                new CustomNumberOption(num++, MultiMenu.imposter, "Drag Speed", 0.75f, 0.25f, 1f, 0.05f, MultiplierFormat);

            Silencer = new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Silencer</color>");
            SilenceCooldown =
                new CustomNumberOption(num++, MultiMenu.imposter, "Initial <color=#FF0000FF>Silencer</color> Cooldown", 10f, 1f, 15f, 1f, CooldownFormat);

            Swooper = new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Swooper</color>");
            SwoopCooldown =
                new CustomNumberOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Swooper</color> Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            SwoopDuration =
                new CustomNumberOption(num++, MultiMenu.imposter, "Swoop Duration", 10f, 5f, 15f, 1f, CooldownFormat);
            SwooperVent =
                new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Swooper</color> Can Vent", false);
            SwooperPolusVent =
                new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Swooper</color> Can Vent On Polus", false);

            Vampire =
                new CustomHeaderOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Vampire</color>");
            BiteDuration =
                new CustomNumberOption(num++, MultiMenu.imposter, "Bite Kill Delay", 5f, 1f, 15f, 1f, CooldownFormat);
            VampireVent =
                new CustomToggleOption(num++, MultiMenu.imposter, "<color=#FF0000FF>Vampire</color> Can Use Vent", false);

            Bait = new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#00B3B3FF>Bait</color>");
            BaitMinDelay = new CustomNumberOption(num++, MultiMenu.modifiers, "Minimum Delay for the <color=#00B3B3FF>Bait</color> Report", 0f, 0f, 15f, 0.5f, CooldownFormat);
            BaitMaxDelay = new CustomNumberOption(num++, MultiMenu.modifiers, "Maximum Delay for the <color=#00B3B3FF>Bait</color> Report", 1f, 0f, 15f, 0.5f, CooldownFormat);

            Diseased = new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#808080FF>Diseased</color>");
            DiseasedKillMultiplier = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#808080FF>Diseased</color> Kill Multiplier", 3f, 1.5f, 5f, 0.5f, MultiplierFormat);

            Mini = new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#a938d6>Mini</color>");
            MiniSize = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#a938d6>Mini</color> Size", 0.45f, 0.3f, 0.6f, 0.5f, MultiplierFormat);
            MiniSpeed = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#a938d6>Mini</color> Speed", 1.25f, 1.05f, 2.5f, 0.05f, MultiplierFormat);

            Flash = new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#FF8080FF>Flash</color>");
            FlashSpeed = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FF8080FF>Flash</color> Speed", 1.25f, 1.05f, 2.5f, 0.05f, MultiplierFormat);

            Giant = new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#FFB34DFF>Giant</color>");
            GiantSize = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FFB34DFF>Giant</color> Size", 0.85f, 0.75f, 1.0f, 0.05f, MultiplierFormat);            
            GiantSlow = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FFB34DFF>Giant</color> Speed", 0.75f, 0.25f, 1f, 0.05f, MultiplierFormat);
            
            Lovers =
                new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#FF66CCFF>Lovers</color>");
            BothLoversDie = new CustomToggleOption(num++, MultiMenu.modifiers, "Both <color=#FF66CCFF>Lovers</color> Die Together");
            LovingImpPercent = new CustomNumberOption(num++, MultiMenu.modifiers, "Loving Impostor Probability", 20f, 0f, 100f, 10f,
                PercentFormat);
            AssassinGuessLovers = new CustomToggleOption(num++, MultiMenu.modifiers, "<color=#FF0000FF>Assassin</color> Can Guess <color=#FF66CCFF>Lovers</color>", false);
            NeutralLovers = new CustomToggleOption(num++, MultiMenu.modifiers, "<color=#80797c>Neutral</color> Roles Can Be <color=#FF66CCFF>Lovers</color>");
            
            Spy =
                new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#CCA3CCFF>Spy</color>");            
            WhoSeesDead = new CustomStringOption(num++, MultiMenu.modifiers, "Who Sees Dead Bodies On Admin",
                new[] { "Nobody", "<color=#CCA3CCFF>Spy</color>", "Everyone But <color=#CCA3CCFF>Spy</color>", "Everyone" });

            Underdog = new CustomHeaderOption(num++, MultiMenu.modifiers, "<color=#FF0000FF>Underdog</color>");
            UnderdogKillBonus = new CustomNumberOption(num++, MultiMenu.modifiers, "<color=#FF0000FF>Underdog</color> Kill Cooldown Bonus", 5f, 2.5f, 10f, 2.5f, CooldownFormat);
            UnderdogIncreasedKC = new CustomToggleOption(num++, MultiMenu.modifiers, "<color=#FF0000FF>Underdog</color> Increased Kill Cooldown When 2+ Imps", true);
        }
    }
}