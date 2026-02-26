using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using ResonantSouls.BombusApis.Core;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class BeekeeperEnchant : BaseEnchant
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance.Enchantments;
        public override string Texture => this.BombusTexture();
        public override Color nameColor => new(164, 179, 193);
        public override void SetDefaults()
        {
            Item.height = 32;
            Item.width = 44;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<BeekeepersVeil>())
            .AddIngredient(ModContent.ItemType<BeekeepersRobe>())
            .AddIngredient(ModContent.ItemType<BeekeepersPants>())
            .AddIngredient(ModContent.ItemType<Beemerang>())
            .AddIngredient(ModContent.ItemType<FrostedHoneycomb>())
            .AddIngredient(ModContent.ItemType<HoneyGun>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}