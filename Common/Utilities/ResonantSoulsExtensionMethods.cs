namespace ResonantSouls.Common.Utilities
{
    public static class ResonantSoulsExtensionMethods
    {
        internal static string BombusTexture(this ModType type) => $"ResonantSouls/BombusApis/Assets/Sprites/{type.Name}";
        internal static string OrchidTexture(this ModType type) => $"ResonantSouls/OrchidMod/Assets/Sprites/{type.Name}";
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