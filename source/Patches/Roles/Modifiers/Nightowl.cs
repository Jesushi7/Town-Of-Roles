using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Nightowl : Modifier
    {
        public Nightowl(PlayerControl player) : base(player)
        {
            Name = "Nightowl";
            TaskText = () => "You can see in the dark";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Nightowl;
        }
    }
}