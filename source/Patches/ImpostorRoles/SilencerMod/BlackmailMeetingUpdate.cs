using HarmonyLib;
using TownOfRoles.Roles;
using UnityEngine;
using System.Linq;
using System.Collections;
using Reactor.Utilities;

namespace TownOfRoles.ImpostorRoles.SilencerMod
{
    public class SilenceMeetingUpdate
    {
        public static bool shookAlready = false;
        public static Sprite PrevXMark = null;
        public static Sprite PrevOverlay = null;

        public const float LetterXOffset = 0.22f;
        public const float LetterYOffset = -0.32f;

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Start))]
        public class MeetingHudStart
        {
            public static Sprite Letter => TownOfRoles.SilenceLetterSprite;

            public static void Postfix(MeetingHud __instance)
            {
                shookAlready = false;

                var Silencers = Role.AllRoles.Where(x => x.RoleType == RoleEnum.Silencer && x.Player != null).Cast<Silencer>();

                foreach (var role in Silencers)
                {
                    if (role.Silenced?.PlayerId == PlayerControl.LocalPlayer.PlayerId && !role.Silenced.Data.IsDead)
                    {
                        Coroutines.Start(SilenceShhh());
                    }
                    if (role.Silenced != null && !role.Silenced.Data.IsDead)
                    {
                        var playerState = __instance.playerStates.FirstOrDefault(x => x.TargetPlayerId == role.Silenced.PlayerId);

                        playerState.XMark.gameObject.SetActive(true);
                        if (PrevXMark == null) PrevXMark = playerState.XMark.sprite;
                        playerState.XMark.sprite = Letter;
                        playerState.XMark.transform.localScale = playerState.XMark.transform.localScale * 0.75f;
                        playerState.XMark.transform.localPosition = new Vector3(
                            playerState.XMark.transform.localPosition.x + LetterXOffset,
                            playerState.XMark.transform.localPosition.y + LetterYOffset,
                            playerState.XMark.transform.localPosition.z);
                    }
                }
            }

            public static IEnumerator SilenceShhh()
            {
                yield return HudManager.Instance.CoFadeFullScreen(Color.clear, new Color(0f, 0f, 0f, 0.98f));
                var TempPosition = HudManager.Instance.shhhEmblem.transform.localPosition;
                var TempDuration = HudManager.Instance.shhhEmblem.HoldDuration;
                HudManager.Instance.shhhEmblem.transform.localPosition = new Vector3(
                    HudManager.Instance.shhhEmblem.transform.localPosition.x,
                    HudManager.Instance.shhhEmblem.transform.localPosition.y,
                    HudManager.Instance.FullScreen.transform.position.z + 1f);
                HudManager.Instance.shhhEmblem.TextImage.text = "YOU ARE Silenced";
                HudManager.Instance.shhhEmblem.HoldDuration = 2.5f;
                yield return HudManager.Instance.ShowEmblem(true);
                HudManager.Instance.shhhEmblem.transform.localPosition = TempPosition;
                HudManager.Instance.shhhEmblem.HoldDuration = TempDuration;
                yield return HudManager.Instance.CoFadeFullScreen(new Color(0f, 0f, 0f, 0.98f), Color.clear);
                yield return null;
            }
        }

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Update))]
        public class MeetingHud_Update
        {
            public static Sprite Overlay => TownOfRoles.SilenceOverlaySprite;

            public static void Postfix(MeetingHud __instance)
            {
                var Silencers = Role.AllRoles.Where(x => x.RoleType == RoleEnum.Silencer && x.Player != null).Cast<Silencer>();

                foreach (var role in Silencers)
                {
                    if (role.Silenced != null && !role.Silenced.Data.IsDead)
                    {
                        var playerState = __instance.playerStates.FirstOrDefault(x => x.TargetPlayerId == role.Silenced.PlayerId);
                        playerState.Overlay.gameObject.SetActive(true);
                        if (PrevOverlay == null) PrevOverlay = playerState.Overlay.sprite;
                        playerState.Overlay.sprite = Overlay;
                        if (__instance.state != MeetingHud.VoteStates.Animating && shookAlready == false)
                        {
                            shookAlready = true;
                            (__instance as MonoBehaviour).StartCoroutine(Effects.SwayX(playerState.transform));
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(TextBoxTMP), nameof(TextBoxTMP.SetText))]
        public class StopChatting
        {
            public static bool Prefix(TextBoxTMP __instance)
            {
                var Silencers = Role.AllRoles.Where(x => x.RoleType == RoleEnum.Silencer && x.Player != null).Cast<Silencer>();
                foreach (var role in Silencers)
                {
                    if (MeetingHud.Instance && role.Silenced != null && !role.Silenced.Data.IsDead && role.Silenced.PlayerId == PlayerControl.LocalPlayer.PlayerId)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}