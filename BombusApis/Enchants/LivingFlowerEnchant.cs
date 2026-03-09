using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using ResonantSouls.BombusApis.Core;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class LivingFlowerEnchant : BaseEnchant
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance?.Enchantments ?? false;
        public override string Texture => ResonantSoulsBombusApisSystems.BombusTexture(this);
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
            .AddIngredient(ModContent.ItemType<LivingFlowerCrown>())
            .AddIngredient(ModContent.ItemType<LivingFlowerChestplate>())
            .AddIngredient(ModContent.ItemType<LivingFlowerLeggings>())
            .AddIngredient(ModContent.ItemType<BladeOfAculeus>())
            .AddIngredient(ModContent.ItemType<Honeycomb>())
            .AddIngredient(ModContent.ItemType<HoneyFlareGun>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}