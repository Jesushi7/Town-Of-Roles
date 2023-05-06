using System;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.ImpostorRoles.SwooperMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Swooper))
            {
                var Swooper = (Swooper) role;
                Swooper.LastSwooped = DateTime.UtcNow;
                Swooper.LastSwooped = Swooper.LastSwooped.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.SwoopCd);
            }
        }
    }
}