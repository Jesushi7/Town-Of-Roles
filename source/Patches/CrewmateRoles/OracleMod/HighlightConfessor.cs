using System;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.OracleMod
{
	[HarmonyPatch(typeof(HudManager), "Update")]
	public class HighlightConfessor
	{
		public static void UpdateMeeting(Oracle role, MeetingHud __instance)
		{
			foreach (PlayerControl player in PlayerControl.AllPlayerControls)
			{
				foreach (PlayerVoteArea state in __instance.playerStates)
				{
					bool flag = player.PlayerId != state.TargetPlayerId;
					if (!flag)
					{
						bool flag2 = player == role.Confessor;
						if (flag2)
						{
							bool flag3 = role.RevealedFaction == Faction.Crewmates;
							if (flag3)
							{
								state.NameText.text = "<color=#00FFFFFF>(Crewmate) </color>" + state.NameText.text;
							}
							else
							{
								bool flag4 = role.RevealedFaction == Faction.Impostors;
								if (flag4)
								{
									state.NameText.text = "<color=#FF0000FF>(Impostor) </color>" + state.NameText.text;
								}
								else
								{
									state.NameText.text = "<color=#808080FF>(Neutral) </color>" + state.NameText.text;
								}
							}
						}
					}
				}
			}
		}

		public static void Postfix(HudManager __instance)
		{
			bool flag = !MeetingHud.Instance || PlayerControl.LocalPlayer.Data.IsDead;
			if (!flag)
			{
				foreach (Role oracle in Role.GetRoles(RoleEnum.Oracle))
				{
					Oracle role = Role.GetRole<Oracle>(oracle.Player);
					bool flag2 = !role.Player.Data.IsDead || role.Confessor == null;
					if (flag2)
					{
						break;
					}
					HighlightConfessor.UpdateMeeting(role, MeetingHud.Instance);
				}
			}
		}
	}
}
