/*using System;
using HarmonyLib;
using TMPro;
using TownOfRoles.Roles;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TownOfRoles.ImpostorRoles.WarlockMod
{
	[HarmonyPatch(typeof(HudManager), "Update")]
	public class HudManagerUpdate
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
						bool flag4 = !PlayerControl.LocalPlayer.Is(RoleEnum.Warlock);
						if (!flag4)
						{
							Warlock role = Role.GetRole<Warlock>(PlayerControl.LocalPlayer);
							bool flag5 = role.ChargeText == null;
							if (flag5)
							{
								role.ChargeText = Object.Instantiate<TextMeshPro>(__instance.KillButton.cooldownTimerText, __instance.KillButton.transform);
								role.ChargeText.gameObject.SetActive(false);
								role.ChargeText.transform.localPosition = new Vector3(role.ChargeText.transform.localPosition.x + 0.26f, role.ChargeText.transform.localPosition.y + 0.29f, role.ChargeText.transform.localPosition.z);
								role.ChargeText.transform.localScale = role.ChargeText.transform.localScale * 0.65f;
								role.ChargeText.alignment = 516;
								role.ChargeText.fontStyle = 1;
								role.ChargeText.enableWordWrapping = false;
							}
							bool flag6 = role.ChargeText != null;
							if (flag6)
							{
								role.ChargeText.text = role.ChargePercent.ToString() + "%";
							}
							role.ChargeText.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled) && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead && AmongUsClient.Instance.GameState == 2 && (role.Charging || role.UsingCharge));
							bool usingCharge = role.UsingCharge;
							if (usingCharge)
							{
								bool charging = role.Charging;
								if (charging)
								{
									role.StartUseTime = DateTime.UtcNow;
									role.Charging = false;
								}
							}
							else
							{
								bool flag7 = PlayerControl.LocalPlayer.killTimer == 0f;
								if (flag7)
								{
									bool flag8 = !role.Charging;
									if (flag8)
									{
										role.StartChargeTime = DateTime.UtcNow;
										role.Charging = true;
									}
								}
								else
								{
									role.ChargePercent = 0;
									role.Charging = false;
									role.UsingCharge = false;
								}
							}
						}
					}
				}
			}
		}
	}
}*/
