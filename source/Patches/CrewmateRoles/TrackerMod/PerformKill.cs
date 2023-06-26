using System;
using HarmonyLib;
using TownOfRoles.Roles;
using UnityEngine;
using TownOfRoles.Extensions;
using AmongUs.GameOptions;
using TownOfRoles.ImpostorRoles.CamouflageMod;

namespace TownOfRoles.CrewmateRoles.TrackerMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static Sprite Sprite => TownOfRoles.Arrow;
        public static bool Prefix(KillButton __instance)
        {
            if (__instance != DestroyableSingleton<HudManager>.Instance.KillButton) return true;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Tracker)) return true;
            var role = Role.GetRole<Tracker>(PlayerControl.LocalPlayer);
            if (!PlayerControl.LocalPlayer.CanMove || role.ClosestPlayer == null) return false;
            var flag2 = role.TrackerTimer() == 0f;
            if (!flag2) return false;
            if (!__instance.enabled) return false;
            var maxDistance = GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
            if (Vector2.Distance(role.ClosestPlayer.GetTruePosition(),
                PlayerControl.LocalPlayer.GetTruePosition()) > maxDistance) return false;
            if (role.ClosestPlayer == null) return false;
            var target = role.ClosestPlayer;
            if (!role.ButtonUsable) return false;

            var interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer);
            if (interact[4] == true)
            {
                var gameObj = new GameObject();
                var arrow = gameObj.AddComponent<ArrowBehaviour>();
                gameObj.transform.parent = PlayerControl.LocalPlayer.gameObject.transform;
                var renderer = gameObj.AddComponent<SpriteRenderer>();
                renderer.sprite = Sprite;
                if (!CamouflageUnCamouflage.IsCamoed)
                {
                    if (ColorUtils.IsRainbow(target.GetDefaultOutfit().ColorId))
                    {
                        renderer.color = ColorUtils.Rainbow;
                    }
                    else
                    {
                        renderer.color = Palette.PlayerColors[target.GetDefaultOutfit().ColorId];
                    }
                }
                arrow.image = renderer;
                gameObj.layer = 5;
                arrow.target = target.transform.position;

                role.TrackerArrows.Add(target.PlayerId, arrow);
                role.UsesLeft--;
            }
            if (interact[0] == true)
            {
                role.LastTracked = DateTime.UtcNow;
                return false;
            }
            else if (interact[1] == true)
            {
                role.LastTracked = DateTime.UtcNow;
                role.LastTracked = role.LastTracked.AddSeconds(CustomGameOptions.ProtectKCReset - CustomGameOptions.SnitchCd);
                return false;
            }
            else if (interact[3] == true) return false;
            return false;
        }
    }
}
