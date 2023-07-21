using System;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;

namespace TownOfSushi.Roles
{
    public class Detective : Role
    {
        public Dictionary<byte, ArrowBehaviour> BodyArrows = new Dictionary<byte, ArrowBehaviour>();        
        private KillButton _examineButton;
        public PlayerControl ClosestPlayer;
        public DateTime LastExamined { get; set; }
        public DeadBody CurrentTarget;
        public bool ExamineMode = false;
        public PlayerControl DetectedKiller;

        public Detective(PlayerControl player) : base(player)
        {
            Name = "Detective";
            ImpostorText = () => "<color=#4D4DFFFF>Find a body then examine players to find blood \nYou may also Report bodies to gain information.</color>";
            TaskText = () => "Examine suspicious players";
            FactionName = "Crewmate";                   
            Color = Patches.Colors.Detective;
            LastExamined = DateTime.UtcNow;
            RoleType = RoleEnum.Detective;
            AddToRoleHistory(RoleType);
        }

        public KillButton ExamineButton
        {
            get => _examineButton;
            set
            {
                _examineButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
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
            var num = CustomGameOptions.DetExamineCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}