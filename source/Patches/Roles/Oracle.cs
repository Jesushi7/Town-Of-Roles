using System;

namespace TownOfSushi.Roles
{
    public class Oracle : Role
    {
        public PlayerControl ClosestPlayer;
        public PlayerControl Confessor;
        public float Accuracy;
        public bool FirstMeetingDead;
        public Faction RevealedFaction;
        public bool SavedConfessor;
        public DateTime LastConfessed { get; set; }

        public Oracle(PlayerControl player) : base(player)
        {
            Name = "Oracle";
            ImpostorText = () => "<color=#BF00BFFF>Make other players confess their sins \nwhen you die, you'll reveal someone's faction.</color>";
            TaskText = () => "Make a player confess";
            FactionName = "Crewmate";            
            Color = Patches.Colors.Oracle;
            LastConfessed = DateTime.UtcNow;
            Accuracy = CustomGameOptions.RevealAccuracy;
            FirstMeetingDead = true;
            FirstMeetingDead = false;
            RoleType = RoleEnum.Oracle;
            AddToRoleHistory(RoleType);
        }
        public float ConfessTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastConfessed;
            var num = CustomGameOptions.ConfessCd * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}