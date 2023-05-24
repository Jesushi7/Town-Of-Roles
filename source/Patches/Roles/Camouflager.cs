using System;
using TownOfRoles.Extensions;
using UnityEngine;

namespace TownOfRoles.Roles
{
    public class Camouflager : Role
    {
        public bool Enabled;
        public DateTime LastSwooped;
        public float TimeRemaining;

        public Camouflager(PlayerControl player) : base(player)
        {
            Name = "Camouflager";
            StartText = () => "<color=#708eef>Turn invisible temporarily</color>";
            TaskText = () => "Turn invisible";
            Color = Patches.Colors.Chameleon;
            LastSwooped = DateTime.UtcNow;
            RoleType = RoleEnum.Camouflager;
            FactionName = "<color=#00EEFFFF>Crewmate</color>";    
            Faction = Faction.Crewmates;               
            AddToRoleHistory(RoleType);
        }

        public bool IsSwooped => TimeRemaining > 0f;

        public float SwoopTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastSwooped;
            var num = CustomGameOptions.ChameleonSwoopCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }

        public void Swoop()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
            if (Player.Data.IsDead)
            {
                TimeRemaining = 0f;
            }
            var color = Color.clear;
            if (Player == PlayerControl.LocalPlayer || PlayerControl.LocalPlayer.Data.IsDead) color.a = 0.1f;

            if (Player.GetCustomOutfitType() != CustomPlayerOutfitType.Swooper)
            {
                Player.SetOutfit(CustomPlayerOutfitType.Swooper, new GameData.PlayerOutfit()
                {
                    ColorId = Player.CurrentOutfit.ColorId,
                    HatId = "",
                    SkinId = "",
                    VisorId = "",
                    PlayerName = " "
                });
                Player.myRend().color = color;
                Player.nameText().color = Color.clear;
                Player.cosmetics.colorBlindText.color = Color.clear;
            }
        }


        public void UnSwoop()
        {
            Enabled = false;
            LastSwooped = DateTime.UtcNow;
            Utils.Unmorph(Player);
            Player.myRend().color = Color.white;
        }
    }
}