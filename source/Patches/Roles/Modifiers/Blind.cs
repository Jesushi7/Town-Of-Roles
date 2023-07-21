using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Blind : Modifier
    {
        public Blind(PlayerControl player) : base(player)
        {
            Name = "Blind";
            TaskText = () => "Your report button does not light up";
            Color = Patches.Colors.Blind;
            ModifierType = ModifierEnum.Blind;
        }
    }
}