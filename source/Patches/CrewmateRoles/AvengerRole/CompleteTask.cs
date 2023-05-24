using System.Linq;
using HarmonyLib;
using TownOfRoles.Roles;
using Reactor.Utilities;
using UnityEngine;
using TownOfRoles.Extensions;

namespace TownOfRoles.CrewmateRoles.AvengerRole
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CompleteTask))]
    public class CompleteTask
    {
        public static Sprite Sprite => TownOfRoles.Arrow;
        public static void Postfix(PlayerControl __instance)
        {
            if (!__instance.Is(RoleEnum.Avenger)) return;
            var role = Role.GetRole<Avenger>(__instance);

            var taskinfos = __instance.Data.Tasks.ToArray();

            var tasksLeft = taskinfos.Count(x => !x.Complete);

            if (tasksLeft == CustomGameOptions.AvengerTasksRemainingAlert && !role.Caught)
            {
                if (PlayerControl.LocalPlayer.Is(RoleEnum.Avenger))
                {
                    Coroutines.Start(Utils.FlashCoroutine(role.Color));
                }
                else if (PlayerControl.LocalPlayer.Data.IsImpostor() || (PlayerControl.LocalPlayer.Is(Faction.Neutral) && CustomGameOptions.AvengerRevealsNeutrals))
                {
                    role.Revealed = true;
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

            if (tasksLeft == 0 && !role.Caught)
            {
                role.CompletedTasks = true;
                if (PlayerControl.LocalPlayer.Is(RoleEnum.Avenger))
                {
                    Coroutines.Start(Utils.FlashCoroutine(Color.white));
                }
                else if (PlayerControl.LocalPlayer.Data.IsImpostor() || (PlayerControl.LocalPlayer.Is(Faction.Neutral) && CustomGameOptions.AvengerRevealsNeutrals))
                {
                    Coroutines.Start(Utils.FlashCoroutine(Color.white));
                }
            }
        }
    }
}