using System.Collections.Generic;
using System.Linq;
using BombusApisbee.NPCs;
using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using ResonantSouls.BombusApis.Souls;
using ResonantSouls.Common.Systems;
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
            ResonantSoulsUtilities.Add("TraitorBee", ModContent.NPCType<TheTraitorBee>());
        }
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.HasResult(ModContent.ItemType<UniverseSoul>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<ApiaristsSoul>());
                    recipe.ShiftRecipeItems();
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