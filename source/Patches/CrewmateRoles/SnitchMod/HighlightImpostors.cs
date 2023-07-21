using HarmonyLib;
using TownOfSushi.Extensions;
using TownOfSushi.Roles;
using UnityEngine;

namespace TownOfSushi.CrewmateRoles.InformantMod
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
                    if (player.Is(Faction.Impostors) && !player.Is(RoleEnum.Traitor))
                        state.NameText.color = Palette.ImpostorRed;
                    else if (player.Is(RoleEnum.Traitor) && CustomGameOptions.InformantSeesTraitor)
                        state.NameText.color = Palette.ImpostorRed;
                    if (player.Is(Faction.NeutralKilling) && CustomGameOptions.InformantSeesNeutrals)
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
                if (player.Data.IsImpostor() && !player.Is(RoleEnum.Traitor)) player.nameText().color = Palette.ImpostorRed;
                else if (player.Is(RoleEnum.Traitor) && CustomGameOptions.InformantSeesTraitor) player.nameText().color = Palette.ImpostorRed;
                var playerRole = Role.GetRole(player);
                if (playerRole.Faction == Faction.NeutralKilling && CustomGameOptions.InformantSeesNeutrals)
                    player.nameText().color = playerRole.Color;
            }
        }
    }
}