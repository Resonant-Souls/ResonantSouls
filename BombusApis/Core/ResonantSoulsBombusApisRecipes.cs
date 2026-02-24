using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using ResonantSouls.BombusApis.Souls;
using Terraria.Localization;

namespace ResonantSouls.BombusApis.Core
{

    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ResonantSoulsBombusApisRecipes : ModSystem
    {
        public override void PostSetupRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult<UniverseSoul>() && !recipe.HasIngredient<ApiaristsSoul>())
                {
                    // Uh, I think this works? 

                    List<Item> notSoul = recipe.requiredItem.Where(item => item.ModItem is not BaseSoul).ToList();

                    foreach (var item in notSoul)
                    {
                        int count = item.stack;
                        recipe.RemoveIngredient(item);
                        if (!recipe.HasIngredient<ApiaristsSoul>()) recipe.AddIngredient<ApiaristsSoul>();
                        recipe.AddIngredient(item.type, count);
                    }
                }
            }
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup group;

            group = new RecipeGroup(() => Language.GetTextValue("Mods.BombusApisBee.Items.HoneyphyteMask.DisplayName"), ModContent.ItemType<HoneyphyteHeadgear>(), ModContent.ItemType<HoneyphyteMask>());
            RecipeGroup.RegisterGroup("ResonantSouls:AnyHoneyphyteMask", group);
        }
    }
}