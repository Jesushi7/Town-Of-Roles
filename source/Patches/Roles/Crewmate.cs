
namespace TownOfRoles.Roles
{
    public class Crewmate : Role
    {
        public Crewmate(PlayerControl player) : base(player)
        {
            Name = "Crewmate";
            StartText = () => "<color=#00EEFFFF>Find The</color> <color=#FF0000FF>Impostors</color>";   
            TaskText = () => "Find the <color=#FF0000FF>Impostors</color>";                     
            RoleType = RoleEnum.Crewmate;
            FactionName = "<color=#00EEFFFF>Crewmate</color>";    
            Faction = Faction.Crewmates;              
            AddToRoleHistory(RoleType);
            Color = Patches.Colors.Crewmate;
        }
    }
}