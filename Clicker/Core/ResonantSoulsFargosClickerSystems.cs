using FargoClickers.Content.Items.Accessories;
using Fargowiltas.Common.Systems.Collections;
using FargowiltasSouls.Common.Collections;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using ResonantSouls.Content.Items.Accessories.Souls;

namespace ResonantSouls.Clicker.Core
{

    [JITWhenModsEnabled(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    [ExtendsFromMod(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    public class ResonantSoulsFargosClickerSystems : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsFargosClickerConfig.ClickerCompat;
        public override void PostSetupContent()
        {
            ModCompatibility.FargoClickers.Mod.Call("CSESupport");
        }
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult<UniverseSoul>() && !recipe.HasIngredient<MasterPlayerSoul>())
                    recipe.AddIngredient<MasterPlayerSoul>();
            }
        }
    }
}