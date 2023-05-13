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
using TownOfRoles.CustomOption;
using TownOfRoles.Patches;
using TownOfRoles.RainbowMod;
using TownOfRoles.Extensions;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TownOfRoles
{
    [BepInPlugin(Id, "TownOfRoles", VersionString)]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency(SubmergedCompatibility.SUBMERGED_GUID, BepInDependency.DependencyFlags.SoftDependency)]
    [ReactorModFlags(Reactor.Networking.ModFlags.RequireOnAllClients)]
    public class TownOfRoles : BasePlugin
    {
        private static readonly Assembly myAssembly = Assembly.GetExecutingAssembly();        
        public const string Id = "TownOfRoles";
        public const string VersionString = "1.0.5";
        public static System.Version Version = System.Version.Parse(VersionString);
        public const int MaxPlayers = 127;
        public const int MaxImpostors = 62;   
        public static Assembly Assembly => typeof(TownOfRoles).Assembly;
        public static Assembly Executing => Assembly.GetExecutingAssembly();        
        public static bool LobbyCapped = true;
        public static bool Persistence = true;
        public static bool MCIActive = false;


        public static Sprite JanitorClean;
        public static Sprite EngineerFix;      
        public static Sprite LighterRoleSprite;        
        public static Sprite Rewind;      
        public static Sprite Logo;        

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
        public static Sprite CrewmateVent;               
        public static Sprite IgniteSprite;
        public static Sprite ReviveSprite;
        public static Sprite ButtonSprite;
        public static Sprite CamoSprite;        
        public static Sprite DisperseSprite;
        public static Sprite CycleBackSprite;
        public static Sprite CycleForwardSprite;
        public static Sprite GuessSprite;

        public static Sprite ShootSprite;        
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
        public static Sprite ProtectSprite;
        public static Sprite SilenceSprite;
        public static Sprite SilenceLetterSprite;
        public static Sprite SilenceOverlaySprite;
        public static Sprite LighterSprite;
        public static Sprite DarkerSprite;
        public static Sprite InfectSprite;
        public static Sprite RampageSprite;
        public static Sprite TrapSprite;
        public static Sprite ExamineSprite;
        public static Sprite JesterVent;        
        public static Sprite EscapeSprite;
        public static Sprite MarkSprite;
        public static Sprite DiscordImage;        
        public static Sprite Revive2Sprite;
        public static Sprite WhisperSprite;
        public static Sprite GameModeSettingsSprite;
        public static Sprite SettingsSprite;        
        public static Sprite ImitateSelectSprite;
        public static Sprite ImitateDeselectSprite;
        public static Sprite HackSprite;
        public static Sprite MimicSprite;
        public static Sprite LockSprite;

        public static Sprite CrewSettingsButtonSprite;
        public static Sprite NeutralSettingsButtonSprite;
        public static Sprite ImposterSettingsButtonSprite;
        public static Sprite ModifierSettingsButtonSprite;
        public static Sprite ToUBanner;
        public static Sprite UpdateTOUButton;
        public static Sprite UpdateSubmergedButton;

        public static Sprite HorseEnabledImage;
        public static Sprite HorseDisabledImage;
        public static Vector3 ButtonPosition { get; private set; } = new Vector3(2.6f, 0.7f, -9f);
        public static Sprite VaultSprite;
        public static Sprite CokpitSprite;
        public static Sprite TaskSprite;
        public static Sprite MedicalSprite;

        public static AnimationClip VaultAnim;
        public static AnimationClip CokpitAnim;
        public static AnimationClip MedicalAnim;

        public static GameObject CallPlateform;
        private static DLoadImage _iCallLoadImage;


        private Harmony _harmony;

        public ConfigEntry<string> Ip { get; set; }

        public ConfigEntry<ushort> Port { get; set; }

        public override void Load()
        {
            System.Console.WriteLine("000.000.000.000/000000000000000000");

            _harmony = new Harmony("TownOfRoles");

            Generate.GenerateAll();

            JanitorClean = CreateSprite("TownOfRoles.Resources.Janitor.png");                  
            EngineerFix = CreateSprite("TownOfRoles.Resources.Engineer.png");
            SwapperSwitch = CreateSprite("TownOfRoles.Resources.SwapperSwitch.png");
            SwapperSwitchDisabled = CreateSprite("TownOfRoles.Resources.SwapperSwitchDisabled.png");
            Footprint = CreateSprite("TownOfRoles.Resources.Footprint.png");
            NormalKill = CreateSprite("TownOfRoles.Resources.NormalKill.png");
            MedicSprite = CreateSprite("TownOfRoles.Resources.Medic.png");
            SnitchSprite = CreateSprite("TownOfRoles.Resources.Snitch.png");
            SampleSprite = CreateSprite("TownOfRoles.Resources.Sample.png");
            MorphSprite = CreateSprite("TownOfRoles.Resources.Morph.png");
            DiscordImage = Utils.CreateSprite("TownOfRoles.Resources.Discord.png");       
            Arrow = CreateSprite("TownOfRoles.Resources.Arrow.png");
            MineSprite = CreateSprite("TownOfRoles.Resources.Mine.png");
            SwoopSprite = CreateSprite("TownOfRoles.Resources.Swoop.png");
            CamoSprite = CreateSprite("TownOfRoles.Resources.Camouflage.png");                       
            DouseSprite = CreateSprite("TownOfRoles.Resources.Douse.png");
            IgniteSprite = CreateSprite("TownOfRoles.Resources.Ignite.png");
            Logo = CreateSprite("TownOfRoles.Resources.Logo.png");            
            ShootSprite = CreateSprite("TownOfRoles.Resources.Shoot.png");            
            ReviveSprite = CreateSprite("TownOfRoles.Resources.Revive.png");
            ButtonSprite = CreateSprite("TownOfRoles.Resources.Button.png");
            DisperseSprite = CreateSprite("TownOfRoles.Resources.Disperse.png");
            DragSprite = CreateSprite("TownOfRoles.Resources.Drag.png");
            DropSprite = CreateSprite("TownOfRoles.Resources.Drop.png");
            JesterVent = CreateSprite("TownOfRoles.Resources.JesterVent.png");          
            CrewmateVent = CreateSprite("TownOfRoles.Resources.CrewVent.png");                       
            CycleBackSprite = CreateSprite("TownOfRoles.Resources.CycleBack.png");
            CycleForwardSprite = CreateSprite("TownOfRoles.Resources.CycleForward.png");
            GuessSprite = CreateSprite("TownOfRoles.Resources.Guess.png");
            FlashSprite = CreateSprite("TownOfRoles.Resources.Flash.png");
            AlertSprite = CreateSprite("TownOfRoles.Resources.Alert.png");
            RememberSprite = CreateSprite("TownOfRoles.Resources.Remember.png");
            TrackSprite = CreateSprite("TownOfRoles.Resources.Track.png");
            PlantSprite = CreateSprite("TownOfRoles.Resources.Plant.png");
            LighterRoleSprite = CreateSprite("TownOfRoles.Resources.LighterRole.png");            
            DetonateSprite = CreateSprite("TownOfRoles.Resources.Detonate.png");
            TransportSprite = CreateSprite("TownOfRoles.Resources.Transport.png");
            MediateSprite = CreateSprite("TownOfRoles.Resources.Mediate.png");
            ProtectSprite = CreateSprite("TownOfRoles.Resources.Protect.png");
            SilenceSprite = CreateSprite("TownOfRoles.Resources.Silence.png");
            Rewind = CreateSprite("TownOfRoles.Resources.Rewind.png");            
            SilenceLetterSprite = CreateSprite("TownOfRoles.Resources.SilenceLetter.png");
            SilenceOverlaySprite = CreateSprite("TownOfRoles.Resources.SilenceOverlay.png");
            LighterSprite = CreateSprite("TownOfRoles.Resources.Lighter.png");
            DarkerSprite = CreateSprite("TownOfRoles.Resources.Darker.png");
            InfectSprite = CreateSprite("TownOfRoles.Resources.Infect.png");
            RampageSprite = CreateSprite("TownOfRoles.Resources.Rampage.png");
            TrapSprite = CreateSprite("TownOfRoles.Resources.Trap.png");
            ExamineSprite = CreateSprite("TownOfRoles.Resources.Examine.png");
            EscapeSprite = CreateSprite("TownOfRoles.Resources.Recall.png");
            MarkSprite = CreateSprite("TownOfRoles.Resources.Mark.png");
            Revive2Sprite = CreateSprite("TownOfRoles.Resources.Revive2.png");
            WhisperSprite = CreateSprite("TownOfRoles.Resources.Whisper.png");
            ImitateSelectSprite = CreateSprite("TownOfRoles.Resources.ImitateSelect.png");
            ImitateDeselectSprite = CreateSprite("TownOfRoles.Resources.ImitateDeselect.png");
            HackSprite = CreateSprite("TownOfRoles.Resources.Hack.png");
            MimicSprite = CreateSprite("TownOfRoles.Resources.Mimic.png");
            LockSprite = CreateSprite("TownOfRoles.Resources.Lock.png");

            CrewSettingsButtonSprite = CreateSprite("TownOfRoles.Resources.Crewmate.png");
            NeutralSettingsButtonSprite = CreateSprite("TownOfRoles.Resources.Neutral.png");
            ImposterSettingsButtonSprite = CreateSprite("TownOfRoles.Resources.Impostor.png");
            ModifierSettingsButtonSprite = CreateSprite("TownOfRoles.Resources.Modifiers.png");
            SettingsSprite = CreateSprite("TownOfRoles.Resources.SettingsButton.png");            
            ToUBanner = CreateSprite("TownOfRoles.Resources.BannerTOR.png");
            UpdateTOUButton = CreateSprite("TownOfRoles.Resources.UpdateToUButton.png");
            UpdateSubmergedButton = CreateSprite("TownOfRoles.Resources.UpdateSubmergedButton.png");

            HorseEnabledImage = CreateSprite("TownOfRoles.Resources.HorseOn.png");
            HorseDisabledImage = CreateSprite("TownOfRoles.Resources.HorseOff.png");

            var resourceStream = myAssembly.GetManifestResourceStream("TownOfRoles.Resources.Airship");
            var assetBundle = AssetBundle.LoadFromMemory(resourceStream.ReadFully());

            VaultSprite = assetBundle.LoadAsset<Sprite>("Vault").DontDestroy();
            CokpitSprite = assetBundle.LoadAsset<Sprite>("Cokpit").DontDestroy();
            MedicalSprite = assetBundle.LoadAsset<Sprite>("Medical").DontDestroy();
            TaskSprite = assetBundle.LoadAsset<Sprite>("task-shields").DontDestroy();

            VaultAnim = assetBundle.LoadAsset<AnimationClip>("Vault.anim").DontDestroy();
            CokpitAnim = assetBundle.LoadAsset<AnimationClip>("Cokpit.anim").DontDestroy();
            MedicalAnim = assetBundle.LoadAsset<AnimationClip>("Medical.anim").DontDestroy();

            CallPlateform = assetBundle.LoadAsset<GameObject>("call.prefab").DontDestroy();
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
            var tex = Utils.CreateEmptyTexture();
            var imageStream = assembly.GetManifestResourceStream(name);
            var img = imageStream.ReadFully();
            LoadImage(tex, img, true);
            tex.DontDestroy();
            var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), pivot, pixelsPerUnit);
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
