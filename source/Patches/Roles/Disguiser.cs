using System;
using UnityEngine;

namespace TownOfRoles.Roles
{
    public class Disguiser : Role

    {
        public KillButton _camouflageButton;
        public bool Enabled;
        public DateTime LastDisguised;
        public float TimeRemaining;

        public Disguiser(PlayerControl player) : base(player)
        {
            Name = "Disguiser";
            StartText = () => "Disguise and turn everyone grey";
            TaskText = () => "Hide among others";
            FactionName = "Impostor";
            Color = Patches.Colors.Impostor;
            RoleType = RoleEnum.Disguiser;
            AddToRoleHistory(RoleType);
            Faction = Faction.Impostors;
        }

        public bool Camouflaged => TimeRemaining > 0f;

        public KillButton CamouflageButton
        {
            get => _camouflageButton;
            set
            {
                _camouflageButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public void Camouflage()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
            Utils.Camouflage();
        }

        public void UnCamouflage()
        {
            Enabled = false;
            LastDisguised = DateTime.UtcNow;
            Utils.UnCamouflage();
        }

        public float CamouflageTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastDisguised;
            var num = CustomGameOptions.DisguiserCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}