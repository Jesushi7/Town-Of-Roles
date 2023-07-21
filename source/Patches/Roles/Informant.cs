using System.Collections.Generic;
using TownOfSushi.Extensions;
using UnityEngine;
using System.Linq;

namespace TownOfSushi.Roles
{
    public class Informant : Role
    {
        public List<ArrowBehaviour> ImpArrows = new List<ArrowBehaviour>();

        public Dictionary<byte, ArrowBehaviour> InformantArrows = new Dictionary<byte, ArrowBehaviour>();

        public Informant(PlayerControl player) : base(player)
        {
            Name = "Informant";
            ImpostorText = () => "<color=#D4AF37FF>Complete all of your tasks \nto find the killers and out them</color>";
            TaskText = () =>
                TasksDone
                    ? "Find the arrows pointing to the Killers!"
                    : "Finish your tasks";
                    FactionName = "Crewmate";                     
            Color = Patches.Colors.Informant;
            RoleType = RoleEnum.Informant;
            AddToRoleHistory(RoleType);
        }

        public bool Revealed => TasksLeft <= CustomGameOptions.InformantTasksRemaining;
        public bool TasksDone => TasksLeft <= 0;

        internal override bool Criteria()
        {
            return Revealed && PlayerControl.LocalPlayer.Data.IsImpostor() && !Player.Data.IsDead ||
                   base.Criteria();
        }

        internal override bool RoleCriteria()
        {
            var localPlayer = PlayerControl.LocalPlayer;
            if (localPlayer.Data.IsImpostor() && !Player.Data.IsDead)
            {
                return Revealed || base.RoleCriteria();
            }
            else if (GetRole(localPlayer).Faction == Faction.NeutralKilling && !Player.Data.IsDead)
            {
                return Revealed && CustomGameOptions.InformantSeesNeutrals || base.RoleCriteria();
            }
            return false || base.RoleCriteria();
        }

        public void DestroyArrow(byte targetPlayerId)
        {
            var arrow = InformantArrows.FirstOrDefault(x => x.Key == targetPlayerId);
            if (arrow.Value != null)
                Object.Destroy(arrow.Value);
            if (arrow.Value.gameObject != null)
                Object.Destroy(arrow.Value.gameObject);
            InformantArrows.Remove(arrow.Key);
        }
    }
}