using HarmonyLib;
using TownOfRoles.Roles;
using UnityEngine;
using System.Linq;
using Hazel;
using TownOfRoles.Extensions;

namespace TownOfRoles.ImpostorRoles.VampireMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HudManagerUpdate
    {
        public static Sprite PoisonSprite => TownOfRoles.PoisonSprite;

        [HarmonyPriority(Priority.Last)]
        
        public static void Postfix(HudManager __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Vampire)) return;
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            var role = Role.GetRole<Vampire>(PlayerControl.LocalPlayer);
            if (role.BiteButton == null)
            {
                role.BiteButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.BiteButton.graphic.enabled = true;
                role.BiteButton.gameObject.SetActive(false);
            }
            role.BiteButton.graphic.sprite = PoisonSprite;
            role.BiteButton.transform.localPosition = new Vector3(0f, 1f, 0f);

            var notImp = PlayerControl.AllPlayerControls
                    .ToArray()
                    .Where(x => !x.Is(Faction.Impostors))
                    .ToList();
            Utils.SetTarget(ref role.ClosestPlayer, role.BiteButton, float.NaN, notImp);

            if (role.ClosestPlayer != null)
            {
                role.ClosestPlayer.myRend().material.SetColor("_OutlineColor", Palette.ImpostorRed);
            }

            role.Player.SetKillTimer(1f);
            try
            {
                if (role.Poisoned)
                {
                    role.Poison();
                    role.BiteButton.SetCoolDown(role.TimeRemaining, CustomGameOptions.BiteDuration);
                }
                else
                {
                    if (role.BittenPlayer && role.BittenPlayer != PlayerControl.LocalPlayer)
                    {
                        role.PoisonKill();
                    }
                    if (role.ClosestPlayer != null)
                    {
                        role.BiteButton.graphic.color = Palette.EnabledColor;
                        role.BiteButton.graphic.material.SetFloat("_Desat", 0f);
                    }
                    else
                    {
                        role.BiteButton.graphic.color = Palette.DisabledClear;
                        role.BiteButton.graphic.material.SetFloat("_Desat", 1f);
                    }
                    role.BiteButton.SetCoolDown(role.BiteTimer(), GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
                    role.BittenPlayer = PlayerControl.LocalPlayer; //Only do this to stop repeatedly trying to re-kill poisoned player. null didn't work for some reason
                }
            }
            catch
            {

            }
        }
    }
}
