using System;
using HarmonyLib;
using Reactor.Utilities;
using TownOfSushi.Roles;
using TownOfSushi.Roles.Cultist;
using UnityEngine;
using AmongUs.GameOptions;

namespace TownOfSushi.CultistRoles.SnitchMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static bool Prefix(KillButton __instance)
        {
            if (__instance != DestroyableSingleton<HudManager>.Instance.KillButton) return true;
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.CultistSnitch);
            if (!flag) return true;
            var role = Role.GetRole<CultistSnitch>(PlayerControl.LocalPlayer);
            if (!PlayerControl.LocalPlayer.CanMove || role.ClosestPlayer == null) return false;
            var flag2 = role.SnitchTimer() == 0f;
            if (!flag2) return false;
            if (!__instance.enabled) return false;
            var maxDistance = GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
            if (Vector2.Distance(role.ClosestPlayer.GetTruePosition(),
                PlayerControl.LocalPlayer.GetTruePosition()) > maxDistance) return false;
            if (role.ClosestPlayer == null) return false;
            if (role.ClosestPlayer.Is(Faction.Impostors) && !role.ClosestPlayer.Is(RoleEnum.Necromancer)
                && !role.ClosestPlayer.Is(RoleEnum.Whisperer)) Coroutines.Start(Utils.FlashCoroutine(Color.red));
            else Coroutines.Start(Utils.FlashCoroutine(Color.green));
            role.LastInvestigated = DateTime.UtcNow;
            role.UsesLeft--;
            return false;
        }
    }
}
