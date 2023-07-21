using HarmonyLib;
using TownOfSushi.Roles;

namespace TownOfSushi.CrewmateRoles.AvengerMod
{
    [HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.ResetMoveState))]
    public class ResetMoveState
    {
        public static void Postfix(PlayerPhysics __instance)
        {
            if (!__instance.myPlayer.Is(RoleEnum.Avenger)) return;

            var role = Role.GetRole<Avenger>(__instance.myPlayer);
            __instance.myPlayer.Collider.enabled = !role.Caught;
        }
    }
}