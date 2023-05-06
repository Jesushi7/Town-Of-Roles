using HarmonyLib;

namespace TownOfRoles.Modifiers
{
    public class Blind
    {
        [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
        public class HudManagerUpdate
        {
            public static void Postfix(HudManager __instance)
            {
                if (PlayerControl.LocalPlayer.Is(ModifierEnum.Blind))
                {
                    try
                    {
                        DestroyableSingleton<HudManager>.Instance.ReportButton.SetActive(false);
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}