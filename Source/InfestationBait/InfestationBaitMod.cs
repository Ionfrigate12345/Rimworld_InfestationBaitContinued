﻿/*
 * Created by SharpDevelop.
 * User: Tobias
 * Date: 10.09.2018
 * Time: 20:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;


namespace InfestationBait
{
    /// <summary>
    /// Description of InfestationBaitMod.
    /// </summary>
    public class InfestationBaitMod : Mod
	{
		public InfestationBaitSettings settings;
		
		public InfestationBaitMod(ModContentPack content) : base(content)
		{
            var harmonyInstance = new Harmony("NavySeal5.InfestationBait");
			harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
			var methods = harmonyInstance.GetPatchedMethods();		
			
			this.settings = this.GetSettings<InfestationBaitSettings>();
		}
		
		public override string SettingsCategory()
		{
			return "InfestationBait_SettingsCategory".Translate();
		}
		
		
		public override void DoSettingsWindowContents(Rect rect)
		{
			Listing_Standard listing= new Listing_Standard(GameFont.Tiny);
			listing.ColumnWidth = rect.width/3f;
			listing.Begin(rect);
			listing.Gap();
			{
				string text = InfestationBaitSettings.baitChance.ToString();
				Rect rectLine = listing.GetRect(Text.LineHeight);
				Rect rectLeft = rectLine.LeftHalf().Rounded();
				Rect rectRight = rectLine.RightHalf().Rounded();
				Widgets.DrawHighlightIfMouseover(rectLine);
				TooltipHandler.TipRegion(rectLine,"InfestationBait_BaitChanceTooltip".Translate());
                TextAnchor anchor = Text.Anchor;
				Text.Anchor = TextAnchor.MiddleLeft;
				Widgets.Label(rectLeft,"InfestationBait_BaitChanceLabel".Translate());
				Text.Anchor= anchor;
				Widgets.TextFieldNumeric(rectRight,ref InfestationBaitSettings.baitChance,ref text,0,100);
					
			}
			listing.End();
			
			
		}
	}
}
