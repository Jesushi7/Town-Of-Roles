using HarmonyLib;
using TownOfRoles.Extensions;
using TownOfRoles.Roles;
using UnityEngine;

namespace TownOfRoles.CrewmateRoles.SnitchRole
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class Update
    {
        private static void UpdateMeeting(MeetingHud __instance, Snitch Snitch)
        {
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (!Snitch.Investigated.Contains(player.PlayerId)) continue;
                foreach (var state in __instance.playerStates)
                {
                    if (player.PlayerId != state.TargetPlayerId) continue;
                    var roleType = Utils.GetRole(player);
                    switch (roleType)
                    {
                        default:
                            if ((player.Is(Faction.Crewmates) && !(player.Is(RoleEnum.Sheriff) || player.Is(RoleEnum.Veteran))) ||
                            ((player.Is(RoleEnum.Sheriff) || player.Is(RoleEnum.Veteran)) && !CustomGameOptions.CrewKillingRed) ||
                            ((player.Is(RoleEnum.Amnesiac) || player.Is(RoleEnum.GuardianAngel)) && !CustomGameOptions.NeutralNNK) ||
                            ((player.Is(RoleEnum.Executioner) || player.Is(RoleEnum.Jester) || player.Is(RoleEnum.Phantom)) && !CustomGameOptions.NeutralNNK) ||
                            ((player.Is(RoleEnum.Arsonist) || player.Is(RoleEnum.Glitch) || player.Is(RoleEnum.Juggernaut) ||
                            player.Is(RoleEnum.Plaguebearer) || player.Is(RoleEnum.Pestilence) || player.Is(RoleEnum.Werewolf)) && !CustomGameOptions.NeutKillingRed))
                            {
                                state.NameText.color = Color.green;
                            }
                            else if (player.Is(RoleEnum.Traitor) && CustomGameOptions.TraitorColourSwap)
                            {
                                foreach (var role in Role.GetRoles(RoleEnum.Traitor))
                                {
                                    var traitor = (Traitor)role;
                                    if (traitor.formerRole == RoleEnum.Sheriff ||
                                        traitor.formerRole == RoleEnum.Veteran) state.NameText.color = Color.red;
                                    else state.NameText.color = Color.green;
                                }
                            }
                            else
                            {
                                state.NameText.color = Color.red;
                            }
                            break;
                    }
                }
            }
        }

        [HarmonyPriority(Priority.Last)]
        private static void Postfix(HudManager __instance)

        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (PlayerControl.LocalPlayer.Data.IsDead) return;

            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Snitch)) return;
            var Snitch = Role.GetRole<Snitch>(PlayerControl.LocalPlayer);
            if (MeetingHud.Instance != null) UpdateMeeting(MeetingHud.Instance, Snitch);

            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (!Snitch.Investigated.Contains(player.PlayerId)) continue;
                var roleType = Utils.GetRole(player);
                switch (roleType)
                {
                    default:
                        if ((player.Is(Faction.Crewmates) && !(player.Is(RoleEnum.Sheriff) || player.Is(RoleEnum.Veteran))) ||
                            ((player.Is(RoleEnum.Sheriff) || player.Is(RoleEnum.Veteran)) && !CustomGameOptions.CrewKillingRed) ||
                            ((player.Is(RoleEnum.Amnesiac) || player.Is(RoleEnum.GuardianAngel)) && !CustomGameOptions.NeutralNNK) ||
                            ((player.Is(RoleEnum.Executioner) || player.Is(RoleEnum.Jester) || player.Is(RoleEnum.Phantom)) && !CustomGameOptions.NeutralNNK) ||
                            ((player.Is(RoleEnum.Arsonist) || player.Is(RoleEnum.Glitch) || player.Is(RoleEnum.Juggernaut) ||
                            player.Is(RoleEnum.Plaguebearer) || player.Is(RoleEnum.Pestilence) || player.Is(RoleEnum.Werewolf)) && !CustomGameOptions.NeutKillingRed))
                        {
                            player.nameText().color = Color.green;
                        }
                        else if (player.Is(RoleEnum.Traitor) && CustomGameOptions.TraitorColourSwap)
                        {
                            foreach (var role in Role.GetRoles(RoleEnum.Traitor))
                            {
                                var traitor = (Traitor)role;
                                if (traitor.formerRole == RoleEnum.Sheriff||
                                    traitor.formerRole == RoleEnum.Veteran) player.nameText().color = Color.red;
                                else player.nameText().color = Color.green;
                            }
                        }
                        else
                        {
                            player.nameText().color = Color.red;
                        }
                        break;
                }
            }
        }
    }
}