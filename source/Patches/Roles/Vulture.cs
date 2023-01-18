/*using System;
using Hazel;
using System.Collections.Generic;
using TownOfUs.CustomOption;
using TownOfUs.Extensions;
using TownOfUs.Patches;
using System.Linq;
using TownOfUs.NeutralRoles.VultureMod;
using Object = UnityEngine.Object;

namespace TownOfUs.Roles
{
    public class Vulture : Role
    {
        private KillButton _eatButton;
        public DeadBody CurrentTarget { get; set; }
        public float EatNeed;
        public string body;
        public bool VultureWin;
        public DateTime LastEaten { get; set; }
        public Dictionary<byte, ArrowBehaviour> BodyArrows = new Dictionary<byte, ArrowBehaviour>();
        
        public Vulture(PlayerControl player) : base(player)
        {
            Name = "Vulture";
            ImpostorText = () => "Eat dead bodies to win";
            TaskText = () => "Eat Bodies to win";
            Color = Patches.Colors.Executioner;
            RoleType = RoleEnum.Vulture;
            EatNeed = CustomGameOptions.VultureBodies;
            AddToRoleHistory(RoleType);
        }
        
        internal override bool EABBNOODFGL(ShipStatus __instance)
        {
            if (Player.Data.IsDead || Player.Data.Disconnected)
                return true;

            else if (EatNeed == 0)
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte) CustomRPC.VultureWin,
                    SendOption.Reliable, -1);
                writer.Write(Player.PlayerId);
                Wins();
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                Utils.EndGame();
                return false;
            }

            return true;
        }

        public void Wins()
        {
            VultureWin = true;
        }
        public void Loses()
        {
            LostByRPC = true;
        }

        public float EatTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastEaten;
            var num = CustomGameOptions.VultureCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;

            if (flag2)
                return 0;

            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }


        public KillButton EatButton
        {
            get => _eatButton;
            set
            {
                _eatButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public void DestroyArrow(byte targetPlayerId)
        {
            var arrow = BodyArrows.FirstOrDefault(x => x.Key == targetPlayerId);

            if (arrow.Value != null)
                Object.Destroy(arrow.Value);
            if (arrow.Value.gameObject != null)
                Object.Destroy(arrow.Value.gameObject);
                
            BodyArrows.Remove(arrow.Key);
        }
    }
}*/