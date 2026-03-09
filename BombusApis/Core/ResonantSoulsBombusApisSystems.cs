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
        internal static string BombusTexture(ModType type)
        {
            return $"ResonantSouls/BombusApis/Assets/Sprites/{type.Name}";
        }
        public override void Load()
        {
            if (ResonantSoulsBombusApisConfig.Instance?.QualityOfLife ?? false)
            {
                ResonantSoulsUtilities.Add("TraitorBee", ModContent.NPCType<TheTraitorBee>());
            }
        }
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (ResonantSoulsBombusApisConfig.Instance?.Enchantments ?? false)
                {
                    if (recipe.HasResult<UniverseSoul>() && !recipe.HasIngredient<ApiaristsSoul>()) recipe.AddIngredient<ApiaristsSoul>();
                }
            }
        }
        public override void PostSetupRecipes()
        {
            // TODO: Make this automatic
            if (ResonantSoulsBombusApisConfig.Instance?.Enchantments ?? false)
            {
                SoulsItemSets.MaterialOfImportantItem[ModContent.ItemType<ApiaristsSoul>()] = ModContent.ItemType<UniverseSoul>();
            }
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup group;

            if (ResonantSoulsBombusApisConfig.Instance?.Enchantments ?? false)
            {
                group = new RecipeGroup(() => Language.GetTextValue("Mods.BombusApisBee.Items.HoneyphyteMask.DisplayName"), ModContent.ItemType<HoneyphyteHeadgear>(), ModContent.ItemType<HoneyphyteMask>());
                RecipeGroup.RegisterGroup("ResonantSouls:AnyHoneyphyteMask", group);
            }
        }
    }
}