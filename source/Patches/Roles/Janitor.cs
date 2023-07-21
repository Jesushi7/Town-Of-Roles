namespace TownOfSushi.Roles
{
    public class Janitor : Role
    {
        public KillButton _cleanButton;

        public Janitor(PlayerControl player) : base(player)
        {
            Name = "Janitor";
            ImpostorText = () => "Clean bodies to prevent Crewmates \nfrom discovering them.";
            TaskText = () => "Clean up bodies";
            FactionName = "Impostor";                   
            Color = Patches.Colors.Impostor;
            RoleType = RoleEnum.Janitor;
            AddToRoleHistory(RoleType);
        
            Faction = Faction.Impostors;
        }

        public DeadBody CurrentTarget { get; set; }

        public KillButton CleanButton
        {
            get => _cleanButton;
            set
            {
                _cleanButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }
    }
}