using ResonantSouls.Common.Systems;
using Terraria.ID;
using static ResonantSouls.Common.Systems.ResonantSoulsRecipeHelper;
using OrchidMod.Content.Guardian.Armors.OreHelms;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Content.Items.Accessories.Eternity;
using OrchidMod.Content.Guardian.Misc;
using FargowiltasSouls.Content.Items.Armor.Eridanus;
using FargowiltasSouls.Content.Items.Armor.Gaia;
using FargowiltasSouls.Content.Items.Dyes;


namespace ResonantSouls.OrchidMod.Core
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class ResonantSoulsOrchidRecipes : ModSystem
    {
    //    static bool Shapeshifter => GetInstance<OrchidServerConfig>().EnableContentShapeshifter;
        Recipe? recipe;
        RecipeGroup? recipeGroup;
        public override void AddRecipes()
        {
            ModifyRecipeGroups();
            AddFargosRecipes();
        }
        void ModifyRecipeGroups()
        {
            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyCobaltHead"]];
            recipeGroup.ValidItems.Add(ItemType<GuardianCobaltHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyPallaHead"]];
            recipeGroup.ValidItems.Add(ItemType<GuardianPalladiumHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyMythrilHead"]];
            recipeGroup.ValidItems.Add(ItemType<GuardianMythrilHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyOriHead"]];
            recipeGroup.ValidItems.Add(ItemType<GuardianOrichalcumHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyAdamHead"]];
            recipeGroup.ValidItems.Add(ItemType<GuardianAdamantiteHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyTitaHead"]];
            recipeGroup.ValidItems.Add(ItemType<GuardianTitaniumHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyHallowHead"]];
            recipeGroup.ValidItems.Add(ItemType<GuardianHallowedHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyAncientHallowHead"]];
            recipeGroup.ValidItems.Add(ItemType<GuardianAncientHallowedHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyChloroHead"]];
            recipeGroup.ValidItems.Add(ItemType<GuardianChlorophyteHead>());

            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];

                if (recipe.HasResult(ItemType<CrystalAssassinEnchant>()) && recipe.HasIngredient(ItemID.CrystalNinjaHelmet))
                {
                    recipe.SafeAddRecipeGroup($"{ModCompatibility.ResonantSoulsMutantMod.Name}:AnyCrystalNinjaHelm");
                    recipe.RemoveIngredient(ItemID.CrystalNinjaHelmet);
                    recipe.ShiftRecipeItems();
                }
            }
        }
        void AddFargosRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];

                if (recipe.HasResult(ItemType<VerdantDoomsayerMask>()))
                {
                    recipe.SafeAddToRecipe(ItemType<HorizonFragment>());
                }
                else if (recipe.HasResult(ItemType<EridanusHat>()))
                {
                    recipe.SafeAddToRecipe(ItemType<HorizonFragment>(), 5);
                }
                else if (recipe.HasResult(ItemType<EridanusBattleplate>()))
                {
                    recipe.SafeAddToRecipe(ItemType<HorizonFragment>(), 5);
                }
                else if (recipe.HasResult(ItemType<EridanusLegwear>()))
                {
                    recipe.SafeAddToRecipe(ItemType<HorizonFragment>(), 5);
                }
                else if (recipe.HasResult(ItemType<GaiaHelmet>()))
                {
                    recipe.SafeAddToRecipe(ItemType<GuardianEmpressMaterial>(), 5);
                }
                else if (recipe.HasResult(ItemType<GaiaPlate>()))
                {
                    recipe.SafeAddToRecipe(ItemType<GuardianEmpressMaterial>(), 8);
                }
                else if (recipe.HasResult(ItemType<GaiaGreaves>()))
                {
                    recipe.SafeAddToRecipe(ItemType<GuardianEmpressMaterial>(), 5);
                }
                else if (recipe.HasResult(ItemType<GaiaDye>()))
                {
                    recipe.SafeAddToRecipe(ItemType<GuardianEmpressMaterial>(), 1);
                }
            }
        }
    }
}