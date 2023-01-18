/*using System.Collections;
using TownOfUs.CustomOption;
using TownOfUs.Extensions;
using UnityEngine;
using TownOfUs.Roles;
using TownOfUs.NeutralRoles.VultureMod;

namespace TownOfUs.Roles.NeutralRoles.VultureMod
{
    public class Eat
    {
        private static readonly int BodyColor = Shader.PropertyToID("_BodyColor");
        private static readonly int BackColor = Shader.PropertyToID("_BackColor");

        public static IEnumerator EatCoroutine(DeadBody body, Vulture role)
        {
            KillButtonTarget.SetTarget(DestroyableSingleton<HudManager>.Instance.KillButton, null, role);
            role.Player.SetKillTimer(CustomGameOptions.VultureCd);
            var renderer = body.bodyRenderer;
            var backColor = renderer.material.GetColor(BackColor);
            var bodyColor = renderer.material.GetColor(BodyColor);
            var newColor = new Color(1f, 1f, 1f, 0f);

            for (var i = 0; i < 60; i++)
            {
                if (body == null)
                    yield break;
                
                renderer.color = Color.Lerp(backColor, newColor, i / 60f);
                renderer.color = Color.Lerp(bodyColor, newColor, i / 60f);
                yield return null;
            }

            Object.Destroy(body.gameObject);  
              
            role.EatNeed--;
            
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Vulture))
            {
                var bodyTxt = role.EatNeed == 1 ? "Body" : "Bodies";
                PlayerControl.LocalPlayer.myTasks.ToArray()[0].Cast<ImportantTextTask>().Text = $"{role.ColorString}Role: Vulture\nEat {role.EatNeed} {bodyTxt} to Win\nFake Tasks:</color>";
            }
        }
    }
}*/