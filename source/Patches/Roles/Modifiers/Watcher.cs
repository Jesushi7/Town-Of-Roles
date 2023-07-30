using UnityEngine;

namespace TownOfSushi.Roles.Modifiers
{
    public class Watcher : Modifier
    {
        public Watcher(PlayerControl player) : base(player)
        {
            Name = "Watcher";
            TaskText = () => "You can see all votes";
            Color = Patches.Colors.Watcher;
            ModifierType = ModifierEnum.Watcher;
        }
    }
}