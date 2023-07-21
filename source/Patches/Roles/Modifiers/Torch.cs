using UnityEngine;

namespace TownOfSushi.Roles.Modifiers
{
    public class Nightowl : Modifier
    {
        public Nightowl(PlayerControl player) : base(player)
        {
            Name = "Nightowl";
            TaskText = () => "You can see in the dark";
            Color = Patches.Colors.Nightowl;
            ModifierType = ModifierEnum.Nightowl;
        }
    }
}