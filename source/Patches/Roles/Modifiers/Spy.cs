using UnityEngine;
using System.Collections.Generic;

namespace TownOfSushi.Roles.Modifiers
{
    public class Spy : Modifier
    {
        public Spy(PlayerControl player) : base(player)
        {
            Name = "Spy";
            TaskText = () => "You can see colors on admin table";
            Color = Patches.Colors.Spy;
            ModifierType = ModifierEnum.Spy;
        }
    }
}