using HarmonyLib;
using TownOfRoles.Roles;
using UnityEngine;

namespace TownOfRoles.ImpostorRoles.CamouflageMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HudManagerUpdate
    {
        public static Sprite Camouflage => TownOfRoles.Disguise;

        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Disguiser)) return;
            var role = Role.GetRole<Disguiser>(PlayerControl.LocalPlayer);
            if (role.CamouflageButton == null)
            {
                role.CamouflageButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.CamouflageButton.graphic.enabled = true;
                role.CamouflageButton.gameObject.SetActive(false);
            }
            role.CamouflageButton.graphic.sprite = Camouflage;
            role.CamouflageButton.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled)
                    && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead
                    && AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started);


            if (role.Enabled)
            {
                role.CamouflageButton.SetCoolDown(role.TimeRemaining, CustomGameOptions.DisguiserDuration);
                return;
            }

            role.CamouflageButton.SetCoolDown(role.CamouflageTimer(), CustomGameOptions.DisguiserCd);
            role.CamouflageButton.graphic.color = Palette.EnabledColor;
            role.CamouflageButton.graphic.material.SetFloat("_Desat", 0f);
        }
    }
}