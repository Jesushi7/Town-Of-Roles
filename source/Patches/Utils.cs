using HarmonyLib;
using Hazel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Reactor.Utilities.Extensions;
using TownOfRoles.CrewmateRoles.MedicMod;
using TownOfRoles.Extensions;
using TownOfRoles.Patches;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Cultist;
using TownOfRoles.Roles.Modifiers;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;
using Object = UnityEngine.Object;
using PerformKill = TownOfRoles.Modifiers.UnderdogMod.PerformKill;
using Random = UnityEngine.Random;
using AmongUs.GameOptions;
using Murder = TownOfRoles.CrewmateRoles.MedicMod.Murder;
using System.Reflection;
using Il2CppInterop.Runtime;
using System.IO;
using InnerNet;
using Reactor.Utilities;

namespace TownOfRoles
{
    [HarmonyPatch]
    public static class Utils
    {
        internal static bool ShowDeadBodies = false;
        private static GameData.PlayerInfo voteTarget = null;

        public static Dictionary<PlayerControl, Color> oldColors = new Dictionary<PlayerControl, Color>();
        private static DLoadImage _iCallLoadImage;
        public static List<WinningPlayerData> potentialWinners = new List<WinningPlayerData>();

        public static void Morph(PlayerControl player, PlayerControl MorphedPlayer, bool resetAnim = false)
        {
            if (CamouflageUnCamouflage.IsCamoed) return;
            if (player.GetCustomOutfitType() != CustomPlayerOutfitType.Morph)
                player.SetOutfit(CustomPlayerOutfitType.Morph, MorphedPlayer.Data.DefaultOutfit);
        }
        public static void MurderPlayer(PlayerControl killer, PlayerControl target, bool lunge)
        {        
                var deadBody = new DeadPlayer
                {
                    PlayerId = target.PlayerId,
                    KillerId = killer.PlayerId,
                    KillTime = DateTime.UtcNow
                };
        }
        public static void Unmorph(PlayerControl player)
        {
           player.SetOutfit(CustomPlayerOutfitType.Default);
        }

        public static void Camouflage()
        {
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (player.GetCustomOutfitType() != CustomPlayerOutfitType.Camouflage && 
                player.GetCustomOutfitType() != CustomPlayerOutfitType.Swooper &&
                player.GetCustomOutfitType() != CustomPlayerOutfitType.PlayerNameOnly)
                {
                    player.SetOutfit(CustomPlayerOutfitType.Camouflage, new GameData.PlayerOutfit()
                    {
                        ColorId = player.GetDefaultOutfit().ColorId,
                        HatId = "",
                        SkinId = "",
                        VisorId = "",
                        PlayerName = " "
                    });

                    PlayerMaterial.SetColors(Color.grey, player.myRend());
                    player.nameText().color = Color.clear;
                    player.cosmetics.colorBlindText.color = Color.clear;
                }
            }
        }
        public static void UnCamouflage()
        {
            foreach (var player in PlayerControl.AllPlayerControls) Unmorph(player);
        }

        public static void AddUnique<T>(this Il2CppSystem.Collections.Generic.List<T> self, T item)
            where T : IDisconnectHandler
        {
            if (!self.Contains(item)) self.Add(item);
        }

        public static bool IsLover(this PlayerControl player)
        {
            return player.Is(ModifierEnum.Lover);
        }

        public static bool Is(this PlayerControl player, RoleEnum roleType)
        {
            return Role.GetRole(player)?.RoleType == roleType;
        }

        public static bool Is(this PlayerControl player, ModifierEnum modifierType)
        {
            return Modifier.GetModifier(player)?.ModifierType == modifierType;
        }

        public static bool Is(this PlayerControl player, AbilityEnum abilityType)
        {
            return Ability.GetAbility(player)?.AbilityType == abilityType;
        }

        public static bool Is(this PlayerControl player, Faction faction)
        {
            return Role.GetRole(player)?.Faction == faction;
        }

        public static List<PlayerControl> GetCrewmates(List<PlayerControl> impostors)
        {
            return PlayerControl.AllPlayerControls.ToArray().Where(
                player => !impostors.Any(imp => imp.PlayerId == player.PlayerId)
            ).ToList();
        }

        public static List<PlayerControl> GetImpostors(
            List<GameData.PlayerInfo> infected)
        {
            var impostors = new List<PlayerControl>();
            foreach (var impData in infected)
                impostors.Add(impData.Object);

            return impostors;
        }

        public static RoleEnum GetRole(PlayerControl player)
        {
            if (player == null) return RoleEnum.None;
            if (player.Data == null) return RoleEnum.None;

            var role = Role.GetRole(player);
            if (role != null) return role.RoleType;

            return player.Data.IsImpostor() ? RoleEnum.Impostor : RoleEnum.Crewmate;
        }

        public static PlayerControl PlayerById(byte id)
        {
            foreach (var player in PlayerControl.AllPlayerControls)
                if (player.PlayerId == id)
                    return player;

            return null;
        }
        public static void DefaultOutfit(PlayerControl player)
        {
            player.myRend().color = new Color32(255, 255, 255, 255);
            player.SetOutfit(CustomPlayerOutfitType.Default);
        }        
        public static void DefaultOutfitAll()
        {
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                DefaultOutfit(player);
                player.myRend().color = new Color32(255, 255, 255, 255);
            }
        }
        public static bool IsShielded(this PlayerControl player)
        {
            return Role.GetRoles(RoleEnum.Medic).Any(role =>
            {
                var shieldedPlayer = ((Medic)role).ShieldedPlayer;
                return shieldedPlayer != null && player.PlayerId == shieldedPlayer.PlayerId;
            });
        }

        public static Medic GetMedic(this PlayerControl player)
        {
            return Role.GetRoles(RoleEnum.Medic).FirstOrDefault(role =>
            {
                var shieldedPlayer = ((Medic)role).ShieldedPlayer;
                return shieldedPlayer != null && player.PlayerId == shieldedPlayer.PlayerId;
            }) as Medic;
        }
       
        public static bool IsOnAlert(this PlayerControl player)
        {
            return Role.GetRoles(RoleEnum.Veteran).Any(role =>
            {
                var veteran = (Veteran)role;
                return veteran != null && veteran.OnAlert && player.PlayerId == veteran.Player.PlayerId;
            });
        }
    

        public static bool IsProtected(this PlayerControl player)
        {
            return Role.GetRoles(RoleEnum.Guardian).Any(role =>
            {
                var gaTarget = ((Guardian)role).target;
                var ga = (Guardian)role;
                return gaTarget != null && ga.Protecting && player.PlayerId == gaTarget.PlayerId;
            });
        }

        public static bool IsInfected(this PlayerControl player)
        {
            return Role.GetRoles(RoleEnum.Plaguebearer).Any(role =>
            {
                var plaguebearer = (Plaguebearer)role;
                return plaguebearer != null && (plaguebearer.InfectedPlayers.Contains(player.PlayerId) || player.PlayerId == plaguebearer.Player.PlayerId);
            });
        }

        public static List<bool> Interact(PlayerControl player, PlayerControl target, bool toKill = false)
        {
            bool fullCooldownReset = false;
            bool gaReset = false;
            bool survReset = false;
            bool zeroSecReset = false;
            bool abilityUsed = false;
            if (target.IsInfected() || player.IsInfected())
            {
                foreach (var pb in Role.GetRoles(RoleEnum.Plaguebearer)) ((Plaguebearer)pb).RpcSpreadInfection(target, player);
            }
            if (target.Is(RoleEnum.Pestilence))
            {
                if (player.IsShielded())
                {
                    var medic = player.GetMedic().Player.PlayerId;
                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                        (byte)CustomRPC.AttemptSound, SendOption.Reliable, -1);
                    writer.Write(medic);
                    writer.Write(player.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);

                    if (CustomGameOptions.ShieldBreaks) fullCooldownReset = true;
                    else zeroSecReset = true;

                    StopKill.BreakShield(medic, player.PlayerId, CustomGameOptions.ShieldBreaks);
                }
                else if (player.IsProtected()) gaReset = true;
                else RpcMurderPlayer(target, player);
            }
            else if (target.IsOnAlert())
            {
                if (player.Is(RoleEnum.Pestilence)) zeroSecReset = true;
                else if (player.IsShielded())
                {
                    var medic = player.GetMedic().Player.PlayerId;
                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                        (byte)CustomRPC.AttemptSound, SendOption.Reliable, -1);
                    writer.Write(medic);
                    writer.Write(player.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);

                    if (CustomGameOptions.ShieldBreaks) fullCooldownReset = true;
                    else zeroSecReset = true;

                    StopKill.BreakShield(medic, player.PlayerId, CustomGameOptions.ShieldBreaks);
                }
                else if (player.IsProtected()) gaReset = true;
                else RpcMurderPlayer(target, player);
                if (toKill && CustomGameOptions.KilledOnAlert)
                {
                    if (target.IsShielded())
                    {
                        var medic = target.GetMedic().Player.PlayerId;
                        var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                            (byte)CustomRPC.AttemptSound, SendOption.Reliable, -1);
                        writer.Write(medic);
                        writer.Write(target.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);

                        if (CustomGameOptions.ShieldBreaks) fullCooldownReset = true;
                        else zeroSecReset = true;

                        StopKill.BreakShield(medic, target.PlayerId, CustomGameOptions.ShieldBreaks);
                    }
                    else if (target.IsProtected()) gaReset = true;
                    else
                    {
                        if (player.Is(RoleEnum.Glitch))
                        {
                            var glitch = Role.GetRole<Glitch>(player);
                            glitch.LastKill = DateTime.UtcNow;
                        }
                        
                        else if (player.Is(RoleEnum.Juggernaut))
                        {
                            var jugg = Role.GetRole<Juggernaut>(player);
                            jugg.JuggKills += 1;
                            jugg.LastKill = DateTime.UtcNow;
                        }
                        else if (player.Is(RoleEnum.Pestilence))
                        {
                            var pest = Role.GetRole<Pestilence>(player);
                            pest.LastKill = DateTime.UtcNow;
                        }                    
                        else if (player.Is(RoleEnum.SerialKiller))
                        {
                            var jack = Role.GetRole<SerialKiller>(player);
                            jack.LastKill = DateTime.UtcNow;
                        }                                   
                        else if (player.Is(RoleEnum.Werewolf))
                        {
                            var ww = Role.GetRole<Werewolf>(player);
                            ww.LastKilled = DateTime.UtcNow;
                        }
                        RpcMurderPlayer(player, target);
                        abilityUsed = true;
                        fullCooldownReset = true;
                        gaReset = false;
                        zeroSecReset = false;
                    }
                }
            }
            else if (target.IsShielded() && toKill)
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                    (byte)CustomRPC.AttemptSound, SendOption.Reliable, -1);
                writer.Write(target.GetMedic().Player.PlayerId);
                writer.Write(target.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);

                System.Console.WriteLine(CustomGameOptions.ShieldBreaks + "- shield break");
                if (CustomGameOptions.ShieldBreaks) fullCooldownReset = true;
                else zeroSecReset = true;
                StopKill.BreakShield(target.GetMedic().Player.PlayerId, target.PlayerId, CustomGameOptions.ShieldBreaks);
            }
            else if (target.IsProtected() && toKill)
            {
                gaReset = true;
            }
            else if (toKill)
            {
                if (player.Is(RoleEnum.Glitch))
                {
                    var glitch = Role.GetRole<Glitch>(player);
                    glitch.LastKill = DateTime.UtcNow;
                }
                else if (player.Is(RoleEnum.Juggernaut))
                {
                    var jugg = Role.GetRole<Juggernaut>(player);
                    jugg.JuggKills += 1;
                    jugg.LastKill = DateTime.UtcNow;
                }
                else if (player.Is(RoleEnum.Pestilence))
                {
                    var pest = Role.GetRole<Pestilence>(player);
                    pest.LastKill = DateTime.UtcNow;
                }                
                else if (player.Is(RoleEnum.SerialKiller))
                {
                    var pest = Role.GetRole<SerialKiller>(player);
                    pest.LastKill = DateTime.UtcNow;
                }                                   
                else if (player.Is(RoleEnum.Werewolf))
                {
                    var ww = Role.GetRole<Werewolf>(player);
                    ww.LastKilled = DateTime.UtcNow;
                }
                RpcMurderPlayer(player, target);
                abilityUsed = true;
                fullCooldownReset = true;
            }
            else
            {
                abilityUsed = true;
                fullCooldownReset = true;
            }
            var reset = new List<bool>();
            reset.Add(fullCooldownReset);
            reset.Add(gaReset);
            reset.Add(survReset);
            reset.Add(zeroSecReset);
            reset.Add(abilityUsed);
            return reset;
        }

        public static Il2CppSystem.Collections.Generic.List<PlayerControl> GetClosestPlayers(Vector2 truePosition, float radius, bool includeDead)
        {
            Il2CppSystem.Collections.Generic.List<PlayerControl> playerControlList = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
            float lightRadius = radius * ShipStatus.Instance.MaxLightRadius;
            Il2CppSystem.Collections.Generic.List<GameData.PlayerInfo> allPlayers = GameData.Instance.AllPlayers;
            for (int index = 0; index < allPlayers.Count; ++index)
            {
                GameData.PlayerInfo playerInfo = allPlayers[index];
                if (!playerInfo.Disconnected && (!playerInfo.Object.Data.IsDead || includeDead))
                {
                    Vector2 vector2 = new Vector2(playerInfo.Object.GetTruePosition().x - truePosition.x, playerInfo.Object.GetTruePosition().y - truePosition.y);
                    float magnitude = ((Vector2)vector2).magnitude;
                    if (magnitude <= lightRadius)
                    {
                        PlayerControl playerControl = playerInfo.Object;
                        playerControlList.Add(playerControl);
                    }
                }
            }
            return playerControlList;
        }
 public static IEnumerator FlashCoro(Color color, string message = "", float duration = 1f, float size = 100f)
        {
            if (!HudManager.Instance || HudManager.Instance.FullScreen == null)
                yield break;

            HudManager.Instance.FullScreen.gameObject.SetActive(true);
            HudManager.Instance.FullScreen.enabled = true;

            // Message Text
            var messageText = Object.Instantiate(HudManager.Instance.KillButton.cooldownTimerText, HudManager.Instance.transform);
            messageText.text = $"<size={size}%>{message}</size>";
            messageText.enableWordWrapping = false;
            messageText.transform.localScale = Vector3.one * 0.5f;
            messageText.transform.localPosition = new Vector3(0f, 0f, 0f);
            messageText.gameObject.SetActive(true);
            HudManager.Instance.StartCoroutine(Effects.Lerp(duration, new Action<float>((p) =>
            {
                var fullscreen = HudManager.Instance.FullScreen;

                if (p < 0.5)
                {
                    if (fullscreen != null)
                        fullscreen.color = new Color(color.r, color.g, color.b, Mathf.Clamp01(p * 1.5f));
                }
                else if (fullscreen != null)
                    fullscreen.color = new Color(color.r, color.g, color.b, Mathf.Clamp01((1 - p) * 1.5f));

                if (p == 1f && fullscreen != null)
                    fullscreen.enabled = false;

                if (p == 1f)
                    messageText.gameObject.Destroy();
            })));
        }
        public static PlayerControl GetClosestPlayer(PlayerControl refPlayer, List<PlayerControl> AllPlayers)
        {
            var num = double.MaxValue;
            var refPosition = refPlayer.GetTruePosition();
            PlayerControl result = null;
            foreach (var player in AllPlayers)
            {
                if (player.Data.IsDead || player.PlayerId == refPlayer.PlayerId || !player.Collider.enabled || (player.inVent)) continue;
                var playerPosition = player.GetTruePosition();
                var distBetweenPlayers = Vector2.Distance(refPosition, playerPosition);
                var isClosest = distBetweenPlayers < num;
                if (!isClosest) continue;
                var vector = playerPosition - refPosition;
                if (PhysicsHelpers.AnyNonTriggersBetween(
                    refPosition, vector.normalized, vector.magnitude, Constants.ShipAndObjectsMask
                )) continue;
                num = distBetweenPlayers;
                result = player;
            }
            
            return result;
        }
        
        public static List<object> AllPlayerInfo(this PlayerControl player)
        {
            var role = Role.GetRole(player);
            var modifier = Modifier.GetModifier(player);
            var ability = Ability.GetAbility(player);

            var info = new List<object>();

            info.Add(role); //0
            info.Add(modifier); //1
            info.Add(ability); 

            return info;
        }

        public static bool LastImp() => PlayerControl.AllPlayerControls.ToArray().Count(x => x.Is(Faction.Impostors) && !(x.Data.IsDead || x.Data.Disconnected)) == 1;


        public static float GetUnderdogChange(PlayerControl player)
        {
            if (!player.Is(ModifierEnum.Underdog))
                return 0f;

            var last = player.Is(Faction.Impostors) ? LastImp() : LastImp();
            var lowerKC = -CustomGameOptions.UnderdogKillBonus;
            var upperKC = CustomGameOptions.UnderdogKillBonus;

            if (CustomGameOptions.UnderdogIncreasedKC && !last)
                return upperKC;
            else if (last)
                return lowerKC;
            else
                return 0f;
        }
        public static void SetTarget(
            ref PlayerControl closestPlayer,
            KillButton button,
            float maxDistance = float.NaN,
            List<PlayerControl> targets = null
        )
        {
            if (!button.isActiveAndEnabled) return;

            button.SetTarget(
                SetClosestPlayer(ref closestPlayer, maxDistance, targets)
            );
        }

        public static PlayerControl SetClosestPlayer(
            ref PlayerControl closestPlayer,
            float maxDistance = float.NaN,
            List<PlayerControl> targets = null
        )
        {
            if (float.IsNaN(maxDistance))
                maxDistance = GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
            var player = GetClosestPlayer(
                PlayerControl.LocalPlayer,
                targets ?? PlayerControl.AllPlayerControls.ToArray().ToList()
            );
            var closeEnough = player == null || (
                GetDistBetweenPlayers(PlayerControl.LocalPlayer, player) < maxDistance
            );
            return closestPlayer = closeEnough ? player : null;
        }

        public static double GetDistBetweenPlayers(PlayerControl player, PlayerControl refplayer)
        {
            var truePosition = refplayer.GetTruePosition();
            var truePosition2 = player.GetTruePosition();
            return Vector2.Distance(truePosition, truePosition2);
        }

        public static void RpcMurderPlayer(PlayerControl killer, PlayerControl target)
        {
            MurderPlayer(killer, target);
            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte)CustomRPC.BypassKill, SendOption.Reliable, -1);
            writer.Write(killer.PlayerId);
            writer.Write(target.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
        public static Texture2D CreateEmptyTexture(int width = 0, int height = 0) => new Texture2D(width, height, TextureFormat.RGBA32, Texture.GenerateAllMips, false, IntPtr.Zero);
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
        public static void MurderPlayer(PlayerControl killer, PlayerControl target)
        {
            var data = target.Data;
            if (data != null && !data.IsDead)
            {
                if (killer == PlayerControl.LocalPlayer)
                    SoundManager.Instance.PlaySound(PlayerControl.LocalPlayer.KillSfx, false, 0.8f);

                if (!killer.Is(Faction.Crewmates) && killer != target
                    && GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.Normal) Role.GetRole(killer).Kills += 1;

                if (killer.Is(RoleEnum.Sheriff))
                {
                    var sheriff = Role.GetRole<Sheriff>(killer);
                    if (target.Is(Faction.Impostors) ||
                        target.Is(RoleEnum.Glitch) && CustomGameOptions.SheriffKillsGlitch ||
                        target.Is(RoleEnum.Arsonist) && CustomGameOptions.SheriffKillsArsonist ||
                        target.Is(RoleEnum.Plaguebearer) && CustomGameOptions.SheriffKillsPlaguebearer ||
                        target.Is(RoleEnum.Pestilence) && CustomGameOptions.SheriffKillsPlaguebearer ||
                        target.Is(RoleEnum.Werewolf) && CustomGameOptions.SheriffKillsWerewolf ||
                         target.Is(RoleEnum.SerialKiller) && CustomGameOptions.SheriffKillsSerialKiller ||
                        target.Is(RoleEnum.Juggernaut) && CustomGameOptions.SheriffKillsJuggernaut ||
                        target.Is(RoleEnum.Executioner) && CustomGameOptions.SheriffKillsExecutioner ||
                        target.Is(ModifierEnum.Lover) && CustomGameOptions.SheriffKillsLovers ||
                        target.Is(RoleEnum.Jester) && CustomGameOptions.SheriffKillsJester) sheriff.CorrectKills += 1;
                    else if (killer == target) sheriff.IncorrectKills += 1;
                }
            
            var playerName = PlayerControl.LocalPlayer.name;
            var blank = "";                
            if (CamouflageUnCamouflage.IsCamoed)
                PlayerControl.LocalPlayer.nameText().text = blank;
                if (killer.Is(RoleEnum.Veteran))
                {
                    var veteran = Role.GetRole<Veteran>(killer);
                    if (target.Is(Faction.Impostors) || target.Is(Faction.Neutral)) veteran.CorrectKills += 1;
                    else if (killer != target) veteran.IncorrectKills += 1;
                }

                target.gameObject.layer = LayerMask.NameToLayer("Ghost");
                target.Visible = false;

                if (PlayerControl.LocalPlayer.Is(RoleEnum.Mystic) && !PlayerControl.LocalPlayer.Data.IsDead)
                {
                    Coroutines.Start(FlashCoroutine(Patches.Colors.Mystic));
                }

                if (target.AmOwner)
                {
                    try
                    {
                        if (Minigame.Instance)
                        {
                            Minigame.Instance.Close();
                            Minigame.Instance.Close();
                        }

                        if (MapBehaviour.Instance)
                        {
                            MapBehaviour.Instance.Close();
                            MapBehaviour.Instance.Close();
                        }
                    }
                    catch
                    {
                    }

                    DestroyableSingleton<HudManager>.Instance.KillOverlay.ShowKillAnimation(killer.Data, data);
                    DestroyableSingleton<HudManager>.Instance.ShadowQuad.gameObject.SetActive(false);
                    target.nameText().GetComponent<MeshRenderer>().material.SetInt("_Mask", 0);
                    target.RpcSetScanner(false);
                    var importantTextTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                    importantTextTask.transform.SetParent(AmongUsClient.Instance.transform, false);
                    if (!GameOptionsManager.Instance.currentNormalGameOptions.GhostsDoTasks)
                    {
                        for (var i = 0; i < target.myTasks.Count; i++)
                        {
                            var playerTask = target.myTasks.ToArray()[i];
                            playerTask.OnRemove();
                            Object.Destroy(playerTask.gameObject);
                        }

                        target.myTasks.Clear();
                        importantTextTask.Text = DestroyableSingleton<TranslationController>.Instance.GetString(
                            StringNames.GhostIgnoreTasks,
                            new Il2CppReferenceArray<Il2CppSystem.Object>(0));
                    }
                    else
                    {
                        importantTextTask.Text = DestroyableSingleton<TranslationController>.Instance.GetString(
                            StringNames.GhostDoTasks,
                            new Il2CppReferenceArray<Il2CppSystem.Object>(0));
                    }

                    target.myTasks.Insert(0, importantTextTask);
                }

                if (!killer.Is(RoleEnum.Arsonist))
                {
                    killer.MyPhysics.StartCoroutine(killer.KillAnimations.Random().CoPerformKill(killer, target));
                }
                else
                {
                    killer.MyPhysics.StartCoroutine(killer.KillAnimations.Random().CoPerformKill(target, target));
                }
                var deadBody = new DeadPlayer
                {
                    PlayerId = target.PlayerId,
                    KillerId = killer.PlayerId,
                    KillTime = DateTime.UtcNow
                };

                Murder.KilledPlayers.Add(deadBody);

                if (MeetingHud.Instance) target.Exiled();

                if (!killer.AmOwner) return;

                if (killer.Data.IsImpostor() && GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.HideNSeek)
                {
                    killer.SetKillTimer(GameOptionsManager.Instance.currentHideNSeekGameOptions.KillCooldown);
                    return;
                }

                Murder.KilledPlayers.Add(deadBody);
                
                if (!killer.AmOwner) return;

                if (target.Is(ModifierEnum.Diseased) && killer.Is(RoleEnum.Glitch))
                {
                    var glitch = Role.GetRole<Glitch>(killer);
                    glitch.LastKill = DateTime.UtcNow.AddSeconds((CustomGameOptions.DiseasedMultiplier - 1f) * GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
                    glitch.Player.SetKillTimer(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * CustomGameOptions.DiseasedMultiplier);
                    return;
                }
                if (target.Is(ModifierEnum.Diseased) && killer.Is(RoleEnum.Werewolf))
                {
                    var werewolf = Role.GetRole<Werewolf>(killer);
                    werewolf.LastKilled = DateTime.UtcNow.AddSeconds((CustomGameOptions.DiseasedMultiplier - 1f) * CustomGameOptions.RampageKillCd);
                    werewolf.Player.SetKillTimer(CustomGameOptions.RampageKillCd * CustomGameOptions.DiseasedMultiplier);
                    return;
                }

                if (target.Is(ModifierEnum.Diseased) && killer.Is(RoleEnum.Glitch))
                {
                    var glitch = Role.GetRole<Glitch>(killer);
                    glitch.LastKill = DateTime.UtcNow.AddSeconds((CustomGameOptions.DiseasedMultiplier - 1f) * GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
                    glitch.Player.SetKillTimer(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * CustomGameOptions.DiseasedMultiplier);
                    return;
                }

                if (target.Is(ModifierEnum.Diseased) && killer.Is(RoleEnum.SerialKiller))
                {
                    var jack = Role.GetRole<SerialKiller>(killer);
                    jack.LastKill = DateTime.UtcNow.AddSeconds((CustomGameOptions.DiseasedMultiplier - 1f) * GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
                    jack.Player.SetKillTimer(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * CustomGameOptions.DiseasedMultiplier);
                    return;
                }
                if (target.Is(ModifierEnum.Diseased) && killer.Is(RoleEnum.Juggernaut))
                {
                    var juggernaut = Role.GetRole<Juggernaut>(killer);
                    juggernaut.LastKill = DateTime.UtcNow.AddSeconds((CustomGameOptions.DiseasedMultiplier - 1f) * (CustomGameOptions.JuggKCd - CustomGameOptions.ReducedKCdPerKill * juggernaut.JuggKills));
                    juggernaut.Player.SetKillTimer((CustomGameOptions.JuggKCd - CustomGameOptions.ReducedKCdPerKill * juggernaut.JuggKills) * CustomGameOptions.DiseasedMultiplier);
                    return;
                }

                if (target.Is(ModifierEnum.Diseased) && killer.Is(ModifierEnum.Underdog))
                {
                    var lowerKC = (GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown - CustomGameOptions.UnderdogKillBonus) * CustomGameOptions.DiseasedMultiplier;
                    var normalKC = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * CustomGameOptions.DiseasedMultiplier;
                    var upperKC = (GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown + CustomGameOptions.UnderdogKillBonus) * CustomGameOptions.DiseasedMultiplier;
                    killer.SetKillTimer(PerformKill.LastImp() ? lowerKC : (PerformKill.IncreasedKC() ? normalKC : upperKC));
                    return;
                }

                if (target.Is(ModifierEnum.Diseased) && killer.Data.IsImpostor())
                {
                    killer.SetKillTimer(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * CustomGameOptions.DiseasedMultiplier);
                    return;
                }

                if (target.Is(ModifierEnum.Bait))
                {
                    BaitReport(killer, target);
                }

                if (killer.Is(ModifierEnum.Underdog))
                {
                    var lowerKC = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown - CustomGameOptions.UnderdogKillBonus;
                    var normalKC = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown;
                    var upperKC = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown + CustomGameOptions.UnderdogKillBonus;
                    killer.SetKillTimer(PerformKill.LastImp() ? lowerKC : (PerformKill.IncreasedKC() ? normalKC : upperKC));
                    return;
                }

                if (killer.Data.IsImpostor())
                {
                    killer.SetKillTimer(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
                    return;
                }
            }
        }

        public static void BaitReport(PlayerControl killer, PlayerControl target)
        {
            Coroutines.Start(BaitReportDelay(killer, target));
        }
    public static bool CanVent(PlayerControl player, GameData.PlayerInfo playerInfo)
        {              
            if (GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.HideNSeek)
                return false;

            if (player.inVent)
                return true;

            if (playerInfo.IsDead)
                return false;

            if (CustomGameOptions.GameMode == GameMode.Cultist && !player.Is(RoleEnum.Engineer)) return false;
            else if (CustomGameOptions.GameMode == GameMode.Cultist && player.Is(RoleEnum.Engineer)) return true;

            if (player.Is(RoleEnum.Morphling) && !CustomGameOptions.MorphlingVent
                || player.Is(RoleEnum.Swooper) && GameOptionsManager.Instance.currentNormalGameOptions.MapId == 2 && !CustomGameOptions.SwooperPolusVent
                || player.Is(RoleEnum.Grenadier) && !CustomGameOptions.GrenadierVent
                || player.Is(RoleEnum.Escapist) && !CustomGameOptions.EscapistVent
                || player.Is(RoleEnum.Bomber) && !CustomGameOptions.BomberVent)
                return false;
            if (player.Is(RoleEnum.Undertaker))
                return true;

            if (player.Is(RoleEnum.Engineer) ||
                (player.Is(RoleEnum.Glitch) && CustomGameOptions.GlitchVent) || (player.Is(RoleEnum.Plaguebearer) && CustomGameOptions.PlaguebearerVent) ||  (player.Is(RoleEnum.Arsonist) && CustomGameOptions.ArsoVent)||(player.Is(RoleEnum.Juggernaut) && CustomGameOptions.JuggVent) ||(player.Is(RoleEnum.Werewolf) && CustomGameOptions.WerewolfVent)||
                 CustomGameOptions.EveryoneVent||(player.Is(RoleEnum.SerialKiller) && CustomGameOptions.SerialKillerVent)  ||
                                 (player.Is(RoleEnum.Pestilence) && CustomGameOptions.PestVent) || (player.Is(RoleEnum.Jester) && CustomGameOptions.JesterVent))
                return true;
            return false;
        }
        public static IEnumerator BaitReportDelay(PlayerControl killer, PlayerControl target)
        {
            var extraDelay = Random.RandomRangeInt(0, (int) (100 * (CustomGameOptions.BaitMaxDelay - CustomGameOptions.BaitMinDelay) + 1));
            if (CustomGameOptions.BaitMaxDelay <= CustomGameOptions.BaitMinDelay)
                yield return new WaitForSeconds(CustomGameOptions.BaitMaxDelay + 0.01f);
            else
                yield return new WaitForSeconds(CustomGameOptions.BaitMinDelay + 0.01f + extraDelay/100f);
            var bodies = Object.FindObjectsOfType<DeadBody>();
            if (AmongUsClient.Instance.AmHost)
            {
                foreach (var body in bodies)
                {
                    try
                    {
                        if (body.ParentId == target.PlayerId) { killer.ReportDeadBody(target.Data); break; }
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                foreach (var body in bodies)
                {
                    try
                    {
                        if (body.ParentId == target.PlayerId)
                        {
                            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                                (byte)CustomRPC.BaitReport, SendOption.Reliable, -1);
                            writer.Write(killer.PlayerId);
                            writer.Write(target.PlayerId);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
    public static void Convert2(PlayerControl player)
        {
            if (PlayerControl.LocalPlayer == player) Coroutines.Start(Utils.FlashCoroutine(Color.red, 3f));
            if (PlayerControl.LocalPlayer != player && PlayerControl.LocalPlayer.Is(RoleEnum.Mystic)
                && !PlayerControl.LocalPlayer.Data.IsDead) Coroutines.Start(Utils.FlashCoroutine(Color.red, 3f));

            if (PlayerControl.LocalPlayer.Is(RoleEnum.Transporter) && PlayerControl.LocalPlayer == player)
            {
                var transporterRole = Role.GetRole<Transporter>(PlayerControl.LocalPlayer);
                Object.Destroy(transporterRole.UsesText);
                if (transporterRole.TransportList != null)
                {
                    transporterRole.TransportList.Toggle();
                    transporterRole.TransportList.SetVisible(false);
                    transporterRole.TransportList = null;
                    transporterRole.PressedButton = false;
                    transporterRole.TransportPlayer1 = null;
                }
            }

            if (player.Is(RoleEnum.Camouflager))
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var Follower = new Follower(player);
                Follower.RegenTask();
            } 

            if (player.Is(RoleEnum.Engineer))
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var Follower = new Follower(player);
                Follower.RegenTask();     
            var engirole = Role.GetRole<Engineer>(PlayerControl.LocalPlayer);
            UnityEngine.Object.Destroy(engirole.UsesText);                  
            }

            if (player.Is(RoleEnum.Veteran))
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var Follower = new Follower(player);
                Follower.RegenTask();
            var vetrole = Role.GetRole<Veteran>(PlayerControl.LocalPlayer);
            UnityEngine.Object.Destroy(vetrole.UsesText);                      
            }            

            if (player.Is(RoleEnum.Tracker))
            {
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var Follower = new Follower(player);
                Follower.RegenTask();
            var vetrole = Role.GetRole<Tracker>(PlayerControl.LocalPlayer);
            UnityEngine.Object.Destroy(vetrole.UsesText);                   
            }
            }            

            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var Follower = new Follower(player);
                Follower.RegenTask();
            } 

            if (player.Is(RoleEnum.Swapper))
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var Follower = new Follower(player);
                Follower.RegenTask();
            } 

            if (player.Is(RoleEnum.Transporter))
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var Follower = new Follower(player);
                Follower.RegenTask();
                var tprole = Role.GetRole<Transporter>(PlayerControl.LocalPlayer);
            UnityEngine.Object.Destroy(tprole.UsesText);                      
            }
            
            if (player.Is(RoleEnum.Imitator))
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var Follower = new Follower(player);
                Follower.RegenTask();
            } 

            if (player.Is(RoleEnum.Crewmate))
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var Follower = new Follower(player);
                Follower.RegenTask();
            } 
            if (player.Is(RoleEnum.Altruist))
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var Follower = new Follower(player);
                Follower.RegenTask();
            }   
                     

            player.Data.Role.TeamType = RoleTeamTypes.Impostor;
            RoleManager.Instance.SetRole(player, RoleTypes.Impostor);
            player.SetKillTimer(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);

            foreach (var player2 in PlayerControl.AllPlayerControls)
            {
                if (player2.Data.IsImpostor() && PlayerControl.LocalPlayer.Data.IsImpostor())
                {
                    player2.nameText().color = Patches.Colors.Impostor;
                }
            }
        }
    public static string credentialsText;        
    public static string ColorString(Color32 color, string str) => $"<color=#{color.r:x2}{color.g:x2}{color.b:x2}{color.a:x2}>{str}</color>";        
        public static void Convert(PlayerControl player)
        {
            if (PlayerControl.LocalPlayer == player) Coroutines.Start(FlashCoroutine(Patches.Colors.Impostor));
            if (PlayerControl.LocalPlayer != player && PlayerControl.LocalPlayer.Is(RoleEnum.CultistMystic)
                && !PlayerControl.LocalPlayer.Data.IsDead) Coroutines.Start(FlashCoroutine(Patches.Colors.Impostor));

            if (PlayerControl.LocalPlayer.Is(RoleEnum.Transporter) && PlayerControl.LocalPlayer == player)
            {
                var transporterRole = Role.GetRole<Transporter>(PlayerControl.LocalPlayer);
                Object.Destroy(transporterRole.UsesText);
                if (transporterRole.TransportList != null)
                {
                    transporterRole.TransportList.Toggle();
                    transporterRole.TransportList.SetVisible(false);
                    transporterRole.TransportList = null;
                    transporterRole.PressedButton = false;
                    transporterRole.TransportPlayer1 = null;
                }
            }

            if (player.Is(RoleEnum.Chameleon))
            {
                var chameleonRole = Role.GetRole<Chameleon>(player);
                if (chameleonRole.IsSwooped) chameleonRole.UnSwoop();
                Role.RoleDictionary.Remove(player.PlayerId);
                var Swooper = new Swooper(player);
                Swooper.LastSwooped = DateTime.UtcNow;
                Swooper.RegenTask();
            }

            if (player.Is(RoleEnum.Engineer))
            {
                var engineer = Role.GetRole<Engineer>(player);
                engineer.Name = "Demolitionist";
                engineer.Color = Patches.Colors.Engineer;
                engineer.Faction = Faction.Impostors;
                engineer.RegenTask();
            }


            if (player.Is(RoleEnum.CultistMystic))
            {
                var mystic = Role.GetRole<CultistMystic>(player);
                mystic.Name = "Clairvoyant";
                mystic.Color = Patches.Colors.Mystic;
                mystic.Faction = Faction.Impostors;
                mystic.RegenTask();
            }


            if (player.Is(RoleEnum.Transporter))
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                var escapist = new Escapist(player);
                escapist.LastEscape = DateTime.UtcNow;
                escapist.RegenTask();
            }

            if (player.Is(RoleEnum.Crewmate))
            {
                Role.RoleDictionary.Remove(player.PlayerId);
                new Impostor(player);
            }

            player.Data.Role.TeamType = RoleTeamTypes.Impostor;
            RoleManager.Instance.SetRole(player, RoleTypes.Impostor);
            player.SetKillTimer(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);

            foreach (var player2 in PlayerControl.AllPlayerControls)
            {
                if (player2.Data.IsImpostor() && PlayerControl.LocalPlayer.Data.IsImpostor())
                {
                    player2.nameText().color = Patches.Colors.Impostor;
                }
            }
        }

        public static IEnumerator FlashCoroutine(Color color, float waitfor = 1f, float alpha = 0.3f)
        {
            color.a = alpha;
            if (HudManager.InstanceExists && HudManager.Instance.FullScreen)
            {
                var fullscreen = DestroyableSingleton<HudManager>.Instance.FullScreen;
                fullscreen.enabled = true;
                fullscreen.gameObject.active = true;
                fullscreen.color = color;
            }

            yield return new WaitForSeconds(waitfor);

            if (HudManager.InstanceExists && HudManager.Instance.FullScreen)
            {
                var fullscreen = DestroyableSingleton<HudManager>.Instance.FullScreen;
                if (fullscreen.color.Equals(color))
                {
                    fullscreen.color = new Color(1f, 0f, 0f, 0.37254903f);
                    fullscreen.enabled = false;
                }
            }
        }

        public static IEnumerable<(T1, T2)> Zip<T1, T2>(List<T1> first, List<T2> second)
        {
            return first.Zip(second, (x, y) => (x, y));
        }

        public static void DestroyAll(this IEnumerable<Component> listie)
        {
            foreach (var item in listie)
            {
                if (item == null) continue;
                Object.Destroy(item);
                if (item.gameObject == null) return;
                Object.Destroy(item.gameObject);
            }
        }
        public static PlayerControl PlayerByVoteArea(PlayerVoteArea state) => PlayerById(state.TargetPlayerId);        
public static bool IsImpostor(this PlayerVoteArea playerinfo) => PlayerByVoteArea(playerinfo).Data?.Role?.TeamType == RoleTeamTypes.Impostor;        

        public static void EndGame(GameOverReason reason = GameOverReason.ImpostorByVote, bool showAds = false)
        {
            GameManager.Instance.RpcEndGame(reason, showAds);
        }

        [HarmonyPatch(typeof(MedScanMinigame), nameof(MedScanMinigame.FixedUpdate))]
        class MedScanMinigameFixedUpdatePatch
        {
            static void Prefix(MedScanMinigame __instance)
            {
                if (CustomGameOptions.ParallelMedScans)
                {
                    //Allows multiple medbay scans at once
                    __instance.medscan.CurrentUser = PlayerControl.LocalPlayer.PlayerId;
                    __instance.medscan.UsersList.Clear();
                }
            }
        }
      
        [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.StartMeeting))]
        class StartMeetingPatch {
            public static void Prefix(PlayerControl __instance, [HarmonyArgument(0)]GameData.PlayerInfo meetingTarget) {
                voteTarget = meetingTarget;
            }
        }

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Update))]
        class MeetingHudUpdatePatch {
            static void Postfix(MeetingHud __instance) {
                // Deactivate skip Button if skipping on emergency meetings is disabled 
                if ((voteTarget == null && CustomGameOptions.SkipButtonDisable == DisableSkipButtonMeetings.Emergency) || (CustomGameOptions.SkipButtonDisable == DisableSkipButtonMeetings.Always)) {
                    __instance.SkipVoteButton.gameObject.SetActive(false);
                }
            }
        }

        //Submerged utils
        public static object TryCast(this Il2CppObjectBase self, Type type)
        {
            return AccessTools.Method(self.GetType(), nameof(Il2CppObjectBase.TryCast)).MakeGenericMethod(type).Invoke(self, Array.Empty<object>());
        }
        public static IList createList(Type myType)
        {
            Type genericListType = typeof(List<>).MakeGenericType(myType);
            return (IList)Activator.CreateInstance(genericListType);
        }

        public static void ResetCustomTimers()
        {
            #region CrewmateRoles
            foreach (Medium role in Role.GetRoles(RoleEnum.Medium))
            {
                role.LastMediated = DateTime.UtcNow;
            }
            foreach (Snitch role in Role.GetRoles(RoleEnum.Snitch))
            {
                role.LastInvestigated = DateTime.UtcNow;
            }
            foreach (CultistSnitch role in Role.GetRoles(RoleEnum.CultistSnitch))
            {
                role.LastInvestigated = DateTime.UtcNow;
            }
            foreach (Sheriff role in Role.GetRoles(RoleEnum.Sheriff))
            {
                role.LastKilled = DateTime.UtcNow;
            }       
            foreach (Tracker role in Role.GetRoles(RoleEnum.Tracker))
            {
                role.LastTracked = DateTime.UtcNow;
            }
            foreach (Transporter role in Role.GetRoles(RoleEnum.Transporter))
            {
                role.LastTransported = DateTime.UtcNow;
            }
            foreach (Veteran role in Role.GetRoles(RoleEnum.Veteran))
            {
                role.LastAlerted = DateTime.UtcNow;
            }
            foreach (Trapper role in Role.GetRoles(RoleEnum.Trapper))
            {
                role.LastTrapped = DateTime.UtcNow;
            }
            foreach (Mystic role in Role.GetRoles(RoleEnum.Mystic))
            {
                role.LastExamined = DateTime.UtcNow;
            }
            foreach (Chameleon role in Role.GetRoles(RoleEnum.Chameleon))
            {
                role.LastSwooped = DateTime.UtcNow;
            }
            foreach (Camouflager role in Role.GetRoles(RoleEnum.Camouflager))
            {
                role.LastSwooped = DateTime.UtcNow;
            }            
            #endregion
            #region NeutralRoles
            foreach (Guardian role in Role.GetRoles(RoleEnum.Guardian))
            {
                role.LastProtected = DateTime.UtcNow;
            }
            foreach (Arsonist role in Role.GetRoles(RoleEnum.Arsonist))
            {
                role.LastDoused = DateTime.UtcNow;
            }
            foreach (Glitch role in Role.GetRoles(RoleEnum.Glitch))
            {
                role.LastHack = DateTime.UtcNow;
                role.LastKill = DateTime.UtcNow;
                role.LastMimic = DateTime.UtcNow;
            }
            foreach (Juggernaut role in Role.GetRoles(RoleEnum.Juggernaut))
            {
                role.LastKill = DateTime.UtcNow;
            }
            foreach (Werewolf role in Role.GetRoles(RoleEnum.Werewolf))
            {
                role.LastRampaged = DateTime.UtcNow;
                role.LastKilled = DateTime.UtcNow;
            }
            foreach (SerialKiller role in Role.GetRoles(RoleEnum.SerialKiller))
            {
                role.LastKill = DateTime.UtcNow;               
            }                        
            foreach (Plaguebearer role in Role.GetRoles(RoleEnum.Plaguebearer))
            {
                role.LastInfected = DateTime.UtcNow;
            }
            foreach (Pestilence role in Role.GetRoles(RoleEnum.Pestilence))
            {
                role.LastKill = DateTime.UtcNow;
            }       
            foreach (Follower role in Role.GetRoles(RoleEnum.Follower))
            {
                role.LastKill = DateTime.UtcNow;
            }            
            #endregion
            #region ImposterRoles
            foreach (Escapist role in Role.GetRoles(RoleEnum.Escapist))
            {
                role.LastEscape = DateTime.UtcNow;
            }
            foreach (Silencer role in Role.GetRoles(RoleEnum.Silencer))
            {
                role.LastSilenced = DateTime.UtcNow;
            }
            foreach (Grenadier role in Role.GetRoles(RoleEnum.Grenadier))
            {
                role.LastFlashed = DateTime.UtcNow;
            }
            foreach (Miner role in Role.GetRoles(RoleEnum.Miner))
            {
                role.LastMined = DateTime.UtcNow;
            }
            foreach (Morphling role in Role.GetRoles(RoleEnum.Morphling))
            {
                role.LastMorphed = DateTime.UtcNow;
            }
            foreach (Swooper role in Role.GetRoles(RoleEnum.Swooper))
            {
                role.LastSwooped = DateTime.UtcNow;
            }                   
            foreach (Undertaker role in Role.GetRoles(RoleEnum.Undertaker))
            {
                role.LastDragged = DateTime.UtcNow;
            }
            foreach (Cultist role in Role.GetRoles(RoleEnum.Cultist))
            {
                role.LastRevived = DateTime.UtcNow;
            }            
            foreach (Necromancer role in Role.GetRoles(RoleEnum.Necromancer))
            {
                role.LastRevived = DateTime.UtcNow;
            }
            foreach (Whisperer role in Role.GetRoles(RoleEnum.Whisperer))
            {
                role.LastWhispered = DateTime.UtcNow;
            }
            #endregion
        }
    }
}
