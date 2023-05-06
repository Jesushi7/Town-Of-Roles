using System;
using System.Collections.Generic;
using UnityEngine;

namespace TownOfRoles.Roles
{
    public class Miner : Role
    {
        public readonly List<Vent> Vents = new List<Vent>();

        public KillButton _mineButton;
        public DateTime LastMined;


        public Miner(PlayerControl player) : base(player)
        {
            Name = "Miner";
            StartText = () => "<color=#565c33>From The Top, Make It Drop, That's A Vent</color>";
            TaskText = () => "Create Vents";
            Color = Patches.Colors.Miner;
            LastMined = DateTime.UtcNow;
            RoleType = RoleEnum.Miner;
            FactionName = "<color=#565c33>Impostor</color>";   
                 
            Faction = Faction.Impostors;               
            AddToRoleHistory(RoleType);
            Faction = Faction.Impostors;
        }

        public bool CanPlace { get; set; }
        public Vector2 VentSize { get; set; }

        public KillButton MineButton
        {
            get => _mineButton;
            set
            {
                _mineButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public float MineTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastMined;
            var num = CustomGameOptions.MineCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}