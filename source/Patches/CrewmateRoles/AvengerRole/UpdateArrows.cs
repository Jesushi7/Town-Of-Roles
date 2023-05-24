using System.Linq;
using HarmonyLib;
using Reactor.Utilities.Extensions;
using TownOfRoles.Extensions;
using TownOfRoles.Roles;

namespace TownOfRoles.CrewmateRoles.AvengerRole
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    public class UpdateArrows
    {
        public static void Postfix(PlayerControl __instance)
        {
            foreach (var role in Role.AllRoles.Where(x => x.RoleType == RoleEnum.Avenger))
            {
                var Avenger = (Avenger)role;
                if (PlayerControl.LocalPlayer.Data.IsDead || Avenger.Caught)
                {
                    Avenger.AvengerArrows.DestroyAll();
                    Avenger.AvengerArrows.Clear();
                    Avenger.ImpArrows.DestroyAll();
                    Avenger.ImpArrows.Clear();
                }

                foreach (var arrow in Avenger.ImpArrows) arrow.target = Avenger.Player.transform.position;

                foreach (var (arrow, target) in Utils.Zip(Avenger.AvengerArrows, Avenger.AvengerTargets))
                {
                    if (target.Data.IsDead)
                    {
                        arrow.Destroy();
                        if (arrow.gameObject != null) arrow.gameObject.Destroy();
                    }

                    arrow.target = target.transform.position;
                }
            }
        }
    }
}