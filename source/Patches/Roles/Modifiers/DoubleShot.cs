namespace TownOfRoles.Roles.Modifiers
{
    public class DoubleShot : Modifier
    {
        public bool LifeUsed;
        public DoubleShot(PlayerControl player) : base(player)
        {
            Name = "Double Shot";
            TaskText = () => "You've got a second chance when guessing";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.DoubleShot;
            LifeUsed = false;
        }
    }
}