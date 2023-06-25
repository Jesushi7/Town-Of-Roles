/*using HarmonyLib;
using UnityEngine;
using TownOfRoles.CustomOption;

namespace TownOfRoles
{
    public class GameStartManagerPatch
    {
        private static float Timer = 600;

        [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Start))]
        public class Start
        {
            public static void Postfix(GameStartManager __instance)
            {
                if (AmongUsClient.Instance.GameId == 32) return;
                Generate.MaxPlayers.Set((float) PlayerControl.GameOptions.MaxPlayers);
                Timer = 600;
            }
        }
        

        [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
        public class Update
        {
            private static string CurrentText = "";
            private static bool Up = false;
        
            public static void Prefix(GameStartManager __instance)
            {
                if (!AmongUsClient.Instance.AmHost  || !GameData.Instance || AmongUsClient.Instance.GameId == 32) return;
                Up = GameData.Instance.PlayerCount != __instance.LastPlayerCount;
            }

            public static void Postfix(GameStartManager __instance)
            {
                if (AmongUsClient.Instance.GameId == 32 || !GameData.Instance) return;
                int max = PlayerControl.GameOptions.MaxPlayers;
                if (__instance.LastPlayerCount != max) __instance.LastPlayerCount = max;
                if (!AmongUsClient.Instance.AmHost) return;
                if (Up) CurrentText = __instance.PlayerCounter.text;
                Timer = Mathf.Max(0f, Timer -= Time.deltaTime);
                int minutes = (int) Timer / 60;
                int seconds = (int) Timer % 60;
                string suffix = $"{minutes:00}:{seconds:00}";
                Color color = minutes > 3 ? Color.green : Color.yellow;
                if (minutes < 1) color = Color.red;
                __instance.PlayerCounter.text = CurrentText + $"\n{suffix.ColoredString(color)}";
                __instance.PlayerCounter.alignment = TMPro.TextAlignmentOptions.Center;
                __instance.PlayerCounter.autoSizeTextContainer = true;
            }
        }
    }
}*/