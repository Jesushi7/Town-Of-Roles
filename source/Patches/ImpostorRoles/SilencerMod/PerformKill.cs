using HarmonyLib;
using Hazel;
using TownOfRoles.Roles;
using TownOfRoles.Extensions;
using UnityEngine;

namespace TownOfRoles.ImpostorRoles.SilencerMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static bool Prefix(KillButton __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Silencer)) return true;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            var role = Role.GetRole<Silencer>(PlayerControl.LocalPlayer);
            var target = role.ClosestPlayer;
            if (__instance == role.SilenceButton)
            {
                if (!__instance.isActiveAndEnabled || role.ClosestPlayer == null) return false;
                if (__instance.isCoolingDown) return false;
                if (!__instance.isActiveAndEnabled) return false;
                if (role.SilenceTimer() != 0) return false;

                var interact = Utils.Interact(PlayerControl.LocalPlayer, target);
                if (interact[4] == true)
                {
                    role.Silenced?.myRend().material.SetFloat("_Outline", 0f);
                    if (role.Silenced != null && role.Silenced.Data.IsImpostor())
                    {
                        if (role.Silenced.GetCustomOutfitType() != CustomPlayerOutfitType.Camouflage &&
                            role.Silenced.GetCustomOutfitType() != CustomPlayerOutfitType.Swooper)
                            role.Silenced.nameText().color = Patches.Colors.Impostor;
                        else role.Silenced.nameText().color = Color.clear;
                    }
                    role.Silenced = target;
                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                        (byte)CustomRPC.Silence, SendOption.Reliable, -1);
                    writer.Write(PlayerControl.LocalPlayer.PlayerId);
                    writer.Write(target.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                }
                role.SilenceButton.SetCoolDown(0.01f, 1f);
                return false;
            }
            return true;
        }
    }
}