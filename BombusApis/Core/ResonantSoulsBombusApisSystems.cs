using BombusApisbee.NPCs;
using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using FargowiltasSouls.Common.Collections;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using ResonantSouls.BombusApis.Souls;
using ResonantSouls.Common.Utilities;
using Terraria.Localization;

namespace ResonantSouls.BombusApis.Core
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class ResonantSoulsBombusApisSystems : ModSystem
    {
        public override void Load()
        {
            if (ResonantSoulsBombusApisConfig.QualityOfLife)
            {
                ResonantSoulsUtilities.Add("TraitorBee", ModContent.NPCType<TheTraitorBee>());
            }
        }
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (ResonantSoulsBombusApisConfig.Enchantments)
                {
                    if (recipe.HasResult(ModContent.ItemType<UniverseSoul>()))
                    {
                        recipe.SafeAddToRecipe(ModContent.ItemType<ApiaristsSoul>());
                    }
                }
            }
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup group;

            if (ResonantSoulsBombusApisConfig.Enchantments)
            {
                group = new RecipeGroup(() => Language.GetTextValue("Mods.BombusApisBee.Items.HoneyphyteMask.DisplayName"), ModContent.ItemType<HoneyphyteHeadgear>(), ModContent.ItemType<HoneyphyteMask>());
                RecipeGroup.RegisterGroup("ResonantSouls:AnyHoneyphyteMask", group);
            }
        }
    }
}