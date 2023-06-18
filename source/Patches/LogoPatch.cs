using System;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace TownOfRoles
{
	[HarmonyPatch(typeof(MainMenuManager), "Start")]
	public static class LogoPatch
	{
		private static Sprite Sprite
		{
			get
			{
				return TownOfRoles.ToUBanner;
			}
		}

		private static void Postfix(PingTracker __instance)
		{
			GameObject touLogo = new GameObject("bannerLogo_TownOfRoles");
			touLogo.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
			SpriteRenderer renderer = touLogo.AddComponent<SpriteRenderer>();
			renderer.sprite = LogoPatch.Sprite;
			AspectPosition position = touLogo.AddComponent<AspectPosition>();
			position.DistanceFromEdge = new Vector3(-0.2f, 1f, 10f);
			AspectScaledAsset scaler = touLogo.AddComponent<AspectScaledAsset>();
			List<SpriteRenderer> renderers = new List<SpriteRenderer>();
			renderers.Add(renderer);
			scaler.spritesToScale = renderers;
			scaler.aspectPosition = position;
			touLogo.transform.SetParent(GameObject.Find("RightPanel").transform);
		}
	}
}
