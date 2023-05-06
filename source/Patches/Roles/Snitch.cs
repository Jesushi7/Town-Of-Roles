using System;
using System.Collections.Generic;

namespace TownOfRoles.Roles
{
    public class Snitch : Role
    {
        public List<byte> Investigated = new List<byte>();

        public Snitch(PlayerControl player) : base(player)
        {
            Name = "Snitch";
            StartText = () => "<color=#61b26c>Reveal The Alliance Of Other Players</color>";
            TaskText = () => "Reveal alliances of other players to find the Impostors";
            Color = Patches.Colors.Snitch;
            LastInvestigated = DateTime.UtcNow;
            RoleType = RoleEnum.Snitch;
            FactionName = "<color=#61b26c>Crewmate</color>";              
            AddToRoleHistory(RoleType);
        }

        public PlayerControl ClosestPlayer;
        public DateTime LastInvestigated { get; set; }

        public float SnitchTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastInvestigated;
            var num = CustomGameOptions.SnitchCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}