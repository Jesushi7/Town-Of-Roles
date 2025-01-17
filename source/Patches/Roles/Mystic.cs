using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;
using System;

namespace TownOfSushi.Roles
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
            ImpostorText = () => "<color=#4D99E6FF>Understand when and where kills happen with your arrows \nExamine players to find blood in their bodies.</color>";
            TaskText = () => "Find out where the kills are and who killed";
            Color = Patches.Colors.Mystic;
            RoleType = RoleEnum.Mystic;
            LastExamined = DateTime.UtcNow;            
            FactionName = "Crewmate";    
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