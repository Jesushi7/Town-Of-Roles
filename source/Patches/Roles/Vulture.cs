using System;
using TMPro;
using Hazel;

namespace TownOfRoles.Roles
{
    public class Vulture : Role
    {
        public KillButton _cleanButton;
        public DateTime LastEat { get; set; }
        public int EatNeeded;
        public bool VultureWins;
        public TextMeshPro UsesText;

        public Vulture(PlayerControl player) : base(player)
        {
            EatNeeded = CustomGameOptions.EatNeeded == 0 ? PlayerControl.AllPlayerControls._size / 4 : CustomGameOptions.EatNeeded;
            string body = EatNeeded == 1 ? "body" : "bodies";
            Name = "Vulture";
            FactionName = "<color=#5c5e5d>Neutral</color>";            
            StartText = () => "<color=#8C4005FF>Eat dead bodies to win</color>";
            TaskText = () => $"Eat {EatNeeded} dead {body} to win";
            Color = Patches.Colors.Vulture;
            RoleType = RoleEnum.Vulture;
            AddToRoleHistory(RoleType);
            Faction = Faction.Neutral;
        }
        public DeadBody CurrentTarget { get; set; }

        public KillButton CleanButton
        {
            get => _cleanButton;
            set
            {
                _cleanButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }
        internal override bool EABBNOODFGL(LogicGameFlowNormal __instance)
        {
            if (Player.Data.IsDead || Player.Data.Disconnected || EatNeeded > 0) return true;
            MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte) CustomRPC.VultureWin, SendOption.Reliable, -1);
            writer.Write(Player.PlayerId);
            Wins();
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            Utils.EndGame();
            return false;
        }
        public void Wins()
        {
            VultureWins = true;
        }

        public void Loses()
        {
            LostByRPC = true;
        }

        protected override void IntroPrefix(IntroCutscene._ShowTeam_d__36 __instance)
        {
            var cannibalTeam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
            cannibalTeam.Add(PlayerControl.LocalPlayer);
            __instance.teamToShow = cannibalTeam;
        }

        public float EatTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastEat;
            var num = CustomGameOptions.VultureCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}