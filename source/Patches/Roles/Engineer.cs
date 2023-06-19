using TMPro;

namespace TownOfRoles.Roles
{
    public class Engineer : Role
    {
        public Engineer(PlayerControl player) : base(player)
        {
            Name = "Engineer";
            StartText = () => "<color=#FFA60AFF>Maintain important systems on the ship</color>";
            TaskText = () => CustomGameOptions.GameMode == GameMode.Cultist ? "Vent around" : "Vent and fix sabotages";
            Color = Patches.Colors.Engineer;
            RoleType = RoleEnum.Engineer;
            FactionName = "Crewmate";    
            Faction = Faction.Crewmates;               
            AddToRoleHistory(RoleType);
            UsesLeft = CustomGameOptions.MaxFixes;
        }

        public int UsesLeft;
        public TextMeshPro UsesText;

        public bool ButtonUsable => UsesLeft != 0;
    }
}