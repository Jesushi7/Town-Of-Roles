using UnityEngine;
using System.Collections.Generic;
using TownOfRoles.Extensions;

namespace TownOfRoles.Roles.Modifiers
{
    public class ChameleonModifier : Modifier
    {
        public bool Faded;
        public ChameleonModifier(PlayerControl player) : base(player)
        {
            Name = "Chameleon";
            TaskText = () => "You are hard to see";
            Color = Patches.Colors.Modifiers;
            ModifierType = ModifierEnum.ChameleonModifier;
        }

        public void Fade()
        {
            Faded = true;
            Player.Visible = true;
            var color = new Color(1f, 1f, 1f, 0f);
            var modifier = Modifier.GetModifier<ChameleonModifier>(PlayerControl.LocalPlayer);

            var maxDistance = ShipStatus.Instance.MaxLightRadius * GameOptionsManager.Instance.currentNormalGameOptions.CrewLightMod;

            if (PlayerControl.LocalPlayer == null)
                return;

            var distance = (PlayerControl.LocalPlayer.GetTruePosition() - Player.GetTruePosition()).magnitude;

            var distPercent = distance / maxDistance;
            distPercent = Mathf.Max(0, distPercent - 1);
            
            var velocity = Player.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            if (!modifier.Player.inVent) color.a = 0.07f + velocity / Player.MyPhysics.GhostSpeed * 0.13f;
            color.a = Mathf.Lerp(color.a, 0, distPercent);


            if (Player.GetCustomOutfitType() != CustomPlayerOutfitType.PlayerNameOnly)
            {
                Player.SetOutfit(CustomPlayerOutfitType.PlayerNameOnly, new GameData.PlayerOutfit()
                {
                    ColorId = Player.GetDefaultOutfit().ColorId,
                    HatId = "",
                    SkinId = "",
                    VisorId = "",
                    PlayerName = ""
                });
            }
            Player.myRend().color = color;
            Player.nameText().color = Color.clear;
            Player.cosmetics.colorBlindText.color = Color.clear;
        }
    }
}