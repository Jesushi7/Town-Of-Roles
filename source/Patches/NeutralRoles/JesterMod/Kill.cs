using System;
using HarmonyLib;

namespace TownOfSushi.NeutralRoles.JesterMod
{
	[HarmonyPatch]
	public static class Kill
	{
		[HarmonyPatch(typeof(KillButton), "DoClick")]
		[HarmonyPostfix]
		public static void postfix()
		{
			bool flag = !PlayerControl.LocalPlayer.Is(RoleEnum.Jester);
			if (!flag)
			{
				bool flag2 = !CustomGameOptions.JesterKill;
				if (!flag2)
				{
					Kill.used = true;
				}
			}
		}

		[HarmonyPatch(typeof(HudManager), "Update")]
		[HarmonyPostfix]
		public static void postfix2(HudManager __instance)
		{
			bool flag = !PlayerControl.LocalPlayer.Is(RoleEnum.Jester);
			if (!flag)
			{
				bool flag2 = !CustomGameOptions.JesterKill;
				if (!flag2)
				{
					__instance.KillButton.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled) && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead && !Kill.used);
				}
			}
		}

		[HarmonyPatch(typeof(ShipStatus), "Begin")]
		[HarmonyPostfix]
		public static void postfix3(HudManager __instance)
		{
			Kill.used = false;
		}

		private static bool used;
	}
}