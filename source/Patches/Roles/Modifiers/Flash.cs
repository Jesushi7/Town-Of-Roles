using TownOfRoles.Extensions;
using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Flash : Modifier, IVisualAlteration
    {

        public Flash(PlayerControl player) : base(player)
        {
            Name = "Flash";
            TaskText = () => "You're faster than others";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Flash;
        }

        public bool TryGetModifiedAppearance(out VisualAppearance appearance)
        {
            appearance = Player.GetDefaultAppearance();
            appearance.SpeedFactor = CustomGameOptions.FlashSpeed;
            return true;
        }
    }
}