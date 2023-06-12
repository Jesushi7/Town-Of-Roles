using UnityEngine;

namespace TownOfRoles.ColorsMod
{
    public static class PalettePatch
    {
        public static void Load()
        {
            Palette.ColorNames = new[]
            {
                StringNames.ColorRed,
                StringNames.ColorBlue,
                StringNames.ColorGreen,
                StringNames.ColorPink,
                StringNames.ColorOrange,
                StringNames.ColorYellow,
                StringNames.ColorBlack,
                StringNames.ColorWhite,
                StringNames.ColorPurple,
                StringNames.ColorBrown,
                StringNames.ColorCyan,
                StringNames.ColorLime,
                StringNames.ColorMaroon,
                StringNames.ColorRose,
                StringNames.ColorBanana,
                StringNames.ColorGray,
                StringNames.ColorTan,
                StringNames.ColorCoral,
                // New colours
                (StringNames)999983,//"Watermelon",
                (StringNames)999984,//"Chocolate",
                (StringNames)999985,//"Sky Blue",
                (StringNames)999986,//"Beige",
                (StringNames)999987,//"Magenta",
                (StringNames)999988,//"Turquoise",
                (StringNames)999989,//"Lilac",
                (StringNames)999990,//"Olive",
                (StringNames)999991,//"Azure",
                (StringNames)999992,//"Plum",
                (StringNames)999993,//"Jungle",
                (StringNames)999994,//"Mint",
                (StringNames)999995,//"Chartreuse",
                (StringNames)999996,//"Macau",
                (StringNames)999997,//"Gold",
                (StringNames)999998,//"Tawny",
                (StringNames)999999,//"Rainbow",
                (StringNames)222222,//"Ice",                
                (StringNames)222221,//"Sunrise",
                (StringNames)222223,//Northie
                (StringNames)222224,//RaLu   
                (StringNames)222225,//Fizz  
                (StringNames)222226,//GGamer    
                (StringNames)222227,//snax    
                (StringNames)222228,//lotty   
                (StringNames)222229,//Bordeaux  
                (StringNames)222210,//peach    
                (StringNames)222211,//Signal Orange                    
            };
            Palette.PlayerColors = new[]
            {
                new Color32(198, 17, 17, byte.MaxValue),
                new Color32(19, 46, 210, byte.MaxValue),
                new Color32(17, 128, 45, byte.MaxValue),
                new Color32(238, 84, 187, byte.MaxValue),
                new Color32(240, 125, 13, byte.MaxValue),
                new Color32(246, 246, 87, byte.MaxValue),
                new Color32(63, 71, 78, byte.MaxValue),
                new Color32(215, 225, 241, byte.MaxValue),
                new Color32(107, 47, 188, byte.MaxValue),
                new Color32(113, 73, 30, byte.MaxValue),
                new Color32(56, byte.MaxValue, 221, byte.MaxValue),
                new Color32(80, 240, 57, byte.MaxValue),
                Palette.FromHex(6233390),
                Palette.FromHex(15515859),
                Palette.FromHex(15787944),
                Palette.FromHex(7701907),
                Palette.FromHex(9537655),
                Palette.FromHex(14115940),
                // New colours
                new Color32(168, 50, 62, byte.MaxValue),
                new Color32(60, 48, 44, byte.MaxValue),
                new Color32(61, 129, 255, byte.MaxValue),
                new Color32(240, 211, 165, byte.MaxValue),
                new Color32(255, 0, 127, byte.MaxValue),
                new Color32(61, 255, 181, byte.MaxValue),
                new Color32(186, 161, 255, byte.MaxValue),
                new Color32(97, 114, 24, byte.MaxValue),
                new Color32(1, 166, 255, byte.MaxValue),
                new Color32(79, 0, 127, byte.MaxValue),
                new Color32(0, 47, 0, byte.MaxValue),
                new Color32(111, 192, 156, byte.MaxValue), 
                new Color32(207, 255, 0, byte.MaxValue),
                new Color32(0, 97, 93, byte.MaxValue),
                new Color32(205, 63, 0, byte.MaxValue),
                new Color32(255, 207, 0, byte.MaxValue),
                new Color32(0, 0, 0, byte.MaxValue),

                //TOR colors
                new Color32(0xA8, 0xDF, 0xFF, byte.MaxValue),   
                new Color32(0xFF, 0xCA, 0x19, byte.MaxValue),     
                new Color32(50, 125, 105, byte.MaxValue),          
                new Color32(235, 192, 192, byte.MaxValue),          
                new Color32(178, 38, 180, byte.MaxValue),   
                new Color32(0, 49, 83, byte.MaxValue),    
                new Color32(221, 87, 28, byte.MaxValue),  
                new Color32(63, 77, 60, byte.MaxValue),        
                new Color32(109, 7, 26, byte.MaxValue),    
                new Color32(255, 164, 119, byte.MaxValue), 
                new Color32(0xF7, 0x44, 0x17, byte.MaxValue), 
            };
            Palette.ShadowColors = new[]
            {
                new Color32(122, 8, 56, byte.MaxValue),
                new Color32(9, 21, 142, byte.MaxValue),
                new Color32(10, 77, 46, byte.MaxValue),
                new Color32(172, 43, 174, byte.MaxValue),
                new Color32(180, 62, 21, byte.MaxValue),
                new Color32(195, 136, 34, byte.MaxValue),
                new Color32(30, 31, 38, byte.MaxValue),
                new Color32(132, 149, 192, byte.MaxValue),
                new Color32(59, 23, 124, byte.MaxValue),
                new Color32(94, 38, 21, byte.MaxValue),
                new Color32(36, 169, 191, byte.MaxValue),
                new Color32(21, 168, 66, byte.MaxValue),
                Palette.FromHex(4263706),
                Palette.FromHex(14586547),
                Palette.FromHex(13810825),
                Palette.FromHex(4609636),
                Palette.FromHex(5325118),
                Palette.FromHex(11813730),
                // New colours
                new Color32(101, 30, 37, byte.MaxValue),
                new Color32(30, 24, 22, byte.MaxValue),
                new Color32(31, 65, 128, byte.MaxValue),
                new Color32(120, 106, 83, byte.MaxValue),
                new Color32(191, 0, 95, byte.MaxValue),
                new Color32(31, 128, 91, byte.MaxValue),
                new Color32(93, 81, 128, byte.MaxValue),
                new Color32(66, 91, 15, byte.MaxValue),
                new Color32(17, 104, 151, byte.MaxValue),
                new Color32(55, 0, 95, byte.MaxValue),
                new Color32(0, 23, 0, byte.MaxValue),
                new Color32(65, 148, 111, byte.MaxValue),
                new Color32(143, 191, 61, byte.MaxValue),
                new Color32(0, 65, 61, byte.MaxValue),
                new Color32(141, 31, 0, byte.MaxValue),
                new Color32(191, 143, 0, byte.MaxValue),
                new Color32(0, 0, 0, byte.MaxValue),

                //TOR colors
                new Color32(0x59, 0x9F, 0xC8, byte.MaxValue),
                new Color32(0xDB, 0x44, 0x42, byte.MaxValue),
                new Color32(37, 97, 81, byte.MaxValue),
                new Color32(201, 163, 163, byte.MaxValue),
                new Color32(144, 29, 145, byte.MaxValue),
                new Color32(0, 26, 43, byte.MaxValue),
                new Color32(191, 73, 21, byte.MaxValue),
                new Color32(41, 51, 39, byte.MaxValue),
                new Color32(54, 2, 11, byte.MaxValue),
                new Color32(238, 128, 100, byte.MaxValue),
                new Color32(0x9B, 0x2E, 0x0F, byte.MaxValue),
            };
        }
    }
}
