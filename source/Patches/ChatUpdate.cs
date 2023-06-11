using HarmonyLib;
using TMPro;
using TownOfRoles.Roles;
using UnityEngine;

namespace TownOfRoles.Patches
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class ChatUpdate
    {
        private static float _time;

        public static void Postfix(HudManager __instance)
        {
            if (!__instance.Chat)
                return;

            if (_time >= CustomGameOptions.ChatCooldown)
            {
                __instance.Chat.TimeSinceLastMessage = 3f;
                _time -= CustomGameOptions.ChatCooldown;
            }
            else
                _time += Time.deltaTime;

            foreach (var bubble in __instance.Chat.chatBubPool.activeChildren)
            {
                if (bubble.Cast<ChatBubble>().NameText != null)
                {
                    bubble.Cast<ChatBubble>().NameText.alignment = TextAlignmentOptions.TopRight;
                    bubble.Cast<ChatBubble>().TextArea.alignment = TextAlignmentOptions.TopRight;
                }
            }

            if (Classes.GameStates.IsLobby)
                return;

            foreach (var bubble in __instance.Chat.chatBubPool.activeChildren)
            {
                var chat = bubble.Cast<ChatBubble>();

                if (chat.NameText != null)
                {
                    foreach (var player in PlayerControl.AllPlayerControls)
                    {
                        if (chat.NameText.text.Contains(player.Data.PlayerName))
                        {
                            var role = Role.GetRole(player);
                        }
                    }
                }
            }
        }
    }
}