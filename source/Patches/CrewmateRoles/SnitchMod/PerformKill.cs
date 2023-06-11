using System;
using HarmonyLib;
using TownOfRoles.Roles;
using UnityEngine;
using AmongUs.GameOptions;

namespace TownOfRoles.CrewmateRoles.SnitchMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static bool Prefix(KillButton __instance)
        {
            if (__instance != DestroyableSingleton<HudManager>.Instance.KillButton) return true;
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Snitch);
            if (!flag) return true;
            var role = Role.GetRole<Snitch>(PlayerControl.LocalPlayer);
            if (!PlayerControl.LocalPlayer.CanMove || role.ClosestPlayer == null) return false;
            var flag2 = role.SnitchTimer() == 0f;
            if (!flag2) return false;
            if (!__instance.enabled) return false;
            var maxDistance = GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
            if (Vector2.Distance(role.ClosestPlayer.GetTruePosition(),
                PlayerControl.LocalPlayer.GetTruePosition()) > maxDistance) return false;
            if (role.ClosestPlayer == null) return false;

            var interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer);
            if (interact[4] == true)
            {
                role.Investigated.Add(role.ClosestPlayer.PlayerId);
            }
            if (interact[0] == true)
            {
                role.LastInvestigated = DateTime.UtcNow;
                return false;
            }
            else if (interact[1] == true)
            {
                role.LastInvestigated = DateTime.UtcNow;
                role.LastInvestigated = role.LastInvestigated.AddSeconds(CustomGameOptions.ProtectKCReset - CustomGameOptions.SnitchCd);
                return false;
            }
            else if (interact[3] == true) return false;
            return false;
        }
    }
}
