using System;
using TMPro;

namespace TownOfSushi.Roles.Cultist
{
    public class CultistSnitch : Role
    {
        public int UsesLeft;
        public TextMeshPro UsesText;
        public bool ButtonUsable => UsesLeft != 0;

        public CultistSnitch(PlayerControl player) : base(player)
        {
            Name = "Snitch";
            ImpostorText = () => "Reveal If Other Players Have Been Converted";
            TaskText = () => "Reveal if other players have been converted";
            Color = Patches.Colors.Snitch;
            LastInvestigated = DateTime.UtcNow;
            RoleType = RoleEnum.CultistSnitch;
            AddToRoleHistory(RoleType);
            UsesLeft = CustomGameOptions.MaxReveals;
        }

        public PlayerControl ClosestPlayer;
        public DateTime LastInvestigated { get; set; }

        public float SnitchTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastInvestigated;
            var num = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}