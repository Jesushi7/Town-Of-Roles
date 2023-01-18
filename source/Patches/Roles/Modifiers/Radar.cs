using System.Collections.Generic;

namespace TownOfUs.Roles.Modifiers
{
    public class Radar : Modifier
    {
        public List<ArrowBehaviour> RadarArrow = new List<ArrowBehaviour>();
        public PlayerControl ClosestPlayer;
        public Radar(PlayerControl player) : base(player)
        {
            Name = "Paranoiac";
            TaskText = () => "Know if someone's near you";
            Color = Patches.Colors.Radar;
            ModifierType = ModifierEnum.Radar;
        }
    }
}