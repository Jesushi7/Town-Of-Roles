using System;
using HarmonyLib;
using TownOfRoles.Extensions;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;

namespace TownOfRoles.ImpostorRoles.SilencerMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    public static class HUDClose
    {
        public static void Postfix(Object obj)
        {
            if (ExileController.Instance == null || obj != ExileController.Instance.gameObject) return;
            foreach (var role in Role.GetRoles(RoleEnum.Silencer))
            {
                var Silencer = (Silencer)role;
                if (Silencer.Player.PlayerId == PlayerControl.LocalPlayer.PlayerId)
                {
                    Silencer.Silenced?.myRend().material.SetFloat("_Outline", 0f);
                }
                Silencer.Silenced = null;
                Silencer.LastSilenced = DateTime.UtcNow;
            }
        }
    }
}