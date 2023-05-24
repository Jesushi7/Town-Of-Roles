using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Diseased : Modifier
    {
        public Diseased(PlayerControl player) : base(player)
        {
            Name = "Diseased";
            TaskText = () => "When you die your killer will have long cooldown";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Diseased;     
        }
    }
}