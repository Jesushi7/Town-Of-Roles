/*using System;
using System.Linq;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;

namespace TownOfSushi.Patches {
    [HarmonyPatch]
    public static class ChatCommands {
        [HarmonyPatch(typeof(ChatController), nameof(ChatController.SendChat))]
        private static class SendChatPatch {
            static bool Prefix(ChatController __instance) {
                //Set up dictionaries and list for colours/hats/pets/nameplates/visors
                var coloursDict = new Dictionary<string, string>();
                List<string> hatsList = new List<string>();
                List<string> petsList = new List<string>();
                List<string> nameplatesList = new List<string>();
                List<string> visorsList = new List<string>();
                coloursDict.Add("RED", "0");
                coloursDict.Add("BLUE", "1");
                coloursDict.Add("GREEN", "2");
                coloursDict.Add("PINK", "3");
                coloursDict.Add("ORANGE", "4");
                coloursDict.Add("YELLOW", "5");
                coloursDict.Add("BLACK", "6");
                coloursDict.Add("WHITE", "7");
                coloursDict.Add("PURPLE", "8");
                coloursDict.Add("BROWN", "9");
                coloursDict.Add("CYAN", "10");
                coloursDict.Add("LIME", "11");
                coloursDict.Add("MAROON", "12");
                coloursDict.Add("ROSE", "13");
                coloursDict.Add("BANANA", "14");
                coloursDict.Add("GREY", "15");
                coloursDict.Add("TAN", "16");
                coloursDict.Add("CORAL", "17");
                coloursDict.Add("WATERMELON", "18");
                coloursDict.Add("CHOCOLATE", "19");
                coloursDict.Add("SKY BLUE", "20");
                coloursDict.Add("BIEGE", "21");
                coloursDict.Add("HOT PINK", "22");
                coloursDict.Add("TURQUOISE", "23");
                coloursDict.Add("LILAC", "24");
                coloursDict.Add("OLIVE", "25");
                coloursDict.Add("AZURE", "26");
                coloursDict.Add("RAINBOW", "27");
                hatsList.Add("hat pk05 Wizardhat");
                hatsList.Add("AbominalHat");
                hatsList.Add("pk02 ScubaHat");
                hatsList.Add("arrowhead");
                hatsList.Add("pkHW01 CatEyes");
                hatsList.Add("pkHW01 BatWings");
                hatsList.Add("pk04 beanie");
                hatsList.Add("pk05 Cheese");
                hatsList.Add("pk05 GeoffreyToppat");
                hatsList.Add("Ponytail");
                hatsList.Add("pk04 CCC");
                hatsList.Add("caitlin");
                hatsList.Add("pk06 Candycanes");
                hatsList.Add("candycorn");
                hatsList.Add("captain");
                hatsList.Add("pk05 Cherry");
                hatsList.Add("Chocolate");
                hatsList.Add("comper");
                hatsList.Add("pkHW01 Machete");
                hatsList.Add("clagger");
                hatsList.Add("pk02 PlungerHat");
                hatsList.Add("clown purple");
                hatsList.Add("pk04 WinterHat");
                hatsList.Add("w21 winterpuff");
                hatsList.Add("ToppatHair");
                hatsList.Add("Winston");
                hatsList.Add("w21 nutcracker");
                hatsList.Add("HardtopHat");
                hatsList.Add("Zipper");
                hatsList.Add("pk02 Crown");
                hatsList.Add("pk05 FlowerPin");
                hatsList.Add("w21 holly");
                hatsList.Add("Pot");
                hatsList.Add("bushhat");
                hatsList.Add("DrillMetal");
                hatsList.Add("DrillStone");
                hatsList.Add("DrillWood");
                hatsList.Add("pk05 Egg");
                hatsList.Add("enforcer");
                hatsList.Add("RockLava");
                hatsList.Add("pk06 tree");
                hatsList.Add("mira flower");
                hatsList.Add("fairywings");
                hatsList.Add("pk03 Fedora");
                hatsList.Add("pk04 Fez");
                hatsList.Add("fishhed");
                hatsList.Add("pk05 Flamingo");
                hatsList.Add("paperhat");
                hatsList.Add("frankenbride");
                hatsList.Add("frankenbolts");
                hatsList.Add("towelwizard");
                hatsList.Add("pk06 Snowman");
                hatsList.Add("pk05 Ellryhat");
                hatsList.Add("pk03 StrapHat");
                hatsList.Add("pk04 GeneralHat");
                hatsList.Add("pk06 Present");
                hatsList.Add("w21 gingerbread");
                hatsList.Add("goggles");
                hatsList.Add("GovtHeadset");
                hatsList.Add("pk03 Headphones");
                hatsList.Add("pk04 Bandana");
                hatsList.Add("Janitor");
                hatsList.Add("mira cloud");
                hatsList.Add("Soccer");
                hatsList.Add("brainslug");
                hatsList.Add("heim");
                hatsList.Add("Basketball");
                hatsList.Add("pk02 HeroCap");
                hatsList.Add("Heart");
                hatsList.Add("pk05 Burthat");
                hatsList.Add("RockIce");
                hatsList.Add("pkHW01 Horns");
                hatsList.Add("mira case");
                hatsList.Add("pk02 HaloHat");
                hatsList.Add("jayce");
                hatsList.Add("jinx");
                hatsList.Add("w21 mistletoe");
                hatsList.Add("pk05 Helmet");
                hatsList.Add("w21 krampus");
                hatsList.Add("pk06 Lights");
                hatsList.Add("Unicorn");
                hatsList.Add("pkHW01 ScaryBag");
                hatsList.Add("military");
                hatsList.Add("pk04 MinerCap");
                hatsList.Add("pk04 MiniCrewmate");
                hatsList.Add("pkHW01 Mohawk");
                hatsList.Add("pk05 Macbethhat");
                hatsList.Add("pk05 cheesetoppat");
                hatsList.Add("EarnmuffBlue");
                hatsList.Add("mummy");
                hatsList.Add("pk05 davehat");
                hatsList.Add("pk04 Chef");
                hatsList.Add("pk04 Vagabond");
                hatsList.Add("NewYears2018");
                hatsList.Add("pk04 HunterCap");
                hatsList.Add("pk05 Fedora");
                hatsList.Add("hardhat");
                hatsList.Add("pk06 Reindeer");
                hatsList.Add("mira bush");
                hatsList.Add("partyhat");
                hatsList.Add("mira milk");
                hatsList.Add("pk04 Banana");
                hatsList.Add("w21 pinecone");
                hatsList.Add("pkHW01 PlagueHat");
                hatsList.Add("flowerpot");
                hatsList.Add("police");
                hatsList.Add("pk04 Pompadour");
                hatsList.Add("pk04 Antenna");
                hatsList.Add("pk06 Santa");
                hatsList.Add("Prototype");
                hatsList.Add("pkHW01 Pumpkin");
                hatsList.Add("tombstone");
                hatsList.Add("pk04 RamHorns");
                hatsList.Add("ratchet");
                hatsList.Add("Records");
                hatsList.Add("pk05 EllieToppat");
                hatsList.Add("pk05 HenryToppat");
                hatsList.Add("pk05 Ellie");
                hatsList.Add("pk05 RHM");
                hatsList.Add("Rupert");
                hatsList.Add("pk03 Goggles");
                hatsList.Add("screamghostface");
                hatsList.Add("pk02 StrawHat");
                hatsList.Add("Deitied");
                hatsList.Add("pk04 Archae");
                hatsList.Add("WilfordIV");
                hatsList.Add("pk04 Slippery");
                hatsList.Add("w21 mittens");
                hatsList.Add("w21 snowflake");
                hatsList.Add("pk04 Snowman");
                hatsList.Add("astronaut");
                hatsList.Add("halospartan");
                hatsList.Add("Voleyball");
                hatsList.Add("axe");
                hatsList.Add("pk02 Eyebrows");
                hatsList.Add("pk02 StickminHat");
                hatsList.Add("Bowlingball");
                hatsList.Add("CuppaJoe");
                hatsList.Add("pk05 Svenhat");
                hatsList.Add("pk04 DoRag");
                hatsList.Add("pk04 JungleHat");
                hatsList.Add("pk02 TenGallonHat");
                hatsList.Add("w21 snowman");
                hatsList.Add("pk02 ToiletPaperHat");
                hatsList.Add("pk02 Toppat");
                hatsList.Add("pk01 BaseballCap");
                hatsList.Add("wallcap");
                hatsList.Add("pk02 ThirdEyeHat");
                hatsList.Add("ThomasC");
                hatsList.Add("pk03 Security1");
                hatsList.Add("pk02 PipCap");
                hatsList.Add("doubletophat");
                hatsList.Add("tophat");
                hatsList.Add("whitetophat");
                hatsList.Add("pk06 ElfHat");
                hatsList.Add("traffic purple");
                hatsList.Add("pk03 Traffic");
                hatsList.Add("pk04 BirdNest");
                hatsList.Add("pk04 Bear");
                hatsList.Add("mira gem");
                hatsList.Add("glowstick");
                hatsList.Add("Viking");
                hatsList.Add("vi");
                hatsList.Add("mira leaf");
                hatsList.Add("Visor");
                hatsList.Add("pkHW01 Pirate");
                hatsList.Add("russian");
                hatsList.Add("pk04 Balloon");
                hatsList.Add("pkHW01 Wolf");
                hatsList.Add("stethescope");
                hatsList.Add("SnowbeanieRed");
                hatsList.Add("pkHW01 Witch");
                hatsList.Add("Rubberglove");
                hatsList.Add("bone");
                hatsList.Add("Dodgeball");
                hatsList.Add("pk05 Plant");
                hatsList.Add("w21 log");
                petsList.Add("Squig");
                petsList.Add("Bedcrab");
                petsList.Add("Alien");
                petsList.Add("UFO");
                petsList.Add("Doggy");
                petsList.Add("Hamster");
                petsList.Add("Crewmate");
                petsList.Add("Robot");
                petsList.Add("Stickmin");
                petsList.Add("Ellie");
                petsList.Add("test");
                petsList.Add("Bush");
                petsList.Add("Lava");
                petsList.Add("Snow");
                petsList.Add("Charles");
                petsList.Add("Charles Red");
                petsList.Add("poro");
                petsList.Add("frankendog");
                petsList.Add("Cube");
                petsList.Add("GuiltySpark");
                petsList.Add("clank");
                nameplatesList.Add("airship Sky");
                nameplatesList.Add("Airship Hull");
                nameplatesList.Add("airship Toppat");
                nameplatesList.Add("is yard");
                nameplatesList.Add("w21 fireplace");
                nameplatesList.Add("airship CCC");
                nameplatesList.Add("hw candy");
                nameplatesList.Add("Polus Colors");
                nameplatesList.Add("airship Diamond");
                nameplatesList.Add("is dig");
                nameplatesList.Add("airship Emerald");
                nameplatesList.Add("is ghost");
                nameplatesList.Add("is green");
                nameplatesList.Add("Polus Ground");
                nameplatesList.Add("Mira Tiles");
                nameplatesList.Add("hw pumpkin");
                nameplatesList.Add("Polus Lava");
                nameplatesList.Add("PolusSkyline");
                nameplatesList.Add("Polus Planet");
                nameplatesList.Add("airship Ruby");
                nameplatesList.Add("is game");
                nameplatesList.Add("is sand");
                nameplatesList.Add("Polus DVD");
                nameplatesList.Add("w21 snow");
                nameplatesList.Add("PolusSnowmates");
                nameplatesList.Add("Polus Snow");
                nameplatesList.Add("Polus SpecimenBlue");
                nameplatesList.Add("Polus SpecimenGreen");
                nameplatesList.Add("Polus SpecimenPurple");
                nameplatesList.Add("hw woods");
                nameplatesList.Add("airship government");
                nameplatesList.Add("Mira Glass");
                nameplatesList.Add("w21 tree");
                nameplatesList.Add("airship Gems");
                nameplatesList.Add("Mira Cafeteria");
                nameplatesList.Add("is trees");
                nameplatesList.Add("Mira Vines");
                nameplatesList.Add("Mira Wood");
                visorsList.Add("Test");
                visorsList.Add("is beard");
                visorsList.Add("pk01 AngeryVisor");
                visorsList.Add("Crack");
                visorsList.Add("pk01 HazmatVisor");
                visorsList.Add("Bomba");
                visorsList.Add("w21 carrot");
                visorsList.Add("clownnose");
                visorsList.Add("w21 nutstache");
                visorsList.Add("Straw");
                visorsList.Add("D2CGoggles");
                visorsList.Add("Dotdot");
                visorsList.Add("pk01 MonoclesVisor");
                visorsList.Add("Galeforce");
                visorsList.Add("JanitorStache");
                visorsList.Add("eyeball");
                visorsList.Add("pk01 FredVisor");
                visorsList.Add("w21 nye");
                visorsList.Add("Carrot");
                visorsList.Add("heim");
                visorsList.Add("Lava");
                visorsList.Add("SkiGogglesWhite");
                visorsList.Add("polus ice");
                visorsList.Add("jinx");
                visorsList.Add("Krieghaus");
                visorsList.Add("LolliRed");
                visorsList.Add("masque blue");
                visorsList.Add("masque green");
                visorsList.Add("masque red");
                visorsList.Add("masque white");
                visorsList.Add("BillyG");
                visorsList.Add("pk01 DumStickerVisor");
                visorsList.Add("Blush");
                visorsList.Add("mira card blue");
                visorsList.Add("mira card red");
                visorsList.Add("EyepatchL");
                visorsList.Add("EyepatchR");
                visorsList.Add("PiercingL");
                visorsList.Add("PiercingR");
                visorsList.Add("pk01 PlagueVisor");
                visorsList.Add("Reginald");
                visorsList.Add("WinstonStache");
                visorsList.Add("pk01 RHMVisor");
                visorsList.Add("pk01 PaperMaskVisor");
                visorsList.Add("SciGoggles");
                visorsList.Add("w21 santabeard");
                visorsList.Add("Scar");
                visorsList.Add("pk01 Security1Visor");
                visorsList.Add("shopglasses");
                visorsList.Add("mira glasses");
                visorsList.Add("mummy");
                visorsList.Add("SmallGlasses");
                visorsList.Add("Dirty");
                visorsList.Add("Mouth");
                visorsList.Add("is beard");
                visorsList.Add("pk01 AngeryVisor");
                visorsList.Add("Crack");
                visorsList.Add("pk01 HazmatVisor");
                visorsList.Add("Bomba");
                visorsList.Add("w21 carrot");
                visorsList.Add("clownnose");
                visorsList.Add("w21 nutstache");
                visorsList.Add("Straw");
                visorsList.Add("D2CGoggles");
                visorsList.Add("Dotdot");
                visorsList.Add("pk01 MonoclesVisor");
                visorsList.Add("Galeforce");
                visorsList.Add("JanitorStache");
                visorsList.Add("eyeball");
                visorsList.Add("pk01 FredVisor");
                visorsList.Add("w21 nye");
                visorsList.Add("Carrot");
                visorsList.Add("heim");
                visorsList.Add("Lava");
                visorsList.Add("SkiGogglesWhite");
                visorsList.Add("polus ice");
                visorsList.Add("jinx");
                visorsList.Add("Krieghaus");
                visorsList.Add("LolliRed");
                visorsList.Add("masque blue");
                visorsList.Add("masque green");
                visorsList.Add("masque red");
                visorsList.Add("masque white");
                visorsList.Add("BillyG");
                visorsList.Add("pk01 DumStickerVisor");
                visorsList.Add("Blush"); 	
                visorsList.Add("mira card blue");
                visorsList.Add("mira card red");
                visorsList.Add("EyepatchL");
                visorsList.Add("EyepatchR");
                visorsList.Add("PiercingL");
                visorsList.Add("PiercingR");
                visorsList.Add("pk01 PlagueVisor");
                visorsList.Add("Reginald");
                visorsList.Add("WinstonStache");
                visorsList.Add("pk01 RHMVisor");
                visorsList.Add("pk01 PaperMaskVisor");
                visorsList.Add("SciGoggles");
                visorsList.Add("w21 santabeard");
                visorsList.Add("Scar");
                visorsList.Add("pk01 Security1Visor");
                visorsList.Add("shopglasses");
                visorsList.Add("mira glasses");
                visorsList.Add("mummy");
                visorsList.Add("SmallGlasses");
                visorsList.Add("Dirty");
                visorsList.Add("Mouth");

                string text = __instance.freeChatField.textArea.text;
                string inputText = "";
                bool chatHandled = false;
                if (AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started) {
                    //Help command - lists commands available
                    if (text.ToLower().StartsWith("/help")) {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer,
                        AmongUsClient.Instance.CanBan()
                        ? "Commands available:\n/motd /name /colour /color /hat /pet /nameplate /visor /kick /ban /listcolours /listcolors /listhats /listpets /listnameplates /listvisors"
                        : "Commands available:\n/motd /name /colour /color /hat /pet /nameplate /visor /listcolours /listcolors /listhats /listpets /listnameplates /listvisors");
                    }
                    //Display a message (Message Of The Day)
                    else if (text.ToLower().StartsWith("/motd")) {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "Welcome to Town of Sushi v" + TownOfSushi.VersionString + "!");
                    }
                    //Name help                    
                    else if (text.ToLower() == "/name" || text.ToLower() == "/name ")
                    {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "Usage: /name <name>");
                    }
                    //Change name (Can have multiple players the same name!)
                    else if (text.ToLower().StartsWith("/name ")) {
                        chatHandled = true;
                        inputText = text.Substring(6);
                        if (!System.Text.RegularExpressions.Regex.IsMatch(inputText, @"^[a-zA-Z0-9]+$")) {
                            __instance.AddChat(PlayerControl.LocalPlayer, "Name contains disallowed characters.");
                        } else {
                            PlayerControl.LocalPlayer.RpcSetName(inputText);
                            __instance.AddChat(PlayerControl.LocalPlayer, "Name changed!");;
                        }
                    }
                    //Colour help                    
                    else if (text.ToLower() == "/colour" || text.ToLower() == "/color" || text.ToLower() == "/colour " || text.ToLower() == "/color ")
                    {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "Usage: /colour <colour>\nOr: /color <color>");
                    }
                    //Change colour (Can have multiple players the same colour!)
                    else if (text.ToLower().StartsWith("/color ") || text.ToLower().StartsWith("/colour ")) {
                        chatHandled = true;
                        int col;
                        inputText = text.Substring(text.ToLower().StartsWith("/color ") ? 7 : 8);
                        string colourSpelling = text.ToLower().StartsWith("/colour ") ? "colour" : "color";
                        if(coloursDict.ContainsKey(inputText.ToUpper())){  
                            inputText = coloursDict[inputText.ToUpper()];
                        }
                        if (!Int32.TryParse(inputText, out col)) {
                            __instance.AddChat(PlayerControl.LocalPlayer, inputText + " is an invalid " + colourSpelling + ".\nYou can use: Red, Blue, Green, Pink, Orange, Yellow, Black, White, Purple, Brown, Cyan, Lime, Maroon, Rose, Banana, Gray, Tan, Coral, Watermelon, Chocolate, SkyBlue, Beige, HotPink, Turquoise, Lilac, Olive, Rainbow and Azure");
                        } else {
                            col = Math.Clamp(col, 0, Palette.PlayerColors.Length - 1);
                            PlayerControl.LocalPlayer.RpcSetColor ((byte)col);
                            __instance.AddChat(PlayerControl.LocalPlayer, colourSpelling + " changed!");
                        }
                    }
                    //List colours
                    else if (text.ToLower().StartsWith("/listcolours") || text.ToLower().StartsWith("/list colours") || text.ToLower().StartsWith("/listcolors") || text.ToLower().StartsWith("/list colors")) {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "nYou can use: Red, Blue, Green, Pink, Orange, Yellow, Black, White, Purple, Brown, Cyan, Lime, Maroon, Rose, Banana, Gray, Tan, Coral, Watermelon, Chocolate, SkyBlue, Beige, HotPink, Turquoise, Lilac, Olive, Rainbow and Azure");
                    }
                    //Hat help                    
                    else if (text.ToLower() == "/hat" || text.ToLower() == "/hat ")
                    {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "Usage: /hat <hat name>");
                    }
                    //Change hat
                    else if (text.ToLower().StartsWith("/hat ")) {
                        chatHandled = true;
                        inputText = text.Substring(5);
                        if (hatsList.Contains(inputText)) {
                            //Replace required as chat dissallows "-" and "_" characters
                            PlayerControl.LocalPlayer.RpcSetHat("hat_" + inputText.Replace(" ", "_"));
                            __instance.AddChat(PlayerControl.LocalPlayer, "Hat set to " + text.Substring(5) + "!");
                        } else {
                            __instance.AddChat(PlayerControl.LocalPlayer, inputText + " is an invalid Hat.");
                        }
                    }
                    //List hats
                    else if (text.ToLower().StartsWith("/listhats") || text.ToLower().StartsWith("/list hats")) {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "List of hats:\n" + string.Join("\n", hatsList.ToArray()));
                    }
                    //Pet help                    
                    else if (text.ToLower() == "/pet" || text.ToLower() == "/pet ")
                    {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "Usage: /pet <pet name>");
                    }
                    //Change pet
                    else if (text.ToLower().StartsWith("/pet ")) {
                        chatHandled = true;
                        inputText = text.Substring(5);
                        if (petsList.Contains(inputText)) {
                            //Replace required as chat dissallows "-" and "_" characters
                            PlayerControl.LocalPlayer.RpcSetPet("pet_" + inputText.Replace("Charles Red", "Charles_Red"));
                            __instance.AddChat(PlayerControl.LocalPlayer, "Pet set to " + inputText + "!");
                        } else {
                            __instance.AddChat(PlayerControl.LocalPlayer, inputText + " is an invalid Pet.");
                        }
                    }
                    //List pets
                    else if (text.ToLower().StartsWith("/listpets") || text.ToLower().StartsWith("/list pets")) {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "List of pets:\n" + string.Join("\n", petsList.ToArray()));
                    }
                    //Nameplate help                    
                    else if (text.ToLower() == "/nameplate" || text.ToLower() == "/nameplate ")
                    {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "Usage: /nameplate <nameplate name>");
                    }
                    //Change nameplate
                    else if (text.ToLower().StartsWith("/nameplate ")) {
                        chatHandled = true;
                        inputText = text.Substring(11);
                        if (nameplatesList.Contains(inputText)) {
                            PlayerControl.LocalPlayer.RpcSetNamePlate("nameplate_" + inputText.Replace(" ", "_").Replace("PolusSkyline", "Polus-Skyline").Replace("PolusSnowmates", "Polus-Snowmates"));
                            __instance.AddChat(PlayerControl.LocalPlayer, "Nameplate set to " + inputText + "!");
                        } else {
                            __instance.AddChat(PlayerControl.LocalPlayer, inputText + " is an invalid Nameplate.");
                        }
                    }
                    //List nameplates
                    else if (text.ToLower().StartsWith("/listnameplates") || text.ToLower().StartsWith("/list nameplates")) {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "List of nameplates:\n" + string.Join("\n", nameplatesList.ToArray()));
                    }
                    //Visor help                    
                    else if (text.ToLower() == "/visor" || text.ToLower() == "/visor ")
                    {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "Usage: /visor <visor name>");
                    }
                    //Change visor
                    else if (text.ToLower().StartsWith("/visor ")) {
                        chatHandled = true;
                        inputText = text.Substring(7);
                        if (visorsList.Contains(inputText)) {
                            PlayerControl.LocalPlayer.RpcSetVisor("visor_" + inputText.Replace(" ", "_"));
                            __instance.AddChat(PlayerControl.LocalPlayer, "Visor set to " + inputText + "!");
                        } else {
                            __instance.AddChat(PlayerControl.LocalPlayer, inputText + " is an invalid Visor.");
                        }
                    }
                    //List visors
                    else if (text.ToLower().StartsWith("/listvisors") || text.ToLower().StartsWith("/list visors")) {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "List of visors:\n" + string.Join("\n", visorsList.ToArray()));
                    }
                    //Kick help                    
                    else if (text.ToLower() == "/kick" || text.ToLower() == "/kick ")
                    {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "Usage: /kick <player name>");
                    }
                    //Kick player (if able to kick, i.e. host command)
                    else if (text.ToLower().StartsWith("/kick ")) {
                        chatHandled = true;
                        inputText = text.Substring(6);
                        PlayerControl target = PlayerControl.AllPlayerControls.ToArray().ToList().FirstOrDefault(x => x.Data.PlayerName.Equals(inputText));
                        if (target != null && AmongUsClient.Instance != null && AmongUsClient.Instance.CanBan()) {
                            var client = AmongUsClient.Instance.GetClient(target.OwnerId);
                            if (client != null) {
                                AmongUsClient.Instance.KickPlayer(client.Id, false);
                                chatHandled = true;
                            }
                        }
                    }
                    //Ban help                    
                    else if (text.ToLower() == "/ban" || text.ToLower() == "/ban ")
                    {
                        chatHandled = true;
                        __instance.AddChat(PlayerControl.LocalPlayer, "Usage: /ban <player name>");
                    }
                    //Ban player (if able to ban, i.e. host command)
                    else if (text.ToLower().StartsWith("/ban ")) {
                        chatHandled = true;
                        inputText = text.Substring(5);
                        PlayerControl target = PlayerControl.AllPlayerControls.ToArray().ToList().FirstOrDefault(x => x.Data.PlayerName.Equals(inputText));
                        if (target != null && AmongUsClient.Instance != null && AmongUsClient.Instance.CanBan()) {
                            var client = AmongUsClient.Instance.GetClient(target.OwnerId);
                            if (client != null) {
                                AmongUsClient.Instance.KickPlayer(client.Id, true);
                                chatHandled = true;
                            }
                        }
                    }
                }
                if (chatHandled) {
                    __instance.freeChatField.textArea.Clear();
                    __instance.quickChatMenu.ResetGlyphs();
                }
                return !chatHandled;
            }
        }
    }
}*/