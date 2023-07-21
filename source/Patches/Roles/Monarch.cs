using UnityEngine;

namespace TownOfSushi.Roles
{
    public class Monarch : Role
    {
        public Monarch(PlayerControl player) : base(player)
        {
            Name = "Monarch";
            ImpostorText = () => "<color=#704FA8FF>Reveal your role to others \nand also gain 3 votes but less vision.</color>";
            TaskText = () => "Reveal yourself when the time is right";
            Color = Patches.Colors.Monarch;
            FactionName = "Crewmate";                   
            RoleType = RoleEnum.Monarch;
            AddToRoleHistory(RoleType);
            Revealed = false;
        }
        public bool Revealed { get; set; }

        public GameObject RevealButton = new GameObject();

        internal override bool Criteria()
        {
            return Revealed && !Player.Data.IsDead || base.Criteria();
        }

        internal override bool RoleCriteria()
        {
            if (!Player.Data.IsDead) return Revealed || base.RoleCriteria();
            return false || base.RoleCriteria();
        }
    }
}