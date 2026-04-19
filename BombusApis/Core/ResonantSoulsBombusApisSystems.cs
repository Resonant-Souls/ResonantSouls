using FargowiltasSouls.Content.Items.Accessories.Souls;
using ResonantSouls.BombusApis.Souls;
using ResonantSouls.Common.Systems;

namespace ResonantSouls.BombusApis.Core
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ResonantSoulsBombusApisSystems : ModSystem
    {
        Recipe? recipe;
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];
                if (recipe.HasResult(ItemType<UniverseSoul>()))
                {
                    recipe.SafeAddToRecipe(ItemType<ApiaristsSoul>());
                    recipe.ShiftRecipeItems();
                }
            }
        }
    }
}