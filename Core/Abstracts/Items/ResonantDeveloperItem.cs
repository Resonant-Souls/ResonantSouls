using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace ResonantSouls.Core.Abstracts.Items
{
    public abstract class ResonantDeveloperItem : ModItem
    {
        public abstract string Developer { get; }
        public abstract string ItemPath { get; }
        public override string Texture => $"{Mod.Name}/Assets/Textures/Content/Items/{ItemPath}/{Name}";
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine Dedicated = new(Mod, "Dedicated", "- " + Language.GetTextValue("Mods.ResonantSouls.Items.Developer.Dedicated") + " " + Language.GetTextValue($"Mods.ResonantSouls.Items.Developer.{Developer}") + " -")
            {
                OverrideColor = Color.Lerp(new(34, 221, 151), new(57, 170, 178), (float)Math.Abs(Math.Sin(Main.GlobalTimeWrappedHourly)))
            };
            tooltips.Add(Dedicated);
        }
    }
}