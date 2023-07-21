using System;
using TMPro;
using TownOfRoles.CrewmateRoles.EngineerMod;
namespace TownOfRoles.Roles
{
    public class Engineer : Role
    {
        public float EngiFixPerRound { get; set; }
        public float EngiFixPerGame { get; set; }
        public DateTime LastFix { get; set; }
        public TextMeshPro UsesText;
        public float TimeRemaining;
        public Engineer(PlayerControl player) : base(player)
        {
            Name = "Engineer";
            StartText = () => "<color=#FFA60AFF>Maintain important systems on the ship</color>";
            TaskText = () => CustomGameOptions.GameMode == GameMode.Cultist ? "Vent around" : "Vent and fix sabotages";
            Color = Patches.Colors.Engineer;
            FactionName = "Crewmate";                
            RoleType = RoleEnum.Engineer;
            EngiFixPerRound = CustomGameOptions.EngineerFixPer  ==  EngineerFixPer.Custom ? CustomGameOptions.EngiFixPerRound : 1;
            EngiFixPerGame = CustomGameOptions.EngiFixPerGame;


            AddToRoleHistory(RoleType);
        }

        public float EngineerTimer(DateTime last, float timer)
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - last;
            var num = timer * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}