using System.Collections.Generic;
using UnityEngine;

namespace TownOfSushi.Roles
{
    public class Swapper : Role
    {
        public readonly List<GameObject> Buttons = new List<GameObject>();

        public readonly List<bool> ListOfActives = new List<bool>();


        public Swapper(PlayerControl player) : base(player)
        {
            Name = "Swapper";
            ImpostorText = () => "<color=#66E666FF>Swap the votes between two players \nand help the crewmates to win.</color>";
            TaskText = () => "Swap votes";
            FactionName = "Crewmate";
            Color = Patches.Colors.Swapper;
            RoleType = RoleEnum.Swapper;
            AddToRoleHistory(RoleType);
        }
    }
}