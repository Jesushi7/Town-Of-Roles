using System.Collections.Generic;
using System.Reflection;
using System.Text;
using HarmonyLib;
using Reactor.Utilities.Extensions;
using TownOfSushi.CustomOption;
using AmongUs.GameOptions;
using System.Linq;
using UnityEngine;

namespace TownOfSushi
{
    [HarmonyPatch]
    public static class GameSettings
    {
        public static int SettingsPage = -1;

        [HarmonyPatch(typeof(IGameOptionsExtensions), nameof(IGameOptionsExtensions.ToHudString))]
        private static class GameOptionsDataPatch
        {
            public static IEnumerable<MethodBase> TargetMethods()
            {
                return typeof(GameOptionsData).GetMethods(typeof(string), typeof(int));
            }

            private static void Postfix(ref string __result)
            {
                if (GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.HideNSeek) return;

                var builder = new StringBuilder();
                builder.AppendLine("Press Tab To Change Page");
                builder.AppendLine($"Currently Viewing Page ({(SettingsPage + 2)}/6)");
                if (SettingsPage == 0) builder.AppendLine("Town of Sushi Settings");
                else if (SettingsPage == 1) builder.AppendLine("Crewmate Role Settings");
                else if (SettingsPage == 2) builder.AppendLine("Neutral Role Settings");
                else if (SettingsPage == 3) builder.AppendLine("Impostor Role Settings");
                else if (SettingsPage == 4) builder.AppendLine("Modifier Settings");

                if (SettingsPage == -1) builder.Append(new StringBuilder(__result));

                else
                {
                    foreach (var option in CustomOption.CustomOption.AllOptions.Where(x => x.Menu == (MultiMenu)SettingsPage))
                    {
                        if (option.Type == CustomOptionType.Button)
                            continue;
                        if (Classes.GameStates.IsLobby)
                        if (option.Type == CustomOptionType.Header)
                            builder.AppendLine($"\n{option.Name}");
                        else
                            builder.AppendLine($"    {option.Name}: {option}");
                    }
                }

                __result = $"<size=1.25>{builder.ToString()}</size>";
            }
        }

        [HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Update))]
        public static class Update
        {
            public static void Postfix(ref GameOptionsMenu __instance)
            {
                __instance.GetComponentInParent<Scroller>().ContentYBounds.max = (__instance.Children.Length - 6.5f) / 2;
            }
        }

        [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
        public class LobbyPatch
        {
            public static void Postfix(HudManager __instance)
            {
                if (!Classes.GameStates.IsLobby)
                    return;

                __instance.ReportButton.gameObject.SetActive(false);

                if (!Classes.GameStates.IsLobby)
                    return;

                __instance.ImpostorVentButton.gameObject.SetActive(false);

                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    if (SettingsPage > 3)
                        SettingsPage = -1;
                    else
                        SettingsPage++;
                }
            }
        }
    }
}