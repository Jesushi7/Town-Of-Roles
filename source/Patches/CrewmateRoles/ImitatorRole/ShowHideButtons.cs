using System.Linq;
using HarmonyLib;
using Hazel;
using TownOfRoles.Roles;
using UnityEngine;
using UnityEngine.UI;

namespace TownOfRoles.CrewmateRoles.ImitatorRole
{
    public class ShowHideButtons
    {
        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Confirm))]
        public static class Confirm
        {
            public static bool Prefix(MeetingHud __instance)
            {
                if (!PlayerControl.LocalPlayer.Is(RoleEnum.Imitator)) return true;
                var imitator = Role.GetRole<Imitator>(PlayerControl.LocalPlayer);
                foreach (var button in imitator.Buttons.Where(button => button != null))
                {
                    if (button.GetComponent<SpriteRenderer>().sprite == AddButton.DisabledSprite)
                        button.SetActive(false);

                    button.GetComponent<PassiveButton>().OnClick = new Button.ButtonClickedEvent();
                }

                if (imitator.ListOfActives.Count(x => x) == 1)
                {
                    for (var i = 0; i < imitator.ListOfActives.Count; i++)
                    {
                        if (!imitator.ListOfActives[i]) continue;
                        SetImitate.Imitate = __instance.playerStates[i];
                    }
                }

                return true;
            }
        }
    }
}