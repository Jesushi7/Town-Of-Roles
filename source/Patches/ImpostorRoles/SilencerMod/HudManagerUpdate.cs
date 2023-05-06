using HarmonyLib;
using TownOfRoles.Roles;
using UnityEngine;
using System.Linq;
using TownOfRoles.Extensions;
using AmongUs.GameOptions;

namespace TownOfRoles.ImpostorRoles.SilencerMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HudManagerUpdate
    {
        public static Sprite Silence => TownOfRoles.SilenceSprite;

        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Silencer)) return;
            var role = Role.GetRole<Silencer>(PlayerControl.LocalPlayer);
            if (role.SilenceButton == null)
            {
                role.SilenceButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.SilenceButton.graphic.enabled = true;
                role.SilenceButton.gameObject.SetActive(false);
            }

            role.SilenceButton.graphic.sprite = Silence;
            role.SilenceButton.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled)
                    && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead
                    && AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started);

            var notSilenced = PlayerControl.AllPlayerControls.ToArray().Where(
                player => role.Silenced?.PlayerId != player.PlayerId
            ).ToList();

            Utils.SetTarget(ref role.ClosestPlayer, role.SilenceButton, GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance], notSilenced);

            role.SilenceButton.SetCoolDown(role.SilenceTimer(), CustomGameOptions.SilenceCd);

            if (role.Silenced != null && !role.Silenced.Data.IsDead && !role.Silenced.Data.Disconnected)
            {
                role.Silenced.myRend().material.SetFloat("_Outline", 1f);
                role.Silenced.myRend().material.SetColor("_OutlineColor", new Color(0.3f, 0.0f, 0.0f));
                if (role.Silenced.GetCustomOutfitType() != CustomPlayerOutfitType.Camouflage &&
                    role.Silenced.GetCustomOutfitType() != CustomPlayerOutfitType.Swooper)
                    role.Silenced.nameText().color = new Color(0.3f, 0.0f, 0.0f);
                else role.Silenced.nameText().color = Color.clear;
            }

            var imps = PlayerControl.AllPlayerControls.ToArray().Where(
                player => player.Data.IsImpostor() && player != role.Silenced
            ).ToList();

            foreach (var imp in imps)
            {
                if ((imp.GetCustomOutfitType() == CustomPlayerOutfitType.Camouflage ||
                    imp.GetCustomOutfitType() == CustomPlayerOutfitType.Swooper)) imp.nameText().color = Color.clear;
                else if (imp.nameText().color == Color.clear ||
                    imp.nameText().color == new Color(0.3f, 0.0f, 0.0f)) imp.nameText().color = Patches.Colors.Impostor;
            }
        }
    }
}