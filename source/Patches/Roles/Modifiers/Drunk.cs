using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Drunk : Modifier
    {
        public Drunk(PlayerControl player) : base(player)
        {
            Name = "Drunk";
            TaskText = () => "Your controls are inverted!";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Drunk;
        }
    }
}