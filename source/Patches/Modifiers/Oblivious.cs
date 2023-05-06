using HarmonyLib;

namespace TownOfRoles.Modifiers
{
    public class Oblivious
    {
        [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
        public class HudManagerUpdate
        {
            public static void Postfix(HudManager __instance)
            {
                if (PlayerControl.LocalPlayer.Is(ModifierEnum.Oblivious))
                {
                        __instance.ReportButton.gameObject.SetActive(false);
                }
            }
        }
        public class PerformReportButton
        {
            [HarmonyPatch(typeof(ReportButton), nameof(ReportButton.DoClick))]
            public static bool Postfix(ReportButton __instance) => !PlayerControl.LocalPlayer.Is(ModifierEnum.Oblivious);
        }
    }
}