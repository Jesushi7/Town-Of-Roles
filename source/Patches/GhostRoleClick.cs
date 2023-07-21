using HarmonyLib;
using Hazel;
using System.Linq;
using TownOfSushi.CrewmateRoles.AvengerMod;
using TownOfSushi.Extensions;
using TownOfSushi.Roles;

namespace TownOfSushi
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.OnClick))]
    public class ClickGhostRole
    {
        public static void Prefix(PlayerControl __instance)
        {
            if (MeetingHud.Instance) return;
            if (PlayerControl.LocalPlayer.Data.IsDead) return;
            var taskinfos = __instance.Data.Tasks.ToArray();
            var tasksLeft = taskinfos.Count(x => !x.Complete);
            if (__instance.Is(RoleEnum.Phantom))
            {
                if (tasksLeft <= CustomGameOptions.PhantomTasksRemaining)
                {
                    var role = Role.GetRole<Phantom>(__instance);
                    role.Caught = true;
                    role.Player.Exiled();
                    Utils.Rpc(CustomRPC.CatchPhantom, role.Player.PlayerId);
                }
            }
            else if (__instance.Is(RoleEnum.Avenger))
            {
                if (CustomGameOptions.AvengerCanBeClickedBy == AvengerCanBeClickedBy.ImpsOnly && !PlayerControl.LocalPlayer.Data.IsImpostor()) return;
                if (CustomGameOptions.AvengerCanBeClickedBy == AvengerCanBeClickedBy.NonCrew && !(PlayerControl.LocalPlayer.Data.IsImpostor() || PlayerControl.LocalPlayer.Is(Faction.NeutralKilling))) return;
                if (tasksLeft <= CustomGameOptions.AvengerTasksRemainingClicked)
                {
                    var role = Role.GetRole<Avenger>(__instance);
                    role.Caught = true;
                    role.Player.Exiled();
                    Utils.Rpc(CustomRPC.CatchAvenger, role.Player.PlayerId);
                }
            }
            return;
        }
    }
}