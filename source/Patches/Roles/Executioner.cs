using Il2CppSystem.Collections.Generic;
using TownOfRoles.Extensions;
using UnityEngine;

namespace TownOfRoles.Roles
{
    public class Executioner : Role
    {
        public PlayerControl target;
        public bool TargetVotedOut;

        public Executioner(PlayerControl player) : base(player)
        {
            Name = "Executioner";
            StartText = () =>
                target == null ? "<color=#2d4222>Vote... uh..Nevermind</color>" : $"<color=#2d4222>Vote out your target</color>";
            TaskText = () =>
                target == null
                    ? "Vote... uh..Nevermind."
                    : $"Vote out your target!\nTarget: {target.name}";
            Color = Patches.Colors.Executioner;
            RoleType = RoleEnum.Executioner;
            FactionName = "<color=#5c5e5d>Neutral</color>";              
            AddToRoleHistory(RoleType);
            Faction = Faction.Neutral;
            Scale = 1.4f;
        }

        protected override void IntroPrefix(IntroCutscene._ShowTeam_d__36 __instance)
        {
            var exeTeam = new List<PlayerControl>();
            exeTeam.Add(PlayerControl.LocalPlayer);
            __instance.teamToShow = exeTeam;
        }

        internal override bool EABBNOODFGL(LogicGameFlowNormal __instance)
        {
            if (Player.Data.IsDead) return true;
            if (!TargetVotedOut || !target.Data.IsDead) return true;
            Utils.EndGame();
            return false;
        }

        public void Wins()
        {
            if (Player.Data.IsDead || Player.Data.Disconnected) return;
            TargetVotedOut = true;
        }

        public void Loses()
        {
            LostByRPC = true;
        }
    }
}