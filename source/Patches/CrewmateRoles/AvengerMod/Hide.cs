using HarmonyLib;
using TownOfRoles.Extensions;
using TownOfRoles.Roles;
using UnityEngine;

namespace TownOfRoles.CrewmateRoles.AvengerMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    [HarmonyPriority(Priority.Last)]
    public class Hide
    {
        public static void Postfix(HudManager __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Avenger))
            {
                var Avenger = (Avenger) role;
                if (role.Player.Data.Disconnected) return;
                var caught = Avenger.Caught;
                if (!caught)
                {
                    Avenger.Fade();
                }
                else if (Avenger.Faded)
                {
                    Utils.Unmorph(Avenger.Player);
                    Avenger.Player.myRend().color = Color.white;
                    Avenger.Player.gameObject.layer = LayerMask.NameToLayer("Ghost");
                    Avenger.Faded = false;
                    Avenger.Player.MyPhysics.ResetMoveState();
                }
            }
        }
    }
}