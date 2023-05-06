using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.CamouflagerMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    [HarmonyPriority(Priority.Last)]
    public class SwoopUnSwoop2
    {
        [HarmonyPriority(Priority.Last)]
        public static void Postfix(HudManager __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Camouflager))
            {
                var chameleon = (Camouflager) role;
                if (chameleon.IsSwooped)
                    chameleon.Swoop();
                else if (chameleon.Enabled) chameleon.UnSwoop();
            }
        }
    }
}