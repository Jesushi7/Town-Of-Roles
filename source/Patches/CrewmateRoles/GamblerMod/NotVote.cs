using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.GamblerMod
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.VotingComplete))] // BBFDNCCEJHI
    public static class VotingComplete
    {
        public static void Postfix(MeetingHud __instance)
        {
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Gambler))
            {
                var retributionist = Role.GetRole<Gambler>(PlayerControl.LocalPlayer);
                ShowHideButtonsGambler.HideButtonsGambler(retributionist);
            }
        }
    }
}