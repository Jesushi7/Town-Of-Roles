using System;
using System.Linq;
using HarmonyLib;
using TownOfRoles.Roles;
using Object = UnityEngine.Object;

namespace TownOfRoles.NeutralRoles.GlitchMod
{
    [HarmonyPatch(typeof(Object), nameof(Object.Destroy), typeof(Object))]
    internal class MeetingExiledEnd
    {
        private static void Prefix(Object obj)
        {
            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                var glitch = Role.AllRoles.FirstOrDefault(x => x.RoleType == RoleEnum.Glitch);
                if (glitch != null)
                {
                    ((Glitch)glitch).LastKill = DateTime.UtcNow;
                    ((Glitch)glitch).LastMimic = DateTime.UtcNow;
                    ((Glitch)glitch).LastHack = DateTime.UtcNow;
                }
            }
        }
    }
}