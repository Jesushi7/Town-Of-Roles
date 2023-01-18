/*using System;
using HarmonyLib;
using Hazel;
using Reactor.Utilities;
using TownOfUs.Extensions;
using TownOfUs.Patches;
using UnityEngine;
using TownOfUs.CustomOption;
using TownOfUs.Roles;

namespace TownOfUs.NeutralRoles.VultureMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKillButton
    {
        public static bool Prefix(KillButton __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Vulture))
                return true;

            if (!PlayerControl.LocalPlayer.CanMove)
                return false;

            if (PlayerControl.LocalPlayer.Data.IsDead)
                return false;

            if (!__instance.isActiveAndEnabled)
                return false;

            if (__instance.isCoolingDown)
                return false;

            var role = Role.GetRole<Vulture>(PlayerControl.LocalPlayer);

            if (role.EatTimer() != 0)
                return false;

            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte) CustomRPC.VultureEat,
                    SendOption.Reliable, -1);
                writer.Write(PlayerControl.LocalPlayer.PlayerId);
                writer.Write(role.CurrentTarget.ParentId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
            }
            
            return false;
        }
        public static void SetTarget(KillButton __instance, DeadBody target, Vulture role)
        {
            if (role.CurrentTarget && role.CurrentTarget != target)
                role.CurrentTarget.bodyRenderer.material.SetFloat("_Outline", 0f);

            role.CurrentTarget = target;
            
            if (role.CurrentTarget && __instance.enabled)
            {
                var component = role.CurrentTarget.bodyRenderer;
                component.material.SetFloat("_Outline", 1f);
                component.material.SetColor("_OutlineColor", role.Color);
                __instance.graphic.color = Palette.EnabledColor;
                __instance.graphic.material.SetFloat("_Desat", 0f);
                return;
            }
    }
}
}*/