using UnityEngine;

namespace TownOfSushi.Roles.Modifiers
{
    public class Lighter : Modifier
    {
        public Lighter(PlayerControl player) : base(player)
        {
            Name = "Lighter";
            TaskText = () => "You Have Impostor Vision";
            Color = Patches.Colors.Lighter;
            ModifierType = ModifierEnum.Lighter;
        }
    }
}