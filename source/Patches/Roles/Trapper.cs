using Reactor.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using TownOfSushi.CrewmateRoles.TrapperMod;
using UnityEngine;

namespace TownOfSushi.Roles
{
    public class Trapper : Role
    {
        public static Material trapMaterial = TownOfSushi.bundledAssets.Get<Material>("trap");

        public List<Trap> traps = new List<Trap>();
        public DateTime LastTrapped { get; set; }
        public int UsesLeft;
        public TextMeshPro UsesText;

        public List<RoleEnum> trappedPlayers;

        public bool ButtonUsable => UsesLeft != 0;
        public Trapper(PlayerControl player) : base(player)
        {
            Name = "Trapper";
            ImpostorText = () => "<color=#A7D1B3FF>Create traps to get a list of the roles\n of the players that go into your trap</color>";
            TaskText = () => "Place traps around the map";
            FactionName = "Crewmate";
            Color = Patches.Colors.Trapper;
            RoleType = RoleEnum.Trapper;
            LastTrapped = DateTime.UtcNow;
            trappedPlayers = new List<RoleEnum>();
            AddToRoleHistory(RoleType);

            UsesLeft = CustomGameOptions.MaxTraps;
        }

        public float TrapTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastTrapped;
            var num = CustomGameOptions.TrapCooldown * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}
