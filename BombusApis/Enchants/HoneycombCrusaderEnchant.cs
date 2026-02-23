using BombusApisBee.Items.Accessories.BeeKeeperDamageClass;
using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using ResonantSouls.BombusApis.Core;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class HoneycombCrusaderEnchant : BaseEnchant
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance.Enchantments;
        public override string Texture => Debug.Placeholder;
        public override Color nameColor => Color.White;
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<HoneycombCrusaderEnchant>())
            .AddIngredient(ModContent.ItemType<HoneycombCrusaderPlatemail>())
            .AddIngredient(ModContent.ItemType<HoneycombCrusaderGreaves>())
            .AddIngredient(ModContent.ItemType<CystComb>())
            .AddIngredient(ModContent.ItemType<CursedHoneycomb>())
            .AddIngredient(ModContent.ItemType<TriTipStinger>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}