using System;
using System.Collections.Generic;
using AmongUs.GameOptions;
using HarmonyLib;
using Hazel;
using TownOfRoles.Roles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TownOfRoles.CrewmateRoles.OracleMod
{
	[HarmonyPatch(typeof(KillButton), "DoClick")]
	public class PerformKill
	{
		public static bool Prefix(KillButton __instance)
		{
			bool flag3 = __instance != DestroyableSingleton<HudManager>.Instance.KillButton;
			bool result;
			if (flag3)
			{
				result = true;
			}
			else
			{
				bool flag = PlayerControl.LocalPlayer.Is(RoleEnum.Oracle);
				bool flag4 = !flag;
				if (flag4)
				{
					result = true;
				}
				else
				{
					Oracle role = Role.GetRole<Oracle>(PlayerControl.LocalPlayer);
					bool flag5 = !PlayerControl.LocalPlayer.CanMove || role.ClosestPlayer == null;
					if (flag5)
					{
						result = false;
					}
					else
					{
						bool flag2 = role.ConfessTimer() == 0f;
						bool flag6 = !flag2;
						if (flag6)
						{
							result = false;
						}
						else
						{
							bool flag7 = !__instance.enabled;
							if (flag7)
							{
								result = false;
							}
							else
							{
								float maxDistance = GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
								bool flag8 = Vector2.Distance(role.ClosestPlayer.GetTruePosition(), PlayerControl.LocalPlayer.GetTruePosition()) > maxDistance;
								if (flag8)
								{
									result = false;
								}
								else
								{
									bool flag9 = role.ClosestPlayer == null;
									if (flag9)
									{
										result = false;
									}
									else
									{
										List<bool> interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer, false);
										bool flag10 = interact[4];
										if (flag10)
										{
											role.Confessor = role.ClosestPlayer;
											int faction = 1;
											bool flag11 = role.Accuracy == 0f;
											bool showsCorrectFaction;
											if (flag11)
											{
												showsCorrectFaction = false;
											}
											else
											{
												int num = Random.RandomRangeInt(1, 101);
												showsCorrectFaction = ((float)num <= role.Accuracy);
											}
											bool flag12 = showsCorrectFaction;
											if (flag12)
											{
												bool flag13 = role.Confessor.Is(Faction.Crewmates);
												if (flag13)
												{
													faction = 0;
												}
												else
												{
													bool flag14 = role.Confessor.Is(Faction.Impostors);
													if (flag14)
													{
														faction = 2;
													}
												}
											}
											else
											{
												int num2 = Random.RandomRangeInt(0, 2);
												bool flag15 = role.Confessor.Is(Faction.Impostors);
												if (flag15)
												{
													faction = num2;
												}
												else
												{
													bool flag16 = role.Confessor.Is(Faction.Crewmates);
													if (flag16)
													{
														faction = num2 + 1;
													}
													else
													{
														bool flag17 = num2 == 1;
														if (flag17)
														{
															faction = 2;
														}
														else
														{
															faction = 0;
														}
													}
												}
											}
											bool flag18 = faction == 0;
											if (flag18)
											{
												role.RevealedFaction = Faction.Crewmates;
											}
											else
											{
												bool flag19 = faction == 1;
												if (flag19)
												{
													role.RevealedFaction = Faction.Neutral;
												}
												else
												{
													role.RevealedFaction = Faction.Impostors;
												}
											}
											var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                                            (byte)CustomRPC.Confess, SendOption.Reliable, -1);
											writer.Write(PlayerControl.LocalPlayer.PlayerId);
											writer.Write(role.Confessor.PlayerId);
											writer.Write(faction);
											AmongUsClient.Instance.FinishRpcImmediately(writer);
										}
										bool flag20 = interact[0];
										if (flag20)
										{
											role.LastConfessed = DateTime.UtcNow;
											result = false;
										}
										else
										{
											bool flag21 = interact[1];
											if (flag21)
											{
												role.LastConfessed = DateTime.UtcNow;
												role.LastConfessed = role.LastConfessed.AddSeconds((double)(CustomGameOptions.ProtectKCReset - CustomGameOptions.ConfessCd));
												result = false;
											}
											else
											{
												bool flag22 = interact[3];
												result = (flag22 && false);
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
