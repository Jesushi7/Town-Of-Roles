using System;
using System.Collections.Generic;
using UnityEngine;

namespace TownOfSushi.Roles
{
    public class Miner : Role
    {
        public readonly List<Vent> Vents = new List<Vent>();

        public KillButton _mineButton;
        public DateTime LastMined;


        public Miner(PlayerControl player) : base(player)
        {
            Name = "Miner";
            ImpostorText = () => "Create a new network of vents \nto move faster around the map";
            TaskText = () => "Create Vents";
            FactionName = "Impostor";                   
            Color = Patches.Colors.Impostor;
            LastMined = DateTime.UtcNow;
            RoleType = RoleEnum.Miner;
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