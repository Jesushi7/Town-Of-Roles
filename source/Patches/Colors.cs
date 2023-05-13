using UnityEngine;

namespace TownOfRoles.Patches
{
    class Colors {

        // Crewmate Colors
        public readonly static Color Crewmate = Color.cyan;  
        public readonly static Color Mayor = new Color(0.44f, 0.31f, 0.66f, 1f);
        public readonly static Color32 Sheriff = new Color32(248, 205, 70, 255); 
        public readonly static Color Engineer = new Color(1f, 0.65f, 0.04f, 1f);
        public readonly static Color32 Swapper = new Color32(134, 55, 86, 255);
        public readonly static Color32 Medic = new Color32(126, 251, 194, 255);      
        public readonly static Color32 Snitch = new Color32(97, 178, 108, 255);
        public readonly static Color Informant = new Color(0.83f, 0.69f, 0.22f, 1f);
        public readonly static Color32 Altruist = new Color32(45, 106, 165, 255); 
        public readonly static Color32 Watcher = new Color32(25, 43, 82, 255); 
        public readonly static Color Veteran = new Color(0.6f, 0.5f, 0.25f, 1f);
        public readonly static Color Avenger = new Color(0.83f, 0.83f, 0.83f, 1f);
        public readonly static Color Tracker = new Color(0f, 0.6f, 0f, 1f);
        public readonly static Color Transporter = new Color(0f, 0.93f, 1f, 1f);
        public readonly static Color Medium = new Color(0.65f, 0.5f, 1f, 1f);
        public readonly static Color32 Mystic = new Color32(77, 77, 255, 255);
        public readonly static Color32 Trapper = new Color32(117, 250, 76, 255);    

        public readonly static Color Imitator = new Color(0.7f, 0.85f, 0.3f, 1f);
        public readonly static Color32 Chameleon = new Color32(112, 142, 239, 255);        

        // Neutral Colors
        public readonly static Color32 Jester = new Color32(203, 129, 192, 255);  
        public static Color32 Scavenger => new(140, 64, 5, 255);
        public readonly static Color32 Executioner = new Color32(45, 66, 34, 255);  
        public readonly static Color Glitch = Color.green;
        public readonly static Color Arsonist = new Color(1f, 0.3f, 0f);
        public readonly static Color Phantom = new Color(0.4f, 0.16f, 0.38f, 1f);
        public readonly static Color Amnesiac = new Color(0.5f, 0.7f, 1f, 1f);
        public readonly static Color Juggernaut = new Color(0.55f, 0f, 0.3f, 1f);
        public readonly static Color GuardianAngel = new Color(0.7f, 1f, 1f, 1f);
        public readonly static Color Plaguebearer = new Color(0.9f, 1f, 0.7f, 1f);
        public readonly static Color Pestilence = new Color(0.3f, 0.3f, 0.3f, 1f);
        public readonly static Color Werewolf = new Color(0.66f, 0.4f, 0.16f, 1f);

        //Imposter Colors
        public readonly static Color Impostor = Palette.ImpostorRed;
        public readonly static Color32 Silencer = new Color32(207, 123, 95, 255); 
        public readonly static Color32 Bomber = new Color32(207, 101, 95, 255);
        public static Color Escapist = new Color32(88, 52, 207, 255); //#5834cf
        public static Color Grenadier = new Color32(207, 196, 186, 255); //#cfc4ba
        public static Color Morphling = new Color32(130, 230, 115, 255); //#82e673
        public static Color Janitor = new Color32(214, 129, 133, 255); //#d68185
        public static Color Miner = new Color32(86, 92, 51, 255); //#565c33         
        public readonly static Color32 Undertaker = new Color32(45, 10, 97, 255);      
        public readonly static Color32 Swooper = new Color32(99, 29, 24, 255);
        public static Color Stealer = new Color32(190, 77, 227, byte.MaxValue);

        //Modifiers
        public readonly static Color32 Lovers = new Color32(232, 57, 185, 255);     

        //extras
        public readonly static Color32 Crew = new Color32(139, 253, 253, 255); 
        public readonly static Color32 Neutral = new Color32(99, 99, 99, 255); 

        public readonly static Color32 Modifiers = new Color32(245, 144, 188, 255);         

    }
}
