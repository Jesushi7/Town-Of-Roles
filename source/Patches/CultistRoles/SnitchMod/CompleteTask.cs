using System.Linq;
using HarmonyLib;
using TownOfSushi.Roles;
using TownOfSushi.Roles.Cultist;

namespace TownOfSushi.CultistRoles.InformantMod
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CompleteTask))]
    public class CompleteTask
    {
        public static void Postfix(PlayerControl __instance)
        {
            if (__instance != PlayerControl.LocalPlayer) return;
            if (!__instance.Is(RoleEnum.CultistInformant)) return;
            var role = Role.GetRole<CultistInformant>(__instance);

            var taskinfos = __instance.Data.Tasks.ToArray();

            var tasksLeft = taskinfos.Count(x => !x.Complete);

            if (tasksLeft == 0)
            {
                role.CompletedTasks = true;
                if (PlayerControl.LocalPlayer == role.Player)
                {
                    if (role.Player.Is(Faction.Impostors))
                    {
                        var crew = PlayerControl.AllPlayerControls.ToArray().Where(x => x.Is(Faction.Crewmates) && !x.Is(RoleEnum.Monarch)).ToList();
                        crew.Shuffle();
                        role.RevealedPlayer = crew[0];
                    }
                    else
                    {
                        var imps = PlayerControl.AllPlayerControls.ToArray().Where(x => x.Is(Faction.Impostors) && !x.Is(RoleEnum.Necromancer) && !x.Is(RoleEnum.Whisperer)).ToList();
                        if (imps.Count == 0) imps = PlayerControl.AllPlayerControls.ToArray().Where(x => x.Is(RoleEnum.Necromancer) || x.Is(RoleEnum.Whisperer)).ToList();
                        imps.Shuffle();
                        role.RevealedPlayer = imps[0];
                    }
                    Utils.Rpc(CustomRPC.InformantCultistReveal, role.Player.PlayerId, role.RevealedPlayer.PlayerId);
                }
            }
        }
    }
}