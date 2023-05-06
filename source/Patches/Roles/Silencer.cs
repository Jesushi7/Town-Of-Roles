using System;

namespace TownOfRoles.Roles
{
    public class Silencer : Role
    {
        public KillButton _SilenceButton;
        
        public PlayerControl ClosestPlayer;
        public PlayerControl Silenced;
        public DateTime LastSilenced { get; set; }

        public Silencer(PlayerControl player) : base(player)
        {
            Name = "Silencer";
            StartText = () => "<color=#cf7b5f>Silence Crewmates During Meetings</color>";
            TaskText = () => "Mute a player for the next meeting";
            Color = Patches.Colors.Silencer;
            LastSilenced = DateTime.UtcNow;
            RoleType = RoleEnum.Silencer;
            FactionName = "<color=#cf7b5f>Impostor</color>";     
                          
            Faction = Faction.Impostors;            
            AddToRoleHistory(RoleType);
            Faction = Faction.Impostors;
        }

        public KillButton SilenceButton
        {
            get => _SilenceButton;
            set
            {
                _SilenceButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }
        public float SilenceTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastSilenced;
            var num = CustomGameOptions.SilenceCd * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}