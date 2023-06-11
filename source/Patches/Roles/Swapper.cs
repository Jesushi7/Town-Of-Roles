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
            StartText = () => "<color=#863756>Swap The Votes Of Two People</color>";
            TaskText = () => "Swap votes";
            Color = Patches.Colors.Swapper;
            FactionName = "Crewmate";               
            RoleType = RoleEnum.Swapper;
            AddToRoleHistory(RoleType);
        }
    }
}