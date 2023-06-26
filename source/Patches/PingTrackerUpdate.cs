using System.Text;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace TownOfRoles
{

    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingTracker_Update
    {
      private static readonly StringBuilder sb = new();
        
        public static TextMeshPro ModVersion;

        public static void Postfix(VersionShower __instance)
        {
            var gameObject = GameObject.Find("LOGO-AU");

            if (gameObject && !ModVersion)
            {
                ModVersion = UObject.Instantiate(__instance.text);
                var pos = VersionShowerUpdate.Logo.transform.position;
                pos.y -= 2f;
                ModVersion.transform.position = pos;
                ModVersion.text = $"<size=175%><b>{TownOfRoles.VersionString}\nCreated by <color=#9fcc90>Jsushi</color></b></size>";
                ModVersion.alignment = TextAlignmentOptions.Center;
                ModVersion.fontStyle = FontStyles.Bold;
                ModVersion.name = "ModVersion";
                ModVersion.transform.SetParent(VersionShowerUpdate.Logo.transform.parent);
            }
        }
        
        [HarmonyPostfix]
        public static void Postfix(PingTracker __instance)
        {
      //Thanks to Town of Host Edited for this code
        __instance.text.alignment = TextAlignmentOptions.TopRight;
        sb.Clear();
        sb.Append(Utils.credentialsText);
        var ping = AmongUsClient.Instance.Ping;
        string color = "#ff4500";
        if (ping < 80) color = "#44dfcc";
        else if (ping < 100) color = "#7bc690";
        else if (ping < 200) color = "#f3920e";
        else if (ping < 400) color = "#ff146e";
        
            __instance.text.text =
                "<size=110%><color=#9fcc90>TownOfRoles v" + TownOfRoles.VersionString + "</color></size>\n"+   
              ($"<color={color}>Ping: {ping}ms</color>") +                    
                  (!MeetingHud.Instance
              ? "<size=70%>\nCreated by: <color=#9fcc90>Jsushi</color>\n</size>" +
                (AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started  
                   ? "<size=70%>Helped from: <color=#9fcc90>Kara, AlchlcDvl</color> and <color=#9fcc90>Discussions</color>\n</size>" : "") +                
                     "<size=70%>Formerly: <color=#9fcc90>Donners, Slushiegoose & Polus.gg</color></size>" : "");       
        }
    }
}