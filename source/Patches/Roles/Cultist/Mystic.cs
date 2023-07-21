namespace TownOfRoles.Roles.Cultist
{
    public class CultistMystic : Role
    {
        public CultistMystic(PlayerControl player) : base(player)
        {
            Name = "Mystic";
            StartText = () => "<color=#4D4DFFFF>Understand when someone gets converted</color>";
            TaskText = () => "Know when someone gets converted";
            Color = Patches.Colors.Mystic;
            RoleType = RoleEnum.CultistMystic;
            AddToRoleHistory(RoleType);
        }
    }
}