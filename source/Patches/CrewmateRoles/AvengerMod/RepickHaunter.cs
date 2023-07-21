using HarmonyLib;
using System.Linq;
using Hazel;
using UnityEngine;

namespace TownOfSushi.CrewmateRoles.AvengerMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class RepickAvenger
    {
        private static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (PlayerControl.LocalPlayer != SetAvenger.WillBeAvenger) return;
            if (PlayerControl.LocalPlayer.Data.IsDead) return;
            if (!PlayerControl.LocalPlayer.Is(Faction.Crewmates))
            {
                var toChooseFromAlive = PlayerControl.AllPlayerControls.ToArray().Where(x => x.Is(Faction.Crewmates)&& !x.Data.Disconnected).ToList();
                if (toChooseFromAlive.Count == 0)
                {
                    SetAvenger.WillBeAvenger = null;

                    Utils.Rpc(CustomRPC.SetAvenger, byte.MaxValue);
                }
                else
                {
                    var rand2 = Random.RandomRangeInt(0, toChooseFromAlive.Count);
                    var pc2 = toChooseFromAlive[rand2];

                    SetAvenger.WillBeAvenger = pc2;

                    Utils.Rpc(CustomRPC.SetAvenger, pc2.PlayerId);
                }
                return;
            }
            var toChooseFrom = PlayerControl.AllPlayerControls.ToArray().Where(x => x.Is(Faction.Crewmates) && x.Data.IsDead && !x.Data.Disconnected).ToList();
            if (toChooseFrom.Count == 0) return;
            var rand = Random.RandomRangeInt(0, toChooseFrom.Count);
            var pc = toChooseFrom[rand];

            SetAvenger.WillBeAvenger = pc;

            Utils.Rpc(CustomRPC.SetAvenger, pc.PlayerId);
            return;
        }
    }
}