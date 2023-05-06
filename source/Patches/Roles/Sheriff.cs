using System;

namespace TownOfRoles.Roles
{
    public class Sheriff : Role
    {
        public Sheriff(PlayerControl player) : base(player)
        {
            Name = "Sheriff";
            StartText = () => "<color=#f8cd46>Shoot The </color> <color=#FF0000FF>Impostors</color>";
            TaskText = () => "Shoot the <color=#FF0000FF>Killers</color>";
            Color = Patches.Colors.Sheriff;         
            LastKilled = DateTime.UtcNow;
            FactionName = "<color=#f8cd46>Crewmate</color>";              
            RoleType = RoleEnum.Sheriff;
            AddToRoleHistory(RoleType);
        }

        public PlayerControl ClosestPlayer;
        public DateTime LastKilled { get; set; }

        public float SheriffKillTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastKilled;
            var num = CustomGameOptions.SheriffKillCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }       
    }
}