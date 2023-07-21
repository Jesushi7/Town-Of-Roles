using HarmonyLib;
using Reactor.Utilities.Extensions;
using TownOfSushi.Roles;

namespace TownOfSushi.CrewmateRoles.MonarchMod
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.VotingComplete))] // BBFDNCCEJHI
    public static class VotingComplete
    {
        public static void Postfix(MeetingHud __instance)
        {
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Monarch))
            {
                var mayor = Role.GetRole<Monarch>(PlayerControl.LocalPlayer);
                if (!mayor.Revealed) mayor.RevealButton.Destroy();
            }
        }
    }
}