using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using ResonantSouls.BombusApis.Souls;
using Terraria.Localization;

namespace ResonantSouls.BombusApis.Core
{

    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ResonantSoulsBombusApisRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (ResonantSoulsBombusApisConfig.Instance.Enchantments)
                {
                    if (recipe.HasResult<UniverseSoul>() && !recipe.HasIngredient<ApiaristsSoul>()) recipe.AddIngredient<ApiaristsSoul>();
                }
            }
        }
        public override void PostSetupRecipes()
        {
            // TODO: Make this automatic
            if (ResonantSoulsBombusApisConfig.Instance.Enchantments)
            {
                FargoSoulsSets.Items.MaterialOfImportantItem[ModContent.ItemType<ApiaristsSoul>()] = ModContent.ItemType<UniverseSoul>();
            }
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup group;

            if (ResonantSoulsBombusApisConfig.Instance.Enchantments)
            {
                group = new RecipeGroup(() => Language.GetTextValue("Mods.BombusApisBee.Items.HoneyphyteMask.DisplayName"), ModContent.ItemType<HoneyphyteHeadgear>(), ModContent.ItemType<HoneyphyteMask>());
                RecipeGroup.RegisterGroup("ResonantSouls:AnyHoneyphyteMask", group);
            }
        }
    }
}