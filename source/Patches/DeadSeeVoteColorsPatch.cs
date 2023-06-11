using HarmonyLib;
using UnityEngine;

namespace TownOfRoles
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.BloopAVoteIcon))]
    public static class DeadSeeVoteColorsPatch
    {
        public static bool Prefix(MeetingHud __instance, [HarmonyArgument(0)] GameData.PlayerInfo voterPlayer,
            [HarmonyArgument(1)] int index, [HarmonyArgument(2)] Transform parent)
        {
            SpriteRenderer spriteRenderer = Object.Instantiate<SpriteRenderer>(__instance.PlayerVotePrefab);
            if (GameOptionsManager.Instance.currentNormalGameOptions.AnonymousVotes && !PlayerControl.LocalPlayer.Is(ModifierEnum.Watcher) && (!CustomGameOptions.DeadSnitcholes
             || !PlayerControl.LocalPlayer.Data.IsDead))
            {
                PlayerMaterial.SetColors(Palette.DisabledGrey, spriteRenderer);
            }
            else
            {
                PlayerMaterial.SetColors(voterPlayer.DefaultOutfit.ColorId, spriteRenderer);
            }
            spriteRenderer.transform.SetParent(parent);
            spriteRenderer.transform.localScale = Vector3.zero;
            
            var Base = __instance as MonoBehaviour;
            Base.StartCoroutine(Effects.Bloop((float)index * 0.3f, spriteRenderer.transform, 1f, 0.5f));
            parent.GetComponent<VoteSpreader>().AddVote(spriteRenderer);
            return false;
        }
    }
}