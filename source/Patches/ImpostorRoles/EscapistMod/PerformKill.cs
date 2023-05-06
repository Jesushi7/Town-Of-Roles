using System;
using HarmonyLib;
using Hazel;
using TownOfRoles.Roles;
using UnityEngine;
using Reactor.Networking.Extensions;

namespace TownOfRoles.ImpostorRoles.EscapistMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static Sprite MarkSprite => TownOfRoles.MarkSprite;
        public static Sprite EscapeSprite => TownOfRoles.EscapeSprite;

        public static bool Prefix(KillButton __instance)
        {
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Escapist);
            if (!flag) return true;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            var role = Role.GetRole<Escapist>(PlayerControl.LocalPlayer);
            if (__instance == role.EscapeButton)
            {
                if (role.Player.inVent) return false;
                if (!__instance.isActiveAndEnabled) return false;
                if (role.EscapeButton.graphic.sprite == MarkSprite)
                {
                    role.EscapePoint = PlayerControl.LocalPlayer.transform.position;
                    role.EscapeButton.graphic.sprite = EscapeSprite;
                    DestroyableSingleton<HudManager>.Instance.KillButton.SetTarget(null);
                    if (role.EscapeTimer() < 5f)
                        role.LastEscape = DateTime.UtcNow.AddSeconds(5 - CustomGameOptions.EscapeCd);
                }
                else
                {
                    if (__instance.isCoolingDown) return false;
                    if (role.EscapeTimer() != 0) return false;
                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                    (byte)CustomRPC.Escape, SendOption.Reliable, -1);
                    writer.Write(PlayerControl.LocalPlayer.PlayerId);
                    writer.Write(role.EscapePoint);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    role.LastEscape = DateTime.UtcNow;
                    Escapist.Escape(role.Player);
                }

                return false;
            }

            return true;
        }
    }
}
