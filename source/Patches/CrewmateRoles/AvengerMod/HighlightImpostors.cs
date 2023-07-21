using HarmonyLib;
using TownOfSushi.Roles;

namespace TownOfSushi.CrewmateRoles.AvengerMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HighlightImpostors
    {
        public static void UpdateMeeting(MeetingHud __instance)
        {
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                foreach (var state in __instance.playerStates)
                {
                    if (player.PlayerId != state.TargetPlayerId) continue;
                    var role = Role.GetRole(player);
                    if (player.Is(Faction.Impostors))
                        state.NameText.color = Palette.ImpostorRed;
                    if (player.Is(Faction.NeutralKilling) && CustomGameOptions.AvengerRevealsNeutrals)
                        state.NameText.color = role.Color;
                }
            }
        }
        public static void Postfix(HudManager __instance)
        {
            foreach (var haunter in Role.GetRoles(RoleEnum.Avenger))
            {
                var role = (Avenger)haunter;
                if (!role.CompletedTasks || role.Caught) return;
                if (MeetingHud.Instance) UpdateMeeting(MeetingHud.Instance);
            }
        }
    }
}