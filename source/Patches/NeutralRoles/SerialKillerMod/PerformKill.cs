using System;
using HarmonyLib;
using TownOfRoles.Roles;
using AmongUs.GameOptions;

namespace TownOfRoles.NeutralRoles.SerialKillerMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static bool Prefix(KillButton __instance)
        {
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.SerialKiller);
            if (!flag) return true;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            var role = Role.GetRole<SerialKiller>(PlayerControl.LocalPlayer);
            if (role.Player.inVent) return false;
            if (role.KillTimer() != 0) return false;

            if (role.ClosestPlayer == null) return false;
            var distBetweenPlayers = Utils.GetDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayer);
            var flag3 = distBetweenPlayers <
                        GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
            if (!flag3) return false;
            var interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer, true);
            if (interact[4] == true) return false;
            else if (interact[0] == true)
            {
                PlayerControl.LocalPlayer.SetKillTimer(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
                return false;
            }
            else if (interact[1] == true)
            {
                PlayerControl.LocalPlayer.SetKillTimer(CustomGameOptions.ProtectKCReset + 0.01f);
                return false;
            }
            else if (interact[3] == true)
            {
                PlayerControl.LocalPlayer.SetKillTimer(0.01f);
                return false;
            }
            return false;
        }
    }
}