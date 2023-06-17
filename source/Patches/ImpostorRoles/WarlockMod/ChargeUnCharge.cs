/*using System;
using HarmonyLib;
using TownOfRoles.Modifiers.UnderdogMod;
using TownOfRoles.Roles;

namespace TownOfRoles.ImpostorRoles.WarlockMod
{
	[HarmonyPatch(typeof(HudManager), "Update")]
	[HarmonyPriority(0)]
	public class ChargeUnCharge
	{
		// Token: 0x0600053C RID: 1340 RVA: 0x00026270 File Offset: 0x00024470
		[HarmonyPriority(0)]
		public static void Postfix(HudManager __instance)
		{
			bool flag = !PlayerControl.LocalPlayer.Is(RoleEnum.Warlock);
			if (!flag)
			{
				foreach (Role role in Role.GetRoles(RoleEnum.Warlock))
				{
					Warlock warlock = (Warlock)role;
					bool charging = warlock.Charging;
					if (charging)
					{
						warlock.ChargePercent = warlock.ChargeUpTimer();
					}
					else
					{
						bool usingCharge = warlock.UsingCharge;
						if (usingCharge)
						{
							warlock.ChargePercent = warlock.ChargeUseTimer();
							bool flag2 = (float)warlock.ChargePercent <= 0f;
							if (flag2)
							{
								warlock.UsingCharge = false;
								bool flag3 = warlock.Player.Is(ModifierEnum.Underdog);
								if (flag3)
								{
									float lowerKC = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown - CustomGameOptions.UnderdogKillBonus;
									float normalKC = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown;
									float upperKC = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown + CustomGameOptions.UnderdogKillBonus;
									warlock.Player.SetKillTimer(PerformKill.LastImp() ? lowerKC : (PerformKill.IncreasedKC() ? normalKC : upperKC));
								}
								else
								{
									warlock.Player.SetKillTimer(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
								}
							}
						}
					}
				}
			}
		}
	}
}*/
