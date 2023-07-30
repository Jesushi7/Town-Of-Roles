using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using Reactor.Utilities.Extensions;
using TownOfSushi.Roles;
using TownOfSushi.Extensions;
using AmongUs.GameOptions;
using TownOfSushi.Patches.ScreenEffects;
using TMPro;
using System.IO;
using UObject = UnityEngine.Object;

namespace TownOfSushi.Patches {

    static class AdditionalTempData {
        public static List<PlayerRoleInfo> playerRoles = new List<PlayerRoleInfo>();

        public static void clear() {
            playerRoles.Clear();
        }

        internal class PlayerRoleInfo {
            public string PlayerName { get; set; }
            public string Role {get;set;}
        }

    }


    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameEnd))]
    public class OnGameEndPatch {

        public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] EndGameResult endGameResult)
        {
            if (CameraEffect.singleton) CameraEffect.singleton.materials.Clear();
            AdditionalTempData.clear();
            var playerRole = "";
            // Theres a better way of doing this e.g. switch statement or dictionary. But this works for now.
            foreach (var playerControl in PlayerControl.AllPlayerControls)
            {
                playerRole = "";
                foreach (var role in Role.RoleHistory.Where(x => x.Key == playerControl.PlayerId))
                {
                    if (role.Value == RoleEnum.Crewmate) { playerRole += "<color=#" + Patches.Colors.Crewmate.ToHtmlStringRGBA() + ">Crewmate</color> > "; }
                    else if (role.Value == RoleEnum.Impostor) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Impostor</color> > "; }
                    else if (role.Value == RoleEnum.Altruist) { playerRole += "<color=#" + Patches.Colors.Altruist.ToHtmlStringRGBA() + ">Altruist</color> > "; }
                    else if (role.Value == RoleEnum.Engineer) { playerRole += "<color=#" + Patches.Colors.Engineer.ToHtmlStringRGBA() + ">Engineer</color> > "; }
                    else if (role.Value == RoleEnum.Monarch) { playerRole += "<color=#" + Patches.Colors.Monarch.ToHtmlStringRGBA() + ">Monarch</color> > "; }
                    else if (role.Value == RoleEnum.Medic) { playerRole += "<color=#" + Patches.Colors.Medic.ToHtmlStringRGBA() + ">Medic</color> > "; }
                    else if (role.Value == RoleEnum.Sheriff) { playerRole += "<color=#" + Patches.Colors.Sheriff.ToHtmlStringRGBA() + ">Sheriff</color> > "; }
                    else if (role.Value == RoleEnum.Swapper) { playerRole += "<color=#" + Patches.Colors.Swapper.ToHtmlStringRGBA() + ">Swapper</color> > "; }
                    else if (role.Value == RoleEnum.Snitch || role.Value == RoleEnum.CultistSnitch) { playerRole += "<color=#" + Patches.Colors.Snitch.ToHtmlStringRGBA() + ">Snitch</color> > "; }
                    else if (role.Value == RoleEnum.Informant || role.Value == RoleEnum.CultistInformant) { playerRole += "<color=#" + Patches.Colors.Informant.ToHtmlStringRGBA() + ">Informant</color> > "; }
                    else if (role.Value == RoleEnum.Mayor) { playerRole += "<color=#" + Patches.Colors.Mayor.ToHtmlStringRGBA() + ">Mayor</color> > "; }
                    else if (role.Value == RoleEnum.Vigilante) { playerRole += "<color=#" + Patches.Colors.Vigilante.ToHtmlStringRGBA() + ">Vigilante</color> > "; }
                    else if (role.Value == RoleEnum.Arsonist) { playerRole += "<color=#" + Patches.Colors.Arsonist.ToHtmlStringRGBA() + ">Arsonist</color> > "; }
                    else if (role.Value == RoleEnum.Executioner) { playerRole += "<color=#" + Patches.Colors.Executioner.ToHtmlStringRGBA() + ">Executioner</color> > "; }
                    else if (role.Value == RoleEnum.Glitch) { playerRole += "<color=#" + Patches.Colors.Glitch.ToHtmlStringRGBA() + ">The Glitch</color> > "; }
                    else if (role.Value == RoleEnum.Jester) { playerRole += "<color=#" + Patches.Colors.Jester.ToHtmlStringRGBA() + ">Jester</color> > "; }
                    else if (role.Value == RoleEnum.Phantom) { playerRole += "<color=#" + Patches.Colors.Phantom.ToHtmlStringRGBA() + ">Phantom</color> > "; }
                    else if (role.Value == RoleEnum.Grenadier) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Grenadier</color> > "; }
                    else if (role.Value == RoleEnum.Janitor) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Janitor</color> > "; }
                    else if (role.Value == RoleEnum.Miner) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Miner</color> > "; }
                    else if (role.Value == RoleEnum.Morphling) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Morphling</color> > "; }
                    else if (role.Value == RoleEnum.Swooper) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Swooper</color> > "; }
                    else if (role.Value == RoleEnum.Undertaker) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Undertaker</color> > "; }
                    else if (role.Value == RoleEnum.Avenger) { playerRole += "<color=#" + Patches.Colors.Avenger.ToHtmlStringRGBA() + ">Avenger</color> > "; }
                    else if (role.Value == RoleEnum.Veteran) { playerRole += "<color=#" + Patches.Colors.Veteran.ToHtmlStringRGBA() + ">Veteran</color> > "; }
                    else if (role.Value == RoleEnum.Amnesiac) { playerRole += "<color=#" + Patches.Colors.Amnesiac.ToHtmlStringRGBA() + ">Amnesiac</color> > "; }
                    else if (role.Value == RoleEnum.Juggernaut) { playerRole += "<color=#" + Patches.Colors.Juggernaut.ToHtmlStringRGBA() + ">Juggernaut</color> > "; }
                    else if (role.Value == RoleEnum.Tracker) { playerRole += "<color=#" + Patches.Colors.Tracker.ToHtmlStringRGBA() + ">Tracker</color> > "; }
                    else if (role.Value == RoleEnum.Transporter) { playerRole += "<color=#" + Patches.Colors.Transporter.ToHtmlStringRGBA() + ">Transporter</color> > "; }
                    else if (role.Value == RoleEnum.Traitor) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Traitor</color> > "; }
                    else if (role.Value == RoleEnum.Medium) { playerRole += "<color=#" + Patches.Colors.Medium.ToHtmlStringRGBA() + ">Medium</color> > "; }
                    else if (role.Value == RoleEnum.Trapper) { playerRole += "<color=#" + Patches.Colors.Trapper.ToHtmlStringRGBA() + ">Trapper</color> > "; }
                    else if (role.Value == RoleEnum.Survivor) { playerRole += "<color=#" + Patches.Colors.Survivor.ToHtmlStringRGBA() + ">Survivor</color> > "; }
                    else if (role.Value == RoleEnum.GuardianAngel) { playerRole += "<color=#" + Patches.Colors.GuardianAngel.ToHtmlStringRGBA() + ">Guardian Angel</color> > "; }
                    else if (role.Value == RoleEnum.Mystic || role.Value == RoleEnum.CultistMystic) { playerRole += "<color=#" + Patches.Colors.Mystic.ToHtmlStringRGBA() + ">Mystic</color> > "; }
                    else if (role.Value == RoleEnum.Blackmailer) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Blackmailer</color> > "; }
                    else if (role.Value == RoleEnum.Plaguebearer) { playerRole += "<color=#" + Patches.Colors.Plaguebearer.ToHtmlStringRGBA() + ">Plaguebearer</color> > "; }
                    else if (role.Value == RoleEnum.Pestilence) { playerRole += "<color=#" + Patches.Colors.Pestilence.ToHtmlStringRGBA() + ">Pestilence</color> > "; }
                    else if (role.Value == RoleEnum.Werewolf) { playerRole += "<color=#" + Patches.Colors.Werewolf.ToHtmlStringRGBA() + ">Werewolf</color> > "; }
                    else if (role.Value == RoleEnum.Detective) { playerRole += "<color=#" + Patches.Colors.Detective.ToHtmlStringRGBA() + ">Detective</color> > "; }
                    else if (role.Value == RoleEnum.Escapist) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Escapist</color> > "; }
                    else if (role.Value == RoleEnum.Necromancer) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Necromancer</color> > "; }
                    else if (role.Value == RoleEnum.Whisperer) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Whisperer</color> > "; }
                    else if (role.Value == RoleEnum.Chameleon) { playerRole += "<color=#" + Patches.Colors.Chameleon.ToHtmlStringRGBA() + ">Chameleon</color> > "; }
                    else if (role.Value == RoleEnum.Camouflager) { playerRole += "<color=#" + Patches.Colors.Camouflager.ToHtmlStringRGBA() + ">Camouflager</color> > "; }
                    else if (role.Value == RoleEnum.Imitator) { playerRole += "<color=#" + Patches.Colors.Imitator.ToHtmlStringRGBA() + ">Imitator</color> > "; }
                    else if (role.Value == RoleEnum.Bomber) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Bomber</color> > "; }
                    else if (role.Value == RoleEnum.Doomsayer) { playerRole += "<color=#" + Patches.Colors.Doomsayer.ToHtmlStringRGBA() + ">Doomsayer</color> > "; }
                    else if (role.Value == RoleEnum.Vampire) { playerRole += "<color=#" + Patches.Colors.Vampire.ToHtmlStringRGBA() + ">Vampire</color> > "; }
                    else if (role.Value == RoleEnum.VampireHunter) { playerRole += "<color=#" + Patches.Colors.VampireHunter.ToHtmlStringRGBA() + ">Vampire Hunter</color> > "; }
                    else if (role.Value == RoleEnum.Prosecutor) { playerRole += "<color=#" + Patches.Colors.Prosecutor.ToHtmlStringRGBA() + ">Prosecutor</color> > "; }
                    else if (role.Value == RoleEnum.Warlock) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Warlock</color> > "; }
                    else if (role.Value == RoleEnum.Oracle) { playerRole += "<color=#" + Patches.Colors.Oracle.ToHtmlStringRGBA() + ">Oracle</color> > "; }
                    else if (role.Value == RoleEnum.Venerer) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Venerer</color> > "; }
                    else if (role.Value == RoleEnum.Aurial) { playerRole += "<color=#" + Patches.Colors.Aurial.ToHtmlStringRGBA() + ">Aurial</color> > "; }
                    if (CustomGameOptions.GameMode == GameMode.Cultist && playerControl.Data.IsImpostor())
                    {
                        if (role.Value == RoleEnum.Engineer) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Demolitionist</color> > "; }
                        else if (role.Value == RoleEnum.CultistMystic) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Clairvoyant</color> > "; }
                        else if (role.Value == RoleEnum.CultistInformant) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Informant</color> > "; }
                        else if (role.Value == RoleEnum.Vigilante) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Assassin</color> > "; }
                    }
                }
                playerRole = playerRole.Remove(playerRole.Length - 3);

                if (playerControl.Is(ModifierEnum.Giant))
                {
                    playerRole += " (<color=#" + Patches.Colors.Giant.ToHtmlStringRGBA() + ">Giant</color>)";
                }
                else if (playerControl.Is(ModifierEnum.ButtonBarry))
                {
                    playerRole += " (<color=#" + Patches.Colors.ButtonBarry.ToHtmlStringRGBA() + ">Button Barry</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Aftermath))
                {
                    playerRole += " (<color=#" + Patches.Colors.Aftermath.ToHtmlStringRGBA() + ">Aftermath</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Bait))
                {
                    playerRole += " (<color=#" + Patches.Colors.Bait.ToHtmlStringRGBA() + ">Bait</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Diseased))
                {
                    playerRole += " (<color=#" + Patches.Colors.Diseased.ToHtmlStringRGBA() + ">Diseased</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Spy))
                {
                    playerRole += " (<color=#" + Patches.Colors.Spy.ToHtmlStringRGBA() + ">Spy</color>)";
                }                
                else if (playerControl.Is(ModifierEnum.Lighter))
                {
                    playerRole += " (<color=#" + Patches.Colors.Lighter.ToHtmlStringRGBA() + ">Lighter</color>)";
                }                    
                else if (playerControl.Is(ModifierEnum.Flash))
                {
                    playerRole += " (<color=#" + Patches.Colors.Flash.ToHtmlStringRGBA() + ">Flash</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Drunk))
                {
                    playerRole += " (<color=#" + Patches.Colors.Drunk.ToHtmlStringRGBA() + ">Drunk</color>)";
                }                 
                else if (playerControl.Is(ModifierEnum.Tiebreaker))
                {
                    playerRole += " (<color=#" + Patches.Colors.Tiebreaker.ToHtmlStringRGBA() + ">Tiebreaker</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Nightowl))
                {
                    playerRole += " (<color=#" + Patches.Colors.Nightowl.ToHtmlStringRGBA() + ">Nightowl</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Mini))
                {
                    playerRole += " (<color=#" + Patches.Colors.Mini.ToHtmlStringRGBA() + ">Mini</color>)";
                }                
                else if (playerControl.Is(ModifierEnum.Lover))
                {
                    playerRole += " (<color=#" + Patches.Colors.Lovers.ToHtmlStringRGBA() + ">Lover</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Sleuth))
                {
                    playerRole += " (<color=#" + Patches.Colors.Sleuth.ToHtmlStringRGBA() + ">Sleuth</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Watcher))
                {
                    playerRole += " (<color=#" + Patches.Colors.Watcher.ToHtmlStringRGBA() + ">Watcher</color>)";
                }                
                else if (playerControl.Is(ModifierEnum.Paranoiac))
                {
                    playerRole += " (<color=#" + Patches.Colors.Paranoiac.ToHtmlStringRGBA() + ">Paranoiac</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Disperser))
                {
                    playerRole += " (<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Disperser</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Multitasker))
                {
                    playerRole += " (<color=#" + Patches.Colors.Multitasker.ToHtmlStringRGBA() + ">Multitasker</color>)";
                }
                else if (playerControl.Is(ModifierEnum.DoubleShot))
                {
                    playerRole += " (<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Double Shot</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Underdog))
                {
                    playerRole += " (<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Underdog</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Frosty))
                {
                    playerRole += " (<color=#" + Patches.Colors.Frosty.ToHtmlStringRGBA() + ">Frosty</color>)";
                }
                var player = Role.GetRole(playerControl);
                if (playerControl.Is(RoleEnum.Phantom) || playerControl.Is(Faction.Crewmates))
                {
                    if ((player.TotalTasks - player.TasksLeft)/player.TotalTasks == 1) playerRole += " | Tasks: <color=#" + Color.green.ToHtmlStringRGBA() + $">{player.TotalTasks - player.TasksLeft}/{player.TotalTasks}</color>";
                    else playerRole += $" | Tasks: {player.TotalTasks - player.TasksLeft}/{player.TotalTasks}";
                }
                if (player.Kills > 0 && !playerControl.Is(Faction.Crewmates))
                {
                    playerRole += " |<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + $"> Kills: {player.Kills}</color>";
                }
                if (player.CorrectKills > 0)
                {
                    playerRole += " |<color=#" + Color.green.ToHtmlStringRGBA() + $"> Correct Kills: {player.CorrectKills}</color>";
                }
                if (player.IncorrectKills > 0)
                {
                    playerRole += " |<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + $"> Incorrect Kills: {player.IncorrectKills}</color>";
                }
                if (player.CorrectAssassinKills > 0)
                {
                    playerRole += " |<color=#" + Color.green.ToHtmlStringRGBA() + $"> Correct Guesses: {player.CorrectAssassinKills}</color>";
                }
                if (player.IncorrectAssassinKills > 0)
                {
                    playerRole += " |<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + $"> Incorrect Guesses: {player.IncorrectAssassinKills}</color>";
                }
                AdditionalTempData.playerRoles.Add(new AdditionalTempData.PlayerRoleInfo() { PlayerName = playerControl.Data.PlayerName, Role = playerRole });
            }
        }
    }

        [HarmonyPatch(typeof(EndGameManager), nameof(EndGameManager.SetEverythingUp))]
        public static class ShipStatusSetUpPatch
        {
            public static void Postfix(EndGameManager __instance)
            {
                if (GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.HideNSeek)
                    return;

                var position = Camera.main.ViewportToWorldPoint(new(0f, 1f, Camera.main.nearClipPlane));
                var roleSummary = UObject.Instantiate(__instance.WinText.gameObject);
                roleSummary.transform.position = new(__instance.Navigation.ExitButton.transform.position.x + 0.1f, position.y - 0.1f, -14f);
                roleSummary.transform.localScale = new(1f, 1f, 1f);

                var roleSummaryText = new StringBuilder();
                var roleSummaryCache = new StringBuilder();
                var winnersText = new StringBuilder();
                var winnersCache = new StringBuilder();
                var losersText = new StringBuilder();
                var losersCache = new StringBuilder();
                var discText = new StringBuilder();
                var discCache = new StringBuilder();

                var winnerCount = 0;
                var loserCount = 0;
                var discCount = 0;

                roleSummaryText.AppendLine("<size=125%><u><b>End Game Summary</b></u>:</size>");
                roleSummaryText.AppendLine();
                roleSummaryCache.AppendLine("End Game Summary:");
                roleSummaryCache.AppendLine();
                winnersText.AppendLine("<size=105%><b>Winners</b></size>");
                losersText.AppendLine("<size=105%><b>Losers</b></size>");
                winnersCache.AppendLine("Winners");
                losersCache.AppendLine("Losers");
                discCache.AppendLine("Disconnected");

                foreach (var data in AdditionalTempData.playerRoles)
                {
                    var role = string.Join(" ", data.Role);
                    var dataString = $"<size=75%>{data.PlayerName} - {role}</size>";

                    if (data.PlayerName.IsWinner())
                    {
                        winnersText.AppendLine(dataString);
                        winnerCount++;
                    }
                    else
                    {
                        losersText.AppendLine(dataString);
                        loserCount++;
                    }
                }

                if (winnerCount == 0)
                {
                    winnersText.AppendLine("<size=75%>No One Won</size>");
                    winnersCache.AppendLine("No One Won");
                }

                if (loserCount == 0)
                {
                    losersText.AppendLine("<size=75%>No One Lost</size>");
                    losersCache.AppendLine("No One Lost");
                }

                roleSummaryText.Append(winnersText);
                roleSummaryText.AppendLine();
                roleSummaryText.Append(losersText);
                roleSummaryCache.Append(winnersCache);
                roleSummaryCache.AppendLine();
                roleSummaryCache.Append(losersCache);

                if (discCount > 0)
                {
                    roleSummaryText.AppendLine();
                    roleSummaryText.Append(discText);
                    roleSummaryCache.AppendLine();
                    roleSummaryCache.Append(discCache);
                }

                var roleSummaryTextMesh = roleSummary.GetComponent<TMP_Text>();
                roleSummaryTextMesh.alignment = TextAlignmentOptions.TopLeft;
                roleSummaryTextMesh.color = Color.white;
                roleSummaryTextMesh.fontSizeMin = 1.5f;
                roleSummaryTextMesh.fontSizeMax = 1.5f;
                roleSummaryTextMesh.fontSize = 1.5f;
                roleSummaryTextMesh.text = $"{roleSummaryText}";
                roleSummaryTextMesh.GetComponent<RectTransform>().anchoredPosition = new(position.x + 3.5f, position.y - 0.1f);

                var text = Path.Combine(Application.persistentDataPath, "Summary-temp");

                try
                {
                    File.WriteAllText(text, roleSummaryCache.ToString());
                    var text2 = Path.Combine(Application.persistentDataPath, "Summary");
                    File.Delete(text2);
                    File.Move(text, text2);
                } catch {}
            }
        private static bool IsWinner(this string playerName)
        {
        foreach(var win in TempData.winners)
        {
        if(win.PlayerName == playerName)
        return true;
        }
     return false;
        }            
        }
}