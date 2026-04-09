using System.Collections.Generic;
using System.Linq;
using Fargowiltas.Utilities;
using Terraria.ID;

namespace ResonantSouls.Common.Systems
{
    public static class ResonantSoulsRecipeHelper
    {
        internal static void ShiftRecipeItems(this Recipe recipe)
        {
            foreach (var item in new List<Item>(recipe.requiredItem.ToList()))
            {
                int count = item.stack;
                recipe.RemoveIngredient(item);
                recipe.AddIngredient(item.type, count);
            }
        }
        public static void SafeAddToRecipe(this Recipe recipe, int ingredient, int ingredientCount = 1)
        {
            if (recipe.TryGetIngredient(ingredient, out Item item))
            {
                item.stack = ingredientCount;
            }
            else
            {
                recipe.AddIngredient(ingredient, ingredientCount);
            }
        }
        public static void SafeAddToRecipe<T>(this Recipe recipe, int ingredientCount = 1) where T : ModItem
        {
            recipe.SafeAddToRecipe(ItemType<T>(), ingredientCount);
        }
        public static void SafeAddRecipeGroup(this Recipe recipe, string recipeGroup)
        {
            if (!recipe.HasRecipeGroup(recipeGroup))
            {
                recipe.AddRecipeGroup(recipeGroup);
            }
        }
    }
}