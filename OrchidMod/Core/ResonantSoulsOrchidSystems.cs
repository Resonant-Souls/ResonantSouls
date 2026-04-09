using System.Collections.Generic;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using OrchidMod;
using ResonantSouls.Common.Systems;
using ResonantSouls.OrchidMod.Souls;

namespace ResonantSouls.OrchidMod.Core
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class ResonantSoulsOrchidSystems : ModSystem
    {
        public static OrchidGuardian GuardianPlayer(Player player) => player.GetModPlayer<OrchidGuardian>();
        Recipe? recipe;
        public readonly static List<int> FargoProjectilesBlockBlacklist =
        [
            
        ];
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];
                if (recipe.HasResult(ItemType<UniverseSoul>()))
                {
                    recipe.SafeAddToRecipe(ItemType<GuardiansSoul>());
                    recipe.ShiftRecipeItems();
                }
            }
        }
        public override void SetStaticDefaults()
        {
            FargoProjectilesBlockBlacklist.ForEach(OrchidGuardian.ProjectilesBlockBlacklist.Add);
        }
    }
}