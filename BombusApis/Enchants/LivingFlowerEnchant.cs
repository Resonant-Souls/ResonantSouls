using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using ResonantSouls.BombusApis.Core;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class LivingFlowerEnchant : BaseEnchant
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance.Enchantments;
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