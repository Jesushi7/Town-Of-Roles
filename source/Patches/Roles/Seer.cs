using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;

namespace TownOfRoles.Roles
{
    public class Seer : Role
    {
        public Dictionary<byte, ArrowBehaviour> BodyArrows = new Dictionary<byte, ArrowBehaviour>();
        public Seer(PlayerControl player) : base(player)
        {
            Name = "Seer";
            StartText = () => "Understand When And Where Kills Happen";
            TaskText = () => "Know When and Where Kills Happen";
            Color = Patches.Colors.Mystic;
            RoleType = RoleEnum.Seer;
            AddToRoleHistory(RoleType);
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