using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.NeutralRoles.GuardianMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    [HarmonyPriority(Priority.Last)]
    public class ProtectUnportect
    {
        [HarmonyPriority(Priority.Last)]
        public static void Postfix(HudManager __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Guardian))
            {
                var ga = (Guardian) role;
                if (ga.Protecting)
                    ga.Protect();
                else if (ga.Enabled) ga.UnProtect();
            }
        }
    }
}