using HarmonyLib;
using Reactor.Utilities.Extensions;

namespace TownOfRoles.NeutralRoles.VultureMod
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    public class Arrows
    {
        public static void Postfix(PlayerControl __instance)
        {
            if (HudManagerUpdate.Arrow != null)
            {
                if (LobbyBehaviour.Instance || MeetingHud.Instance || PlayerControl.LocalPlayer.Data.IsDead || HudManagerUpdate.Target == null)
                {
                    HudManagerUpdate.Arrow.gameObject.Destroy();
                    return;
                }

                HudManagerUpdate.Arrow.target = HudManagerUpdate.Target.transform.position;
            }
        }
    }
}