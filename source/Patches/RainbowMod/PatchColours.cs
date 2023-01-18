using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace TownOfUs.RainbowMod
{
    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.GetString),
        new[] { typeof(StringNames), typeof(Il2CppReferenceArray<Il2CppSystem.Object>) })]
    public class PatchColours
    {
        public static bool Prefix(ref string __result, [HarmonyArgument(0)] StringNames name)
        {
            var newResult = (int)name switch
            {
                999990 => "Watermelon",
                999991 => "Chocolate",
                999992 => "Sky Blue",
                999993 => "Beige",
                999994 => "Hot Pink",
                999995 => "Turquoise",
                999996 => "Liliac",
                999997 => "Olive",
                999998 => "Azure",
                999999 => "Rainbow",
                999910 => "Ice",
                999911 => "Wine",
                999912 => "BlueBerry",
                999913 => "Mint",
                999914 => "Light Purple",
                999915 => "Peach",
                999916 => "Sushi",
                999917 => "Sylveon",
                999918 => "Discussions",
                999919 => "Petrol",
                999920 => "Hannah",
                999921 => "Stormy Blue",
                999922 => "VantaBlack",
                999923 => "Ambar",                                
                999924 => "Light Grape",    
                999925 => "(M)aize Red",  
                999926 => "Sloth",
                999927 => "AD",
                999928 => "Lotty",  
                999929 => "Mom",
                999930 => "Kara",
                999931 => "EurMom",
                999932 => "Donald",
                999933 => "Sen",   
                999934 => "Fizz",


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
