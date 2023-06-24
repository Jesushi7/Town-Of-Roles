using HarmonyLib;
using TownOfRoles.Roles;
using TownOfRoles.Extensions;

namespace TownOfRoles.ImpostorRoles.VampireMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.SetTarget))]
    public class SetTarget
    {
        public static void Postfix(KillButton __instance, [HarmonyArgument(0)] PlayerControl target)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Vampire)) return;
            var role = Role.GetRole<Vampire>(PlayerControl.LocalPlayer);
            if (target != null && __instance == DestroyableSingleton<HudManager>.Instance.KillButton)
                if (target.Data.IsImpostor())
                {
                    __instance.graphic.color = Palette.DisabledClear;
                    __instance.graphic.material.SetFloat("_Desat", 1f);
                }
        }
    }
}