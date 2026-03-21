using System.Collections.Generic;
using System.Linq;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using ResonantSouls.Common.Utilities;
using ResonantSouls.Content.Items.Accessories.Souls;

namespace ResonantSouls.Core
{
    public class ResonantSoulsRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ModContent.ItemType<EternitySoul>()) && ModCompatibility.AnyMicroverse)
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<MicroverseSoul>());
                }
            }
        }
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.createItem.ModItem is BaseSoul)
                {
                    List<Item> notSoul = recipe.requiredItem.Where(item => item.ModItem is not BaseSoul).ToList();

                    foreach (var item in notSoul)
                    {
                        int count = item.stack;
                        recipe.RemoveIngredient(item);
                        recipe.AddIngredient(item.type, count);
                    }
                }
            }
        }
    }
}