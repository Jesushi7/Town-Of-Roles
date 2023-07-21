using System.Linq;
using HarmonyLib;
using TownOfSushi.Roles;

namespace TownOfSushi.CrewmateRoles.InformantMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class UpdateArrows
    {
        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;

            foreach (var role in Role.AllRoles.Where(x => x.RoleType == RoleEnum.Informant))
            {
                var snitch = (Informant)role;
                if (PlayerControl.LocalPlayer.Data.IsDead || snitch.Player.Data.IsDead)
                {
                    snitch.InformantArrows.Values.DestroyAll();
                    snitch.InformantArrows.Clear();
                    snitch.ImpArrows.DestroyAll();
                    snitch.ImpArrows.Clear();
                }

                foreach (var arrow in snitch.ImpArrows) arrow.target = snitch.Player.transform.position;

                foreach (var arrow in snitch.InformantArrows)
                {
                    var player = Utils.PlayerById(arrow.Key);
                    if (player == null || player.Data == null || player.Data.IsDead || player.Data.Disconnected)
                    {
                        snitch.DestroyArrow(arrow.Key);
                        continue;
                    }
                    arrow.Value.target = player.transform.position;
                }
            }
        }
    }
}