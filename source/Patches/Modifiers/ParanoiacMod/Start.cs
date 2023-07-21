using HarmonyLib;
using TownOfRoles.CrewmateRoles.EngineerMod;
using TownOfRoles.Patches;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Modifiers;
using UnityEngine;

namespace TownOfRoles.Modifiers.ParanoiacMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static Sprite Sprite => TownOfRoles.Arrow;
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var modifier in Modifier.GetModifiers(ModifierEnum.Paranoiac))
            {
                if (PlayerControl.LocalPlayer.Is(ModifierEnum.Paranoiac))
                {
                    var paranoiac = (Paranoiac)modifier;
                    var gameObj = new GameObject();
                    var arrow = gameObj.AddComponent<ArrowBehaviour>();
                    gameObj.transform.parent = PlayerControl.LocalPlayer.gameObject.transform;
                    var renderer = gameObj.AddComponent<SpriteRenderer>();
                    renderer.sprite = Sprite;
                    renderer.color = Colors.Radar;
                    arrow.image = renderer;
                    gameObj.layer = 5;
                    arrow.target = PlayerControl.LocalPlayer.transform.position;
                    paranoiac.ParanoiacArrow.Add(arrow);
                }
            }
        }
    }
}