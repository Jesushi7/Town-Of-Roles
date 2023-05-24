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
            StartText = () => "Silence a player during meetings";
            TaskText = () => "Mute a player during meetings";
            Color = Patches.Colors.Impostor;
            LastSilenced = DateTime.UtcNow;
            RoleType = RoleEnum.Silencer;
            FactionName = "Impostor";     
                          
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