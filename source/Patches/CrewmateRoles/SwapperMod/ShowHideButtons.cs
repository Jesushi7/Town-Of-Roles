using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Hazel;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using TownOfRoles.CrewmateRoles.MayorMod;
using TownOfRoles.Extensions;
using TownOfRoles.Roles;
using UnityEngine;
using UnityEngine.UI;

namespace TownOfRoles.CrewmateRoles.SwapperMod
{
	// Token: 0x02000153 RID: 339
	public class ShowHideButtonsSwapper
	{
		// Token: 0x06000661 RID: 1633 RVA: 0x00035574 File Offset: 0x00033774
		public static Dictionary<byte, int> CalculateVotes(MeetingHud __instance)
		{
			Dictionary<byte, int> self = ShowHideButtonsSwapper.CalculateVotesSwap(__instance);
			bool tie;
			KeyValuePair<byte, int> maxIdx = self.MaxPair(out tie);
			GameData.PlayerInfo exiled = GameData.Instance.AllPlayers.ToArray().FirstOrDefault((GameData.PlayerInfo v) => !tie && v.PlayerId == maxIdx.Key);
			foreach (Role oracle in Role.GetRoles(RoleEnum.Oracle))
			{
				Oracle oracleRole = (Oracle)oracle;
				bool flag = oracleRole.Player.Data.IsDead || oracleRole.Player.Data.Disconnected || exiled == null || oracleRole.Confessor == null;
				if (!flag)
				{
					bool flag2 = oracleRole.Confessor.PlayerId == exiled.PlayerId;
					if (flag2)
					{
						oracleRole.SavedConfessor = true;
                   var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                    (byte) CustomRPC.SetSwaps, SendOption.Reliable, -1);
						writer.Write(oracleRole.Player.PlayerId);
						AmongUsClient.Instance.FinishRpcImmediately(writer);
						return new Dictionary<byte, int>();
					}
				}
			}
			return self;
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x000356C8 File Offset: 0x000338C8
		public static Dictionary<byte, int> CalculateVotesSwap(MeetingHud __instance)
		{
			Dictionary<byte, int> self = RegisterExtraVotes.CalculateAllVotes(__instance);
			bool flag = SwapVotes.Swap1 == null || SwapVotes.Swap2 == null;
			Dictionary<byte, int> result;
			if (flag)
			{
				result = self;
			}
			else
			{
				foreach (Role swapper in from x in Role.AllRoles
				where x.RoleType == RoleEnum.Swapper
				select x)
				{
					bool flag2 = swapper.Player.Data.IsDead || swapper.Player.Data.Disconnected;
					if (flag2)
					{
						return self;
					}
				}
				PlayerControl swapPlayer = null;
				PlayerControl swapPlayer2 = null;
				foreach (PlayerControl player in PlayerControl.AllPlayerControls)
				{
					bool flag3 = player.PlayerId == SwapVotes.Swap1.TargetPlayerId;
					if (flag3)
					{
						swapPlayer = player;
					}
					bool flag4 = player.PlayerId == SwapVotes.Swap2.TargetPlayerId;
					if (flag4)
					{
						swapPlayer2 = player;
					}
				}
				bool flag5 = swapPlayer.Data.IsDead || swapPlayer.Data.Disconnected || swapPlayer2.Data.IsDead || swapPlayer2.Data.Disconnected;
				if (flag5)
				{
					result = self;
				}
				else
				{
					int swap = 0;
					int value;
					bool flag6 = self.TryGetValue(SwapVotes.Swap1.TargetPlayerId, out value);
					if (flag6)
					{
						swap = value;
					}
					int swap2 = 0;
					int value2;
					bool flag7 = self.TryGetValue(SwapVotes.Swap2.TargetPlayerId, out value2);
					if (flag7)
					{
						swap2 = value2;
					}
					self[SwapVotes.Swap2.TargetPlayerId] = swap;
					self[SwapVotes.Swap1.TargetPlayerId] = swap2;
					result = self;
				}
			}
			return result;
		}

		// Token: 0x020002E2 RID: 738
		[HarmonyPatch(typeof(MeetingHud), "Confirm")]
		public static class Confirm
		{
			// Token: 0x06000B45 RID: 2885 RVA: 0x00050E20 File Offset: 0x0004F020
			public static bool Prefix(MeetingHud __instance)
			{
				bool flag = !PlayerControl.LocalPlayer.Is(RoleEnum.Swapper);
				bool result;
				if (flag)
				{
					result = true;
				}
				else
				{
					Swapper swapper = Role.GetRole<Swapper>(PlayerControl.LocalPlayer);
					foreach (GameObject button2 in from button in swapper.Buttons
					where button != null
					select button)
					{
						bool flag2 = button2.GetComponent<SpriteRenderer>().sprite == AddButton.DisabledSprite;
						if (flag2)
						{
							button2.SetActive(false);
						}
						button2.GetComponent<PassiveButton>().OnClick = new Button.ButtonClickedEvent();
					}
					bool flag3 = swapper.ListOfActives.Count((bool x) => x) == 2;
					if (flag3)
					{
						bool toSet = true;
						for (int i = 0; i < swapper.ListOfActives.Count; i++)
						{
							bool flag4 = !swapper.ListOfActives[i];
							if (!flag4)
							{
								bool flag5 = toSet;
								if (flag5)
								{
									SwapVotes.Swap1 = __instance.playerStates[i];
									toSet = false;
								}
								else
								{
									SwapVotes.Swap2 = __instance.playerStates[i];
								}
							}
						}
					}
					bool flag6 = SwapVotes.Swap1 == null || SwapVotes.Swap2 == null;
					if (flag6)
					{
						result = true;
					}
					else
					{
                   var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                    (byte) CustomRPC.SetSwaps, SendOption.Reliable, -1);
						writer.Write(SwapVotes.Swap1.TargetPlayerId);
						writer.Write(SwapVotes.Swap2.TargetPlayerId);
						AmongUsClient.Instance.FinishRpcImmediately(writer);
						result = true;
					}
				}
				return result;
			}
		}

		[HarmonyPatch(typeof(MeetingHud), "CheckForEndVoting")]
		public static class CheckForEndVoting
		{
			private static bool CheckVoted(PlayerVoteArea playerVoteArea)
			{
				bool flag = playerVoteArea.AmDead || playerVoteArea.DidVote;
				bool result;
				if (flag)
				{
					result = true;
				}
				else
				{
					GameData.PlayerInfo playerInfo = GameData.Instance.GetPlayerById(playerVoteArea.TargetPlayerId);
					bool flag2 = playerInfo == null;
					if (flag2)
					{
						result = true;
					}
					else
					{
						PlayerControl playerControl = playerInfo.Object;
						bool flag3 = playerControl.Is(AbilityEnum.Assassin) && playerInfo.IsDead;
						if (flag3)
						{
							playerVoteArea.VotedFor = PlayerVoteArea.DeadVote;
							playerVoteArea.SetDead(false, true, false);
							result = true;
						}
						else
						{
							result = true;
						}
					}
				}
				return result;
			}
			public static bool Prefix(MeetingHud __instance)
			{
				bool flag = __instance.playerStates.All((PlayerVoteArea ps) => ps.AmDead || (ps.DidVote && ShowHideButtonsSwapper.CheckForEndVoting.CheckVoted(ps)));
				if (flag)
				{
					Dictionary<byte, int> self = ShowHideButtonsSwapper.CalculateVotes(__instance);
					Il2CppStructArray<MeetingHud.VoterState> array = new Il2CppStructArray<MeetingHud.VoterState>((long)__instance.playerStates.Length);
					bool tie;
					KeyValuePair<byte, int> maxIdx = self.MaxPair(out tie);
					GameData.PlayerInfo exiled = GameData.Instance.AllPlayers.ToArray().FirstOrDefault((GameData.PlayerInfo v) => !tie && v.PlayerId == maxIdx.Key);
					for (int i = 0; i < __instance.playerStates.Length; i++)
					{
						PlayerVoteArea playerVoteArea = __instance.playerStates[i];
						Il2CppArrayBase<MeetingHud.VoterState> il2CppArrayBase = array;
						int num = i;
						MeetingHud.VoterState voterState = default(MeetingHud.VoterState);
						voterState.VoterId = playerVoteArea.TargetPlayerId;
						voterState.VotedForId = playerVoteArea.VotedFor;
						il2CppArrayBase[num] = voterState;
					}
					__instance.RpcVotingComplete(array, exiled, tie);
				}
				return false;
			}
		}
	}
}
