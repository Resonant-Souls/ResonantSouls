using System.Collections.Generic;
using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Content.Rarities;
using ResonantSouls.Clicker;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;

namespace ResonantSouls.Content.Items.Accessories.Souls
{
    public class MicroverseSoul : BaseSoul
    {
        public override string Texture => "ResonantSouls/Assets/Textures/Content/Items/Accessories/Souls/MicroverseSoul";
        public static readonly List<ModItem> Forces = [];
        public static bool Click => ModCompatibility.FargoClickers.Loaded && ModCompatibility.ClickerClass.Loaded && ResonantSoulsFargosClickerConfig.ClickerCompat;
        public static bool Bee => ModCompatibility.BombusApisBee.Loaded;
        public static bool Bloom => ModCompatibility.OrchidMod.Loaded;
        public static void AddForce(bool ModLoaded, string Forcename, string Modname = "ResonantSouls")
        {
            if (ModLoaded && TryFind(Forcename, out ModItem force))
            {
                Forces.Add(force);
            }
        }
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 40));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            AddForce(Bee, "PollinationForce");
            AddForce(Click, "ForceOfMatrix", ModCompatibility.FargoClickers.Name);
            AddForce(Bloom, "BloomForce");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 84;
            Item.rare = RarityType<AbominableRarity>();
            Item.height = 120;
        }
        public override void AddRecipes()
        {
            if (Forces.Count == 0)
                return;

            Recipe recipe = CreateRecipe();
            Forces.ForEach(force => recipe.AddIngredient(force));
            recipe.AddIngredient<AbomEnergy>(10)
            .AddTile<CrucibleCosmosSheet>()
            .Register();
        }
        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
            int Tooltip0 = tooltips.FindIndex(line => line.Name == "Tooltip0");
            int Tooltip = tooltips.FindLastIndex(t => t.Name.StartsWith("Tooltip") && t.Mod == "Terraria");

            if (IsNotRuminating(Item))
            {
                tooltips.Insert(Tooltip, new TooltipLine(Mod, "Forces", string.Concat(
                    (Bee ? $"[i:{Mod.Name}/PollinationForce]" : "") +
                    (Click ? "[i:FargoClickers/ForceOfMatrix]" : "") +
                    (Bloom ? $"[i:{Mod.Name}/BloomForce]" : "") +
                    (Forces.Count > 0 ? " " : "") +
                    Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Forces"))));
            }
            else
            {
                if (Click)
                {
                    tooltips.Insert(Tooltip, new(Mod, "ForceOfMatrix", Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Effects.ForceOfMatrix")));
                }
                if (Bee)
                {
                    tooltips.Insert(Tooltip, new(Mod, "PollinationForce", Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Effects.PollinationForce")));
                }
                if (Bloom)
                {
                    tooltips.Insert(Tooltip, new(Mod, "BloomForce", Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Effects.BloomForce")));
                }
            }
        }
    }
}