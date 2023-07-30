using System;
using System.Collections.Generic;
using System.Linq;
using AmongUs.Data;
using AmongUs.Data.Player;
using Assets.InnerNet;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace TownOfSushi.Patches.ModNews;

// ##https://github.com/Yumenopai/TownOfHost_Y
public class ModNews
{
    public int Number;
    public int BeforeNumber;
    public string Title;
    public string SubTitle;
    public string ShortTitle;
    public string Text;
    public string Date;

    public Announcement ToAnnouncement()
    {
        var result = new Announcement
        {
            Number = Number,
            Title = Title,
            SubTitle = SubTitle,
            ShortTitle = ShortTitle,
            Text = Text,
            Language = (uint)DataManager.Settings.Language.CurrentLanguage,
            Date = Date,
            Id = "ModNews"
        };

        return result;
    }
}
[HarmonyPatch]
public class ModNewsHistory
{
    public static List<ModNews> AllModNews = new();
    public static void Init()
    { 
        {


            // TOU 5.0.1
            var news = new ModNews
            {
                Number = 100001, // 100001
                Title = "TownOfSushi v2.0.0 + TownOfUs v5.0.1",
                SubTitle = "★★★★A lot of new stuff...yikes★★★★",
                ShortTitle = "★Merges from TOU v5.0.1",
                Text = "<size=150%>Welcome to TownOfSushi v2.0.0</size>\n\n<size=125%>Support for Among Us v2023.6.13/2023.6.27.</size>\n"
                    + "\n【Fixes】\n - Bug Fix: Airship Ladders work again (from ToU-R)\n\r"
                    + "\n- Bug fix: lag spreads with some roles\r\n"
                    + "\n 【New Roles】\n - Disguiser & Oracle\r\n"
+ "\n 【New Modifiers】\n - Spy, Watcher & Lighter\r\n"         
+ "\n 【Changes】\n\r\n"           
+ "\n- New Mod Banner by Gun (thank you so much)\r\n"
+ "\n- Renamed Torch to Nightowl\r\n"
+ "\n- Removed Chameleon (for now)\r\n"
+ "\n- Removed Crewmate/Neutral Non-killer \nassassins (Vigilante is back)\r\n"
+ "\n- Added back ''The'' in Glitch's name\r\n"
+"\n- Lovers tasks doesn't count for a Task Win\r\n"
+ "\n- Dead players can see Everyone's modifier now.\r\n"
+ "\n- Now Bait/Diseased/Double Shot are Global Modifiers\r\n"
+ "\n- Ping Tracker now has different colours \ndepending of the ping\r\n"
+ "\n- Pestilence can be guessed now as lover or just by its role\r\n"
+ "\n- Informant will only see Neutral Killers if the option to see neutrals is on\r\n"
+ "\n- Avenger will only reveal Neutral Killers if the option is on\r\n"
+ "\n- Changed Mystic's examine report once again \nand updated them\r\n"
+ "\n 【New Features】\n\r\n" 
+ "\n- New Option: Swapper Swaps after voting\r\n"
+ "\n- New Option: Medic Can't have killer's name during a grenadier flash\r\n"
+ "\n- New Option: Mayor Can Button\r\n"
+ "\n- New End Game Summary\r\n"
+ "\n- Changed Camouflaged comms color\r\n"
+ "\n- Changed the Medic shield and ga protect a little bit\r\n"
+ "\n- New Option: Vigilante can guess Crewmate roles if \ntheir lover is not a Crewmate\r\n"
+ "\n- Added zooming as Ghost\r\n"
+ "\n- Added New Colours\r\n",
                Date = "2023-7-11T00:00:00Z"

            };
            AllModNews.Add(news);
        }   

        {
            // When creating new news, you can not delete old news
            // TOU v5.0.0
            var news = new ModNews
            {
                Number = 100000,
                Title = "TownOfSushi v2.0.0 + TownOfUs v5.0.0",
                SubTitle = "★★★★TownOfSushi + TOU-R v5.0.0★★★★",
                ShortTitle = "★TOU v5.0.0 + TOS v2.0.0",
                Text = "Added Support AU 2023.6.13\n"

                    + "\n【Fixes】\n - Plaguebearer no longer turns into Pestilence early\r\n"
                    + "\n 【New Roles】\n - Doomsayer, Vampire, Vampire Haunter, Prosecutor, Oracle, Venerer\r\n"
                    + "\n 【Re worked】\n - Detective, Mayor\r\n"
                    + "\n 【New Modifiers】\n - AfterMath, Frosty\r\n"
                    + "\n 【Remove】\n - Blind, And Settings for disabling name plates and level numbers\r\n"

                    + "\n 【Changes】\n - Neutral Non-Killing settings split into Neutral Benign and Neutral Evil\r\n "
                    + "\n 【Changes】\n - New Setting: First round shield for first death in prior game\r\n"
                    + "\n 【Changes】\n - New Setting: Guardian Angel target evil percentage\r\n"
                    + "\n 【Changes】\n - Guardian Angel targets can now be a Neutral Killer\r\n"
                    + "\n 【Changes】\n - Added a new version of Snitch to Cultist\r\n",                 
                Date = "2023-7-5T00:00:00Z"

            };
            AllModNews.Add(news);
        }
    }

    [HarmonyPatch(typeof(PlayerAnnouncementData), nameof(PlayerAnnouncementData.SetAnnouncements)), HarmonyPrefix]
    public static bool SetModAnnouncements(PlayerAnnouncementData __instance, [HarmonyArgument(0)] ref Il2CppReferenceArray<Announcement> aRange)
    {
        if (AllModNews.Count < 1)
        {
            Init();
            AllModNews.Sort((a1, a2) => { return DateTime.Compare(DateTime.Parse(a2.Date), DateTime.Parse(a1.Date)); });
        }

        List<Announcement> FinalAllNews = new();
        AllModNews.Do(n => FinalAllNews.Add(n.ToAnnouncement()));
        foreach (var news in aRange)
        {
            if (!AllModNews.Any(x => x.Number == news.Number))
                FinalAllNews.Add(news);
        }
        FinalAllNews.Sort((a1, a2) => { return DateTime.Compare(DateTime.Parse(a2.Date), DateTime.Parse(a1.Date)); });

        aRange = new(FinalAllNews.Count);
        for (int i = 0; i < FinalAllNews.Count; i++)
            aRange[i] = FinalAllNews[i];

        return true;
    }
}