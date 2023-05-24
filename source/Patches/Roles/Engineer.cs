using TMPro;

namespace TownOfRoles.Roles
{
    public class Engineer : Role
    {
        public Engineer(PlayerControl player) : base(player)
        {
            Name = "Engineer";
            StartText = () => "<color=#FFA60AFF>Mantain the ship and help the crew</color>";
            TaskText = () => "Vent around and fix sabotages";
            Color = Patches.Colors.Engineer;
            RoleType = RoleEnum.Engineer;
            FactionName = "<color=#00EEFFFF>Crewmate</color>";    
            Faction = Faction.Crewmates;               
            AddToRoleHistory(RoleType);
            UsesLeft = CustomGameOptions.MaxFixes;
        }

        public int UsesLeft;
        public TextMeshPro UsesText;

        public bool ButtonUsable => UsesLeft != 0;
    }
}