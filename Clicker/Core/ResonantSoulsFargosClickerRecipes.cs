using FargoClickers.Content.Items.Accessories;
using Fargowiltas.Common.Systems.Collections;
using ResonantSouls.Content.Items.Accessories.Souls;

namespace ResonantSouls.Clicker.Core
{

    [JITWhenModsEnabled(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    [ExtendsFromMod(ModCompatibility.FargoClickers.Name, ModCompatibility.ClickerClass.Name)]
    public class ResonantSoulsFargosClickerRecipes : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsFargosClickerConfig.Instance.ClickerCompat;
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult<UniverseSoul>() && !recipe.HasIngredient<MasterPlayerSoul>()) recipe.AddIngredient<MasterPlayerSoul>();
            }
        }
        public override void PostSetupRecipes()
        {
            // TODO: Make this automatic
            FargoSoulsSets.Items.MaterialOfImportantItem[ModContent.ItemType<MasterPlayerSoul>()] = ModContent.ItemType<UniverseSoul>();
            FargoSoulsSets.Items.MaterialOfImportantItem[ModContent.ItemType<ForceOfMatrix>()] = ModContent.ItemType<MicroverseSoul>();

            // TODO: It's because it's named ForceOfMatrix instead of MatrixForce. It needs to end in Force to automatically be dupable.
            FargoItemSets.DuplicatableItems[ModContent.ItemType<MasterPlayerSoul>()] = DupeType.Dupable;
            FargoItemSets.DuplicatableItems[ModContent.ItemType<ForceOfMatrix>()] = DupeType.Dupable;
        }
    }
}   