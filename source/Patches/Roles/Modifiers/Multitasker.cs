using UnityEngine;

namespace TownOfSushi.Roles.Modifiers
{
    public class Multitasker : Modifier
    {
        public Multitasker(PlayerControl player) : base(player)
        {
            Name = "Multitasker";
            TaskText = () => "Your task windows are transparent";
            Color = Patches.Colors.Multitasker;
            ModifierType = ModifierEnum.Multitasker;
        }
    }
}