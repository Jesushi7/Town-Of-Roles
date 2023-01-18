using HarmonyLib;
using TownOfUs.Roles;

namespace TownOfUs.CrewmateRoles.MysticMod
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    public class HudExamine
    {
        public static void Postfix(PlayerControl __instance)
        {
            UpdateExamineButton(__instance);
        }

        public static void UpdateExamineButton(PlayerControl __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Mystic)) return;
            var data = PlayerControl.LocalPlayer.Data;
            var isDead = data.IsDead;
            var examineButton = DestroyableSingleton<HudManager>.Instance.KillButton;

            var role = Role.GetRole<Mystic>(PlayerControl.LocalPlayer);

            if (isDead)
            {
                examineButton.gameObject.SetActive(false);
            }
            else
            {
                examineButton.gameObject.SetActive(!MeetingHud.Instance);
                // trackButton.isActive = !MeetingHud.Instance;
                examineButton.SetCoolDown(role.ExamineTimer(), CustomGameOptions.ExamineCd);

                Utils.SetTarget(ref role.ClosestPlayer, examineButton, float.NaN);
            }

            var renderer = examineButton.graphic;
            if (role.ClosestPlayer != null)
            {
                renderer.color = Palette.EnabledColor;
                renderer.material.SetFloat("_Desat", 0f);
            }
            else
            {
                renderer.color = Palette.DisabledClear;
                renderer.material.SetFloat("_Desat", 1f);
            }
        }
    }
}