using System.Linq;
using HarmonyLib;
using Reactor.Utilities.Extensions;
using TownOfSushi.Extensions;
using TownOfSushi.Roles;

namespace TownOfSushi.CrewmateRoles.AvengerMod
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    public class UpdateArrows
    {
        public static void Postfix(PlayerControl __instance)
        {
            foreach (var role in Role.AllRoles.Where(x => x.RoleType == RoleEnum.Avenger))
            {
                var haunter = (Avenger)role;
                if (PlayerControl.LocalPlayer.Data.IsDead || haunter.Caught)
                {
                    haunter.AvengerArrows.DestroyAll();
                    haunter.AvengerArrows.Clear();
                    haunter.ImpArrows.DestroyAll();
                    haunter.ImpArrows.Clear();
                }

                foreach (var arrow in haunter.ImpArrows) arrow.target = haunter.Player.transform.position;

                foreach (var (arrow, target) in Utils.Zip(haunter.AvengerArrows, haunter.AvengerTargets))
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