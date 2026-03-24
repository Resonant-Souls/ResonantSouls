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
        // I met a traveller from an antique land
        // Who said: Two vast and trunkless legs of stone
        // Stand in the desert. Near them, on the sand,
        // Half sunk, a shattered visage lies, whose frown,
        // And wrinkled lip, and sneer of cold command,
        // Tell that its sculptor well those passions read
        // Which yet survive, stamped on these lifeless things,
        // The hand that mocked them, and the heart that fed:
        // And on the pedestal, these words appear:
        // My name is Ozymandias, King of Kings;
        // Look on my Works, ye Mighty, and despair!
        // Nothing beside remains. Round the decay
        // Of that colossal Wreck, boundless and bare
        // The lone and level sands stretch far away.
        // - Cheesenuggets
        public override string Texture => "ResonantSouls/Assets/Textures/Content/Items/Accessories/Souls/MicroverseSoul";
        public static readonly List<ModItem> Forces = [ ];
        public static bool Click => ModCompatibility.FargoClickers.Loaded && ModCompatibility.ClickerClass.Loaded && ResonantSoulsFargosClickerConfig.ClickerCompat;
        public static bool Bee => ModCompatibility.BombusApisBee.Loaded;
        public static bool Bloom => ModCompatibility.OrchidMod.Loaded;
        public static void AddForce(bool ModLoaded, string ModName, string Forcename)
        {
            if (ModLoaded && ModContent.TryFind(ModName, Forcename, out ModItem force))
                Forces.Add(force);
        }
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 40));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            AddForce(Bee, Mod.Name, "PollinationForce");
            AddForce(Click, ModCompatibility.FargoClickers.Name, "ForceOfMatrix");
            AddForce(Bloom, Mod.Name, "BloomForce");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 84;
            Item.rare = ModContent.RarityType<AbominableRarity>();
            Item.height = 120;
        }
        public override void AddRecipes()
        {
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
                    tooltips.Insert(Tooltip, new TooltipLine(Mod, "ForceOfMatrix", Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Effects.ForceOfMatrix")));
                }
                if (Bee)
                {
                    tooltips.Insert(Tooltip, new TooltipLine(Mod, "PollinationForce", Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Effects.PollinationForce")));
                }
                if (Bloom)
                {
                    tooltips.Insert(Tooltip, new TooltipLine(Mod, "BloomForce", Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Effects.BloomForce")));
                }
            }
        }
    }
}