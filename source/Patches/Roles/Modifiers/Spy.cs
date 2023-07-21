using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Spy : Modifier
    {
        public Spy(PlayerControl player) : base(player)
        {
            Name = "Spy";
            TaskText = () => "You can see colors in Admin Table";
            Color = Patches.Colors.Spy;
            ModifierType = ModifierEnum.Spy;
        }
    }
}