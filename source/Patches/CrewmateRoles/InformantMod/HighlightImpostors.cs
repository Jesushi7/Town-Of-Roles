using HarmonyLib;
using TownOfRoles.Extensions;
using TownOfRoles.Roles;
using UnityEngine;

namespace TownOfRoles.CrewmateRoles.InformantMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HighlightImpostors
    {
        private static void UpdateMeeting(MeetingHud __instance)
        {
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                foreach (var state in __instance.playerStates)
                {
                    if (player.PlayerId != state.TargetPlayerId) continue;
                    var role = Role.GetRole(player);
                    if (player.Is(Faction.Impostors))
                        state.NameText.color = Palette.ImpostorRed;
                    if (player.Is(RoleEnum.Glitch) || player.Is(RoleEnum.Werewolf) 
                || player.Is(RoleEnum.Juggernaut)|| player.Is(RoleEnum.SerialKiller)||player.Is(RoleEnum.Plaguebearer) || player.Is(RoleEnum.Pestilence)
                || player.Is(RoleEnum.Arsonist) && CustomGameOptions.InformantSeesNeutrals)
                        state.NameText.color = role.Color;
                }
            }
        }

        public static void Postfix(HudManager __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Informant)) return;
            var role = Role.GetRole<Informant>(PlayerControl.LocalPlayer);
            if (!role.TasksDone) return;
            if (MeetingHud.Instance && CustomGameOptions.InformantSeesImpInMeeting) UpdateMeeting(MeetingHud.Instance);

            foreach (var player in PlayerControl.AllPlayerControls)
            {
                var playerRole = Role.GetRole(player);
                if (playerRole.Faction == Faction.Neutral && CustomGameOptions.InformantSeesNeutrals)
                    player.nameText().color = playerRole.Color;
            }
        }
    }
}