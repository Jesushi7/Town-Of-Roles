using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.AvengerMod
{
    [HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.HandleAnimation))]
    public class HandleAnimation
    {
        public static void Prefix(PlayerPhysics __instance, [HarmonyArgument(0)] ref bool amDead)
        {
            if (__instance.myPlayer.Is(RoleEnum.Avenger)) amDead = Role.GetRole<Avenger>(__instance.myPlayer).Caught;
        }
    }
}