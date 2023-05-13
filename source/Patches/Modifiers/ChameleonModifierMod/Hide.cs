using HarmonyLib;
using TownOfRoles.Extensions;
using TownOfRoles.Roles;
using UnityEngine;
using TownOfRoles.Roles.Modifiers;

namespace TownOfRoles.Modifiers.ChameleonModifierMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    [HarmonyPriority(Priority.Last)]
    public class Hide
    {
        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.LocalPlayer.Is(ModifierEnum.ChameleonModifier))
            {
                var haunter = Modifier.GetModifier<ChameleonModifier>(PlayerControl.LocalPlayer);
                haunter.Fade();
                haunter.Faded = true;

                if (haunter.Player.Data.IsDead)
                {
                    Utils.Unmorph(haunter.Player);
                    haunter.Player.myRend().color = Color.white;
                    haunter.Player.gameObject.layer = LayerMask.NameToLayer("Ghost");
                    haunter.Faded = false;
                    haunter.Player.MyPhysics.ResetMoveState();
                }
            }
        }
    }
}