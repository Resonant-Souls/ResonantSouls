using FargowiltasSouls.Content.Items.Accessories.Forces;
using ResonantSouls.BombusApis.Core;
using ResonantSouls.BombusApis.Enchants;

namespace ResonantSouls.BombusApis.Forces
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class PollinationForce : BaseForce
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance.Enchantments;
        public override string Texture => Debug.Placeholder;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Enchants[Type] =
            [
                ModContent.ItemType<BeekeeperEnchant>(),
                ModContent.ItemType<HoneycombCrusaderEnchant>(),
                ModContent.ItemType<HoneyphyteEnchant>(),
                ModContent.ItemType<BeeSniperEnchant>(),
                ModContent.ItemType<LivingFlowerEnchant>(),
                ModContent.ItemType<SkeletalBeeEnchant>(),
                ModContent.ItemType<WaspEnchant>()
            ];
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            SetActive(player);

            //    player.AddEffect<Effect>(Item);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            foreach (int ench in Enchants[Type])
                recipe.AddIngredient(ench);
            recipe.AddTile<LuminiteOmniforgeTile>();
            recipe.Register();
        }
    }
}