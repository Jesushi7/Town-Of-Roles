using HarmonyLib;
using UnityEngine;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Twitch;
using Reactor.Utilities;
using System.Text.Json.Serialization;

namespace TownOfRoles {
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public class ModUpdaterButton {
        private static Sprite TORUpdateSprite => TownOfRoles.UpdateTORButton;
        private static Sprite SubmergedUpdateSprite => TownOfRoles.UpdateSubmergedButton;
        private static void Prefix(MainMenuManager __instance) {
            //Check if there's a ToU update
            ModUpdater.LaunchUpdater();
            if (ModUpdater.hasTORUpdate) {
                //If there's an update, create and show the update button
                var template = GameObject.Find("ExitGameButton");
                if (template != null) {

                    var touButton = UnityEngine.Object.Instantiate(template, null);
                    touButton.transform.localPosition = new Vector3(touButton.transform.localPosition.x, touButton.transform.localPosition.y + 0.6f, touButton.transform.localPosition.z);

                    PassiveButton passiveTORButton = touButton.GetComponent<PassiveButton>();
                    SpriteRenderer touButtonSprite = touButton.GetComponent<SpriteRenderer>();
                    passiveTORButton.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();

                    touButtonSprite.sprite = TORUpdateSprite;

                    //Add onClick event to run the update on button click
                    passiveTORButton.OnClick.AddListener((Action) (() =>
                    {
                        ModUpdater.ExecuteUpdate("TOR");
                        touButton.SetActive(false);
                    }));
                    
                    //Set button text
                    var text = touButton.transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
                    __instance.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) => {
                        text.SetText("");
                    })));

                    //Set popup stuff
                    TwitchManager man = DestroyableSingleton<TwitchManager>.Instance;
                    ModUpdater.InfoPopup = UnityEngine.Object.Instantiate<GenericPopup>(man.TwitchPopup);
                    ModUpdater.InfoPopup.TextAreaTMP.fontSize *= 0.7f;
                    ModUpdater.InfoPopup.TextAreaTMP.enableAutoSizing = false;
                }
            }
            if (ModUpdater.hasSubmergedUpdate) {
                //If there's an update, create and show the update button
                var template = GameObject.Find("ExitGameButton");
                if (template != null) {

                    var submergedButton = UnityEngine.Object.Instantiate(template, null);
                    submergedButton.transform.localPosition = new Vector3(submergedButton.transform.localPosition.x, submergedButton.transform.localPosition.y + 1.2f, submergedButton.transform.localPosition.z);

                    PassiveButton passiveSubmergedButton = submergedButton.GetComponent<PassiveButton>();
                    SpriteRenderer submergedButtonSprite = submergedButton.GetComponent<SpriteRenderer>();
                    passiveSubmergedButton.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();

                    submergedButtonSprite.sprite = SubmergedUpdateSprite;

                    //Add onClick event to run the update on button click
                    passiveSubmergedButton.OnClick.AddListener((Action) (() =>
                    {
                        ModUpdater.ExecuteUpdate("Submerged");
                        submergedButton.SetActive(false);
                    }));
                    
                    //Set button text
                    var text = submergedButton.transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
                    __instance.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) => {
                        text.SetText("");
                    })));

                    //Set popup stuff
                    TwitchManager man = DestroyableSingleton<TwitchManager>.Instance;
                    ModUpdater.InfoPopup = UnityEngine.Object.Instantiate<GenericPopup>(man.TwitchPopup);
                    ModUpdater.InfoPopup.TextAreaTMP.fontSize *= 0.7f;
                    ModUpdater.InfoPopup.TextAreaTMP.enableAutoSizing = false;
                }
            }
        }
    }

    public class ModUpdater { 
        public static bool running = false;
        public static bool hasTORUpdate = false;
        public static bool hasSubmergedUpdate = false;
        public static string updateTORURI = null;
        public static string updateSubmergedURI = null;
        private static Task updateTORTask = null;
        private static Task updateSubmergedTask = null;
        public static GenericPopup InfoPopup;

        public static void LaunchUpdater() {
            if (running) return;
            running = true;

            checkForUpdate("TOR").GetAwaiter().GetResult();

            //Only check of Submerged update if Submerged is already installed
            string codeBase = Assembly.GetExecutingAssembly().Location;
            System.UriBuilder uri = new System.UriBuilder(codeBase);
            string submergedPath = System.Uri.UnescapeDataString(uri.Path.Replace("TownOfRoles", "Submerged"));
            if (File.Exists(submergedPath)) {
                checkForUpdate("Submerged").GetAwaiter().GetResult();
            }

            clearOldVersions();
        }

        public static void ExecuteUpdate(string updateType = "TOR") {
            string info = "";
            if (updateType == "TOR") {
                info = "Updating Town of Roles\nPlease wait...";
                ModUpdater.InfoPopup.Show(info);
                if (updateTORTask == null) {
                    if (updateTORURI != null) {
                        updateTORTask = downloadUpdate("TOR");
                    } else {
                        info = "Unable to auto-update\nPlease update manually";
                    }
                } else {
                    info = "Update might already\nbe in progress";
                }
            }
            else if (updateType == "Submerged") {
                info = "Updating Submerged\nPlease wait...";
                ModUpdater.InfoPopup.Show(info);
                if (updateSubmergedTask == null) {
                    if (updateSubmergedURI != null) {
                        updateSubmergedTask = downloadUpdate("Submerged");
                    } else {
                        info = "Unable to auto-update\nPlease update manually";
                    }
                } else {
                    info = "Update might already\nbe in progress";
                }
            }
            ModUpdater.InfoPopup.StartCoroutine(Effects.Lerp(0.01f, new System.Action<float>((p) => { ModUpdater.setPopupText(info); })));
        }
        
        public static void clearOldVersions() {
            //Removes any old versions (Denoted by the suffix `.old`)
            try {
                DirectoryInfo d = new DirectoryInfo(Path.GetDirectoryName(Application.dataPath) + @"\BepInEx\plugins");
                string[] files = d.GetFiles("*.old").Select(x => x.FullName).ToArray();
                foreach (string f in files)
                    File.Delete(f);
            } catch (System.Exception e) {
                PluginSingleton<TownOfRoles>.Instance.Log.LogMessage("Exception occured when clearing old versions:\n" + e);
            }
        }
        public static async Task<bool> checkForUpdate(string updateType = "TOR") {
            //Checks the github api for Town of Roles tags. Compares current version (from VersionString in TownOfRoles.cs) to the latest tag version(on GitHub)
            try {
                string githubURI = "";
                if (updateType == "TOR") {
                    githubURI = "https://api.github.com/repos/Jsushi7/Town-Of-Roles/releases/latest";
                } else if (updateType == "Submerged") {
                    githubURI = "https://api.github.com/repos/SubmergedAmongUs/Submerged/releases/latest";
                }
                HttpClient http = new HttpClient();
                http.DefaultRequestHeaders.Add("User-Agent", "TownOfRoles Updater");
                var response = await http.GetAsync(new System.Uri(githubURI), HttpCompletionOption.ResponseContentRead);
                
                if (response.StatusCode != HttpStatusCode.OK || response.Content == null) {
                    PluginSingleton<TownOfRoles>.Instance.Log.LogMessage("Server returned no data: " + response.StatusCode.ToString());
                    return false;
                }
                string json = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<GitHubApiObject>(json);

                string tagname = data.tag_name;
                if (tagname == null) {
                    return false; // Something went wrong
                }

                int diff = 0;
                System.Version ver = System.Version.Parse(tagname.Replace("v", ""));
                if (updateType == "TOR") { //Check TOR version
                    diff = TownOfRoles.Version.CompareTo(ver);
                    if (diff < 0) { // TOR update required
                        hasTORUpdate = true;
                    }
                } else if (updateType == "Submerged") {
                    //account for broken version
                    if (Patches.SubmergedCompatibility.Version == null) hasSubmergedUpdate = true;
                    else
                    {
                        diff = Patches.SubmergedCompatibility.Version.CompareTo(SemanticVersioning.Version.Parse(tagname.Replace("v", ""))); ;
                        if (diff < 0)
                        { // Submerged update required
                            hasSubmergedUpdate = true;
                        }
                    } 
                }
                var assets = data.assets;
                if (assets == null)
                    return false;

                foreach (var asset in assets)
                {
                    if (asset.browser_download_url == null) continue;
                    if (asset.browser_download_url.EndsWith(".dll"))
                    {
                        if (updateType == "TOR")
                        {
                            updateTORURI = asset.browser_download_url;
                        }
                        else if (updateType == "Submerged")
                        {
                            updateSubmergedURI = asset.browser_download_url;
                        }
                        return true;
                    }
                }
            } catch (System.Exception ex) {
                PluginSingleton<TownOfRoles>.Instance.Log.LogMessage(ex);
            }
            return false;
        }

        public static async Task<bool> downloadUpdate(string updateType = "TOR") {
            //Downloads the new TownOfRoles/Submerged dll from GitHub into the plugins folder
            string downloadDLL= "";
            string info = "";
            if (updateType == "TOR") {
                downloadDLL = updateTORURI;
                info = "Town of Roles\nupdated successfully.\nPlease RESTART the game.";
            } else if (updateType == "Submerged") {
                downloadDLL = updateSubmergedURI;
                info = "Submerged\nupdated successfully.\nPlease RESTART the game.";
            }
            try {
                HttpClient http = new HttpClient();
                http.DefaultRequestHeaders.Add("User-Agent", "TownOfRoles Updater");
                var response = await http.GetAsync(new System.Uri(downloadDLL), HttpCompletionOption.ResponseContentRead);
                if (response.StatusCode != HttpStatusCode.OK || response.Content == null) {
                    PluginSingleton<TownOfRoles>.Instance.Log.LogMessage("Server returned no data: " + response.StatusCode.ToString());
                    return false;
                }
                string codeBase = Assembly.GetExecutingAssembly().Location;
                System.UriBuilder uri = new System.UriBuilder(codeBase);
                string fullname = System.Uri.UnescapeDataString(uri.Path);
                if (updateType == "Submerged") {
                    fullname = fullname.Replace("TownOfRoles", "Submerged"); //TODO A better solution than this to correctly name the dll files
                }
                if (File.Exists(fullname + ".old")) // Clear old file in case it wasnt;
                    File.Delete(fullname + ".old");

                File.Move(fullname, fullname + ".old"); // rename current executable to old

                using (var responseStream = await response.Content.ReadAsStreamAsync()) {
                    using (var fileStream = File.Create(fullname)) {
                        responseStream.CopyTo(fileStream);
                    }
                }
                showPopup(info);
                return true;
            } catch (System.Exception ex) {
                PluginSingleton<TownOfRoles>.Instance.Log.LogMessage(ex);
            }
            showPopup("Update wasn't successful\nTry again later,\nor update manually.");
            return false;
        }
        private static void showPopup(string message) {
            setPopupText(message);
            InfoPopup.gameObject.SetActive(true);
        }

        public static void setPopupText(string message) {
            if (InfoPopup == null)
                return;
            if (InfoPopup.TextAreaTMP != null) {
                InfoPopup.TextAreaTMP.text = message;
            }
        }


        class GitHubApiObject
        {
            [JsonPropertyName("tag_name")]
            public string tag_name { get; set; }
            [JsonPropertyName("assets")]
            public GitHubApiAsset[] assets { get; set; }
        }

        class GitHubApiAsset
        {
            [JsonPropertyName("browser_download_url")]
            public string browser_download_url { get; set; }
        }


    }

}