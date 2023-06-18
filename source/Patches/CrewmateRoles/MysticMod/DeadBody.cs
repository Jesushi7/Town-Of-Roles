using System;
using TownOfRoles.CrewmateRoles.ImitatorMod;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.MysticMod
{
    public class BodyReport
    {
        public PlayerControl Killer { get; set; }
        public PlayerControl Reporter { get; set; }
        public PlayerControl Body { get; set; }
        public float KillAge { get; set; }

        public static string ParseBodyReport(BodyReport br)
        {
            if (br.KillAge > CustomGameOptions.MysticFactionDuration * 1000)
                return
                    $"Error: Can't get information from the body, old kill. (Died {Math.Round(br.KillAge / 1000)}s ago)";

            if (br.Killer.PlayerId == br.Body.PlayerId)
                return
                    $"Body Report: This smells like a silly sheriff shot (Died {Math.Round(br.KillAge / 1000)}s ago)";

            var role = Role.GetRole(br.Killer);

            if (br.KillAge < CustomGameOptions.MysticRoleDuration * 1000)
                return
                    $"Body Report: The killer appears to be a {role.Name}! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            if (br.Killer.Is(Faction.Crewmates))
                return
                    $"Body Report: The killer's faction appears to be Crewmate! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            else if (br.Killer.Is(Faction.Neutral))
                return
                    $"Body Report: The killer's faction appears to be Neutral! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            else
                return
                    $"Body Report: The killer's faction appears to be Impostor! (Killed {Math.Round(br.KillAge / 1000)}s ago)";
        }
        public static string PlayerReportFeedback(PlayerControl player)
        {
            if (player.Is(RoleEnum.Glitch) || player.Is(RoleEnum.Imitator) || StartImitate.ImitatingPlayer == player
                 || player.Is(RoleEnum.Morphling) || player.Is(RoleEnum.Camouflager))
                return "Your target is one of these roles: The Glitch, Imitator, Morphling or Camouflager.";
            else if (player.Is(RoleEnum.Altruist) || player.Is(RoleEnum.Amnesiac) || player.Is(RoleEnum.Janitor)
                 || player.Is(RoleEnum.Medium) || player.Is(RoleEnum.Undertaker)|| player.Is(RoleEnum.Oracle))
                return "Your target is one of these roles: Undertaker, Altruist, Amnesiac, Oracle, Janitor, Medium or Cultist.";
            else if (player.Is(RoleEnum.Grenadier) || player.Is(RoleEnum.Guardian) || player.Is(RoleEnum.Medic)
                  || player.Is(RoleEnum.Veteran))
                return "Your target is one of these roles: Grenadier, Guardian, Medic or Veteran.";
            else if (player.Is(RoleEnum.Bomber) || player.Is(RoleEnum.Executioner) || player.Is(RoleEnum.Jester)
                 || player.Is(RoleEnum.Swapper) || player.Is(RoleEnum.Transporter))
                return "Your target is one of these roles: Bomber, Swapper, Executioner, Jester or Transporter.";
            else if (player.Is(RoleEnum.Silencer) || player.Is(RoleEnum.Mayor) || player.Is(RoleEnum.Informant)
                 || player.Is(RoleEnum.Swooper) || player.Is(RoleEnum.Trapper))
                return "Your target is one of these roles: Silencer, Trapper, Mayor, Informant, Swooper.";
            else if (player.Is(RoleEnum.Juggernaut) || player.Is(RoleEnum.Pestilence) || player.Is(RoleEnum.Sheriff)
                 || player.Is(RoleEnum.Werewolf))
                return "Your target is one of these roles: Juggernaut, Pestilence, Sheriff or Werewolf.";
            else if (player.Is(RoleEnum.Arsonist) || player.Is(RoleEnum.Plaguebearer)
                 || player.Is(RoleEnum.Snitch) || player.Is(RoleEnum.Tracker))
                return "Your target is one of these roles: Arsonist, Snitch, Tracker or Plaguebearer.";
            else if (player.Is(RoleEnum.Engineer)|| player.Is(RoleEnum.SerialKiller) || player.Is(RoleEnum.Escapist) || player.Is(RoleEnum.Miner))
                return "Your target likes exploring\nThey must be an Engineer, Escapist, Miner or Serial Killer.";
            else if (player.Is(RoleEnum.Crewmate) || player.Is(RoleEnum.Impostor))
                return "Your target is one of these roles: Impostor or Crewmate.";
            else
                return "Error";
        }
    }
}
