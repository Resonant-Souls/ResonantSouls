using System;
using ResonantSouls.Core.Globals.Items;

namespace ResonantSouls.Common.Utilities
{
    public static class ResonantSoulsExtensionMethods
    {
        public static ResonantDeveloper ResonantDeveloper(this Item item) => item.GetGlobalItem<ResonantDeveloper>();
        internal static string BombusTexture(this ModType type) => $"ResonantSouls/BombusApis/Assets/Sprites/{type.Name}";
        /*
            public static void SafeAddToRecipe(this Recipe recipe, int mainItem, int ingredient, int ingredientCount = 1)
            {
                if (recipe.HasResult(mainItem) && !recipe.HasIngredient(ingredient)) recipe.AddIngredient(ingredient, ingredientCount);
            }
        */
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
        public static int IndexOf(this Array array, object? value) => Array.IndexOf(array, value);
    }
}