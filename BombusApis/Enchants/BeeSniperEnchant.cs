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
        public override string Texture => Debug.Placeholder;
        public override Color nameColor => Color.White;
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