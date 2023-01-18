using UnityEngine;

namespace TownOfUs.RainbowMod
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
                // Town Of Us Colors 
                (StringNames)999990,//"Watermelon",
                (StringNames)999991,//"Chocolate",
                (StringNames)999992,//"Sky Blue",
                (StringNames)999993,//"Beige",
                (StringNames)999994,//"Hot Pink",
                (StringNames)999995,//"Turquoise",
                (StringNames)999996,//"Lilac",
                (StringNames)999997,//"Olive",
                (StringNames)999998,//"Azure",
                (StringNames)999999,//"Rainbow",
                //Town Of Roles Colors
                (StringNames)999910,//"Ice",
                (StringNames)999911,//"Wine",
                (StringNames)999912,//"BlueBerry",
                (StringNames)999913,//"Mint",
                (StringNames)999914,//"Light Purple",
                (StringNames)999915,//"Peach",
                (StringNames)999916,//"Sushi",
                (StringNames)999917,//"Sylveon"
                (StringNames)999918,//"Discussions",
                (StringNames)999919,//"Petrol",
                (StringNames)999920,//"Hannah",
                (StringNames)999921,//"Stormy Blue",
                (StringNames)999922,//"VantaBlack",
                (StringNames)999923,//"Ambar",
                (StringNames)999924,//"Light Grape",
                (StringNames)999925,//"(M)aize Red",
                (StringNames)999926,//"Sloth",
                (StringNames)999927,//"AD",
                (StringNames)999928,//"Lotty",
                (StringNames)999929,//"Mom",    
                (StringNames)999930,//"Kara",   
                (StringNames)999931,//"EurMom",   
                (StringNames)999932,//"Donald",
                (StringNames)999933,//"Sen",
                (StringNames)999934,//"Fizz",
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
                // Town Of Us Colors 
                new Color32(168, 50, 62, byte.MaxValue),
                new Color32(60, 48, 44, byte.MaxValue),
                new Color32(61, 129, 255, byte.MaxValue),
                new Color32(240, 211, 165, byte.MaxValue),
                new Color32(236, 61, 255, byte.MaxValue),
                new Color32(61, 255, 181, byte.MaxValue),
                new Color32(186, 161, 255, byte.MaxValue),
                new Color32(97, 114, 24, byte.MaxValue),
                new Color32(1, 166, 255, byte.MaxValue),
                new Color32(0, 0, 0, byte.MaxValue),
                //New Colors Of Town Of Roles
                new Color32(0xA8, 0xDF, 0xFF, byte.MaxValue),//ice
                new Color32(109, 7, 26, byte.MaxValue), //Wine
                new Color32(0x59, 0x3C, 0xD6, byte.MaxValue), //BlueBerry
                new Color32(111, 192, 156, byte.MaxValue),//Mint
                new Color32(173, 126, 201, byte.MaxValue), //Light Purple
                new Color32(255, 164, 119, byte.MaxValue),// peach
                new Color32(160, 101, 56, byte.MaxValue),//Sushi
                new Color32(238, 154, 172, byte.MaxValue),//Sylveon
                new Color32(115, 250, 115, byte.MaxValue),//Discussions
                new Color32(17, 74, 67, byte.MaxValue),//Petrol   
                new Color32(255, 0, 102, byte.MaxValue),//Hannah     
                new Color32(39, 53, 74, byte.MaxValue),//Stormy Blue        
                new Color32(0, 0, 0, byte.MaxValue),//VantaBlack      
                new Color32(255, 191, 0, byte.MaxValue),//Ambar
                new Color32(93, 86, 199, byte.MaxValue),//Light Grape
                new Color32(201, 169, 166, byte.MaxValue),//(M)aize Red
                new Color32(120, 82, 169, byte.MaxValue),//Sloth   
                new Color32(69, 69, 169, byte.MaxValue),//AD  
                new Color32(105, 151, 89, byte.MaxValue),//Lotty    
                new Color32(166, 196, 67, byte.MaxValue),//Mom    
                new Color32(146, 0, 0, byte.MaxValue),//Kara
                new Color32(102, 0, 0, byte.MaxValue),//EurMom
                new Color32(193, 20, 26, byte.MaxValue),//Donald
                new Color32(170, 32, 30, byte.MaxValue),//Sen    
                new Color32(178, 38, 180, byte.MaxValue),//Fizz            
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
                // Modded Shadow Colors 
                new Color32(101, 30, 37, byte.MaxValue),
                new Color32(30, 24, 22, byte.MaxValue),
                new Color32(31, 65, 128, byte.MaxValue),
                new Color32(120, 106, 83, byte.MaxValue),
                new Color32(118, 31, 128, byte.MaxValue),
                new Color32(31, 128, 91, byte.MaxValue),
                new Color32(93, 81, 128, byte.MaxValue),
                new Color32(66, 91, 15, byte.MaxValue),
                new Color32(17, 104, 151, byte.MaxValue),
                new Color32(0, 0, 0, byte.MaxValue),
                //new Color Shadows Of Town Of Roles
                new Color32(0x59, 0x9F, 0xC8, byte.MaxValue),//ice
                new Color32(54, 2, 11, byte.MaxValue),//wine
                new Color32(0x29, 0x17, 0x96, byte.MaxValue),//blueberry
                new Color32(65, 148, 111, byte.MaxValue),//Mint
                new Color32(131, 58, 203, byte.MaxValue),//Light Purple
                new Color32(238, 128, 100, byte.MaxValue),//Peach
                new Color32(115, 15, 78, byte.MaxValue),//Sushi
                new Color32(191, 122, 137, byte.MaxValue),//Sylveon 
                new Color32(94, 204, 94, byte.MaxValue),//Discussions
                new Color32(11, 46, 42, byte.MaxValue),//Petrol     
                new Color32(153, 2, 62, byte.MaxValue),//Hannah       
                new Color32(23, 31, 43, byte.MaxValue),//Stormy Blue   
                new Color32(0, 0, 0, byte.MaxValue),//VantaBlack     
                new Color32(196, 147, 0, byte.MaxValue),//Ambar     
                new Color32(64, 59, 138, byte.MaxValue),//Light Grape   
                new Color32(143, 119, 117, byte.MaxValue),//(M)aize Red   
                new Color32(94, 64, 133, byte.MaxValue),//Sloth                                                                                       
                new Color32(48, 48, 117, byte.MaxValue),//AD    
                new Color32(77, 110, 66, byte.MaxValue),//Lotty      
                new Color32(132, 156, 53, byte.MaxValue),//Mom   
                new Color32(102, 0, 0, byte.MaxValue),//Kara   
                new Color32(74, 1, 1, byte.MaxValue),//EurMom    
                new Color32(156, 16, 20, byte.MaxValue),//Donald   
                new Color32(122, 22, 21, byte.MaxValue),//Sen      
                new Color32(134, 28, 135, byte.MaxValue),//Fizz                                                                                                      
            };
        }
    }
}