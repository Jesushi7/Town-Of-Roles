using System.Collections.Generic;
using UnityEngine;

namespace TownOfSushi.Roles
{
    public class Imitator : Role
    {
        public readonly List<GameObject> Buttons = new List<GameObject>();

        public readonly List<bool> ListOfActives = new List<bool>();
        public PlayerControl ImitatePlayer = null;

        public List<RoleEnum> trappedPlayers = null;
        public PlayerControl confessingPlayer = null;


        public Imitator(PlayerControl player) : base(player)
        {
            Name = "Imitator";
            ImpostorText = () => "<color=#B3D94DFF>Use the abilities of whoever \ndies to help people.</color>";
            TaskText = () => "Use dead roles to benefit the crew";
            FactionName = "Crewmate";                   
            Color = Patches.Colors.Imitator;
            RoleType = RoleEnum.Imitator;
            AddToRoleHistory(RoleType);
        }
    }
}