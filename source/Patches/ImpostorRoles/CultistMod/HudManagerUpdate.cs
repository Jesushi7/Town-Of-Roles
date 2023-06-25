using HarmonyLib;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Cultist;
using UnityEngine;
using AmongUs.GameOptions;

namespace TownOfRoles.CultistRoles.CultistMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class ReviveHudManagerUpdate
    {
        public static Sprite ReviveSprite => TownOfRoles.Revive2Sprite;
        public static byte DontRevive = byte.MaxValue;

        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (PlayerControl.LocalPlayer.Data.IsDead) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Cultist)) return;
            var role = Role.GetRole<Cultist>(PlayerControl.LocalPlayer);
            if (role.ReviveButton == null)
            {
                role.ReviveButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.ReviveButton.graphic.enabled = true;
                role.ReviveButton.gameObject.SetActive(false);
            }

            role.ReviveButton.graphic.sprite = ReviveSprite;

            role.ReviveButton.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled)
                    && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead
                    && AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started);

            var data = PlayerControl.LocalPlayer.Data;
            var isDead = data.IsDead;
            var truePosition = PlayerControl.LocalPlayer.GetTruePosition();
            var maxDistance = GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
            var flag = (GameOptionsManager.Instance.currentNormalGameOptions.GhostsDoTasks || !data.IsDead) &&
                       (!AmongUsClient.Instance || !AmongUsClient.Instance.IsGameOver) &&
                       PlayerControl.LocalPlayer.CanMove;
            var allocs = Physics2D.OverlapCircleAll(truePosition, maxDistance,
                LayerMask.GetMask(new[] { "Players", "Ghost" }));

            DeadBody closestBody = null;
            var closestDistance = float.MaxValue;

            foreach (var collider2D in allocs)
            {
                if (!flag || isDead || collider2D.tag != "DeadBody") continue;
                var component = collider2D.GetComponent<DeadBody>();


                if (!(Vector2.Distance(truePosition, component.TruePosition) <=
                      maxDistance)) continue;

                var distance = Vector2.Distance(truePosition, component.TruePosition);
                if (!(distance < closestDistance)) continue;
                closestBody = component;
                closestDistance = distance;
            }

            role.ReviveButton.SetCoolDown(role.ReviveTimer(),
                CustomGameOptions.ReviveCooldown2 + CustomGameOptions.IncreasedCooldownPerRevive2 * role.ReviveCount);

            if (role.CurrentTarget && role.CurrentTarget != closestBody)
            {
                foreach (var body in role.CurrentTarget.bodyRenderers) body.material.SetFloat("_Outline", 0f);
            }

            if (closestBody != null && closestBody.ParentId == DontRevive) closestBody = null;
            role.CurrentTarget = closestBody;
            if (role.CurrentTarget == null)
            {
                role.ReviveButton.graphic.color = Palette.DisabledClear;
                role.ReviveButton.graphic.material.SetFloat("_Desat", 1f);
                return;
            }
            var player = Utils.PlayerById(role.CurrentTarget.ParentId);
            if (role.CurrentTarget && role.ReviveButton.enabled &&
                !(player.Is(RoleEnum.Sheriff) || player.Is(RoleEnum.Snitch)  || player.Is(RoleEnum.Informant)|| player.Is(RoleEnum.Mystic)
                || player.Is(RoleEnum.Mayor)|| player.Is(RoleEnum.Medium)|| player.Is(RoleEnum.Altruist)|| player.Is(RoleEnum.Trapper)
                || player.Is(Faction.Neutral)) &&
                !(PlayerControl.LocalPlayer.killTimer > GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown - 0.5f))
            {
                SpriteRenderer component = null;
                foreach (var body in role.CurrentTarget.bodyRenderers) component = body;
                component.material.SetFloat("_Outline", 1f);
                component.material.SetColor("_OutlineColor", Color.red);
                role.ReviveButton.graphic.color = Palette.EnabledColor;
                role.ReviveButton.graphic.material.SetFloat("_Desat", 0f);
                return;
            }

            role.ReviveButton.graphic.color = Palette.DisabledClear;
            role.ReviveButton.graphic.material.SetFloat("_Desat", 1f);
        }
    }
}