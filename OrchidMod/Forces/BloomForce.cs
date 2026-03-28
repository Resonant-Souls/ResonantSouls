using FargowiltasSouls.Content.Items.Accessories.Forces;
using Fargowiltas.Content.Items.Tiles;
using ResonantSouls.OrchidMod.Enchants;

namespace ResonantSouls.OrchidMod.Forces
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class BloomForce : BaseForce
    {
        public override string Texture => DebugItem.Placeholder;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Enchants[Type] =
            [
                ItemType<BambooEnchant>(),
                ItemType<DawnlightEnchant>(),
                ItemType<HorizonEnchant>(),
                ItemType<MeteorWardenEnchant>(),
                ItemType<PyreEnchant>(),
                ItemType<SoaringEnchant>(),
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
            //    recipe.AddIngredient<Eridanium>(5);
            recipe.AddTile<LuminiteOmniforgeTile>();
            recipe.Register();
        }
    }
}