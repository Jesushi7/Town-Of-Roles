using HarmonyLib;
using TownOfRoles.Roles;
using UnityEngine;

namespace TownOfRoles.NeutralRoles.VultureMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HudManagerUpdate
    {
        public static ArrowBehaviour Arrow;
        public static DeadBody Target;
        public static Sprite EatSprite => TownOfRoles.VultureEat;
        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1) return;
            if (PlayerControl.LocalPlayer == null) return;
            if (PlayerControl.LocalPlayer.Data == null) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Vulture)) return;

            var role = Role.GetRole<Vulture>(PlayerControl.LocalPlayer);

            __instance.KillButton.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled)
                    && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead
                    && AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started);
            __instance.KillButton.SetCoolDown(role.EatTimer(), CustomGameOptions.VultureCd);

            if (role.CleanButton == null)
            {
                role.CleanButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.CleanButton.graphic.enabled = true;
                role.CleanButton.gameObject.SetActive(false);
            }

            role.CleanButton.graphic.sprite = EatSprite;
            role.CleanButton.transform.localPosition = new Vector3(0f, 1f, 0f);

            role.CleanButton.gameObject.SetActive((__instance.UseButton.isActiveAndEnabled || __instance.PetButton.isActiveAndEnabled)
                    && !MeetingHud.Instance && !PlayerControl.LocalPlayer.Data.IsDead
                    && AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started);

            var data = PlayerControl.LocalPlayer.Data;
            var isDead = data.IsDead;
            var truePosition = PlayerControl.LocalPlayer.GetTruePosition();
            var maxDistance = GameOptionsManager.Instance.currentNormalGameOptions.KillDistance;
            var flag = (GameOptionsManager.Instance.currentNormalGameOptions.GhostsDoTasks || !data.IsDead) &&
                       (!AmongUsClient.Instance || !AmongUsClient.Instance.IsGameOver) &&
                       PlayerControl.LocalPlayer.CanMove;
            var allocs = Physics2D.OverlapCircleAll(truePosition, 10,
                LayerMask.GetMask(new[] { "Players", "Ghost" }));
            var killButton = role.CleanButton;
            DeadBody closestBody = null;
            var closestDistance = float.MaxValue;

            foreach (var collider2D in allocs)
            {
                if (!flag || isDead || collider2D.tag != "DeadBody") continue;
                var component = collider2D.GetComponent<DeadBody>();
                var distance = Vector2.Distance(truePosition, component.TruePosition);
                if (distance <= 10 && Arrow == null) Target = component;
                else if (distance > 10 && Target == component) Target = null;
                if (!(distance <= maxDistance)) continue;
                if (!(distance < closestDistance)) continue;
                closestBody = component;
                closestDistance = distance;
            }


            KillButtonTarget.SetTarget(killButton, closestBody, role);
            role.CleanButton.SetCoolDown(role.EatTimer(), CustomGameOptions.VultureCd);
            if (Target != null && Arrow == null)
            {
                var gameObj = new GameObject();
                Arrow = gameObj.AddComponent<ArrowBehaviour>();
                gameObj.transform.parent = PlayerControl.LocalPlayer.gameObject.transform;
                var renderer = gameObj.AddComponent<SpriteRenderer>();
                renderer.sprite = TownOfRoles.Arrow;
                Arrow.image = renderer;
                gameObj.layer = 5;
            }
        }
    }
}