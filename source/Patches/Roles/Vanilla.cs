using UnityEngine;

namespace TownOfSushi.Roles
{
    public class Impostor : Role
    {
        public Impostor(PlayerControl player) : base(player)
        {
            Name = "Impostor";
            ImpostorText = () => "Kill everyone to win";
            ImpostorText = () => "Kill all the <color=#8cffff>Crewmates</color>";
            FactionName = "Impostor";
            
            Faction = Faction.Impostors;
            RoleType = RoleEnum.Impostor;
            AddToRoleHistory(RoleType);
            Color = Palette.ImpostorRed;
        }
    }

    public class Crewmate : Role
    {
        public Crewmate(PlayerControl player) : base(player)
        {
            Name = "Crewmate";
            ImpostorText = () => "Find the <color=#FF0000FF>Impostors</color>";
            TaskText = () => "Find the <color=#FF0000FF>Impostors</color>"; 
            FactionName = "Crewmate";
            Faction = Faction.Crewmates;
            RoleType = RoleEnum.Crewmate;
            AddToRoleHistory(RoleType);
            Color = Patches.Colors.Crewmate;
        }
    }
}