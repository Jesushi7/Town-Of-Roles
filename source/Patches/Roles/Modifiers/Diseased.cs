using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Diseased : Modifier
    {
        public Diseased(PlayerControl player) : base(player)
        {
            Name = "Diseased";
            TaskText = () => "Killing you gives your killer a high kill cooldown";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Diseased;     
        }
    }
}