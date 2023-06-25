using System.Linq;
using HarmonyLib;
using TownOfRoles.Roles;
using UnityEngine;
using Hazel;

namespace TownOfRoles.NeutralRoles.SerialKillerMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HudManagerUpdate
    {
        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.SerialKiller)) return;
            var role = Role.GetRole<SerialKiller>(PlayerControl.LocalPlayer);

            __instance.KillButton.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled)
                    && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead
                    && AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started);

            __instance.KillButton.SetCoolDown(role.KillTimer(), GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);

            Utils.SetTarget(ref role.ClosestPlayer, __instance.KillButton);
        }
    }
}