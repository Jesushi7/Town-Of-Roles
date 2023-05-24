using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.AvengerRole
{
    [HarmonyPatch(typeof(SpawnInMinigame), nameof(SpawnInMinigame.Begin))]
    public class NoSpawn
    {
        public static bool Prefix(SpawnInMinigame __instance)
        {
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Avenger))
            {
                var caught = Role.GetRole<Avenger>(PlayerControl.LocalPlayer).Caught;
                if (!caught)
                {
                    __instance.Close();
                    return false;
                }
            }

            return true;
        }
    }
}