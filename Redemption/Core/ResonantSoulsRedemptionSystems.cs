using FargowiltasSouls.Content.Items.Accessories.Souls;
using Redemption.NPCs.Friendly.TownNPCs;
using ResonantSouls.Common.Systems;

namespace ResonantSouls.Redemption.Core
{
    [JITWhenModsEnabled(ModCompatibility.Redemption.Name)]
    [ExtendsFromMod(ModCompatibility.Redemption.Name)]
    public class ResonantSoulsRedemptionSystems : ModSystem
    {
        public override void PostSetupContent()
        {
            AddCaughtNPCs();
        }
        void AddCaughtNPCs()
        {
            Mod fargowiltas = ModCompatibility.Fargowiltas.Mod;

            fargowiltas.Call("AddCaughtNPC", "Fallen", ModContent.NPCType<Fallen>(), Mod.Name);
        }
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.HasResult(ModContent.ItemType<UniverseSoul>()))
                {
                //    recipe.SafeAddToRecipe(ModContent.ItemType<ApiaristsSoul>());
                    recipe.ShiftRecipeItems();
                }
            }
        }
    }
}