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
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                List<int> Tier2Souls = [];
                
                if (ModCompatibility.AnyMicroverse)
                {
                    Tier2Souls.Add(ModContent.ItemType<MicroverseSoul>());
                }

                if (Tier2Souls.Contains(recipe.createItem.type) && !recipe.HasIngredient(ModContent.ItemType<AshesofAnnihilation>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<AshesofAnnihilation>(), 5);
                    recipe.SafeAddToRecipe(ModContent.ItemType<ExoPrism>(), 5);

                    if (recipe.RemoveTile(ModContent.TileType<CrucibleCosmosSheet>()))
                    {
                        recipe.AddTile<DraedonsForge>();
                    }
                }
            }
        }
    }
}