using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using OrchidMod.Content.Guardian.Weapons.Warhammers;
using OrchidMod.Content.Shapeshifter.Armors.Ashwood;
using OrchidMod.Content.Shapeshifter.Weapons.Sage;
using Terraria.ID;

namespace ResonantSouls.OrchidMod.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class PyreEnchant : BaseEnchant
    {
        public override string Texture => ResonantSouls.Placeholder;
        public override Color nameColor => Color.White;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 22;
            Item.height = 24;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient<ShapeshifterAshwoodHead>()
            .AddIngredient<ShapeshifterAshwoodChest>()
            .AddIngredient<ShapeshifterAshwoodLegs>()
            .AddIngredient<SageImp>()
            .AddIngredient<HellWarhammer>()
            .AddIngredient(ItemID.AshWoodCandelabra)
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}