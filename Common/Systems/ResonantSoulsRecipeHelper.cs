using System.Collections.Generic;
using System.Linq;
using Fargowiltas.Utilities;
using Terraria.ID;

namespace ResonantSouls.Common.Systems
{
    public static class ResonantSoulsRecipeHelper
    {
        // Used from Fargos
        internal static int TravellingMerchant;
        internal static void CreateCrateRecipe(int result, int crate, int crateAmount, int hardmodeCrate = -1, int extraItem = -1, params Condition[] conditions)
        {
            if (crate != -1)
            {
                var recipe = Recipe.Create(result);
                recipe.AddRecipeGroup(crate, crateAmount);
                if (extraItem != -1)
                {
                    recipe.AddIngredient(extraItem);
                }
                recipe.AddTile(TileID.WorkBenches);
                foreach (Condition condition in conditions)
                {
                    recipe.AddCondition(condition);
                }
                recipe.DisableDecraft();
                recipe.Register();
            }
            if (hardmodeCrate != -1)
            {
                var recipe = Recipe.Create(result);
                recipe.AddIngredient(hardmodeCrate, crateAmount);
                if (extraItem != -1)
                {
                    recipe.AddIngredient(extraItem);
                }
                recipe.AddTile(TileID.WorkBenches);
                foreach (Condition condition in conditions)
                {
                    recipe.AddCondition(condition);
                }
                recipe.DisableDecraft();
                recipe.Register();
            }
        }
        internal static void CreateTreasureGroupRecipe(int input, params int[] outputs)
        {
            int amount = (ItemID.Sets.BossBag[input] || input == ItemID.TreasureMagnet) ? 2 : 1;
            foreach (int output in outputs)
            {
                RecipeHelper.CreateSimpleRecipe(input, output, TileID.Solidifier, ingredientAmount: amount, disableDecraft: true);
            }
        }
        internal static void AddBannerGroupToItemRecipe(int recipeGroupID, int resultID, int resultAmount = 1, int groupAmount = 1, params Condition[] conditions)
        {
            RecipeHelper.CreateSimpleRecipe(recipeGroupID, resultID, TileID.Solidifier, groupAmount, resultAmount, true, true, conditions);
        }
        internal static void AddBannerToItemRecipe(int bannerItemID, int resultID, int bannerAmount = 1, int resultAmount = 1, params Condition[] conditions)
        {
            RecipeHelper.CreateSimpleRecipe(bannerItemID, resultID, TileID.Solidifier, bannerAmount, resultAmount, true, conditions: conditions);
        }
        internal static void ShiftRecipeItems(this Recipe recipe)
        {
            foreach (var item in new List<Item>(recipe.requiredItem.ToList()))
            {
                int count = item.stack;
                recipe.RemoveIngredient(item);
                recipe.AddIngredient(item.type, count);
            }
        }
        internal static void AddConvertRecipe(int itemID, int otherItemID)
        {
            RecipeHelper.CreateSimpleRecipe(itemID, otherItemID, TileID.DemonAltar, disableDecraft: true);
            RecipeHelper.CreateSimpleRecipe(otherItemID, itemID, TileID.DemonAltar, disableDecraft: true);
        }
    }
}