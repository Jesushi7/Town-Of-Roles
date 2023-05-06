using HarmonyLib;
using System.Linq;
using TownOfRoles.CustomOption;

namespace TownOfRoles.Patches
{
    [HarmonyPatch(typeof(OverlayKillAnimation), nameof(OverlayKillAnimation.Initialize))]
    static class OverlayKillAnimationPatch
    {
        static int currentOutfitTypeCache;

        public static void Prefix(GameData.PlayerInfo kInfo)
        {
            var playerControl = PlayerControl.AllPlayerControls.ToArray().FirstOrDefault(p => p.PlayerId == kInfo.PlayerId);
            currentOutfitTypeCache = (int)playerControl.CurrentOutfitType;

            if (!CustomGameOptions.AppearanceAnimation)
                playerControl.CurrentOutfitType = PlayerOutfitType.Default;
        }

        public static void Postfix(GameData.PlayerInfo kInfo)
        {
            var playerControl = PlayerControl.AllPlayerControls.ToArray().FirstOrDefault(p => p.PlayerId == kInfo.PlayerId);
            playerControl.CurrentOutfitType = (PlayerOutfitType)currentOutfitTypeCache;
        }
    }
}