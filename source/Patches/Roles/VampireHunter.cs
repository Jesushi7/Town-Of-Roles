using System;
using TMPro;

namespace TownOfSushi.Roles
{
    public class VampireHunter : Role
    {
        public PlayerControl ClosestPlayer;
        public DateTime LastStaked { get; set; }

        public int UsesLeft;
        public TextMeshPro UsesText;
        public bool AddedStakes;

        public bool ButtonUsable => UsesLeft != 0;

        public VampireHunter(PlayerControl player) : base(player)
        {
            Name = "Vampire Hunter";
            ImpostorText = () => "<color=#B3B3E6FF>Find and shoot all the </color><color=#262626FF>Vampires</color>";
            TaskText = () => "Stake the Vampires";
            FactionName = "Crewmate";
            Color = Patches.Colors.VampireHunter;
            LastStaked = DateTime.UtcNow;
            RoleType = RoleEnum.VampireHunter;
            AddToRoleHistory(RoleType);

            UsesLeft = 0;
            AddedStakes = false;
        }

        public float StakeTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastStaked;
            var num = CustomGameOptions.StakeCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}