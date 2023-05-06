using System.Collections.Generic;
using System.Linq;
using TMPro;
using TownOfRoles.Patches;
using UnityEngine;
using TownOfRoles.NeutralRoles.ExecutionerMod;
using TownOfRoles.NeutralRoles.GuardianAngelMod;

namespace TownOfRoles.Roles
{
    public class Gambler : Role
    {
        public Dictionary<byte, (GameObject, GameObject, GameObject, TMP_Text)> Buttons = new Dictionary<byte, (GameObject, GameObject, GameObject, TMP_Text)>();

        private Dictionary<string, Color> ColorMapping = new Dictionary<string, Color>();

        public Dictionary<string, Color> SortedColorMapping;

        public Dictionary<byte, string> Guesses = new Dictionary<byte, string>();

        public Gambler(PlayerControl player) : base(player)
        {
            Name = "Gambler";
            StartText = () => "<color=#fce700>Guess And Shoot</color>";
            TaskText = () => "Guess and Shoot";
            Color = Patches.Colors.Gambler;
            FactionName = "<color=#fce700>Crewmate</color>";    
            Faction = Faction.Crewmates;               
            RoleType = RoleEnum.Gambler;
            AddToRoleHistory(RoleType);

            RemainingKills = CustomGameOptions.GamblerKills;

            if (CustomGameOptions.GameMode == GameMode.Classic || CustomGameOptions.GameMode == GameMode.AllAny)
            {
                ColorMapping.Add("Impostor", Colors.Impostor);
                if (CustomGameOptions.JanitorOn > 0) ColorMapping.Add("Janitor", Colors.Janitor);
                if (CustomGameOptions.MorphlingOn > 0) ColorMapping.Add("Morphling", Colors.Morphling);
                if (CustomGameOptions.MinerOn > 0) ColorMapping.Add("Miner", Colors.Miner);
                if (CustomGameOptions.SwooperOn > 0) ColorMapping.Add("Swooper", Colors.Swooper);
                if (CustomGameOptions.UndertakerOn > 0) ColorMapping.Add("Undertaker", Colors.Undertaker);
                if (CustomGameOptions.EscapistOn > 0) ColorMapping.Add("Escapist", Colors.Escapist);
                if (CustomGameOptions.GrenadierOn > 0) ColorMapping.Add("Grenadier", Colors.Grenadier);
                if (CustomGameOptions.TraitorOn > 0) ColorMapping.Add("Traitor", Colors.Impostor);               
                if (CustomGameOptions.SilencerOn > 0) ColorMapping.Add("Silencer", Colors.Silencer);
                if (CustomGameOptions.BomberOn > 0) ColorMapping.Add("Bomber", Colors.Bomber);
                if (CustomGameOptions.UnderdogOn > 0) ColorMapping.Add("Underdog", Colors.Modifiers);
                if (CustomGameOptions.DisperserOn > 0) ColorMapping.Add("Disperser", Colors.Modifiers);  
                              
                if (CustomGameOptions.GamblerGuessNeutrals)
                {
                    if (CustomGameOptions.AmnesiacOn > 0 || (CustomGameOptions.ExecutionerOn > 0 && CustomGameOptions.OnTargetDead == OnTargetDead.Amnesiac) || (CustomGameOptions.GuardianAngelOn > 0 && CustomGameOptions.GaOnTargetDeath == BecomeOptions.Amnesiac)) ColorMapping.Add("Amnesiac", Colors.Amnesiac);
                    if (CustomGameOptions.GuardianAngelOn > 0) ColorMapping.Add("Guardian Angel", Colors.GuardianAngel);
                    if (CustomGameOptions.ExecutionerOn > 0) ColorMapping.Add("Executioner", Colors.Executioner);
                    if (CustomGameOptions.JesterOn > 0 || (CustomGameOptions.ExecutionerOn > 0 && CustomGameOptions.OnTargetDead == OnTargetDead.Jester) || (CustomGameOptions.GuardianAngelOn > 0 && CustomGameOptions.GaOnTargetDeath == BecomeOptions.Jester)) ColorMapping.Add("Jester", Colors.Jester);
                    
                }
                if (CustomGameOptions.GamblerGuessNeutralKilling)
                {
                    if (CustomGameOptions.ArsonistOn > 0) ColorMapping.Add("Arsonist", Colors.Arsonist);
                    if (CustomGameOptions.GlitchOn > 0) ColorMapping.Add("Glitch", Colors.Glitch);
                    if (CustomGameOptions.PlaguebearerOn > 0) ColorMapping.Add("Plaguebearer", Colors.Plaguebearer);
                    if (CustomGameOptions.WerewolfOn > 0) ColorMapping.Add("Werewolf", Colors.Werewolf);
                     if (CustomGameOptions.JuggernautOn > 0) ColorMapping.Add("Juggernaut", Colors.Juggernaut);
                }
                if (CustomGameOptions.GamblerGuessLovers && CustomGameOptions.LoversOn > 0) ColorMapping.Add("Lover", Colors.Lovers);
                if (CustomGameOptions.GamblerGuessLovers && CustomGameOptions.ButtonBarryOn > 0) ColorMapping.Add("Button Barry", Colors.Modifiers);
            }
            else if (CustomGameOptions.GameMode == GameMode.KillingOnly)
            {
                ColorMapping.Add("Morphling", Colors.Morphling);
                ColorMapping.Add("Miner", Colors.Miner);
                ColorMapping.Add("Swooper", Colors.Swooper);
                ColorMapping.Add("Undertaker", Colors.Undertaker);
                ColorMapping.Add("Grenadier", Colors.Grenadier);
                ColorMapping.Add("Traitor", Colors.Impostor);
                ColorMapping.Add("Escapist", Colors.Escapist);

                if (CustomGameOptions.GamblerGuessNeutralKilling)
                {
                    if (CustomGameOptions.AddArsonist) ColorMapping.Add("Arsonist", Colors.Arsonist);
                    if (CustomGameOptions.AddPlaguebearer) ColorMapping.Add("Plaguebearer", Colors.Plaguebearer);
                    ColorMapping.Add("Glitch", Colors.Glitch);
                    ColorMapping.Add("Werewolf", Colors.Werewolf);
                    ColorMapping.Add("Juggernaut", Colors.Juggernaut);
                }
            }
            else
            {
                ColorMapping.Add("Necromancer", Colors.Impostor);
                ColorMapping.Add("Whisperer", Colors.Impostor);
                if (CustomGameOptions.MaxChameleons > 0) ColorMapping.Add("Swooper", Colors.Swooper);
                if (CustomGameOptions.MaxEngineers > 0) ColorMapping.Add("Demolitionist", Colors.Engineer);
                if (CustomGameOptions.MaxMystics > 0) ColorMapping.Add("Clairvoyant", Colors.Mystic);
                if (CustomGameOptions.MaxTransporters > 0) ColorMapping.Add("Escapist", Colors.Escapist);
                if (CustomGameOptions.MaxGamblers > 1) ColorMapping.Add("Assassin", Colors.Gambler);
                ColorMapping.Add("Impostor", Colors.Impostor);
            }

            SortedColorMapping = ColorMapping.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        public bool GuessedThisMeeting { get; set; } = false;

        public int RemainingKills { get; set; }

        public List<string> PossibleGuesses => SortedColorMapping.Keys.ToList();
    }
}
