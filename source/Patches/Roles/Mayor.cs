using System.Collections.Generic;

namespace TownOfRoles.Roles
{
    public class Mayor : Role
    {
        public List<byte> ExtraVotes = new List<byte>();

        public Mayor(PlayerControl player) : base(player)
        {
            Name = "Mayor";
            StartText = () => "<color=#704FA8FF>Safe your votes to vote multiple times</color>";
            TaskText = () => $"You have {VoteBank} votes left";
            Color = Patches.Colors.Mayor;
            RoleType = RoleEnum.Mayor;
            FactionName = "<color=#00EEFFFF>Crewmate</color>";    
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