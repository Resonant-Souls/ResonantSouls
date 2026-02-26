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
        public override string Texture => Debug.Placeholder;
        public override Color nameColor => Color.White;
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