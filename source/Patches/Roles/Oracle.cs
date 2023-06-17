using System;
using TownOfRoles.Patches;

namespace TownOfRoles.Roles
{
	public class Oracle : Role
	{
		public DateTime LastConfessed { get; set; }

		public Oracle(PlayerControl player) : base(player)
		{
			Name = "Oracle";
			StartText = (() => "Get Other Player's To Confess Their Sins");
			TaskText = (() => "Get other player to confess");
			Color = Colors.Oracle;
			LastConfessed = DateTime.UtcNow;
			Accuracy = CustomGameOptions.RevealAccuracy;
			FirstMeetingDead = true;
			FirstMeetingDead = false;
			RoleType = RoleEnum.Oracle;
			AddToRoleHistory(RoleType);
		}

		public float ConfessTimer()
		{
			DateTime utcNow = DateTime.UtcNow;
			TimeSpan timeSpan = utcNow - LastConfessed;
			float num = CustomGameOptions.ConfessCd * 1000f;
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
		public PlayerControl ClosestPlayer;

		public PlayerControl Confessor;

		public float Accuracy;
		public bool FirstMeetingDead;
		public Faction RevealedFaction;
		public bool SavedConfessor;
	}
}