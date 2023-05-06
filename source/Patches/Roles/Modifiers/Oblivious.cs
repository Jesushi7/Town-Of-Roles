using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Oblivious : Modifier
    {
        public Oblivious(PlayerControl player) : base(player)
        {
            Name = "Oblivious";
            TaskText = () => "You don't have a report button";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Oblivious;
        }
    }
}