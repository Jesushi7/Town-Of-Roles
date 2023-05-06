using System.Linq;
using Hazel;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Modifiers;
using UnityEngine;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using TownOfRoles.CrewmateRoles.MedicMod;
using TownOfRoles.Modifiers.AssassinMod;
using TownOfRoles.ImpostorRoles.SilencerMod;
using TownOfRoles.Extensions;

namespace TownOfRoles.CrewmateRoles.GamblerMod
{
    public class GamblerKill
    {
        public static void RpcMurderPlayer(PlayerControl player, PlayerControl Gambler)

        {
            PlayerVoteArea voteArea = MeetingHud.Instance.playerStates.First(
                x => x.TargetPlayerId == player.PlayerId
            );
            RpcMurderPlayer(voteArea, player, Gambler);
        }
        public static void RpcMurderPlayer(PlayerVoteArea voteArea, PlayerControl player, PlayerControl Gambler)
        {
            MurderPlayer(voteArea, player);
            VigiKillCount(player, Gambler);
            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte)CustomRPC.GamblerKill, SendOption.Reliable, -1);
            writer.Write(player.PlayerId);
            writer.Write(Gambler.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }

        public static void MurderPlayer(PlayerControl player, bool checkLover = true)
        {
            PlayerVoteArea voteArea = MeetingHud.Instance.playerStates.First(
                x => x.TargetPlayerId == player.PlayerId
            );
            MurderPlayer(voteArea, player, checkLover);
        }
        public static void VigiKillCount(PlayerControl player, PlayerControl Gambler)
        {
            var vigi = Role.GetRole<Gambler>(Gambler);
            if (player == Gambler) vigi.IncorrectAssassinKills += 1;
            else vigi.CorrectAssassinKills += 1;
        }
        public static void MurderPlayer(
            PlayerVoteArea voteArea,
            PlayerControl player,
            bool checkLover = true
        )
        {
            var hudManager = DestroyableSingleton<HudManager>.Instance;
            if (checkLover)
            {
                SoundManager.Instance.PlaySound(player.KillSfx, false, 0.8f);
                hudManager.KillOverlay.ShowKillAnimation(player.Data, player.Data);
            }
            var amOwner = player.AmOwner;
            if (amOwner)
            {
                Utils.ShowDeadBodies = true;
                hudManager.ShadowQuad.gameObject.SetActive(false);
                player.nameText().GetComponent<MeshRenderer>().material.SetInt("_Mask", 0);
                player.RpcSetScanner(false);
                ImportantTextTask importantTextTask = new GameObject("_Player").AddComponent<ImportantTextTask>();
                importantTextTask.transform.SetParent(AmongUsClient.Instance.transform, false);
                if (!GameOptionsManager.Instance.currentNormalGameOptions.GhostsDoTasks)
                {
                    for (int i = 0;i < player.myTasks.Count;i++)
                    {
                        PlayerTask playerTask = player.myTasks.ToArray()[i];
                        playerTask.OnRemove();
                        Object.Destroy(playerTask.gameObject);
                    }

                    player.myTasks.Clear();
                    importantTextTask.Text = DestroyableSingleton<TranslationController>.Instance.GetString(
                        StringNames.GhostIgnoreTasks,
                        new Il2CppReferenceArray<Il2CppSystem.Object>(0)
                    );
                }
                else
                {
                    importantTextTask.Text = DestroyableSingleton<TranslationController>.Instance.GetString(
                        StringNames.GhostDoTasks,
                        new Il2CppReferenceArray<Il2CppSystem.Object>(0));
                }

                player.myTasks.Insert(0, importantTextTask);

                if (player.Is(AbilityEnum.Assassin))
                {
                    var assassin = Ability.GetAbility<Assassin>(PlayerControl.LocalPlayer);
                    ShowHideButtons.HideButtons(assassin);
                }
            }
            player.Die(DeathReason.Kill, false);
            if (checkLover && player.IsLover() && CustomGameOptions.BothLoversDie)
            {
                var otherLover = Modifier.GetModifier<Lover>(player).OtherLover.Player;
                if (!otherLover.Is(RoleEnum.Pestilence)) MurderPlayer(otherLover, false);
            }

            var meetingHud = MeetingHud.Instance;
            if (amOwner)
            {
                meetingHud.SetForegroundForDead();
            }
            var deadPlayer = new DeadPlayer
            {
                PlayerId = player.PlayerId,
                KillerId = player.PlayerId,
                KillTime = System.DateTime.UtcNow,
            };

            Murder.KilledPlayers.Add(deadPlayer);
            if (voteArea == null) return;
            if (voteArea.DidVote) voteArea.UnsetVote();
            voteArea.AmDead = true;
            voteArea.Overlay.gameObject.SetActive(true);
            voteArea.Overlay.color = Color.white;
            voteArea.XMark.gameObject.SetActive(true);
            voteArea.XMark.transform.localScale = Vector3.one;

            var Silencers = Role.AllRoles.Where(x => x.RoleType == RoleEnum.Silencer && x.Player != null).Cast<Silencer>();
            foreach (var role in Silencers)
            {
                if (role.Silenced != null && voteArea.TargetPlayerId == role.Silenced.PlayerId)
                {
                    if (SilenceMeetingUpdate.PrevXMark != null && SilenceMeetingUpdate.PrevOverlay != null)
                    {
                        voteArea.XMark.sprite = SilenceMeetingUpdate.PrevXMark;
                        voteArea.Overlay.sprite = SilenceMeetingUpdate.PrevOverlay;
                        voteArea.XMark.transform.localPosition = new Vector3(
                            voteArea.XMark.transform.localPosition.x - SilenceMeetingUpdate.LetterXOffset,
                            voteArea.XMark.transform.localPosition.y - SilenceMeetingUpdate.LetterYOffset,
                            voteArea.XMark.transform.localPosition.z);
                    }
                }
            }

            foreach (var playerVoteArea in meetingHud.playerStates)
            {
                if (playerVoteArea.VotedFor != player.PlayerId) continue;
                playerVoteArea.UnsetVote();
                var voteAreaPlayer = Utils.PlayerById(playerVoteArea.TargetPlayerId);
                if (!voteAreaPlayer.AmOwner) continue;
                meetingHud.ClearVote();
            }

            player.Exiled();

            if (AmongUsClient.Instance.AmHost)
            {
                foreach (var role in Role.GetRoles(RoleEnum.Mayor))
                {
                    if (role is Mayor mayor)
                    {
                        if (role.Player == player)
                        {
                            mayor.ExtraVotes.Clear();
                        }
                        else
                        {
                            var votesRegained = mayor.ExtraVotes.RemoveAll(x => x == player.PlayerId);

                            if (mayor.Player == PlayerControl.LocalPlayer)
                                mayor.VoteBank += votesRegained;

                            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                                (byte)CustomRPC.AddMayorVoteBank, SendOption.Reliable, -1);
                            writer.Write(mayor.Player.PlayerId);
                            writer.Write(votesRegained);
                            AmongUsClient.Instance.FinishRpcImmediately(writer);
                        }
                    }
                }
                meetingHud.CheckForEndVoting();
            }
        }
    }
}
