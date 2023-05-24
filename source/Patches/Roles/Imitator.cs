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
            StartText = () => "<color=#B3D94DFF>Copy dead people's role</color>";
            TaskText = () => "Imitate roles";
            Color = Patches.Colors.Imitator;
            FactionName = "<color=#00EEFFFF>Crewmate</color>";              
            RoleType = RoleEnum.Imitator;
            AddToRoleHistory(RoleType);
        }
    }
}