using HarmonyLib;
using TownOfRoles.Roles;
using System.Linq;

namespace TownOfRoles.ImpostorRoles.VampireMod
{

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.StartMeeting))]
    class StartMeetingPatch
    {
        public static void Prefix(PlayerControl __instance, [HarmonyArgument(0)] GameData.PlayerInfo meetingTarget)
        {
            if (__instance == null)
            {
                return;
            }
            var poisoners = PlayerControl.AllPlayerControls.ToArray().Where(x => x.Is(RoleEnum.Vampire)).ToList();
            foreach (var poisoner in poisoners)
            {
                var role = Role.GetRole<Vampire>(poisoner);
                if (poisoner != role.BittenPlayer && role.BittenPlayer != null)
                {
                    if (!role.BittenPlayer.Data.IsDead && !role.BittenPlayer.Is(RoleEnum.Pestilence))
                        Utils.MurderPlayer(poisoner, role.BittenPlayer);
                }
                return;
            }
        }
    }
}
