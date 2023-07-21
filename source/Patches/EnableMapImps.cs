using Discord;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;

namespace TownOfSushi
{
    [HarmonyPatch(typeof(GameSettingMenu), nameof(GameSettingMenu.InitializeOptions))]
    public class EnableMapImps
    {
        private static void Prefix(ref GameSettingMenu __instance)
        {
            __instance.HideForOnline = new Il2CppReferenceArray<Transform>(0);
        }
    }

    [HarmonyPatch(typeof(ImpostorRole), nameof(ImpostorRole.CanUse))]
    public class ImpTasks
    {
        private static bool Prefix(ImpostorRole __instance, ref IUsable usable, ref bool __result)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.CultistInformant)) return true;
            __result = true;
            return false;
        }
    }
}