using HarmonyLib;
using TownOfRoles.Roles;

namespace TownOfRoles.ImpostorRoles.CamouflageMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class CamouflageUnCamouflage
    {
        public static bool CommsEnabled;
        public static bool DisguiserEnabled;

        public static bool IsCamoed => CommsEnabled | DisguiserEnabled;

        public static void Postfix(HudManager __instance)
        {
            DisguiserEnabled = false;
            foreach (var role in Role.GetRoles(RoleEnum.Disguiser))
            {
                var camouflager = (Disguiser) role;
                if (camouflager.Camouflaged)
                {
                    DisguiserEnabled = true;
                    camouflager.Camouflage();
                }
                else if (camouflager.Enabled)
                {
                    DisguiserEnabled = false;
                    camouflager.UnCamouflage();
                }
            }
        }
    }
}