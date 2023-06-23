using Hazel;
using InnerNet;
using System;
using System.Linq;
using TownOfRoles.Extensions;
using UnityEngine;

namespace TownOfRoles.Roles
{
    public class SerialKiller : Role
    {
        public KillButton _swoopButton;        
        public bool Enabled;
        public float TimeRemaining;        
        public SerialKiller(PlayerControl owner) : base(owner)
        {
            Name = "Serial Killer";
            Color = Patches.Colors.SerialKiller;
            LastKill = DateTime.UtcNow;
            KillTarget = null;            
            RoleType = RoleEnum.SerialKiller;
            AddToRoleHistory(RoleType);
            StartText = () => "<color=#642DEAFF>Kill everyone in time</color>";
            TaskText = () => "Kill everyone in time";          
            Faction = Faction.Neutral;
            FactionName = "<color=#5c5e5d>Neutral</color>";           
        }
        public KillButton SwoopButton
        {
            get => _swoopButton;
            set
            {
                _swoopButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }
        public PlayerControl ClosestPlayer;
        public DateTime LastKill { get; set; }
        public PlayerControl KillTarget { get; set; }        
        public bool SerialKillerWins { get; set; }

        internal override bool EABBNOODFGL(LogicGameFlowNormal __instance)
        {
            if (Player.Data.IsDead || Player.Data.Disconnected) return true;

            if (PlayerControl.AllPlayerControls.ToArray().Count(x => !x.Data.IsDead && !x.Data.Disconnected) <= 2 &&
                    PlayerControl.AllPlayerControls.ToArray().Count(x => !x.Data.IsDead && !x.Data.Disconnected &&
                    (x.Data.IsImpostor() || x.Is(RoleEnum.Glitch) || x.Is(RoleEnum.Pyromaniac) || x.Is(RoleEnum.Juggernaut) ||
                    x.Is(RoleEnum.Werewolf) || x.Is(RoleEnum.Plaguebearer) || x.Is(RoleEnum.Pestilence))) == 0)
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(
                    PlayerControl.LocalPlayer.NetId,
                    (byte)CustomRPC.SerialKillerWin,
                    SendOption.Reliable,
                    -1
                );
                writer.Write(Player.PlayerId);
                Wins();
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                Utils.EndGame();
                return false;
            }

            return false;
        }
        
        public void Suicide()
        {
            TimeRemaining -= Time.deltaTime;
        }
              
        public void Wins()
        {
            SerialKillerWins = true;
        }

        public void Loses()
        {
            LostByRPC = true;
        }

        public float KillTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastKill;
            var num = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }

        protected override void IntroPrefix(IntroCutscene._ShowTeam_d__36 __instance)
        {
            var SerialKillerteam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
            SerialKillerteam.Add(PlayerControl.LocalPlayer);
            __instance.teamToShow = SerialKillerteam;
        }
    }
}