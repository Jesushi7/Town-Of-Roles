using System.Collections.Generic;
using System.Linq;
using TMPro;
using TownOfRoles.Patches;
using UnityEngine;
using TownOfRoles.NeutralRoles.ExecutionerMod;
using TownOfRoles.NeutralRoles.GuardianMod;

namespace TownOfRoles.Roles.Modifiers
{
    public class Assassin : Ability
    {
        public Dictionary<byte, (GameObject, GameObject, GameObject, TMP_Text)> Buttons = new Dictionary<byte, (GameObject, GameObject, GameObject, TMP_Text)>();


        private Dictionary<string, Color> ColorMapping = new Dictionary<string, Color>();

        public Dictionary<string, Color> SortedColorMapping;

        public Dictionary<byte, string> Guesses = new Dictionary<byte, string>();


        public Assassin(PlayerControl player) : base(player)
        {
            Name = "Assassin";
            TaskText = () => "Guess and Shoot";
            Color = Patches.Colors.Impostor;
            AbilityType = AbilityEnum.Assassin;

            RemainingKills = CustomGameOptions.AssassinKills;

            // Adds all the roles that have a non-zero chance of being in the game.
            if (CustomGameOptions.MayorOn > 0) ColorMapping.Add("Mayor", Colors.Mayor);
            if (CustomGameOptions.SheriffOn > 0) ColorMapping.Add("Sheriff", Colors.Sheriff);
            if (CustomGameOptions.EngineerOn > 0) ColorMapping.Add("Engineer", Colors.Engineer);
            if (CustomGameOptions.SwapperOn > 0) ColorMapping.Add("Swapper", Colors.Swapper);
            if (CustomGameOptions.MedicOn > 0) ColorMapping.Add("Medic", Colors.Medic);
            if (CustomGameOptions.SnitchOn > 0) ColorMapping.Add("Snitch", Colors.Snitch);
            if (CustomGameOptions.InformantOn > 0) ColorMapping.Add("Informant", Colors.Informant);
            if (CustomGameOptions.AltruistOn > 0) ColorMapping.Add("Altruist", Colors.Altruist);
            if (CustomGameOptions.VeteranOn > 0) ColorMapping.Add("Veteran", Colors.Veteran);
            if (CustomGameOptions.TrackerOn > 0) ColorMapping.Add("Tracker", Colors.Tracker);
            if (CustomGameOptions.TrapperOn > 0) ColorMapping.Add("Trapper", Colors.Trapper);
            if (CustomGameOptions.TransporterOn > 0) ColorMapping.Add("Transporter", Colors.Transporter);
            if (CustomGameOptions.MediumOn > 0) ColorMapping.Add("Medium", Colors.Medium);
            if (CustomGameOptions.MysticOn > 0) ColorMapping.Add("Mystic", Colors.Mystic);        
            if (CustomGameOptions.ImitatorOn > 0) ColorMapping.Add("Imitator", Colors.Imitator);
             if (CustomGameOptions.OracleOn > 0) ColorMapping.Add("Oracle", Colors.Oracle);
            if (CustomGameOptions.CamouflagerOn > 0) ColorMapping.Add("Camouflager", Colors.Chameleon);

                    if (CustomGameOptions.PlaguebearerOn > 0)
                {
                    if (!Player.Is(RoleEnum.Pestilence))
                        ColorMapping.Add("Pestilence", Colors.Pestilence);

                    if (!Player.Is(RoleEnum.Plaguebearer))
                        ColorMapping.Add("Plaguebearer", Colors.Plaguebearer);
                }         
                if (CustomGameOptions.AmnesiacOn > 0 || (CustomGameOptions.ExecutionerOn > 0 && CustomGameOptions.OnTargetDead == OnTargetDead.Amnesiac) || (CustomGameOptions.GuardianOn > 0 && CustomGameOptions.GaOnTargetDeath == BecomeOptions.Amnesiac)) ColorMapping.Add("Amnesiac", Colors.Amnesiac);
                if (CustomGameOptions.GuardianOn > 0) ColorMapping.Add("Guardian", Colors.Guardian);
                if (CustomGameOptions.VultureOn > 0) ColorMapping.Add("Vulture", Colors.Vulture);
                if (CustomGameOptions.ExecutionerOn > 0) ColorMapping.Add("Executioner", Colors.Executioner);
                if (CustomGameOptions.JesterOn > 0 || (CustomGameOptions.ExecutionerOn > 0 && CustomGameOptions.OnTargetDead == OnTargetDead.Jester) || (CustomGameOptions.GuardianOn > 0 && CustomGameOptions.GaOnTargetDeath == BecomeOptions.Jester)) ColorMapping.Add("Jester", Colors.Jester);
                if (CustomGameOptions.PyromaniacOn > 0 && !PlayerControl.LocalPlayer.Is(RoleEnum.Pyromaniac)) ColorMapping.Add("Pyromaniac", Colors.Pyromaniac);
                if (CustomGameOptions.GlitchOn > 0 && !PlayerControl.LocalPlayer.Is(RoleEnum.Glitch)) ColorMapping.Add("The Glitch", Colors.Glitch);
                if (CustomGameOptions.WerewolfOn > 0 && !PlayerControl.LocalPlayer.Is(RoleEnum.Werewolf)) ColorMapping.Add("Werewolf", Colors.Werewolf);
                if (CustomGameOptions.JuggernautOn > 0 && !PlayerControl.LocalPlayer.Is(RoleEnum.Juggernaut)) ColorMapping.Add("Juggernaut", Colors.Juggernaut);
                if (CustomGameOptions.SerialKillerOn > 0 && !PlayerControl.LocalPlayer.Is(RoleEnum.SerialKiller)) ColorMapping.Add("Serial Killer", Colors.SerialKiller);
            
                if (!PlayerControl.LocalPlayer.Is(Faction.Impostors))
                {
                    ColorMapping.Add("Impostor", Colors.Impostor);
                    if (CustomGameOptions.DisguiserOn > 0) ColorMapping.Add("Disguiser", Colors.Impostor);
                    if (CustomGameOptions.VampireOn > 0) ColorMapping.Add("Vampire", Colors.Impostor);
                    if (CustomGameOptions.CultistOn > 0) ColorMapping.Add("Cultist", Colors.Impostor);
                    if (CustomGameOptions.CultistOn > 0) ColorMapping.Add("Follower", Colors.Impostor);
                    if (CustomGameOptions.JanitorOn > 0) ColorMapping.Add("Janitor", Colors.Impostor);
                    if (CustomGameOptions.MorphlingOn > 0) ColorMapping.Add("Morphling", Colors.Impostor);
                    if (CustomGameOptions.MinerOn > 0) ColorMapping.Add("Miner", Colors.Impostor);
                    if (CustomGameOptions.SwooperOn > 0) ColorMapping.Add("Swooper", Colors.Impostor);
                    if (CustomGameOptions.UndertakerOn > 0) ColorMapping.Add("Undertaker", Colors.Impostor);
                    if (CustomGameOptions.EscapistOn > 0) ColorMapping.Add("Escapist", Colors.Impostor);            
                    if (CustomGameOptions.GrenadierOn > 0) ColorMapping.Add("Grenadier", Colors.Impostor);
                    if (CustomGameOptions.SilencerOn > 0) ColorMapping.Add("Silencer", Colors.Impostor);
                    if (CustomGameOptions.BomberOn > 0) ColorMapping.Add("Bomber", Colors.Impostor);
                    if (CustomGameOptions.UnderdogOn > 0) ColorMapping.Add("Underdog", Colors.Impostor);
                    if (CustomGameOptions.DisperserOn > 0) ColorMapping.Add("Disperser", Colors.Impostor);                 
                }
            // Add extra options if the options are on
            if (CustomGameOptions.AssassinCrewmateGuess) ColorMapping.Add("Crewmate", Colors.Crewmate);
            if (CustomGameOptions.AssassinGuessModifiers && CustomGameOptions.BaitOn > 0) ColorMapping.Add("Bait", Colors.Modifiers);
            if (CustomGameOptions.AssassinGuessModifiers && CustomGameOptions.BlindOn > 0) ColorMapping.Add("Blind", Colors.Modifiers);
            if (CustomGameOptions.AssassinGuessModifiers && CustomGameOptions.DiseasedOn > 0) ColorMapping.Add("Diseased", Colors.Modifiers);
            if (CustomGameOptions.AssassinGuessModifiers && CustomGameOptions.MultitaskerOn > 0) ColorMapping.Add("Multitasker", Colors.Modifiers);
            if (CustomGameOptions.AssassinGuessModifiers && CustomGameOptions.NightowlOn > 0) ColorMapping.Add("Nightowl", Colors.Modifiers);
            if (CustomGameOptions.AssassinGuessModifiers && CustomGameOptions.LighterOn > 0) ColorMapping.Add("Lighter", Colors.Modifiers);            
            if (CustomGameOptions.AssassinGuessSpy && CustomGameOptions.SpyOn > 0) ColorMapping.Add("Spy", Colors.Modifiers); 
            if (CustomGameOptions.AssassinGuessButtonBarry && CustomGameOptions.ButtonBarryOn > 0) ColorMapping.Add("Button Barry", Colors.Modifiers);                         
            if (CustomGameOptions.AssassinGuessLovers && CustomGameOptions.LoversOn > 0) ColorMapping.Add("Lover", Colors.Lovers);

            // Sorts the list alphabetically. 
            SortedColorMapping = ColorMapping.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        public bool GuessedThisMeeting { get; set; } = false;

        public int RemainingKills { get; set; }

        public List<string> PossibleGuesses => SortedColorMapping.Keys.ToList();
    }
}
