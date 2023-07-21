using System.Linq;
using AmongUs.GameOptions;
using HarmonyLib;
using InnerNet;

namespace TownOfSushi.Classes
{
    //Thanks to Town Of Us Reworked for this Code
    [HarmonyPatch]
    public static class GameStates
    {
        public static bool IsMeeting => IsInGame && MeetingHud.Instance;        
        public static bool IsCountDown => GameStartManager.Instance && GameStartManager.Instance.startState == GameStartManager.StartingStates.Countdown;
        public static bool IsInGame => (AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started || GameManager.Instance?.GameHasStarted ==  true) && !LobbyBehaviour.Instance;
        public static bool IsLobby => AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Joined || LobbyBehaviour.Instance;
        public static bool IsEnded => AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Ended;
        public static bool IsHnS => GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.HideNSeek;
        public static bool IsNormal => GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.Normal;
        public static bool IsOnlineGame => AmongUsClient.Instance.NetworkMode == NetworkModes.OnlineGame;
        public static bool IsLocalGame => AmongUsClient.Instance.NetworkMode == NetworkModes.LocalGame;
        public static bool IsFreePlay => AmongUsClient.Instance.NetworkMode == NetworkModes.FreePlay;
    }
}