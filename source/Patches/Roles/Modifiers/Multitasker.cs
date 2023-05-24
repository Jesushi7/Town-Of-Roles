using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Multitasker : Modifier
    {
        public Multitasker(PlayerControl player) : base(player)
        {
            Name = "Multitasker";
            TaskText = () => "Your tasks are transparent";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Multitasker;
        }
    }
}