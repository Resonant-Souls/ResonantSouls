using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using FargowiltasSouls.Content.Items.Materials;
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
                    // Thanks autocomplete? I have no clue how this works.
                    int abom = recipe.requiredItem.Where(item => item.type == ModContent.ItemType<AbomEnergy>()).Sum(item => item.stack);
                    recipe.RemoveIngredient(ModContent.ItemType<AbomEnergy>());
                    recipe.AddIngredient<ApiaristsSoul>();
                    recipe.AddIngredient<AbomEnergy>(abom);
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