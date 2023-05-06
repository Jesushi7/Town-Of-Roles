using HarmonyLib;

namespace TownOfRoles
{
	internal class GiantAndChildMedScan
	{

		[HarmonyPatch(typeof(MedScanMinigame))]
		private static class MedScanMinigamePatch
		{
			[HarmonyPatch(nameof(MedScanMinigame.Begin))]
			[HarmonyPostfix]
			private static void BeginPostfix(MedScanMinigame __instance)
			{
                if (PlayerControl.LocalPlayer.Is(ModifierEnum.Giant))
                {
					__instance.completeString = __instance.completeString.Replace("3' 6\"", "5' 0\"").Replace("92lb", "188lb");
				} else if (PlayerControl.LocalPlayer.Is(ModifierEnum.Mini))
                {
					__instance.completeString = __instance.completeString.Replace("3' 6\"", "1' 2\"").Replace("92lb", "25lb");
				}
			}
		}
	}
}