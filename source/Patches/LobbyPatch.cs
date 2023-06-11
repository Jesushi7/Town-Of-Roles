using HarmonyLib;
using UnityEngine;

namespace TownOfRoles;

[HarmonyPatch(typeof(LobbyBehaviour), nameof(LobbyBehaviour.FixedUpdate))]
public class LobbyFixedUpdatePatch
{
    private static GameObject Paint;
    public static void Postfix()
    {
        if (Paint == null && Classes.GameStates.IsLobby)
        {
            var LeftBox = GameObject.Find("Leftbox");
            if (LeftBox != null && !Classes.GameStates.IsInGame)
            {
                Paint = Object.Instantiate(LeftBox, LeftBox.transform.parent.transform);
                Paint.name = "Lobby Paint";
                Paint.transform.localPosition = new Vector3(0.042f, -10f, -20);
                SpriteRenderer renderer = Paint.GetComponent<SpriteRenderer>();
                var spriteObject = new GameObject("LobbyPaintSprite");
                spriteObject.AddComponent<SpriteRenderer>().sprite = TownOfRoles.LobbyPaintSprite;
            }
        }
    }
}