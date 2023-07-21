using System;
using TownOfSushi.Roles;

namespace TownOfSushi.CrewmateRoles.DetectiveMod
{
    public class BodyReport
    {
        public PlayerControl Killer { get; set; }
        public PlayerControl Reporter { get; set; }
        public PlayerControl Body { get; set; }
        public float KillAge { get; set; }

        public static string ParseBodyReport(BodyReport br)
        {
            if (br.KillAge > CustomGameOptions.DetectiveFactionDuration * 1000)
                return
                    $"Body Report: The body has been dead for too long, Can't gain information. (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            if (br.Killer.PlayerId == br.Body.PlayerId)
                return
                    $"Body Report: The dead confesses that they shot wrong! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            var role = Role.GetRole(br.Killer);
            if (br.Killer.Is(Faction.Crewmates))
                return
                    $"Body Report: The killer appears to be a Crewmate! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            else if (br.Killer.Is(Faction.NeutralKilling) || br.Killer.Is(Faction.NeutralBenign))
                return
                    $"Body Report: The killer appears to be a Neutral Killer! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            else
                return
                    $"Body Report: The killer appears to be an Impostor! (Killed {Math.Round(br.KillAge / 1000)}s ago)";
        }
    }
}
