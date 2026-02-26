using ResonantSouls.Content.Items.Accessories.Souls;

namespace ResonantSouls.Core
{
    public class ResonantSoulsRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult<EternitySoul>() && !recipe.HasIngredient<MicroverseSoul>())
                {
                    recipe.AddIngredient(ModContent.ItemType<MicroverseSoul>());
                }

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
        public override void PostSetupRecipes()
        {
            // TODO: Make this automatic
            FargoSoulsSets.Items.MaterialOfImportantItem[ModContent.ItemType<MicroverseSoul>()] = ModContent.ItemType<EternitySoul>();
        }
    }
}