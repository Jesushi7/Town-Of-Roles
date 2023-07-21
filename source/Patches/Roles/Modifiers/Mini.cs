using TownOfRoles.Extensions;
using UnityEngine;

namespace TownOfRoles.Roles.Modifiers
{
    public class Mini : Modifier, IVisualAlteration
    {
        public Mini(PlayerControl player) : base(player)
        {
            Name = "Mini";
            TaskText = () => "You are tiny";
            Color = Patches.Colors.Mini;
            ModifierType = ModifierEnum.Mini;
        }

        public bool TryGetModifiedAppearance(out VisualAppearance appearance)
        {
            appearance = Player.GetDefaultAppearance();
            appearance.SpeedFactor = CustomGameOptions.MiniSpeed;            
            appearance.SizeFactor = new Vector3(CustomGameOptions.MiniSize, CustomGameOptions.MiniSize, CustomGameOptions.MiniSize);
            return true;
        }
    }
}