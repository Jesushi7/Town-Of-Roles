using System;
using HarmonyLib;
using Hazel;
using TownOfSushi.Roles;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using TownOfSushi.Patches;
using TownOfSushi.CrewmateRoles.AurialMod;
using TownOfSushi.Patches.ScreenEffects;

namespace TownOfSushi.CrewmateRoles.AvengerMod
{
    [HarmonyPatch(typeof(AirshipExileController), nameof(AirshipExileController.WrapUpAndSpawn))]
    public static class AirshipExileController_WrapUpAndSpawn
    {
        public static void Postfix(AirshipExileController __instance) => SetAvenger.ExileControllerPostfix(__instance);
    }

    [HarmonyPatch(typeof(ExileController), nameof(ExileController.WrapUp))]
    public class SetAvenger
    {
        public static PlayerControl WillBeAvenger;
        public static Vector2 StartPosition;

        public static void ExileControllerPostfix(ExileController __instance)
        {
            if (WillBeAvenger == null) return;
            var exiled = __instance.exiled?.Object;
            if (!WillBeAvenger.Data.IsDead && exiled.Is(Faction.Crewmates)) WillBeAvenger = exiled;
            if (WillBeAvenger.Data.Disconnected) return;
            if (!WillBeAvenger.Data.IsDead && WillBeAvenger != exiled) return;

            if (!WillBeAvenger.Is(RoleEnum.Avenger))
            {
                if (WillBeAvenger == PlayerControl.LocalPlayer)
                {
                    if (PlayerControl.LocalPlayer.Is(RoleEnum.Aurial))
                    {
                        var aurial = Role.GetRole<Aurial>(PlayerControl.LocalPlayer);
                        aurial.NormalVision = true;
                        SeeAll.AllToNormal();
                        CameraEffect.singleton.materials.Clear();
                    }
                }
                var oldRole = Role.GetRole(WillBeAvenger);
                var killsList = (oldRole.CorrectKills, oldRole.IncorrectKills, oldRole.CorrectAssassinKills, oldRole.IncorrectAssassinKills);
                Role.RoleDictionary.Remove(WillBeAvenger.PlayerId);
                if (PlayerControl.LocalPlayer == WillBeAvenger)
                {
                    var role = new Avenger(PlayerControl.LocalPlayer);
                    role.formerRole = oldRole.RoleType;
                    role.CorrectKills = killsList.CorrectKills;
                    role.IncorrectKills = killsList.IncorrectKills;
                    role.CorrectAssassinKills = killsList.CorrectAssassinKills;
                    role.IncorrectAssassinKills = killsList.IncorrectAssassinKills;
                    role.RegenTask();
                }
                else
                {
                    var role = new Avenger(WillBeAvenger);
                    role.formerRole = oldRole.RoleType;
                    role.CorrectKills = killsList.CorrectKills;
                    role.IncorrectKills = killsList.IncorrectKills;
                    role.CorrectAssassinKills = killsList.CorrectAssassinKills;
                    role.IncorrectAssassinKills = killsList.IncorrectAssassinKills;
                }

                Utils.RemoveTasks(WillBeAvenger);
                if (!PlayerControl.LocalPlayer.Is(RoleEnum.Phantom)) WillBeAvenger.MyPhysics.ResetMoveState();

                WillBeAvenger.gameObject.layer = LayerMask.NameToLayer("Players");
            }

            if (PlayerControl.LocalPlayer != WillBeAvenger) return;

            if (Role.GetRole<Avenger>(PlayerControl.LocalPlayer).Caught) return;
            var startingVent =
                ShipStatus.Instance.AllVents[Random.RandomRangeInt(0, ShipStatus.Instance.AllVents.Count)];


            Utils.Rpc(CustomRPC.SetPos, PlayerControl.LocalPlayer.PlayerId, startingVent.transform.position.x, startingVent.transform.position.y + 0.3636f);

            PlayerControl.LocalPlayer.NetTransform.RpcSnapTo(new Vector2(startingVent.transform.position.x, startingVent.transform.position.y + 0.3636f));
            PlayerControl.LocalPlayer.MyPhysics.RpcEnterVent(startingVent.Id);
        }

        public static void Postfix(ExileController __instance) => ExileControllerPostfix(__instance);

        [HarmonyPatch(typeof(Object), nameof(Object.Destroy), new Type[] { typeof(GameObject) })]
        public static void Prefix(GameObject obj)
        {
            if (!SubmergedCompatibility.Loaded || GameOptionsManager.Instance?.currentNormalGameOptions?.MapId != 5) return;
            if (obj.name?.Contains("ExileCutscene") == true) ExileControllerPostfix(ExileControllerPatch.lastExiled);
        }
    }
}