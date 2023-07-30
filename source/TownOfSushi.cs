using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Reactor;
using Reactor.Utilities.Extensions;
using Reactor.Networking.Attributes;
using TownOfSushi.CustomOption;
using TownOfSushi.Patches;
using TownOfSushi.RainbowMod;
using TownOfSushi.Extensions;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;
using UnityEngine.SceneManagement;
using TownOfSushi.Patches.ScreenEffects;
using AmongUs.GameOptions;

namespace TownOfSushi
{
    [BepInPlugin(Id, "Town of Sushi", VersionString)]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency(SubmergedCompatibility.SUBMERGED_GUID, BepInDependency.DependencyFlags.SoftDependency)]
    [ReactorModFlags(Reactor.Networking.ModFlags.RequireOnAllClients)]
    public class TownOfSushi : BasePlugin
    {
        public const string Id = "com.slushiegoose.townofus";
        public const string VersionString = "2.0.0";
        public static System.Version Version = System.Version.Parse(VersionString);

        public static AssetLoader bundledAssets;

        public static Sprite JanitorClean;
        public static Sprite EngineerFix;
        public static Sprite SwapperSwitch;
        public static Sprite SwapperSwitchDisabled;
        public static Sprite Footprint;
        public static Sprite NormalKill;
        public static Sprite MedicSprite;
        public static Sprite SnitchSprite;
        public static Sprite SampleSprite;
        public static Sprite MorphSprite;
        public static Sprite Arrow;
        public static Sprite MineSprite;
        public static Sprite SwoopSprite;
        public static Sprite DouseSprite;
        public static Sprite IgniteSprite;
        public static Sprite ReviveSprite;
        public static Sprite ButtonSprite;
        public static Sprite DisperseSprite;
        public static Sprite CycleBackSprite;
        public static Sprite CycleForwardSprite;
        public static Sprite GuessSprite;
        public static Sprite DragSprite;
        public static Sprite DropSprite;
        public static Sprite FlashSprite;
        public static Sprite AlertSprite;
        public static Sprite RememberSprite;
        public static Sprite TrackSprite;
        public static Sprite PlantSprite;
        public static Sprite DetonateSprite;
        public static Sprite TransportSprite;
        public static Sprite MediateSprite;
        public static Sprite VestSprite;
        public static Sprite ProtectSprite;
        public static Sprite BlackmailSprite;
        public static Sprite BlackmailLetterSprite;
        public static Sprite BlackmailOverlaySprite;
        public static Sprite LighterSprite;
        public static Sprite DarkerSprite;
        public static Sprite InfectSprite;
        public static Sprite RampageSprite;
        public static Sprite TrapSprite;
        public static Sprite InspectSprite;
        public static Sprite ExamineSprite;
        public static Sprite EscapeSprite;
        public static Sprite MarkSprite;
        public static Sprite Revive2Sprite;
        public static Sprite WhisperSprite;
        public static Sprite ImitateSelectSprite;
        public static Sprite ImitateDeselectSprite;
        public static Sprite ObserveSprite;
 public static NormalGameOptionsV07 VanillaOptions => GameOptionsManager.Instance.currentNormalGameOptions;        
        public static Sprite BiteSprite;
        public static Sprite StakeSprite;
        public static Sprite RevealSprite;
        public static Sprite ConfessSprite;
        public static Sprite NoAbilitySprite;
        public static Sprite CamouflageSprite;
        public static Sprite CamoSprintSprite;
        public static Sprite CamoSprintFreezeSprite;
        public static Sprite RadiateSprite;
        public static Sprite HackSprite;
        public static Sprite MimicSprite;
        public static Sprite LockSprite;

        public static Sprite SettingsButtonSprite;
        public static Sprite CrewSettingsButtonSprite;
        public static Sprite NeutralSettingsButtonSprite;
        public static Sprite ImposterSettingsButtonSprite;
        public static Sprite ModifierSettingsButtonSprite;
        public static Sprite ToUBanner;
        public static Sprite UpdateTOUButton;
        public static Sprite UpdateSubmergedButton;

        public static Sprite ZoomPlusButton;
        public static Sprite ZoomMinusButton;

        public static Vector3 ButtonPosition { get; private set; } = new Vector3(2.6f, 0.7f, -9f);

        private static DLoadImage _iCallLoadImage;


        private Harmony _harmony;

        public ConfigEntry<string> Ip { get; set; }

        public ConfigEntry<ushort> Port { get; set; }

        public override void Load()
        {
            System.Console.WriteLine("000.000.000.000/000000000000000000");

            _harmony = new Harmony("com.slushiegoose.townofus");

            Generate.GenerateAll();

            bundledAssets = new();

            JanitorClean = CreateSprite("TownOfSushi.Resources.Janitor.png");
            EngineerFix = CreateSprite("TownOfSushi.Resources.Engineer.png");
            SwapperSwitch = CreateSprite("TownOfSushi.Resources.SwapperSwitch.png");
            SwapperSwitchDisabled = CreateSprite("TownOfSushi.Resources.SwapperSwitchDisabled.png");
            Footprint = CreateSprite("TownOfSushi.Resources.Footprint.png");
            NormalKill = CreateSprite("TownOfSushi.Resources.NormalKill.png");
            MedicSprite = CreateSprite("TownOfSushi.Resources.Medic.png");
            SnitchSprite = CreateSprite("TownOfSushi.Resources.Seer.png");
            SampleSprite = CreateSprite("TownOfSushi.Resources.Sample.png");
            MorphSprite = CreateSprite("TownOfSushi.Resources.Morph.png");
            Arrow = CreateSprite("TownOfSushi.Resources.Arrow.png");
            MineSprite = CreateSprite("TownOfSushi.Resources.Mine.png");
            SwoopSprite = CreateSprite("TownOfSushi.Resources.Swoop.png");
            DouseSprite = CreateSprite("TownOfSushi.Resources.Douse.png");
            IgniteSprite = CreateSprite("TownOfSushi.Resources.Ignite.png");
            ReviveSprite = CreateSprite("TownOfSushi.Resources.Revive.png");
            ButtonSprite = CreateSprite("TownOfSushi.Resources.Button.png");
            DisperseSprite = CreateSprite("TownOfSushi.Resources.Disperse.png");
            DragSprite = CreateSprite("TownOfSushi.Resources.Drag.png");
            DropSprite = CreateSprite("TownOfSushi.Resources.Drop.png");
            CycleBackSprite = CreateSprite("TownOfSushi.Resources.CycleBack.png");
            CycleForwardSprite = CreateSprite("TownOfSushi.Resources.CycleForward.png");
            GuessSprite = CreateSprite("TownOfSushi.Resources.Guess.png");
            FlashSprite = CreateSprite("TownOfSushi.Resources.Flash.png");
            AlertSprite = CreateSprite("TownOfSushi.Resources.Alert.png");
            RememberSprite = CreateSprite("TownOfSushi.Resources.Remember.png");
            TrackSprite = CreateSprite("TownOfSushi.Resources.Track.png");
            PlantSprite = CreateSprite("TownOfSushi.Resources.Plant.png");
            DetonateSprite = CreateSprite("TownOfSushi.Resources.Detonate.png");
            TransportSprite = CreateSprite("TownOfSushi.Resources.Transport.png");
            MediateSprite = CreateSprite("TownOfSushi.Resources.Mediate.png");
            VestSprite = CreateSprite("TownOfSushi.Resources.Vest.png");
            ProtectSprite = CreateSprite("TownOfSushi.Resources.Protect.png");
            BlackmailSprite = CreateSprite("TownOfSushi.Resources.Blackmail.png");
            BlackmailLetterSprite = CreateSprite("TownOfSushi.Resources.BlackmailLetter.png");
            BlackmailOverlaySprite = CreateSprite("TownOfSushi.Resources.BlackmailOverlay.png");
            LighterSprite = CreateSprite("TownOfSushi.Resources.Lighter.png");
            DarkerSprite = CreateSprite("TownOfSushi.Resources.Darker.png");
            InfectSprite = CreateSprite("TownOfSushi.Resources.Infect.png");
            RampageSprite = CreateSprite("TownOfSushi.Resources.Rampage.png");
            TrapSprite = CreateSprite("TownOfSushi.Resources.Trap.png");
            InspectSprite = CreateSprite("TownOfSushi.Resources.Inspect.png");
            ExamineSprite = CreateSprite("TownOfSushi.Resources.Examine.png");
            EscapeSprite = CreateSprite("TownOfSushi.Resources.Recall.png");
            MarkSprite = CreateSprite("TownOfSushi.Resources.Mark.png");
            Revive2Sprite = CreateSprite("TownOfSushi.Resources.Revive2.png");
            WhisperSprite = CreateSprite("TownOfSushi.Resources.Whisper.png");
            ImitateSelectSprite = CreateSprite("TownOfSushi.Resources.ImitateSelect.png");
            ImitateDeselectSprite = CreateSprite("TownOfSushi.Resources.ImitateDeselect.png");
            ObserveSprite = CreateSprite("TownOfSushi.Resources.Observe.png");
            BiteSprite = CreateSprite("TownOfSushi.Resources.Bite.png");
            StakeSprite = CreateSprite("TownOfSushi.Resources.Stake.png");
            RevealSprite = CreateSprite("TownOfSushi.Resources.Reveal.png");
            ConfessSprite = CreateSprite("TownOfSushi.Resources.Confess.png");
            NoAbilitySprite = CreateSprite("TownOfSushi.Resources.NoAbility.png");
            CamouflageSprite = CreateSprite("TownOfSushi.Resources.Camouflage.png");
            CamoSprintSprite = CreateSprite("TownOfSushi.Resources.CamoSprint.png");
            CamoSprintFreezeSprite = CreateSprite("TownOfSushi.Resources.CamoSprintFreeze.png");
            RadiateSprite = CreateSprite("TownOfSushi.Resources.Radiate.png");
            HackSprite = CreateSprite("TownOfSushi.Resources.Hack.png");
            MimicSprite = CreateSprite("TownOfSushi.Resources.Mimic.png");
            LockSprite = CreateSprite("TownOfSushi.Resources.Lock.png");

            SettingsButtonSprite = CreateSprite("TownOfSushi.Resources.SettingsButton.png");
            CrewSettingsButtonSprite = CreateSprite("TownOfSushi.Resources.Crewmate.png");
            NeutralSettingsButtonSprite = CreateSprite("TownOfSushi.Resources.Neutral.png");
            ImposterSettingsButtonSprite = CreateSprite("TownOfSushi.Resources.Impostor.png");
            ModifierSettingsButtonSprite = CreateSprite("TownOfSushi.Resources.Modifiers.png");
            ToUBanner = CreateSprite("TownOfSushi.Resources.TownOfUsBanner.png");
            UpdateTOUButton = CreateSprite("TownOfSushi.Resources.UpdateToUButton.png");
            UpdateSubmergedButton = CreateSprite("TownOfSushi.Resources.UpdateSubmergedButton.png");

            ZoomPlusButton = CreateSprite("TownOfSushi.Resources.Plus.png");
            ZoomMinusButton = CreateSprite("TownOfSushi.Resources.Minus.png");

            PalettePatch.Load();
            ClassInjector.RegisterTypeInIl2Cpp<RainbowBehaviour>();

            // RegisterInIl2CppAttribute.Register();

            Ip = Config.Bind("Custom", "Ipv4 or Hostname", "127.0.0.1");
            Port = Config.Bind("Custom", "Port", (ushort) 22023);
            var defaultRegions = ServerManager.DefaultRegions.ToList();
            var ip = Ip.Value;
            if (Uri.CheckHostName(Ip.Value).ToString() == "Dns")
                foreach (var address in Dns.GetHostAddresses(Ip.Value))
                {
                    if (address.AddressFamily != AddressFamily.InterNetwork)
                        continue;
                    ip = address.ToString();
                    break;
                }

            ServerManager.DefaultRegions = defaultRegions.ToArray();

            SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>) ((scene, loadSceneMode) =>
            {
                try { ModManager.Instance.ShowModStamp(); }
                catch { }
            }));

            _harmony.PatchAll();
            SubmergedCompatibility.Initialize();
        }

        public static Sprite CreateSprite(string name)
        {
            var pixelsPerUnit = 100f;
            var pivot = new Vector2(0.5f, 0.5f);

            var assembly = Assembly.GetExecutingAssembly();
            var tex = AmongUsExtensions.CreateEmptyTexture();
            var imageStream = assembly.GetManifestResourceStream(name);
            var img = imageStream.ReadFully();
            LoadImage(tex, img, true);
            tex.DontDestroy();
            var sprite = Sprite.Create(tex, new UnityEngine.Rect(0.0f, 0.0f, tex.width, tex.height), pivot, pixelsPerUnit);
            sprite.DontDestroy();
            return sprite;
        }

        public static void LoadImage(Texture2D tex, byte[] data, bool markNonReadable)
        {
            _iCallLoadImage ??= IL2CPP.ResolveICall<DLoadImage>("UnityEngine.ImageConversion::LoadImage");
            var il2CPPArray = (Il2CppStructArray<byte>) data;
            _iCallLoadImage.Invoke(tex.Pointer, il2CPPArray.Pointer, markNonReadable);
        }

        private delegate bool DLoadImage(IntPtr tex, IntPtr data, bool markNonReadable);
    }
}
