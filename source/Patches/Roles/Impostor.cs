
namespace TownOfRoles.Roles
{
    public class Impostor : Role
    {
        public Impostor(PlayerControl player) : base(player)
        {
            Name = "Impostor";
            StartText = () => "Kill the <color=#8cffff>Crewmates</color>";    
            TaskText = () => "Find and kill the <color=#8cffff>Crewmates</color>";                      
            FactionName = "Impostor";             
            Faction = Faction.Impostors;
            RoleType = RoleEnum.Impostor;
            AddToRoleHistory(RoleType);
            Color = Palette.ImpostorRed;
        }
    }
}