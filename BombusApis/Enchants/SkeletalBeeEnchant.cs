using BombusApisBee.Items.Accessories.BeeKeeperDamageClass;
using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using ResonantSouls.BombusApis.Core;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class SkeletalBeeEnchant : BaseEnchant
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance.Enchantments;
        public override string Texture => Debug.Placeholder;
        public override Color nameColor => Color.White;
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<SkeletalBeeHelmet>())
            .AddIngredient(ModContent.ItemType<SkeletalBeeChestplate>())
            .AddIngredient(ModContent.ItemType<SkeletalBeeLeggings>())
            .AddIngredient(ModContent.ItemType<Beemstick>())
            .AddIngredient(ModContent.ItemType<HellcombShard>())
            .AddIngredient(ModContent.ItemType<BeenadeLauncher>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}