namespace TownOfSushi.Roles
{
    public class Altruist : Role
    {
        public bool CurrentlyReviving;
        public DeadBody CurrentTarget;

        public bool ReviveUsed;
        
        public Altruist(PlayerControl player) : base(player)
        {
            Name = "Altruist";
            ImpostorText = () => "<color=#660000FF>Find a dead body and sacrifice yourself to \nrevive somebody else and out the killers.</color>";
            TaskText = () => "Revive a dead body";
            FactionName = "Crewmate";                   
            Color = Patches.Colors.Altruist;
            RoleType = RoleEnum.Altruist;
            AddToRoleHistory(RoleType);
        }
    }
}