using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;

namespace TownOfSushi.Roles
{
    public class Amnesiac : Role
    {
        public Dictionary<byte, ArrowBehaviour> BodyArrows = new Dictionary<byte, ArrowBehaviour>();
        public bool SpawnedAs = true;

        public Amnesiac(PlayerControl player) : base(player)
        {
            Name = "Amnesiac";
            ImpostorText = () => "<color=#80B2FFFF>Find a dead bodie to remember a new role.</color>";
            TaskText = () => SpawnedAs ? "Remember a role" : "Your target has died. Now remember a new role!";
            FactionName = "<color=#5c5e5d>Neutral</color>";                   
            Color = Patches.Colors.Amnesiac;
            RoleType = RoleEnum.Amnesiac;
            AddToRoleHistory(RoleType);
            Faction = Faction.NeutralBenign;
        }

        public DeadBody CurrentTarget;

        protected override void IntroPrefix(IntroCutscene._ShowTeam_d__36 __instance)
        {
            var amnesiacTeam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
            amnesiacTeam.Add(PlayerControl.LocalPlayer);
            __instance.teamToShow = amnesiacTeam;
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
    }
}