using System;
using System.Collections.Generic;
using AmongUs.GameOptions;
using HarmonyLib;
using TownOfSushi.Roles;

namespace TownOfSushi.NeutralRoles.JesterMod
{
	[HarmonyPatch(typeof(KillButton), "DoClick")]
	public class PerformKill
	{
		public static bool Prefix(KillButton __instance)
		{
			bool flag = PlayerControl.LocalPlayer.Is(RoleEnum.Jester);
			bool flag3 = !flag;
			bool result;
			if (flag3)
			{
				result = true;
			}
			else
			{
				bool flag4 = !CustomGameOptions.JesterKill;
				if (flag4)
				{
					result = true;
				}
				else
				{
					bool isDead = PlayerControl.LocalPlayer.Data.IsDead;
					if (isDead)
					{
						result = false;
					}
					else
					{
						bool flag5 = !PlayerControl.LocalPlayer.CanMove;
						if (flag5)
						{
							result = false;
						}
						else
						{
							Jester role = Role.GetRole<Jester>(PlayerControl.LocalPlayer);
							bool inVent = role.Player.inVent;
							if (inVent)
							{
								result = false;
							}
							else
							{
								bool flag6 = role.ClosestPlayer == null;
								if (flag6)
								{
									result = false;
								}
								else
								{
									double distBetweenPlayers = Utils.GetDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayer);
									bool flag2 = distBetweenPlayers < (double)GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
									bool flag7 = !flag2;
									if (flag7)
									{
										result = false;
									}
									else
									{
										List<bool> interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer, true);
										bool flag8 = interact[4];
										if (flag8)
										{
											result = false;
										}
										else
										{
											bool flag9 = interact[0];
											if (flag9)
											{
												role.LastKilled = DateTime.UtcNow;
												result = false;
											}
											else
											{
												bool flag10 = interact[1];
												if (flag10)
												{
													role.LastKilled = DateTime.UtcNow;
													role.LastKilled = role.LastKilled.AddSeconds((double)(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown + CustomGameOptions.ProtectKCReset));
													result = false;
												}
												else
												{
													bool flag11 = interact[2];
													if (flag11)
													{
														role.LastKilled = DateTime.UtcNow;
														role.LastKilled = role.LastKilled.AddSeconds((double)(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown + CustomGameOptions.VestKCReset));
														result = false;
													}
													else
													{
														bool flag12 = interact[3];
														result = (flag12 && false);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}
	}
}