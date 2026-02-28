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
        public override string Texture => this.BombusTexture();
        public override Color nameColor => new(185, 107, 23);
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 36;
            Item.height = 32;
        }
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