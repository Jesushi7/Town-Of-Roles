using System;
using TownOfSushi.CrewmateRoles.ImitatorMod;
using TownOfSushi.Roles;

namespace TownOfSushi.CrewmateRoles.MysticMod
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
                    $"Body Report: The {role.Name} has killed this body! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            if (br.Killer.Is(Faction.Crewmates))
                return
                    $"Body Report: The killer's faction appears to be Crewmate! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            else if (br.Killer.Is(Faction.NeutralKilling))
                return
                    $"Body Report: The killer appears to be a Neutral Killer! (Killed {Math.Round(br.KillAge / 1000)}s ago)";

            else
                return
                    $"Body Report: The killer's faction appears to be Impostor! (Killed {Math.Round(br.KillAge / 1000)}s ago)";
        }
        public static string PlayerReportFeedback(PlayerControl player)
        {
            if (player.Is(RoleEnum.Glitch) || player.Is(RoleEnum.Imitator) || StartImitate.ImitatingPlayer == player
                 || player.Is(RoleEnum.Morphling)|| player.Is(RoleEnum.Swooper)|| player.Is(RoleEnum.Venerer)|| player.Is(RoleEnum.Camouflager))
                return "Your target likes to change the way they look like.\nThey must be The Glitch, Venerer, Imitator, Camouflager, Morphling or Swooper.";
            else if (player.Is(RoleEnum.Altruist) || player.Is(RoleEnum.Amnesiac) || player.Is(RoleEnum.Janitor)
                 || player.Is(RoleEnum.Medium) || player.Is(RoleEnum.Undertaker)|| player.Is(RoleEnum.Oracle))
                return "Your target has an unusual obession with dead bodies.\nThey must be an Undertaker, Altruist, Amnesiac, Oracle, Janitor or Medium";
            else if (player.Is(RoleEnum.Grenadier) || player.Is(RoleEnum.GuardianAngel) || player.Is(RoleEnum.Medic)|| player.Is(RoleEnum.Survivor)
                  || player.Is(RoleEnum.Veteran))
                return "Your target is a protector of themselves or others.\nThey must be a Grenadier, Guardian Angel, Medic, Survivor or Veteran.";
            else if (player.Is(RoleEnum.Bomber) || player.Is(RoleEnum.Executioner) || player.Is(RoleEnum.Jester)
                 || player.Is(RoleEnum.Swapper) || player.Is(RoleEnum.Transporter)|| player.Is(RoleEnum.Prosecutor))
                return "Your target likes to make chaos.\nThey must be a Bomber, Prosecutor, Swapper, Executioner, Jester or Transporter.";
            else if (player.Is(RoleEnum.Blackmailer) || player.Is(RoleEnum.Mayor) || player.Is(RoleEnum.Informant)
                 || player.Is(RoleEnum.Trapper)|| player.Is(RoleEnum.Doomsayer)|| player.Is(RoleEnum.Aurial)|| player.Is(RoleEnum.Monarch))
                return "Your target can have a lot of information.\nThey must be a Blackmailer, Doomsasyer, Trapper, Mayor, Aurial, Monarch, Informant, Swooper.";
            else if (player.Is(RoleEnum.Juggernaut) || player.Is(RoleEnum.Pestilence) || player.Is(RoleEnum.Sheriff)
                 || player.Is(RoleEnum.Werewolf)|| player.Is(RoleEnum.Vampire)|| player.Is(RoleEnum.Warlock)|| player.Is(RoleEnum.VampireHunter))
                return "Your target is known for killing a lot.\nThey must be a Vampire Hunter, Warlock, Juggernaut, Vampire, Pestilence, Sheriff or Werewolf.";
            else if (player.Is(RoleEnum.Arsonist) || player.Is(RoleEnum.Plaguebearer)
                 || player.Is(RoleEnum.Snitch) || player.Is(RoleEnum.Tracker))
                return "Your target enjoys to interact with others.\nThey must be an Arsonist, Snitch, Tracker or Plaguebearer.";
            else if (player.Is(RoleEnum.Engineer)|| player.Is(RoleEnum.Escapist) || player.Is(RoleEnum.Miner))
                return "Your target likes exploring.\nThey must be an Engineer, Escapist or Miner";
            else if (player.Is(RoleEnum.Crewmate) || player.Is(RoleEnum.Impostor))
                return "Your target appears to be roleless.\nThey must be an Impostor or Crewmate.";
            else
                return "Error";
        }
    }
}
