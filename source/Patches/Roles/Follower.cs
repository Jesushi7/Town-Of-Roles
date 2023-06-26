using System;

namespace TownOfRoles.Roles
{
    public class Follower : Role
    {
        public DateTime LastKilled;        
        
        public Follower(PlayerControl player) : base(player)
        {
            Name = "Follower";
            StartText = () => "";    
            TaskText = () => "Follow your Cultist";                      
            FactionName = "Impostor";             
            Faction = Faction.Impostors;
            LastKilled = DateTime.UtcNow;        
            RoleType = RoleEnum.Follower;
            AddToRoleHistory(RoleType);
            Color = Palette.ImpostorRed;
        }   
        public float KillTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastKilled;
            var num = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }        
    }
}