using System;
using HarmonyLib;
using TownOfRoles.Roles;
using TownOfRoles.Modifiers.UnderdogMod;

namespace TownOfRoles.ImpostorRoles.VampireMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__33), nameof(IntroCutscene._CoBegin_d__33.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__33 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Vampire))
            {
                var poisoner = (Vampire)role;
                poisoner.LastBitten = DateTime.UtcNow;
                if (poisoner.Player.Is(ModifierEnum.Underdog))
                {
                    poisoner.LastBitten = poisoner.LastBitten.AddSeconds(PerformKill.LastImp() ? CustomGameOptions.UnderdogKillBonus : (PerformKill.IncreasedKC() ? 0f : (-CustomGameOptions.UnderdogKillBonus)));
                }
                poisoner.LastBitten = poisoner.LastBitten.AddSeconds(CustomGameOptions.InitialCooldowns - GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
            }
        }
    }
}