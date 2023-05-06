using System.Collections.Generic;
using UnityEngine;

namespace TownOfRoles.Roles
{
    public class Imitator : Role
    {
        public readonly List<GameObject> Buttons = new List<GameObject>();

        public readonly List<bool> ListOfActives = new List<bool>();
        public PlayerControl ImitatePlayer = null;

        public PlayerControl LastExaminedPlayer = null;
        public List<RoleEnum> trappedPlayers = null;


        public Imitator(PlayerControl player) : base(player)
        {
            Name = "Imitator";
            StartText = () => "<color=#B3D94DFF>Copy Dead People's Role</color>";
            TaskText = () => "Use dead roles to benefit the crew";
            Color = Patches.Colors.Imitator;
            FactionName = "<color=#B3D94DFF>Crewmate</color>";              
            RoleType = RoleEnum.Imitator;
            AddToRoleHistory(RoleType);
        }
    }
}