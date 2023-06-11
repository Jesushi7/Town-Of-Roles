using System;

namespace TownOfRoles.Roles
{
    public class Follower : Role
    {
        
        public Follower(PlayerControl player) : base(player)
        {
            Name = "Follower";
            StartText = () => "";    
            TaskText = () => "Follow your Cultist";                      
            FactionName = "Impostor";             
            Faction = Faction.Impostors;
            LastKill = DateTime.UtcNow;        
            RoleType = RoleEnum.Follower;
            AddToRoleHistory(RoleType);
            Color = Palette.ImpostorRed;
        }
        public DateTime LastKill { get; set; }        
        public float KillTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastKill;
            var num = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }        
    }
}