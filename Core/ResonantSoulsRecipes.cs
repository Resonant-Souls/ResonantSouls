namespace ResonantSouls.Core
{
    public class ResonantSoulsRecipes : ModSystem
    {
        public override void PostSetupRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult<UniverseSoul>())
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