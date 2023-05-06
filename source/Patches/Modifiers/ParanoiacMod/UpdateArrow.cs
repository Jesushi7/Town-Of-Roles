using System.Linq;
using HarmonyLib;
using TownOfRoles.Roles.Modifiers;
using System.Collections.Generic;
using UnityEngine;

namespace TownOfRoles.Modifiers.ParanoiacMod
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    public class UpdateArrow
    {
        public static void Postfix(PlayerControl __instance)
        {
            foreach (var modifier in Modifier.AllModifiers.Where(x => x.ModifierType == ModifierEnum.Paranoiac))
            {
                var paranoiac = (Paranoiac)modifier;
                if (paranoiac.Player.Data.IsDead)
                {
                    paranoiac.ParanoiacArrow.DestroyAll();
                    paranoiac.ParanoiacArrow.Clear();
                }

                foreach (var arrow in paranoiac.ParanoiacArrow)
                {
                    paranoiac.ClosestPlayer = GetClosestPlayer(PlayerControl.LocalPlayer, PlayerControl.AllPlayerControls.ToArray().ToList());
                    arrow.target = paranoiac.ClosestPlayer.transform.position;
                }
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