using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using ResonantSouls.BombusApis.Core;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class BeeSniperEnchant : BaseEnchant
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance.Enchantments;
        public override string Texture => this.BombusTexture();
        public override Color nameColor => new(121, 135, 170);
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 48;
            Item.height = 40;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<BeeSniperGoggles>())
            .AddIngredient(ModContent.ItemType<BeeSniperArmor>())
            .AddIngredient(ModContent.ItemType<BeeSniperLeggings>())
            .AddIngredient(ModContent.ItemType<BeekeeperEnchant>())
            .AddIngredient(ModContent.ItemType<TheStingerSlinger>())
            .AddIngredient(ModContent.ItemType<TheStarSwarmer>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}