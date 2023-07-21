using HarmonyLib;
using TownOfSushi.Roles;
using Reactor.Utilities.Extensions;

namespace TownOfSushi.CrewmateRoles.MonarchMod
{
    public class ShowHideButtonsMonarch
    {
        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Confirm))]
        public static class Confirm
        {
            public static bool Prefix(MeetingHud __instance)
            {
                if (!PlayerControl.LocalPlayer.Is(RoleEnum.Monarch)) return true;
                var mayor = Role.GetRole<Monarch>(PlayerControl.LocalPlayer);
                if (!mayor.Revealed) mayor.RevealButton.Destroy();
                return true;
            }
        }
    }
}