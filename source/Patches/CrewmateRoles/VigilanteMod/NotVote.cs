using HarmonyLib;
using TownOfSushi.Roles;

namespace TownOfSushi.CrewmateRoles.VigilanteMod
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.VotingComplete))] // BBFDNCCEJHI
    public static class VotingComplete
    {
        public static void Postfix(MeetingHud __instance)
        {
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Vigilante))
            {
                var retributionist = Role.GetRole<Vigilante>(PlayerControl.LocalPlayer);
                ShowHideButtonsVigi.HideButtonsVigi(retributionist);
            }
        }
    }
}