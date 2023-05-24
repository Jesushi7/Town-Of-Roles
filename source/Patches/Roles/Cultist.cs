using System;

namespace TownOfRoles.Roles.Cultist
{
    public class Cultist : Role
    {
        public DeadBody CurrentTarget;
        public KillButton _reviveButton;
        public int UsesLeft;        
        public DateTime LastRevived;
        public int ReviveCount;
        public bool ButtonUsable => UsesLeft != 0;
        public Cultist(PlayerControl player) : base(player)
        {
            Name = "Cultist";
            StartText = () => "Get players to follow you";
            TaskText = () => "Requit Players";
            Color = Patches.Colors.Impostor;
            FactionName = "Impostor";               
            LastRevived = DateTime.UtcNow;
            RoleType = RoleEnum.Cultist;
            AddToRoleHistory(RoleType);
            Faction = Faction.Impostors;       
        }

        public KillButton ReviveButton
        {
            get => _reviveButton;
            set
            {
                _reviveButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public float ReviveTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastRevived;
            var num = (CustomGameOptions.ReviveCooldown2 + CustomGameOptions.IncreasedCooldownPerRevive2 * ReviveCount) * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}