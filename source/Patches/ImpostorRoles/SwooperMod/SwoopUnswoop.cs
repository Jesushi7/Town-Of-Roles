using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.ImpostorRoles.SwooperMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    [HarmonyPriority(Priority.Last)]
    public class SwoopUnswoop
    {
        [HarmonyPriority(Priority.Last)]
        public static void Postfix(HudManager __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Swooper))
            {
                var Swooper = (Swooper) role;
                if (Swooper.IsSwooped)
                    Swooper.Swoop();
                else if (Swooper.Enabled) Swooper.UnSwoop();
            }
        }
    }
}