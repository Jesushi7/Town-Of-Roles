using HarmonyLib;
using Hazel;
using TownOfRoles.Roles;

namespace TownOfRoles.NeutralRoles.VultureMod
{
    [HarmonyPatch(typeof(GameManager), nameof(GameManager.RpcEndGame))]
    public class EndGame
    {
        public static bool Prefix(GameManager __instance, [HarmonyArgument(0)] GameOverReason reason)
        {
            if (reason != GameOverReason.HumansByVote && reason != GameOverReason.HumansByTask) return true;

            foreach (var role in Role.AllRoles)
                if (role.RoleType == RoleEnum.Vulture)
                    ((Vulture) role).Loses();

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                (byte) CustomRPC.VultureLose,
                SendOption.Reliable, -1);
            AmongUsClient.Instance.FinishRpcImmediately(writer);

            return true;
        }
    }
}