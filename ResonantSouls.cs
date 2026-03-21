global using Terraria;
global using Terraria.ModLoader;
global using ResonantSouls.Core;
global using LumUtils = Luminance.Common.Utilities.Utilities;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System.Collections.Generic;

namespace ResonantSouls
{
    public class ResonantSouls : Mod
    {
        internal static ResonantSouls? Instance;
        public override void Load()
        {
            Instance = this;
            Fargowiltas.Fargowiltas.SoulsMods.Add(Instance.Name);
        }
        public override void Unload()
        {
            Instance = null;
        }
    }

    public class DebugItem : GlobalItem
    {
        internal const string Placeholder = "FargowiltasSouls/Content/Items/Placeholder";
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!ResonantSoulsClientConfig.Debug)
                return;

            TooltipLine Value = new(Mod, "Value", "Value: " + item.value.ToString())
            {
                OverrideColor = Color.Green
            };
            tooltips.Add(Value);
            TooltipLine Rare = new(Mod, "Rarity", "Rarity: " + item.rare.ToString())
            {
                OverrideColor = Color.Cyan
            };
            tooltips.Add(Rare);
            TooltipLine Name = new(Mod, "Name", "Name: " + ItemID.Search.GetName(item.type))
            {
                OverrideColor = Color.Red
            };
            tooltips.Add(Name);
        }
    }
}