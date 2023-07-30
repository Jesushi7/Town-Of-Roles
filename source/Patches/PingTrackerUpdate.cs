using HarmonyLib;
using UnityEngine;

namespace TownOfSushi
{
    //[HarmonyPriority(Priority.VeryHigh)] // to show this message first, or be overrided if any plugins do
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingTracker_Update
    {

        [HarmonyPostfix]
        public static void Postfix(PingTracker __instance)
        {
            __instance.text.alignment = TMPro.TextAlignmentOptions.TopRight;

        var ping = AmongUsClient.Instance.Ping;
        string color = "#ff4500";
        if (ping < 80) color = "#44dfcc";
        else if (ping < 100) color = "#7bc690";
        else if (ping < 200) color = "#f3920e";
        else if (ping < 400) color = "#ff146e";

            __instance.text.text =
                "<color=#00FF00FF>TownOfSushi v" + TownOfSushi.VersionString + "</color>\n" +
             ($"<color={color}>Ping: {ping}ms</color>") +                    
                  (!MeetingHud.Instance
                    ? "<color=#00FF00FF>\nModded By: Jsushi </color>\n" +
                    "<color=#00FF00FF>Helped by: Kara, AlchlcDvl and Discussions</color>\n" : "") +
                (AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started
                    ? "<color=#00FF00FF>Formerly: TOUR, Slushiegoose & Polus.gg</color>" : "");
        }
    }
}
