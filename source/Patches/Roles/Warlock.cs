/*using System;
using TMPro;
using TownOfRoles.Patches;

namespace TownOfRoles.Roles
{
	// Token: 0x02000077 RID: 119
	public class Warlock : Role
	{
		// Token: 0x060003BF RID: 959 RVA: 0x000170A0 File Offset: 0x000152A0
		public Warlock(PlayerControl player) : base(player)
		{
			base.Name = "Warlock";
			this.StartText = (() => "Charge up your kill button To multi kill");
			this.TaskText = (() => "Kill people in small bursts");
			base.Color = Colors.Impostor;
			base.RoleType = RoleEnum.Warlock;
			base.AddToRoleHistory(base.RoleType);
			base.Faction = Faction.Impostors;
			this.ChargePercent = 0;
		}

		public int ChargeUpTimer()
		{
			DateTime utcNow = DateTime.UtcNow;
			TimeSpan timeSpan = utcNow - this.StartChargeTime;
			float num = CustomGameOptions.ChargeUpDuration * 1000f;
			float result = (float)timeSpan.TotalMilliseconds / num * 100f;
			bool flag = result > 100f;
			if (flag)
			{
				result = 100f;
			}
			return Convert.ToInt32(Math.Round((double)result));
		}

		public int ChargeUseTimer()
		{
			DateTime utcNow = DateTime.UtcNow;
			TimeSpan timeSpan = this.StartUseTime - utcNow;
			float num = this.ChargeUseDuration * 1000f;
			float result = ((float)timeSpan.TotalMilliseconds / num + 1f) * this.ChargeUseDuration / CustomGameOptions.ChargeUseDuration * 100f;
			bool flag = result < 0f;
			if (flag)
			{
				result = 0f;
			}
			return Convert.ToInt32(Math.Round((double)result));
		}
		public TextMeshPro ChargeText;

		public int ChargePercent;

		public bool Charging;

		public bool UsingCharge;

		public float ChargeUseDuration;

		public DateTime StartChargeTime;
		public DateTime StartUseTime;
	}
}
*/