using TownOfRoles.Roles;
using TownOfRoles.Roles.Modifiers;
using HarmonyLib;
using AmongUs.GameOptions;

namespace TownOfRoles
{
    [HarmonyPatch]

    internal sealed class Hauntpatch
    {
        [HarmonyPatch(typeof(HauntMenuMinigame), nameof(HauntMenuMinigame.SetFilterText))]
        [HarmonyPrefix]

        public static bool Prefix(HauntMenuMinigame __instance)
        {
            if (!CustomGameOptions.DeadSeesEverything)
            {
                __instance.FilterText.text = " ";
                return false;
            }            
            if (GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.HideNSeek) return true;
            var role = Role.GetRole(__instance.HauntTarget);
            var modifier = Modifier.GetModifier(__instance.HauntTarget);
            var ability = Ability.GetAbility(__instance.HauntTarget);
            var otherString = "";
            var objectiveString = "";
            
            if (role != null)
                objectiveString += role.Name;

            if (ability != null && ability.AbilityType != AbilityEnum.None)
                otherString += $" {ability.Name}";
                
            if (modifier != null && modifier.ModifierType != ModifierEnum.None)
                otherString += $" {modifier.Name}";                
            return false;
        }
    }
}