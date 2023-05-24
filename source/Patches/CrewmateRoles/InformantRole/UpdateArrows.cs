using System.Linq;
using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.InformantRole
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    public class UpdateArrows
    {
        public static void Postfix(PlayerControl __instance)
        {
            foreach (var role in Role.AllRoles.Where(x => x.RoleType == RoleEnum.Informant))
            {
                var Informant = (Informant)role;
                if (PlayerControl.LocalPlayer.Data.IsDead || Informant.Player.Data.IsDead)
                {
                    Informant.InformantArrows.Values.DestroyAll();
                    Informant.InformantArrows.Clear();
                    Informant.ImpArrows.DestroyAll();
                    Informant.ImpArrows.Clear();
                }

                foreach (var arrow in Informant.ImpArrows) arrow.target = Informant.Player.transform.position;

                foreach (var arrow in Informant.InformantArrows)
                {
                    var player = Utils.PlayerById(arrow.Key);
                    if (player == null || player.Data == null || player.Data.IsDead || player.Data.Disconnected)
                    {
                        Informant.DestroyArrow(arrow.Key);
                        continue;
                    }
                    arrow.Value.target = player.transform.position;
                }
            }
        }
    }
}