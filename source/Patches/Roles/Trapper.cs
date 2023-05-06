﻿using Reactor.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using TownOfRoles.CrewmateRoles.TrapperMod;
using UnityEngine;

namespace TownOfRoles.Roles
{
    public class Trapper : Role
    {
        public static AssetBundle bundle = loadBundle();
        public static Material trapMaterial = bundle.LoadAsset<Material>("trap").DontUnload();

        public List<Trap> traps = new List<Trap>();
        public DateTime LastTrapped { get; set; }
        public int UsesLeft;
        public TextMeshPro UsesText;

        public List<RoleEnum> trappedPlayers;

        public bool ButtonUsable => UsesLeft != 0;
        public Trapper(PlayerControl player) : base(player)
        {
            Name = "Trapper";
            StartText = () => "<color=#75fa4c>Place Traps To Know Roles</color>";
            TaskText = () => "Place traps";
            Color = Patches.Colors.Trapper;
            RoleType = RoleEnum.Trapper;
            FactionName = "<color=#75fa4c>Crewmate</color>";    
            Faction = Faction.Crewmates;               
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


        public static AssetBundle loadBundle()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("TownOfRoles.Resources.trappershader");
            var assets = stream.ReadFully();
            return AssetBundle.LoadFromMemory(assets);
        }
    }
}
