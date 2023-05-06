using TMPro;

namespace TownOfRoles.Roles
{
    public class Engineer : Role
    {
        public Engineer(PlayerControl player) : base(player)
        {
            Name = "Engineer";
            StartText = () => "<color=#FFA60AFF>Maintain Important Systems On The Ship</color>";
            TaskText = () => CustomGameOptions.GameMode == GameMode.Cultist ? "Vent around" : "Vent and fix sabotages around the map";
            Color = Patches.Colors.Engineer;
            RoleType = RoleEnum.Engineer;
            FactionName = "<color=#FFA60AFF>Crewmate</color>";    
            Faction = Faction.Crewmates;               
            AddToRoleHistory(RoleType);
            UsesLeft = CustomGameOptions.MaxFixes;
        }

        public int UsesLeft;
        public TextMeshPro UsesText;

        public bool ButtonUsable => UsesLeft != 0;
    }
}