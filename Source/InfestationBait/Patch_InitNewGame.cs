using System;
using System.Collections.Generic;
using Verse;
using HarmonyLib;

namespace InfestationBait
{
	[HarmonyPatch(typeof(Game))]
	[HarmonyPatch("InitNewGame")]
	internal static class Patch_InitNewGame
	{
		private static bool Prefix()
		{
			InfestationBaitSettings.mapDict=new Dictionary<Map,Thing>();
			return true;
		}
	}
}
