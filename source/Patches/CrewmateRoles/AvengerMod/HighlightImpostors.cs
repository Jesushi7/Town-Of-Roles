using HarmonyLib;
using TownOfRoles.Roles;
using Hazel;

namespace TownOfRoles.CrewmateRoles.AvengerMod
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
                    if (player.Is(RoleEnum.Glitch) || player.Is(RoleEnum.Werewolf) 
                || player.Is(RoleEnum.Juggernaut) ||  player.Is(RoleEnum.SerialKiller)||player.Is(RoleEnum.Plaguebearer) || player.Is(RoleEnum.Pestilence)
                || player.Is(RoleEnum.Pyromaniac) && CustomGameOptions.AvengerRevealsNeutrals)
                        state.NameText.color = role.Color;
                }
            }
        }
        public static void Postfix(HudManager __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Avenger)) return;
            var role = Role.GetRole<Avenger>(PlayerControl.LocalPlayer);
            if (!role.CompletedTasks || role.Caught) return;
            if (MeetingHud.Instance)
            {
                UpdateMeeting(MeetingHud.Instance);
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                        (byte)CustomRPC.AvengerFinished, SendOption.Reliable, -1);
                writer.Write(role.Player.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
            }
        }
    }
}