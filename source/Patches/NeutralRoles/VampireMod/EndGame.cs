/*using System;
using HarmonyLib;
using Hazel;
using TownOfRoles.Roles;

namespace TownOfRoles.NeutralRoles.JackalMod
{
	[HarmonyPatch(typeof(GameManager), "RpcEndGame")]
	public class EndGame
	{
		public static bool Prefix(GameManager __instance, [HarmonyArgument(0)] GameOverReason reason)
		{
			bool flag = reason != null && reason != 1;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				foreach (Role role in Role.AllRoles)
				{
					bool flag2 = role.RoleType == RoleEnum.Jackal;
					if (flag2)
					{
						((Jackal)role).Loses();
					}
				}
				MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, 138, 1, -1);
				AmongUsClient.Instance.FinishRpcImmediately(writer);
				result = true;
			}
			return result;
		}
	}
}
*/