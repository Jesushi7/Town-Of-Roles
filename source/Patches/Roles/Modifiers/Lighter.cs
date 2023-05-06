using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Lighter : Modifier
    {
        public Lighter(PlayerControl player) : base(player)
        {
            Name = "Lighter";
            TaskText = () => "You Have Impostor Vision";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Lighter;
        }
    }
}