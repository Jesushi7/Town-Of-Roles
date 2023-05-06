
namespace TownOfRoles.Roles
{
    public class Impostor : Role
    {
        public Impostor(PlayerControl player) : base(player)
        {
            Name = "Impostor";
            StartText = () => "Kill The <color=#00EEFFFF>Crewmates</color>";    
            TaskText = () => "Find and kill the <color=#00EEFFFF>Crewmates</color>";                      
            FactionName = "Impostor";             
            Faction = Faction.Impostors;
            RoleType = RoleEnum.Impostor;
            AddToRoleHistory(RoleType);
            Color = Palette.ImpostorRed;
        }
    }
}