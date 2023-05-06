using System;
using System.Linq;
using HarmonyLib;
using Hazel;
using TownOfRoles.Roles;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace TownOfRoles.CrewmateRoles.ImitatorMod
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Start))]
    public class AddButton
    {
        private static int _mostRecentId;
        private static Sprite ActiveSprite => TownOfRoles.ImitateSelectSprite;
        public static Sprite DisabledSprite => TownOfRoles.ImitateDeselectSprite;


        public static void GenButton(Imitator role, int index, bool isDead)
        {
            if (!isDead)
            {
                role.Buttons.Add(null);
                role.ListOfActives.Add(false);
                return;
            }

            var confirmButton = MeetingHud.Instance.playerStates[index].Buttons.transform.GetChild(0).gameObject;

            var newButton = Object.Instantiate(confirmButton, MeetingHud.Instance.playerStates[index].transform);
            var renderer = newButton.GetComponent<SpriteRenderer>();
            var passive = newButton.GetComponent<PassiveButton>();

            renderer.sprite = DisabledSprite;
            newButton.transform.position = confirmButton.transform.position - new Vector3(0.75f, 0f, 0f);
            newButton.transform.localScale *= 0.8f;
            newButton.layer = 5;
            newButton.transform.parent = confirmButton.transform.parent.parent;

            passive.OnClick = new Button.ButtonClickedEvent();
            passive.OnClick.AddListener(SetActive(role, index));
            role.Buttons.Add(newButton);
            role.ListOfActives.Add(false);
        }


        private static Action SetActive(Imitator role, int index)
        {
            void Listener()
            {
                if (role.ListOfActives.Count(x => x) == 1 &&
                    role.Buttons[index].GetComponent<SpriteRenderer>().sprite == DisabledSprite) return;

                role.Buttons[index].GetComponent<SpriteRenderer>().sprite =
                    role.ListOfActives[index] ? DisabledSprite : ActiveSprite;

                role.ListOfActives[index] = !role.ListOfActives[index];

                _mostRecentId = index;

                SetImitate.Imitate = null;
                for (var i = 0; i < role.ListOfActives.Count; i++)
                {
                    if (!role.ListOfActives[i]) continue;
                    SetImitate.Imitate = MeetingHud.Instance.playerStates[i];
                }
            }

            return Listener;
        }

        public static void Postfix(MeetingHud __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Imitator))
            {
                var imitator = (Imitator)role;
                imitator.ListOfActives.Clear();
                imitator.Buttons.Clear();
            }

            if (PlayerControl.LocalPlayer.Data.IsDead) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Imitator)) return;
            var imitatorRole = Role.GetRole<Imitator>(PlayerControl.LocalPlayer);
            for (var i = 0; i < __instance.playerStates.Length; i++)
            {
                foreach (var player in PlayerControl.AllPlayerControls)
                {
                    if (player.PlayerId == __instance.playerStates[i].TargetPlayerId)
                    {
                        var imitatable = false;
                        var imitatedRole = Role.GetRole(player).RoleType;
                        if (imitatedRole == RoleEnum.Avenger)
                        {
                            var Avenger = Role.GetRole<Avenger>(player);
                            imitatedRole = Avenger.formerRole;
                        }
                        if (player.Data.IsDead && !player.Data.Disconnected && (imitatedRole == RoleEnum.Mystic ||
                            imitatedRole == RoleEnum.Mystic ||
                            imitatedRole == RoleEnum.Snitch || imitatedRole == RoleEnum.Camouflager ||
                            imitatedRole == RoleEnum.Tracker || imitatedRole == RoleEnum.Sheriff ||
                            imitatedRole == RoleEnum.Veteran || imitatedRole == RoleEnum.Altruist ||
                            imitatedRole == RoleEnum.Engineer || imitatedRole == RoleEnum.Medium ||
                            imitatedRole == RoleEnum.Transporter || imitatedRole == RoleEnum.Trapper ||
                            imitatedRole == RoleEnum.Medic)) imitatable = true;
                        GenButton(imitatorRole, i, imitatable);
                    }
                }
            }
        }
    }
}