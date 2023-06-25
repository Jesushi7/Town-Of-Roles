/*using System;
using System.Linq;
using HarmonyLib;
using TMPro;
using TownOfRoles.Extensions;
using TownOfRoles.Roles;
using UnityEngine;

namespace TownOfRoles.NeutralRoles.JackalMod
{
	[HarmonyPatch(typeof(EndGameManager), "Start")]
	public class Outro
	{

		public static void Postfix(EndGameManager __instance)
		{
			Role role = Role.AllRoles.FirstOrDefault((Role x) => x.RoleType == RoleEnum.Jackal && Role.JackalWins);
			bool flag = role == null;
			if (!flag)
			{
				PoolablePlayer[] array = UnityEngine.Object.FindObjectsOfType<PoolablePlayer>();
				foreach (PoolablePlayer player in array)
				{
					player.NameText().text = role.ColorString + player.NameText().text + "</color>";
				}
				__instance.BackgroundBar.material.color = role.Color;
				TextMeshPro text = UnityEngine.Object.Instantiate<TextMeshPro>(__instance.WinText);
				text.text = "Jackals Win!";
				text.color = role.Color;
				Vector3 pos = __instance.WinText.transform.localPosition;
				pos.y = 1.5f;
				text.transform.position = pos;
				text.text = "<size=4>" + text.text + "</size>";
			}
		}
	}
}*/
