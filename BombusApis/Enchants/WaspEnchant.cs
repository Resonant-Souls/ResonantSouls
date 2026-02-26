using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using ResonantSouls.BombusApis.Core;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class WaspEnchant : BaseEnchant
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance.Enchantments;
        public override string Texture => Debug.Placeholder;
        public override Color nameColor => Color.White;
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<WaspHead>())
            .AddIngredient(ModContent.ItemType<WaspBreastplate>())
            .AddIngredient(ModContent.ItemType<WaspGreaves>())
            .AddIngredient(ModContent.ItemType<BrainyHoneycomb>())
            .AddIngredient(ModContent.ItemType<EaterOfHoneycombs>())
            .AddIngredient(ModContent.ItemType<NectarBolt>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }

    }
}