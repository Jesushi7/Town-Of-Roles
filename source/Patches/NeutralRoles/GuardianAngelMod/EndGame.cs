using HarmonyLib;
using Hazel;
using TownOfRoles.Roles;

namespace TownOfRoles.NeutralRoles.GuardianMod
{
    [HarmonyPatch(typeof(GameManager), nameof(GameManager.RpcEndGame))]
    public class EndGame
    {
        public static bool Prefix(GameManager __instance, [HarmonyArgument(0)] GameOverReason reason)
        {
            foreach (var role in Role.AllRoles)
                if (role.RoleType == RoleEnum.Guardian && ((Guardian)role).target.Is(Faction.Impostors))
                {
                    if (reason != GameOverReason.HumansByVote && reason != GameOverReason.HumansByTask)
                    {
                        ((Guardian)role).ImpTargetWin();

                        var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                            (byte)CustomRPC.GAImpWin,
                            SendOption.Reliable, -1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                    }
                    else
                    {
                        ((Guardian)role).ImpTargetLose();

                        var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                            (byte)CustomRPC.GAImpLose,
                            SendOption.Reliable, -1);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                    }
                    return true;
                }
            return true;
        }
    }
}