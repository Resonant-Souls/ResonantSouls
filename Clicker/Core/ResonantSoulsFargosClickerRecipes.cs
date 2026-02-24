using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using FargoClickers.Content.Items.Accessories;
using ResonantSouls.BombusApis.Souls;
using Terraria.Localization;

namespace ResonantSouls.Clicker.Core
{

    [JITWhenModsEnabled(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    [ExtendsFromMod(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    public class ResonantSoulsFargosClickerRecipes : ModSystem
    {
        public override void PostSetupRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult<UniverseSoul>() && !recipe.HasIngredient<MasterPlayerSoul>()) recipe.AddIngredient<MasterPlayerSoul>();
            }
        }
    }
}