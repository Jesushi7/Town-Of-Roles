using System.Collections.Generic;

namespace TownOfRoles.Roles
{
    public class Mayor : Role
    {
        public List<byte> ExtraVotes = new List<byte>();

        public Mayor(PlayerControl player) : base(player)
        {
            Name = "Mayor";
            StartText = () => "<color=#704FA8FF>Save Your Votes To Vote Multiple Times</color>";
            TaskText = () => "Save your votes to Mayor dump someone";
            Color = Patches.Colors.Mayor;
            RoleType = RoleEnum.Mayor;
            FactionName = "<color=#704FA8FF>Crewmate</color>";    
            Faction = Faction.Crewmates;               
            AddToRoleHistory(RoleType);
            VoteBank = CustomGameOptions.MayorVoteBank;
        }

        public int VoteBank { get; set; }
        public bool SelfVote { get; set; }

        public bool VotedOnce { get; set; }

        public PlayerVoteArea Abstain { get; set; }

        public bool CanVote => VoteBank > 0 && !SelfVote;
    }
}