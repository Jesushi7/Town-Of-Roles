using System.Collections;
using UnityEngine;

namespace TownOfRoles.Roles
{
    public class Altruist : Role
    {
        public bool CurrentlyReviving;
        public DeadBody CurrentTarget;
        public static ArrowBehaviour Arrow;
        public static PlayerControl Target;        
        public bool ReviveUsed;
        
        public Altruist(PlayerControl player) : base(player)
        {
            Name = "Altruist";
            StartText = () => "<color=#2d6aa5>Sacrifice Yourself To Save Another</color>";
            TaskText = () => "Help the crew by reviving someone \nat the cost of your life";
            Color = Patches.Colors.Altruist;
            FactionName = "<color=#2d6aa5>Crewmate</color>";    
            Faction = Faction.Crewmates;               
            RoleType = RoleEnum.Altruist;
            AddToRoleHistory(RoleType);
        }
        public static IEnumerator Revive(DeadBody target, Altruist role)
        {        
            if (PlayerControl.LocalPlayer.Is(Faction.Impostors) || PlayerControl.LocalPlayer.Is(Faction.Neutral))
            {
                var gameObj = new GameObject();
                Arrow = gameObj.AddComponent<ArrowBehaviour>();
                gameObj.transform.parent = PlayerControl.LocalPlayer.gameObject.transform;
                var renderer = gameObj.AddComponent<SpriteRenderer>();
                Arrow.image = renderer;
                gameObj.layer = 5;
                //Target = player;
                yield return Utils.FlashCoro(role.Color, "Someone has been revived!");
            }    
        }    
    }
}