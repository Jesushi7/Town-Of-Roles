using System;
using UnityEngine;
using Reactor.Utilities;
using System.Collections.Generic;

namespace TownOfRoles.Roles
{
    public class Medium : Role
    {
        public DateTime LastMediated { get; set; }

        public Dictionary<byte, ArrowBehaviour> MediatedPlayers = new Dictionary<byte, ArrowBehaviour>();
        
        public static Sprite Arrow => TownOfRoles.Arrow;
        
        public Medium(PlayerControl player) : base(player)
        {
            Name = "Medium";
            StartText = () => "<color=#A680FFFF>Watch the spooky ghosts</color>";
            TaskText = () => "Follow ghosts";
            Color = Patches.Colors.Medium;
            LastMediated = DateTime.UtcNow;
            RoleType = RoleEnum.Medium;
            FactionName = "Crewmate";    
            Faction = Faction.Crewmates;               
            AddToRoleHistory(RoleType);
            Scale = 1.4f;
            MediatedPlayers = new Dictionary<byte, ArrowBehaviour>();
        }

        internal override bool RoleCriteria()
        {
            return (MediatedPlayers.ContainsKey(PlayerControl.LocalPlayer.PlayerId) && CustomGameOptions.ShowMediumToDead) || base.RoleCriteria();
        }

        public float MediateTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastMediated;
            var num = CustomGameOptions.MediateCooldown * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }

        public void AddMediatePlayer(byte playerId)
        {
            var gameObj = new GameObject();
            var arrow = gameObj.AddComponent<ArrowBehaviour>();
            if (Player.PlayerId == PlayerControl.LocalPlayer.PlayerId || CustomGameOptions.ShowMediumToDead)
            {
                gameObj.transform.parent = PlayerControl.LocalPlayer.gameObject.transform;
                var renderer = gameObj.AddComponent<SpriteRenderer>();
                renderer.sprite = Arrow;
                arrow.image = renderer;
                gameObj.layer = 5;
                arrow.target = Utils.PlayerById(playerId).transform.position;
            }
            MediatedPlayers.Add(playerId, arrow);
            Coroutines.Start(Utils.FlashCoroutine(Color));
        }
    }
}