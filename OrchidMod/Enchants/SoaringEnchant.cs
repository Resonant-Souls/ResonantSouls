using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using OrchidMod.Content.Guardian.Weapons.Shields;
using OrchidMod.Content.Shapeshifter.Armors.Harpy;
using OrchidMod.Content.Shapeshifter.Weapons.Predator;
using Terraria.ID;

namespace ResonantSouls.OrchidMod.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class SoaringEnchant : BaseEnchant
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
            .AddIngredient<ShapeshifterHarpyHead>()
            .AddIngredient<ShapeshifterHarpyChest>()
            .AddIngredient<ShapeshifterHarpyLegs>()
            .AddIngredient<PredatorHarpy>()
            .AddIngredient<SkywareShield>()
            .AddIngredient(ItemID.GiantHarpyFeather)
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}