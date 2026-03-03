using System.Collections.Generic;
using System.Linq;
using Fargowiltas.Content.Items.Tiles;
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
        public static readonly List<ModItem> Forces = [];
        public override void Load()
        {
            ModContent.TryFind(ModCompatibility.ResonantSouls.Name, "PollinationForce", out ModItem PollinationForce);
            if (ModCompatibility.BombusApisBee.Loaded && PollinationForce != null) Forces.Add(PollinationForce);

            ModContent.TryFind(ModCompatibility.FargoClickers.Name, "ForceOfMatrix", out ModItem ForceOfMatrix);
            if (ModCompatibility.FargoClickers.Loaded && ForceOfMatrix != null) Forces.Add(ForceOfMatrix);
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
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            Forces.ForEach(force => recipe.AddIngredient(force));
            recipe.AddIngredient<AbomEnergy>(10)
            .AddTile<CrucibleCosmosSheet>()
            .Register();
        }
        static string Icon(ModItem item)
        {
            return $"[i:{item.Mod.Name}/{item.Name}]";
        }
        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
            int Tooltip0 = tooltips.FindIndex(line => line.Name == "Tooltip0");

            if (IsNotRuminating(Item))
            {
                tooltips.Insert(Tooltip0, new TooltipLine(Mod, "Forces", string.Concat(Forces.Select(Icon)) + " " + Language.GetTextValue("Mods.ResonantSouls.Items.MicroverseSoul.Forces")));
            }
            else
            {
                Forces.ForEach(force => tooltips.Insert(Tooltip0 + Forces.IndexOf(force), new TooltipLine(Mod, force.Name, Language.GetTextValue($"Mods.ResonantSouls.Items.MicroverseSoul.Effects.{force.Name}"))));
            }
        }
    }
}