using System;
using UnityEngine;
using TMPro;

namespace TownOfSushi.Roles
{
    public class Veteran : Role
    {
        public bool Enabled;
        public DateTime LastAlerted;
        public float TimeRemaining;

        public int UsesLeft;
        public TextMeshPro UsesText;

        public bool ButtonUsable => UsesLeft != 0;

        public Veteran(PlayerControl player) : base(player)
        {
            Name = "Veteran";
            ImpostorText = () => "<color=#998040FF>Alert to kill anyone who interacts \nwith you while your alert is on.</color>";
            TaskText = () => "Alert and Shoot";
            FactionName = "Crewmate";
            Color = Patches.Colors.Veteran;
            LastAlerted = DateTime.UtcNow;
            RoleType = RoleEnum.Veteran;
            AddToRoleHistory(RoleType);

            UsesLeft = CustomGameOptions.MaxAlerts;
        }

        public bool OnAlert => TimeRemaining > 0f;

        public float AlertTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastAlerted;
            ;
            var num = CustomGameOptions.AlertCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }

        public void Alert()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
        }


        public void UnAlert()
        {
            Enabled = false;
            LastAlerted = DateTime.UtcNow;
        }
    }
}