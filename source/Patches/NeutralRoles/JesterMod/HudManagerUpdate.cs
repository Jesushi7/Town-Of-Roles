using System;
using HarmonyLib;
using TownOfSushi.Roles;
using UnityEngine;

namespace TownOfSushi.NeutralRoles.JesterMod
{
	[HarmonyPatch(typeof(HudManager), "Update")]
	public static class HudManagerUpdate
	{
		public static void Postfix(HudManager __instance)
		{
			bool flag = PlayerControl.AllPlayerControls.Count <= 1;
			if (!flag)
			{
				bool flag2 = PlayerControl.LocalPlayer == null;
				if (!flag2)
				{
					bool flag3 = PlayerControl.LocalPlayer.Data == null;
					if (!flag3)
					{
						bool flag4 = !PlayerControl.LocalPlayer.Is(RoleEnum.Jester);
						if (!flag4)
						{
							bool flag5 = !CustomGameOptions.JesterKill;
							if (!flag5)
							{
								Jester role = Role.GetRole<Jester>(PlayerControl.LocalPlayer);
								__instance.KillButton.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled) && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead);
								__instance.KillButton.SetCoolDown(role.KillTimer(), GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
								Utils.SetTarget(ref role.ClosestPlayer, __instance.KillButton, float.NaN, null);
								Utils.SetTarget(ref role.ClosestPlayer, __instance.KillButton, float.NaN, null);
								SpriteRenderer renderer = __instance.KillButton.graphic;
								bool flag6 = !__instance.KillButton.isCoolingDown && role.ClosestPlayer != null;
								if (flag6)
								{
									renderer.color = Palette.EnabledColor;
									renderer.material.SetFloat("_Desat", 0f);
								}
								else
								{
									renderer.color = Palette.DisabledClear;
									renderer.material.SetFloat("_Desat", 1f);
								}
							}
						}
					}
				}
			}
		}
	}
}