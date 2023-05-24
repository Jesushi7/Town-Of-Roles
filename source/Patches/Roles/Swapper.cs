using System.Collections.Generic;
using UnityEngine;

namespace TownOfRoles.Roles
{
    public class Swapper : Role
    {
        public readonly List<GameObject> Buttons = new List<GameObject>();

        public readonly List<bool> ListOfActives = new List<bool>();


        public Swapper(PlayerControl player) : base(player)
        {
            Name = "Swapper";
            StartText = () => "<color=#863756>Swap the votes between two players</color>";
            TaskText = () => "Swap votes";
            Color = Patches.Colors.Swapper;
            FactionName = "<color=#00EEFFFF>Crewmate</color>";               
            RoleType = RoleEnum.Swapper;
            AddToRoleHistory(RoleType);
        }
    }
}