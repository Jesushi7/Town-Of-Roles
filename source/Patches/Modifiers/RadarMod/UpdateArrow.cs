using System.Linq;
using HarmonyLib;
using TownOfSushi.Roles.Modifiers;
using System.Collections.Generic;
using UnityEngine;

namespace TownOfSushi.Modifiers.ParanoiacMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class UpdateArrow
    {
        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(ModifierEnum.Paranoiac)) return;

            var radar = Modifier.GetModifier<Paranoiac>(PlayerControl.LocalPlayer);
            if (radar.Player.Data.IsDead)
            {
                radar.ParanoiacArrow.DestroyAll();
                radar.ParanoiacArrow.Clear();
            }

            foreach (var arrow in radar.ParanoiacArrow)
            {
                radar.ClosestPlayer = GetClosestPlayer(PlayerControl.LocalPlayer, PlayerControl.AllPlayerControls.ToArray().ToList());
                arrow.target = radar.ClosestPlayer.transform.position;
            }
        }

        public static PlayerControl GetClosestPlayer(PlayerControl refPlayer, List<PlayerControl> AllPlayers)
        {
            var num = double.MaxValue;
            var refPosition = refPlayer.GetTruePosition();
            PlayerControl result = null;
            foreach (var player in AllPlayers)
            {
                if (player.Data.IsDead || player.PlayerId == refPlayer.PlayerId || !player.Collider.enabled) continue;
                var playerPosition = player.GetTruePosition();
                var distBetweenPlayers = Vector2.Distance(refPosition, playerPosition);
                var isClosest = distBetweenPlayers < num;
                if (!isClosest) continue;
                var vector = playerPosition - refPosition;
                num = distBetweenPlayers;
                result = player;
            }

            return result;
        }
    }
}