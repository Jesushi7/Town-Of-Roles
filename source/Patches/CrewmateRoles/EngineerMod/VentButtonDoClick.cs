using System;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.EngineerMod
{
    [HarmonyPatch(typeof(VentButton), nameof(VentButton.DoClick))]
    public class VentButtonDoClick
    {
        public static bool Prefix(VentButton __instance)
        {
            if (!CustomGameOptions.EngiHasVentCooldown) return true;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Engineer)) return true;
            if (PlayerControl.LocalPlayer.Data.IsDead) return true;
            if (!__instance.enabled) return true;
            if (__instance.isCoolingDown && !PlayerControl.LocalPlayer.inVent) return false;
            var role = Role.GetRole<Engineer>(PlayerControl.LocalPlayer);
            role.TimeRemaining = CustomGameOptions.EngiVentDuration;
            role.LastVent = DateTime.UtcNow;
            return true;
        }
    }
}