using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using ResonantSouls.Content.Items.Accessories.Souls;
    
namespace ResonantSouls.Calamity.Core
{

    [JITWhenModsEnabled(ModCompatibility.CalamityMod.Name, ModCompatibility.FargowiltasCrossmod.Name)]
    [ExtendsFromMod(ModCompatibility.CalamityMod.Name, ModCompatibility.FargowiltasCrossmod.Name)]
    public class ResonantSoulsCalamityRecipes : ModSystem
    {
        public override void PostSetupRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                List<int> Tier2Souls =
                [
                    ModContent.ItemType<MicroverseSoul>(),
                ];

                if (Tier2Souls.Contains(recipe.createItem.type) && !recipe.HasIngredient(ModContent.ItemType<AshesofAnnihilation>()))
                {
                    recipe.AddIngredient<AshesofAnnihilation>(5);
                    recipe.AddIngredient<ExoPrism>(5);
                    if (recipe.RemoveTile(ModContent.TileType<CrucibleCosmosSheet>()))
                    {
                        recipe.AddTile<DraedonsForge>();
                    }
                }
            }
        }
    }
}