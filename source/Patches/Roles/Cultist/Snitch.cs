namespace TownOfSushi.Roles.Cultist
{
    public class CultistInformant : Role
    {
        public bool CompletedTasks;
        public PlayerControl RevealedPlayer;
        public CultistInformant(PlayerControl player) : base(player)
        {
            Name = "Informant";
            ImpostorText = () => "Complete All Your Tasks To Reveal An Impostor";
            TaskText = () => "Complete all your tasks to reveal an Impostor!";
            Color = Patches.Colors.Informant;
            RoleType = RoleEnum.CultistInformant;
            AddToRoleHistory(RoleType);
        }
    }
}