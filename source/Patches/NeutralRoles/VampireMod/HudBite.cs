/*using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using TownOfRoles.Roles;
using UnityEngine;

namespace TownOfRoles.NeutralRoles.JackalMod
{
	[HarmonyPatch(typeof(HudManager))]
	public class HudBite
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
						bool flag4 = !PlayerControl.LocalPlayer.Is(RoleEnum.Jackal);
						if (!flag4)
						{
							KillButton biteButton = __instance.KillButton;
							Jackal role = Role.GetRole<Jackal>(PlayerControl.LocalPlayer);
							biteButton.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled) && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead && AmongUsClient.Instance.GameState == 2);
							biteButton.SetCoolDown(role.BiteTimer(), CustomGameOptions.BiteCd);
							List<PlayerControl> notJackal = (from x in PlayerControl.AllPlayerControls.ToArray()
							where !x.Is(RoleEnum.Jackal)
							select x).ToList<PlayerControl>();
							Utils.SetTarget(ref role.ClosestPlayer, biteButton, float.NaN, notJackal);
							SpriteRenderer renderer = biteButton.graphic;
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
}*/