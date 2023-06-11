
namespace TownOfRoles.Roles
{
    public class Crewmate : Role
    {
        public Crewmate(PlayerControl player) : base(player)
        {
            Name = "Crewmate";
            StartText = () => "Find the <color=#FF0000FF>Impostors</color>";   
            TaskText = () => "Find the <color=#FF0000FF>Impostors</color>";                     
            RoleType = RoleEnum.Crewmate;
            FactionName = "Crewmate";    
            Faction = Faction.Crewmates;              
            AddToRoleHistory(RoleType);
            Color = Patches.Colors.Crewmate;
        }
    }
}