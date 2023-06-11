using System;
using Il2CppSystem.Collections.Generic;
using TownOfRoles.Patches;

namespace TownOfRoles.Roles
{
	public class Jester : Role
	{
		public DateTime LastKilled { get; set; }

        public Jester(PlayerControl player) : base(player)
        {
            Name = "Jester";
            StartText = () => "<color=#cb81c0>Get voted out/color>";
            TaskText = () => SpawnedAs ? "Trick everyone into voting you" : "Your target was killed.\nNow you trick everyone to vote you and win!";
            Color = Patches.Colors.Jester;
            RoleType = RoleEnum.Jester;
            AddToRoleHistory(RoleType);
            FactionName = "<color=#5c5e5d>Neutral</color>";              
            Faction = Faction.Neutral;
        }

		protected override void IntroPrefix(IntroCutscene._ShowTeam_d__36 __instance)
		{
			List<PlayerControl> jestTeam = new List<PlayerControl>();
			jestTeam.Add(PlayerControl.LocalPlayer);
			__instance.teamToShow = jestTeam;
		}

        internal override bool EABBNOODFGL(LogicGameFlowNormal __instance)
        {
            if (!VotedOut || !Player.Data.IsDead && !Player.Data.Disconnected) return true;
            Utils.EndGame();
            return false;
        }

		public void Wins()
		{
			this.VotedOut = true;
		}

		public void Loses()
		{
			base.LostByRPC = true;
		}

		public float KillTimer()
		{
			DateTime utcNow = DateTime.UtcNow;
			TimeSpan timeSpan = utcNow - this.LastKilled;
			float num = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * 1000f;
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

		public bool VotedOut;

		public bool SpawnedAs = true;

		public PlayerControl ClosestPlayer;


		public int UsesLeft;
	}
}