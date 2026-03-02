using System.Collections.Generic;
using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;

namespace ResonantSouls.Content.Items.Accessories.Souls
{
    public class MicroverseSoul : BaseSoul
    {
        public override string Texture => "ResonantSouls/Assets/Textures/Content/Items/Accessories/Souls/MicroverseSoul";
        public static readonly List<int> Forces = [];
        public override void Load()
        {
            base.Load();

            ModContent.TryFind(ModCompatibility.ResonantSouls.Name, "PollinationForce", out ModItem PollinationForce);
            if (ModCompatibility.BombusApisBee.Loaded && PollinationForce != null) Forces.Add(PollinationForce.Type);

            ModContent.TryFind(ModCompatibility.FargoClickers.Name, "ForceOfMatrix", out ModItem ForceOfMatrix);
            if (ModCompatibility.FargoClickers.Loaded && ForceOfMatrix != null) Forces.Add(ForceOfMatrix.Type);
        }
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 40));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 84;
            Item.height = 120;

            // This item doesn't have a tooltip if it's not an expert item
            Item.expert = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            foreach (int force in Forces)
                recipe.AddIngredient(force);

            recipe.AddIngredient<AbomEnergy>(10)
            .AddTile<CrucibleCosmosSheet>()
            .Register();
        }
        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
            base.SafeModifyTooltips(tooltips);
            int tooltip0 = tooltips.FindIndex(t => t.Name == "Tooltip0");

            if (IsNotRuminating(Item))
            {
                tooltips.Insert(tooltip0 + 2, new TooltipLine(Mod, "Forces", " " + Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Forces")));
            }
        }
    }
}