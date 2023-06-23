using HarmonyLib;
using UnityEngine;
using TownOfRoles.Roles;

namespace TownOfRoles
{
    [HarmonyPatch(typeof(Vent), nameof(Vent.SetOutline))]
    class SetVentOutlinePatch
    {
        public static void Postfix(Vent __instance, [HarmonyArgument(1)] ref bool mainTarget)
        {
            var player = PlayerControl.LocalPlayer;
            bool active = PlayerControl.LocalPlayer != null  && !MeetingHud.Instance && (player.Is(RoleEnum.Pyromaniac)|| player.Is(RoleEnum.SerialKiller) || player.Is(RoleEnum.Engineer) || player.Is(RoleEnum.Glitch) || player.Is(RoleEnum.Jester) || player.Is(RoleEnum.Juggernaut) || player.Is(RoleEnum.Pestilence) || player.Is(RoleEnum.Werewolf));
            if (!active) return;
            Color color = Role.GetRole(PlayerControl.LocalPlayer).Color;
            ((Renderer)__instance.myRend).material.SetColor("_OutlineColor", color);
            ((Renderer)__instance.myRend).material.SetColor("_AddColor", mainTarget ? color : Color.clear);
        }
    }
}