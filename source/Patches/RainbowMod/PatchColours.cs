using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace TownOfSushi.RainbowMod
{
    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.GetString),
        new[] { typeof(StringNames), typeof(Il2CppReferenceArray<Il2CppSystem.Object>) })]
    public class PatchColours
    {
        public static bool Prefix(ref string __result, [HarmonyArgument(0)] StringNames name)
        {
            var newResult = (int)name switch
            {
                999983 => "Watermelon",
                999984 => "Chocolate",
                999985 => "Sky Blue",
                999986 => "Beige",
                999987 => "Magenta",
                999988 => "Turquoise",
                999989 => "Lilac",
                999990 => "Olive",
                999991 => "Azure",
                999992 => "Plum",
                999993 => "Jungle",
                999994 => "Mint",
                999995 => "Chartreuse",
                999996 => "Macau",
                999997 => "Tawny",
                999998 => "Gold",
                999999 => "Rainbow",
                //TOR Colors
                000001 => "Sloth",     
                000002 => "Northie :)",     
                000003 => "Darkness",   
                000004 => "Juggernaut",    
                000005 => "RaLu",   
                000006 => "Diddly",         
                000007 => "Hannah",     
                000008 => "Poop Color",    
                000009 => "Burnishe Bronze",              
                000010 => "Lotty",      
                000011 => "Snax",        
                000012=> "GGamer",  
                000013=> "Blackberry",                                                                                                                                         
                _ => null
            };
            if (newResult != null)
            {
                __result = newResult;
                return false;
            }

            return true;
        }
    }
}
