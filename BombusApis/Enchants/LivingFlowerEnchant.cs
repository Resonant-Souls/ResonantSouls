using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using ResonantSouls.Common.Utilities;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class LivingFlowerEnchant : BaseEnchant
    {
        public override string Texture => this.BombusTexture();
        public override Color nameColor => new(184, 139, 96);
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 42;
            Item.height = 42;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemType<LivingFlowerCrown>())
            .AddIngredient(ItemType<LivingFlowerChestplate>())
            .AddIngredient(ItemType<LivingFlowerLeggings>())
            .AddIngredient(ItemType<BladeOfAculeus>())
            .AddIngredient(ItemType<Honeycomb>())
            .AddIngredient(ItemType<HoneyFlareGun>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}