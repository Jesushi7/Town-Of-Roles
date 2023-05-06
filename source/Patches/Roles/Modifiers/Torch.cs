using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Torch : Modifier
    {
        public Torch(PlayerControl player) : base(player)
        {
            Name = "Torch";
            TaskText = () => "You can see in the dark";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Torch;
        }
    }
}