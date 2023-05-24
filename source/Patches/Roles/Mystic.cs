using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;
using System;

namespace TownOfRoles.Roles
{
    public class Mystic : Role
    {
        public PlayerControl ClosestPlayer;
        public PlayerControl LastExaminedPlayer;
        public DateTime LastExamined { get; set; }
        public Dictionary<byte, ArrowBehaviour> BodyArrows = new Dictionary<byte, ArrowBehaviour>();

        public Mystic(PlayerControl player) : base(player)
        {
            Name = "Mystic";
            StartText = () => "<color=#4D4DFFFF>Find out who killed and where the kills are</color>";
            TaskText = () => "Find out where there kills are and who killed";
            Color = Patches.Colors.Mystic;
            RoleType = RoleEnum.Mystic;
            LastExamined = DateTime.UtcNow;            
            FactionName = "<color=#00EEFFFF>Crewmate</color>";    
            Faction = Faction.Crewmates;               
            AddToRoleHistory(RoleType);
        }

        public void DestroyArrow(byte targetPlayerId)
        {
            var arrow = BodyArrows.FirstOrDefault(x => x.Key == targetPlayerId);
            if (arrow.Value != null)
                Object.Destroy(arrow.Value);
            if (arrow.Value.gameObject != null)
                Object.Destroy(arrow.Value.gameObject);
            BodyArrows.Remove(arrow.Key);
        }
        public float ExamineTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastExamined;
            var num = CustomGameOptions.ExamineCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }        
    }
}