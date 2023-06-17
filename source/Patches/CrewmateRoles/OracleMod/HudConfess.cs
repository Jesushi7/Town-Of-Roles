using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using TownOfRoles.Roles;
using UnityEngine;

namespace TownOfRoles.CrewmateRoles.OracleMod
{
	[HarmonyPatch(typeof(HudManager))]
	public class HudConfess
	{
		[HarmonyPatch("Update")]
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
						bool flag4 = !PlayerControl.LocalPlayer.Is(RoleEnum.Oracle);
						if (!flag4)
						{
							KillButton confessButton = __instance.KillButton;
							Oracle role = Role.GetRole<Oracle>(PlayerControl.LocalPlayer);
							confessButton.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled) && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead && Classes.GameStates.IsInGame);
							confessButton.SetCoolDown(role.ConfessTimer(), CustomGameOptions.ConfessCd);
							List<PlayerControl> notConfessing = (from x in PlayerControl.AllPlayerControls.ToArray()
							where x != role.Confessor
							select x).ToList<PlayerControl>();
							Utils.SetTarget(ref role.ClosestPlayer, confessButton, float.NaN, notConfessing);
							SpriteRenderer renderer = confessButton.graphic;
							bool flag5 = role.ClosestPlayer != null;
							if (flag5)
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
