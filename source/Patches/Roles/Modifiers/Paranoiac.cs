using System.Collections.Generic;

namespace TownOfSushi.Roles.Modifiers
{
    public class Paranoiac : Modifier
    {
        public List<ArrowBehaviour> ParanoiacArrow = new List<ArrowBehaviour>();
        public PlayerControl ClosestPlayer;
        public Paranoiac(PlayerControl player) : base(player)
        {
            Name = "Paranoiac";
            TaskText = () => "Be on high alert";
            Color = Patches.Colors.Paranoiac;
            ModifierType = ModifierEnum.Paranoiac;
        }
    }
}