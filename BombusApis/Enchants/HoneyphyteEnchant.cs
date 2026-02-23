using BombusApisBee.Items.Accessories.BeeKeeperDamageClass;
using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using ResonantSouls.BombusApis.Core;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class HoneyphyteEnchant : BaseEnchant
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance.Enchantments;
        public override string Texture => Debug.Placeholder;
        public override Color nameColor => Color.White;
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup("ResonantSouls:AnyHoneyphyteMask")
            .AddIngredient(ModContent.ItemType<HoneyphyteChestpiece>())
            .AddIngredient(ModContent.ItemType<HoneyphyteGreaves>())
            .AddIngredient(ModContent.ItemType<LihzardianHornetRelic>())
            .AddIngredient(ModContent.ItemType<TomeOfTheSun>())
            .AddIngredient(ModContent.ItemType<MegaHornet>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}