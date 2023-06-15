using System.Linq;
using HarmonyLib;
using Reactor.Utilities;
using TownOfRoles.Extensions;
using TownOfRoles.Roles;
using UnityEngine;

namespace TownOfRoles.CrewmateRoles.InformantMod
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CompleteTask))]
    public class CompleteTask2
    {
        public static Sprite Sprite => TownOfRoles.Arrow;

        public static void Postfix(PlayerControl __instance)
        {
            if (!__instance.Is(RoleEnum.Informant)) return;
            if (__instance.Data.IsDead) return;
            var taskinfos = __instance.Data.Tasks.ToArray();

            var tasksLeft = taskinfos.Count(x => !x.Complete);
            var role = Role.GetRole<Informant>(__instance);
            var localRole = Role.GetRole(PlayerControl.LocalPlayer);
            switch (tasksLeft)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    if (tasksLeft == CustomGameOptions.InformantTasksRemaining)
                    {
                        role.RegenTask();
                        if (PlayerControl.LocalPlayer.Is(RoleEnum.Informant))
                        {
                            Coroutines.Start(Utils.FlashCoroutine(role.Color));
                        }
                        else if ((PlayerControl.LocalPlayer.Data.IsImpostor())
                            || ((PlayerControl.LocalPlayer.Is(RoleEnum.Glitch) || PlayerControl.LocalPlayer.Is(RoleEnum.Juggernaut)
                            || PlayerControl.LocalPlayer.Is(RoleEnum.Arsonist)|| PlayerControl.LocalPlayer.Is(RoleEnum.SerialKiller) || PlayerControl.LocalPlayer.Is(RoleEnum.Werewolf)
                            || PlayerControl.LocalPlayer.Is(RoleEnum.Plaguebearer) || PlayerControl.LocalPlayer.Is(RoleEnum.Pestilence)) && CustomGameOptions.InformantSeesNeutrals))
                        {
                            Coroutines.Start(Utils.FlashCoroutine(role.Color));
                            var gameObj = new GameObject();
                            var arrow = gameObj.AddComponent<ArrowBehaviour>();
                            gameObj.transform.parent = PlayerControl.LocalPlayer.gameObject.transform;
                            var renderer = gameObj.AddComponent<SpriteRenderer>();
                            renderer.sprite = Sprite;
                            arrow.image = renderer;
                            gameObj.layer = 5;
                            role.ImpArrows.Add(arrow);
                        }
                    }
                    break;

                case 0:
                    role.RegenTask();
                    if (PlayerControl.LocalPlayer.Is(RoleEnum.Informant))
                    {
                        Coroutines.Start(Utils.FlashCoroutine(Color.green));
                        var impostors = PlayerControl.AllPlayerControls.ToArray().Where(x => x.Data.IsImpostor());
                    }
                    else if (PlayerControl.LocalPlayer.Data.IsImpostor() || ((PlayerControl.LocalPlayer.Is(RoleEnum.Glitch)  ||  PlayerControl.LocalPlayer.Is(RoleEnum.Juggernaut)
                            || PlayerControl.LocalPlayer.Is(RoleEnum.Arsonist) || PlayerControl.LocalPlayer.Is(RoleEnum.Werewolf)|| PlayerControl.LocalPlayer.Is(RoleEnum.SerialKiller)
                            || PlayerControl.LocalPlayer.Is(RoleEnum.Plaguebearer) || PlayerControl.LocalPlayer.Is(RoleEnum.Pestilence)) && CustomGameOptions.InformantSeesNeutrals))
                    {
                        Coroutines.Start(Utils.FlashCoroutine(Color.green));
                    }

                    break;
            }
        }
    }
}