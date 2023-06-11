using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Tiebreaker : Modifier
    {
        public Tiebreaker(PlayerControl player) : base(player)
        {
            Name = "Tiebreaker";
            TaskText = () => "Break the tie";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Tiebreaker;
        }
    }
}