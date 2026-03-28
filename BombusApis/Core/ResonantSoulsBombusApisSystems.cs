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
        RecipeGroup? group;
        Recipe? recipe;
        public override void Load()
        {
            ModCompatibility.Fargowiltas.Mod.Call("AddCaughtNPC", "TheTraitorBee", NPCType<TheTraitorBee>(), Mod.Name);
        }
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];
                if (recipe.HasResult(ItemType<UniverseSoul>()))
                {
                    recipe.SafeAddToRecipe(ItemType<ApiaristsSoul>());
                    recipe.ShiftRecipeItems();
                }
            }
        }
        public override void AddRecipeGroups()
        {
            group = new RecipeGroup(() => Language.GetTextValue("Mods.BombusApisBee.Items.HoneyphyteMask.DisplayName"), ItemType<HoneyphyteHeadgear>(), ItemType<HoneyphyteMask>());
            RecipeGroup.RegisterGroup("ResonantSouls:AnyHoneyphyteMask", group);
        }
    }
}