/*using System;
using System.Collections.Generic;
using System.Linq;
using Hazel;
using Il2CppSystem.Collections.Generic;
using TownOfRoles.Extensions;
using TownOfRoles.Patches;

namespace TownOfRoles.Roles
{
	public class Vampire : Role
	{
		public Vampire(PlayerControl player) : base(player)
		{
			base.Name = "Vampire";
			this.StartText = (() => "Convert crewmates and kill the rest");
			this.TaskText = (() => "Bite all other players");
			base.Color = Colors.Vampire;
			this.LastBit = DateTime.UtcNow;
			base.RoleType = RoleEnum.Vampire;
			base.Faction = Faction.Neutral;
			base.AddToRoleHistory(base.RoleType);
		}
		public DateTime LastBit { get; set; }
		public float BiteTimer()
		{
			DateTime utcNow = DateTime.UtcNow;
			TimeSpan timeSpan = utcNow - this.LastBit;
			float num = CustomGameOptions.BiteCd * 1000f;
			bool flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
			bool flag3 = flag2;
			float result;
			if (flag3)
			{
				result = 0f;
			}
			else
			{
				result = (num - (float)timeSpan.TotalMilliseconds) / 1000f;
			}
			return result;
		}
		internal override bool NeutralWin(LogicGameFlowNormal __instance)
		{
			bool flag = base.Player.Data.IsDead || base.Player.Data.Disconnected;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2;
				if (PlayerControl.AllPlayerControls.ToArray().Count((PlayerControl x) => !x.Data.IsDead && !x.Data.Disconnected) <= 2)
				{
					flag2 = (PlayerControl.AllPlayerControls.ToArray().Count((PlayerControl x) => !x.Data.IsDead && !x.Data.Disconnected && (x.Data.IsImpostor() || x.Is(Faction.NeutralKilling))) == 1);
				}
				else
				{
					flag2 = false;
				}
				bool flag3 = flag2;
				if (flag3)
				{
					MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, 137, 1, -1);
					Role.VampWin();
					AmongUsClient.Instance.FinishRpcImmediately(writer);
					Utils.EndGame(2, false);
					result = false;
				}
				else
				{
					bool flag4;
					if (PlayerControl.AllPlayerControls.ToArray().Count((PlayerControl x) => !x.Data.IsDead && !x.Data.Disconnected) <= 4)
					{
						flag4 = (PlayerControl.AllPlayerControls.ToArray().Count((PlayerControl x) => !x.Data.IsDead && !x.Data.Disconnected && (x.Data.IsImpostor() || x.Is(Faction.NeutralKilling)) && !x.Is(RoleEnum.Vampire)) == 0);
					}
					else
					{
						flag4 = false;
					}
					bool flag5 = flag4;
					if (flag5)
					{
                        System.Collections.Generic.List<PlayerControl> vampsAlives = (from x in PlayerControl.AllPlayerControls.ToArray()
						where !x.Data.IsDead && !x.Data.Disconnected && x.Is(RoleEnum.Vampire)
						select x).ToList<PlayerControl>();
						bool flag6 = vampsAlives.Count == 1;
						if (flag6)
						{
							result = false;
						}
						else
						{
                            System.Collections.Generic.List<PlayerControl> alives = (from x in PlayerControl.AllPlayerControls.ToArray()
							where !x.Data.IsDead && !x.Data.Disconnected
							select x).ToList<PlayerControl>();
                            Il2CppSystem.Collections.Generic.List<PlayerControl> killersAlive = (from x in PlayerControl.AllPlayerControls.ToArray()
							where !x.Data.IsDead && !x.Data.Disconnected && !x.Is(RoleEnum.Vampire) && (x.Is(Faction.Impostors) || x.Is(Faction.NeutralKilling))
							select x).ToList<PlayerControl>();
							bool flag7 = killersAlive.Count > 0;
							if (flag7)
							{
								result = false;
							}
							else
							{
								bool flag8 = vampsAlives.Count == 2 && killersAlive.Count == 0 && alives.Count <= 4;
								if (flag8)
								{
									MessageWriter writer2 = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, 137, 1, -1);
									Role.VampWin();
									AmongUsClient.Instance.FinishRpcImmediately(writer2);
									Utils.EndGame(2, false);
									result = false;
								}
								else
								{
									result = false;
								}
							}
						}
					}
					else
					{
						List<PlayerControl> vampsAlives2 = (from x in PlayerControl.AllPlayerControls.ToArray()
						where !x.Data.IsDead && !x.Data.Disconnected && x.Is(RoleEnum.Vampire)
						select x).ToList<PlayerControl>();
						bool flag9 = vampsAlives2.Count == 1 || vampsAlives2.Count == 2;
						if (flag9)
						{
							result = false;
						}
						else
						{
                            System.Collections.Generic.List<PlayerControl> alives2 = (from x in PlayerControl.AllPlayerControls.ToArray()
							where !x.Data.IsDead && !x.Data.Disconnected
							select x).ToList<PlayerControl>();
                            Il2CppSystem.Collections.Generic.List<PlayerControl> killersAlive2 = (from x in PlayerControl.AllPlayerControls.ToArray()
							where !x.Data.IsDead && !x.Data.Disconnected && !x.Is(RoleEnum.Vampire) && (x.Is(Faction.Impostors) || x.Is(Faction.NeutralKilling))
							select x).ToList<PlayerControl>();
							bool flag10 = killersAlive2.Count > 0;
							if (flag10)
							{
								result = false;
							}
							else
							{
								bool flag11 = vampsAlives2.Count == 3 && killersAlive2.Count == 0 && alives2.Count <= 6;
								if (flag11)
								{
									MessageWriter writer3 = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, 137, 1, -1);
									Role.VampWin();
									AmongUsClient.Instance.FinishRpcImmediately(writer3);
									Utils.EndGame(2, false);
									result = false;
								}
								else
								{
									result = false;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x000158A0 File Offset: 0x00013AA0
		protected override void IntroPrefix(IntroCutscene._ShowTeam_d__36 __instance)
		{
            Il2CppSystem.Collections.Generic.List<PlayerControl> vampTeam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
			vampTeam.Add(PlayerControl.LocalPlayer);
			__instance.teamToShow = vampTeam;
		}

		public void Loses()
		{
			base.LostByRPC = true;
		}

		public PlayerControl ClosestPlayer;
	}
}*/