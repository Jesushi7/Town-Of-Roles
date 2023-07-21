using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class VIP : Modifier
    {
        public VIP(PlayerControl player) : base(player)
        {
            Name = "VIP";
            TaskText = () => "Everyone knows where and when you die";
            Color = Patches.Colors.VIP;
            ModifierType = ModifierEnum.Watcher;
        }
    }
}