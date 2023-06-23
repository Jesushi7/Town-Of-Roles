using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using System.Linq;
using TownOfRoles.Roles;
using TownOfRoles.Roles.Modifiers;

namespace TownOfRoles
{
    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameEnd))]
    public class AmongUsClient_OnGameEnd
    {
        public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] EndGameResult endGameResult)
        {
            Utils.potentialWinners.Clear();
            foreach (var player in PlayerControl.AllPlayerControls)
                Utils.potentialWinners.Add(new WinningPlayerData(player.Data));
        }
    }

    [HarmonyPatch(typeof(EndGameManager), nameof(EndGameManager.Start))]
    public class EndGameManager_SetEverythingUp
    {
        public static void Prefix()
        {
            var toRemoveColorIds = Role.AllRoles.Where(o => o.LostByRPC).Select(o => o.Player.Data.DefaultOutfit.ColorId).ToArray();
            var toRemoveWinners = TempData.winners.ToArray().Where(o => toRemoveColorIds.Contains(o.ColorId)).ToArray();
            for (int i = 0; i < toRemoveWinners.Count(); i++)
            {
                TempData.winners.Remove(toRemoveWinners[i]);
            }

            if (Role.NobodyWins)
            {
                TempData.winners = new List<WinningPlayerData>();
                return;
            }
            foreach (var role in Role.AllRoles)
            {
                var type = role.RoleType;

                if (type == RoleEnum.Jester)
                {
                    var jester = (Jester)role;
                    if (jester.VotedOut)
                    {
                        var winners = Utils.potentialWinners.Where(x => x.PlayerName == jester.PlayerName).ToList();
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners)
                        {
                            win.IsDead = false;
                            TempData.winners.Add(win);
                        }
                        return;
                    }
                }
                else if (type == RoleEnum.Executioner)
                {
                    var executioner = (Executioner)role;
                    if (executioner.TargetVotedOut)
                    {
                        var winners = Utils.potentialWinners.Where(x => x.PlayerName == executioner.PlayerName).ToList();
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners) TempData.winners.Add(win);
                        return;
                    }
                }                   
            }
            foreach (var role in Role.AllRoles)
            {
                var type = role.RoleType;

                if (type == RoleEnum.Glitch)
                {
                    var glitch = (Glitch)role;
                    if (glitch.GlitchWins)
                    {
                        var winners = Utils.potentialWinners.Where(x => x.PlayerName == glitch.PlayerName).ToList();
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners) TempData.winners.Add(win);
                        return;
                    }
                }
                else if (type == RoleEnum.Juggernaut)
                {
                    var juggernaut = (Juggernaut)role;
                    if (juggernaut.JuggernautWins)
                    {
                        var winners = Utils.potentialWinners.Where(x => x.PlayerName == juggernaut.PlayerName).ToList();
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners) TempData.winners.Add(win);
                        return;
                    }
                }
      
                else if (type == RoleEnum.SerialKiller)
                {
                    var SerialKiller = (SerialKiller)role;
                    if (SerialKiller.SerialKillerWins)
                    {
                        var winners = Utils.potentialWinners.Where(x => x.PlayerName == SerialKiller.PlayerName).ToList();
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners) TempData.winners.Add(win);
                        return;
                    }
                }                
                else if (type == RoleEnum.Pyromaniac)
                {
                    var arsonist = (Pyromaniac)role;
                    if (arsonist.PyromaniacWins)
                    {
                        var winners = Utils.potentialWinners.Where(x => x.PlayerName == arsonist.PlayerName).ToList();
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners) TempData.winners.Add(win);
                        return;
                    }
                }
                else if (type == RoleEnum.Plaguebearer)
                {
                    var plaguebearer = (Plaguebearer)role;
                    if (plaguebearer.PlaguebearerWins)
                    {
                        var winners = Utils.potentialWinners.Where(x => x.PlayerName == plaguebearer.PlayerName).ToList();
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners) TempData.winners.Add(win);
                        return;
                    }
                }
                else if (type == RoleEnum.Pestilence)
                {
                    var pestilence = (Pestilence)role;
                    if (pestilence.PestilenceWins)
                    {
                        var winners = Utils.potentialWinners.Where(x => x.PlayerName == pestilence.PlayerName).ToList();
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners) TempData.winners.Add(win);
                        return;
                    }
                }
                else if (type == RoleEnum.Werewolf)
                {
                    var werewolf = (Werewolf)role;
                    if (werewolf.WerewolfWins)
                    {
                        var winners = Utils.potentialWinners.Where(x => x.PlayerName == werewolf.PlayerName).ToList();
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners) TempData.winners.Add(win);
                        return;
                    }
                }
                else if (type == RoleEnum.Phantom)
                {
                    var phantom = (Phantom)role;
                    if (phantom.CompletedTasks)
                    {
                        var winners = Utils.potentialWinners.Where(x => x.PlayerName == phantom.PlayerName).ToList();
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners) TempData.winners.Add(win);
                    }
                }
            }

            foreach (var modifier in Modifier.AllModifiers)
            {
                var type = modifier.ModifierType;

                if (type == ModifierEnum.Lover)
                {
                    var lover = (Lover)modifier;
                    if (lover.LoveCoupleWins)
                    {
                        var otherLover = lover.OtherLover;
                        List<WinningPlayerData> winners = new List<WinningPlayerData>();
                        foreach (var player in Utils.potentialWinners)
                        {
                            if (player.PlayerName == lover.PlayerName ||
                               player.PlayerName == otherLover.PlayerName) winners.Add(player);
                        }
                        TempData.winners = new List<WinningPlayerData>();
                        foreach (var win in winners) TempData.winners.Add(win);
                        return;
                    }
                }
            }
        }
    }
}
