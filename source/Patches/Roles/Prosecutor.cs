namespace TownOfSushi.Roles
{
    public class Prosecutor : Role
    {
        public Prosecutor(PlayerControl player) : base(player)
        {
            Name = "Prosecutor";
            ImpostorText = () => "<color=#B38000FF>Exile someone that is suspicious</color>";
            TaskText = () => "Exile a player";
            FactionName = "Crewmate";             
            Color = Patches.Colors.Prosecutor;
            RoleType = RoleEnum.Prosecutor;
            AddToRoleHistory(RoleType);
            StartProsecute = false;
            Prosecuted = false;
            ProsecuteThisMeeting = false;
        }
        public bool ProsecuteThisMeeting { get; set; }
        public bool Prosecuted { get; set; }
        public bool StartProsecute { get; set; }
        public PlayerVoteArea Prosecute { get; set; }
    }
}
