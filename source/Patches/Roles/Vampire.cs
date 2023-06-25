using System;
using UnityEngine;
using TownOfRoles.Modifiers.UnderdogMod;

namespace TownOfRoles.Roles
{
    public class Vampire : Role

    {
        public KillButton _poisonButton;
        public PlayerControl ClosestPlayer;
        public DateTime LastBitten;
        public PlayerControl BittenPlayer;
        public float TimeRemaining;
        public bool Enabled = false;

        public Vampire(PlayerControl player) : base(player)
        {
            Name = "Vampire";
            StartText = () => "Bite to have delayed kills";
            TaskText = () => "Bite your enemies";
            FactionName = "Impostor";             
            Color = Palette.ImpostorRed;
            LastBitten = DateTime.UtcNow;
            RoleType = RoleEnum.Vampire;
            AddToRoleHistory(RoleType);
            Faction = Faction.Impostors;
            BittenPlayer = null;
        }
        public KillButton BiteButton
        {
            get => _poisonButton;
            set
            {
                _poisonButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }
        public bool Poisoned => TimeRemaining > 0f;
        public void Poison()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
            if (MeetingHud.Instance)
            {
                TimeRemaining = 0;
            }
            if (TimeRemaining <= 0)
            {
                PoisonKill();
            }
        }
        public void PoisonKill()
        {
            if (!BittenPlayer.Is(RoleEnum.Pestilence))
            {
                Utils.RpcMurderPlayer(Player, BittenPlayer);
                if (!BittenPlayer.Data.IsDead) SoundManager.Instance.PlaySound(PlayerControl.LocalPlayer.KillSfx, false, 0.5f);
            }
            BittenPlayer = null;
            Enabled = false;
            LastBitten = DateTime.UtcNow;
        }
        public float BiteTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastBitten;
            var num = GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * 1000f;
            if (Player.Is(ModifierEnum.Underdog))
            {
                num = PerformKill.LastImp() ? (GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown - CustomGameOptions.UnderdogKillBonus) * 1000f :
                    (PerformKill.IncreasedKC() ?GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown * 1000 : (GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown + CustomGameOptions.UnderdogKillBonus) * 1000);
            }
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}