using FargowiltasSouls.Content.Items.Accessories.Forces;
using ResonantSouls.BombusApis.Enchants;
using Fargowiltas.Content.Items.Tiles;

namespace ResonantSouls.BombusApis.Forces
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class PollinationForce : BaseForce
    {
        public override string Texture => DebugItem.Placeholder;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Enchants[Type] =
            [
                ItemType<BeekeeperEnchant>(),
                ItemType<HoneycombCrusaderEnchant>(),
                ItemType<HoneyphyteEnchant>(),
                ItemType<BeeSniperEnchant>(),
                ItemType<LivingFlowerEnchant>(),
                ItemType<SkeletalBeeEnchant>(),
                ItemType<WaspEnchant>()
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