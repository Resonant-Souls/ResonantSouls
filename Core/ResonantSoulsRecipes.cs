using FargowiltasSouls.Content.Items.Accessories.Souls;
using ResonantSouls.Common.Systems;
using ResonantSouls.Content.Items.Accessories.Souls;

namespace ResonantSouls.Core
{
    public class ResonantSoulsRecipes : ModSystem
    {
        Recipe? recipe;
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];

                if (recipe.HasResult(ItemType<EternitySoul>()))
                {
                    recipe.SafeAddToRecipe(ItemType<MicroverseSoul>());
                }
            }
        }
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];

                if (recipe.createItem.ModItem is BaseSoul)
                {
                    recipe.ShiftRecipeItems();
                }
            }
        }
    }
}