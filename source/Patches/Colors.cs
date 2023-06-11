using UnityEngine;

namespace TownOfRoles.Patches
{
    class Colors {

        // Crewmate Colors
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
        public static Color32 SerialKiller => new(100, 45, 234, 255); //#642DEAFF        
        public readonly static Color Phantom = new Color(0.4f, 0.16f, 0.38f, 1f);
        public static Color32 Incendiary => new(238, 112, 46, 255); //#ee702e        
        public readonly static Color Amnesiac = new Color(0.5f, 0.7f, 1f, 1f);
        public readonly static Color Juggernaut = new Color(0.55f, 0f, 0.3f, 1f);
        public readonly static Color Guardian = new Color(0.7f, 1f, 1f, 1f);
        public readonly static Color Plaguebearer = new Color(0.9f, 1f, 0.7f, 1f);
        public readonly static Color Pestilence = new Color(0.3f, 0.3f, 0.3f, 1f);
        public readonly static Color Werewolf = new Color(0.66f, 0.4f, 0.16f, 1f);

        //Imposter Colors
        public readonly static Color Impostor = Palette.ImpostorRed;

        //Modifiers
        public readonly static Color32 Lovers = new Color32(232, 57, 185, 255);     

        //extras
        public readonly static Color32 Crewmate = new Color32(140, 255, 255, 255); 
        public readonly static Color32 Neutral = new Color32(99, 99, 99, 255); 

        public readonly static Color32 Modifiers = new Color32(156,190,228, 255);         

    }
}
