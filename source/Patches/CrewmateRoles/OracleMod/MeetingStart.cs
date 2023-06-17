using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TownOfRoles.Extensions;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.OracleMod
{
	[HarmonyPatch(typeof(MeetingHud), "Start")]
	public class MeetingStart
	{
		public static void Postfix(MeetingHud __instance)
		{
			bool isDead = PlayerControl.LocalPlayer.Data.IsDead;
			if (!isDead)
			{
				bool flag = !PlayerControl.LocalPlayer.Is(RoleEnum.Oracle);
				if (!flag)
				{
					Oracle oracleRole = Role.GetRole<Oracle>(PlayerControl.LocalPlayer);
					bool flag2 = oracleRole.Confessor != null;
					if (flag2)
					{
						string playerResults = MeetingStart.PlayerReportFeedback(oracleRole.Confessor);
						bool flag3 = !string.IsNullOrWhiteSpace(playerResults);
						if (flag3)
						{
							DestroyableSingleton<HudManager>.Instance.Chat.AddChat(PlayerControl.LocalPlayer, playerResults);
						}
					}
				}
			}
		}

		public static string PlayerReportFeedback(PlayerControl player)
		{
			bool flag = player.Data.IsDead || player.Data.Disconnected;
			string result;
			if (flag)
			{
				result = "Your confessor failed to survive so you received no confession";
			}
			else
			{
				List<PlayerControl> allPlayers = (from x in PlayerControl.AllPlayerControls.ToArray()
				where !x.Data.IsDead && !x.Data.Disconnected && x != PlayerControl.LocalPlayer && x != player
				select x).ToList<PlayerControl>();
				bool flag2 = allPlayers.Count < 2;
				if (flag2)
				{
					result = "Too few people alive to receive a confessional";
				}
				else
				{
					List<PlayerControl> evilPlayers = (from x in PlayerControl.AllPlayerControls.ToArray()
					where !x.Data.IsDead && !x.Data.Disconnected && (x.Is(Faction.Impostors) || 
					(x.Is(Faction.Neutral) &&  x.Is(RoleEnum.Glitch)&&  x.Is(RoleEnum.Werewolf)&&  x.Is(RoleEnum.SerialKiller) &&  x.Is(RoleEnum.Arsonist) 
					&&  x.Is(RoleEnum.Plaguebearer) &&  x.Is(RoleEnum.Pestilence) && CustomGameOptions.NeutralKillingShowsEvil) 
					|| (x.Is(Faction.Neutral)&&  x.Is(RoleEnum.Jester) &&  x.Is(RoleEnum.Executioner)
					&&  x.Is(RoleEnum.Guardian) &&  x.Is(RoleEnum.Amnesiac) &&  x.Is(RoleEnum.Phantom) && CustomGameOptions.NeutralNonKillersShowsEvil))
					select x).ToList<PlayerControl>();
					bool flag3 = evilPlayers.Count == 0;
					if (flag3)
					{
						result = player.GetDefaultOutfit().PlayerName + " confesses to knowing that there are no more evil players!";
					}
					else
					{
						allPlayers.Shuffle<PlayerControl>();
						evilPlayers.Shuffle<PlayerControl>();
						PlayerControl secondPlayer = allPlayers[0];
						bool firstTwoEvil = false;
						foreach (PlayerControl evilPlayer in evilPlayers)
						{
							bool flag4 = evilPlayer == player || evilPlayer == secondPlayer;
							if (flag4)
							{
								firstTwoEvil = true;
							}
						}
						bool flag5 = firstTwoEvil;
						if (flag5)
						{
							PlayerControl thirdPlayer = allPlayers[1];
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 3);
							defaultInterpolatedStringHandler.AppendFormatted(player.GetDefaultOutfit().PlayerName);
							defaultInterpolatedStringHandler.AppendLiteral(" confesses to knowing that they, ");
							defaultInterpolatedStringHandler.AppendFormatted(secondPlayer.GetDefaultOutfit().PlayerName);
							defaultInterpolatedStringHandler.AppendLiteral(" and/or ");
							defaultInterpolatedStringHandler.AppendFormatted(thirdPlayer.GetDefaultOutfit().PlayerName);
							defaultInterpolatedStringHandler.AppendLiteral(" is evil!");
							result = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						else
						{
							PlayerControl thirdPlayer2 = evilPlayers[0];
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 3);
							defaultInterpolatedStringHandler.AppendFormatted(player.GetDefaultOutfit().PlayerName);
							defaultInterpolatedStringHandler.AppendLiteral(" confesses to knowing that they, ");
							defaultInterpolatedStringHandler.AppendFormatted(secondPlayer.GetDefaultOutfit().PlayerName);
							defaultInterpolatedStringHandler.AppendLiteral(" and/or ");
							defaultInterpolatedStringHandler.AppendFormatted(thirdPlayer2.GetDefaultOutfit().PlayerName);
							defaultInterpolatedStringHandler.AppendLiteral(" is evil!");
							result = defaultInterpolatedStringHandler.ToStringAndClear();
						}
					}
				}
			}
			return result;
		}
	}
}
