namespace TownOfRoles.Roles
{
    public class Janitor : Role
    {
        public KillButton _cleanButton;

        public Janitor(PlayerControl player) : base(player)
        {
            Name = "Janitor";
            StartText = () => "<color=#d68185>Clean Up Bodies</color>";
            TaskText = () => "Clean and hide bodies";
            Color = Patches.Colors.Janitor;
            RoleType = RoleEnum.Janitor;
            AddToRoleHistory(RoleType);
            FactionName = "Impostor";               
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