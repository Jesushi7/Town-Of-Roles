using System.Collections.Generic;

namespace TownOfRoles.Roles.Modifiers
{
    public class Paranoiac : Modifier
    {
        public List<ArrowBehaviour> ParanoiacArrow = new List<ArrowBehaviour>();
        public PlayerControl ClosestPlayer;
        public Paranoiac(PlayerControl player) : base(player)
        {
            Name = "Paranoiac";
            TaskText = () => "See when someone is close to you";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.Paranoiac;
        }
    }
}