using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Bait : Modifier
    {
        public Bait(PlayerControl player) : base(player)
        {
            Name = "Bait";
            TaskText = () => "Killing you causes a self-report";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Bait;
        }
    }
}