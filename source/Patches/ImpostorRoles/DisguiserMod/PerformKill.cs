using HarmonyLib;
using Hazel;
using TownOfRoles.Roles;

namespace TownOfRoles.ImpostorRoles.CamouflageMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static bool Prefix(KillButton __instance)
        {
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Disguiser);
            if (!flag) return true;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            var role = Role.GetRole<Disguiser>(PlayerControl.LocalPlayer);
            var target = DestroyableSingleton<HudManager>.Instance.KillButton.currentTarget;
            if (__instance == role.CamouflageButton)
            {
                if (__instance.isCoolingDown) return false;
                if (!__instance.isActiveAndEnabled) return false;
                if (role.CamouflageTimer() != 0) return false;

                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                    (byte) CustomRPC.Camouflage,
                    SendOption.Reliable, -1);
                writer.Write(PlayerControl.LocalPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                role.TimeRemaining = CustomGameOptions.DisguiserDuration;
                Utils.Camouflage();

                return false;
            }

            return true;
        }
    }
}