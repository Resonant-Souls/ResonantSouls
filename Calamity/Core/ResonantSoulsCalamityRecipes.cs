using System.Collections.Generic;
using CalamityMod.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Fargowiltas.Content.Items.Tiles;
using ResonantSouls.Common.Utilities;
using ResonantSouls.Content.Items.Accessories.Souls;

namespace ResonantSouls.Calamity.Core
{

    [JITWhenModsEnabled(ModCompatibility.CalamityMod.Name, ModCompatibility.FargowiltasCrossmod.Name)]
    [ExtendsFromMod(ModCompatibility.CalamityMod.Name, ModCompatibility.FargowiltasCrossmod.Name)]
    public class ResonantSoulsCalamityRecipes : ModSystem
    {
        Recipe? recipe;
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];

                List<int> Tier2Souls =
                [
                    ItemType<MicroverseSoul>()
                ];

                if (Tier2Souls.Contains(recipe.createItem.type) && !recipe.HasIngredient(ItemType<AshesofAnnihilation>()))
                {
                    recipe.SafeAddToRecipe(ItemType<AshesofAnnihilation>(), 5);
                    recipe.SafeAddToRecipe(ItemType<ExoPrism>(), 5);

                    if (recipe.RemoveTile(TileType<CrucibleCosmosSheet>()))
                    {
                        recipe.AddTile<DraedonsForge>();
                    }
                }
            }
        }
    }
}