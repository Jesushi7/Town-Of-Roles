using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Watcher : Modifier
    {
        public Watcher(PlayerControl player) : base(player)
        {
            Name = "Watcher";
            TaskText = () => "You can see anonymous votes";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Watcher;
        }
    }
}