using System;
using UnityEngine;
using TMPro;
using AmongUs.GameOptions;
using TownOfSushi.Extensions;

namespace TownOfSushi.Roles
{
    public class GuardianAngel : Role
    {
        public bool Enabled;
        public DateTime LastProtected;
        public float TimeRemaining;

        public int UsesLeft;
        public TextMeshPro UsesText;

        public bool ButtonUsable => UsesLeft != 0;

        public PlayerControl target;

        public GuardianAngel(PlayerControl player) : base(player)
        {
            Name = "Guardian Angel";
            ImpostorText = () =>
                target == null ? "<color=#B3FFFFFF>The game couldn't give you a target....sorry</color>" : $"<color=#B3FFFFFF>Protect {target.name} with your life!</color>";
            TaskText = () =>
                target == null
                    ? "You don't have a target for some reason... weird..."
                    : $"Protect {target.name}!";
            FactionName = "<color=#5c5e5d>Neutral</color>";                           
            Color = Patches.Colors.GuardianAngel;
            LastProtected = DateTime.UtcNow;
            RoleType = RoleEnum.GuardianAngel;
            AddToRoleHistory(RoleType);
            Faction = Faction.NeutralBenign;
            Scale = 1.4f;

            UsesLeft = CustomGameOptions.MaxProtects;
        }

        public bool Protecting => TimeRemaining > 0f;

        public float ProtectTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastProtected;
            var num = CustomGameOptions.ProtectCd * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }

        public void Protect()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
        }


        public void UnProtect()
        {
            var ga = GetRole<GuardianAngel>(Player);
            if (!ga.target.IsShielded())
            {
                ga.target.myRend().material.SetColor("_VisorColor", Palette.VisorColor);
                ga.target.myRend().material.SetFloat("_Outline", 0f);
            }
            Enabled = false;
            LastProtected = DateTime.UtcNow;
        }

        protected override void IntroPrefix(IntroCutscene._ShowTeam_d__36 __instance)
        {
            var gaTeam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
            gaTeam.Add(PlayerControl.LocalPlayer);
            gaTeam.Add(target);
            __instance.teamToShow = gaTeam;
        }
    }
}