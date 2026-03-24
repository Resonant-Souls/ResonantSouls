using FargowiltasSouls.Content.Items.Accessories.Souls;
using OrchidMod;
using OrchidMod.Content.Guardian.Armors.Misc;
using OrchidMod.Content.Guardian.Weapons.Gauntlets;
using OrchidMod.Content.Guardian.Weapons.Quarterstaves;
using OrchidMod.Content.Guardian.Weapons.Runes;
using OrchidMod.Content.Guardian.Weapons.Shields;
using OrchidMod.Content.Guardian.Weapons.Standards;
using OrchidMod.Content.Guardian.Weapons.Warhammers;
using OrchidMod.Content.Shapeshifter.Weapons.Predator;
using OrchidMod.Content.Shapeshifter.Weapons.Sage;
using OrchidMod.Content.Shapeshifter.Weapons.Warden;
using ResonantSouls.Common.Systems;
using ResonantSouls.Common.Utilities;
using ResonantSouls.OrchidMod.Souls;

namespace ResonantSouls.OrchidMod.Core
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class ResonantSoulsOrchidSystems : ModSystem
    {
        public static OrchidGuardian GuardianPlayer(Player player) => player.GetModPlayer<OrchidGuardian>();
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.HasResult(ModContent.ItemType<UniverseSoul>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<GuardiansSoul>());
                    recipe.ShiftRecipeItems();
                }
            }
        }
        public override void PostSetupContent()
        {
            ResonantSoulsUtilities.SetSacrifice(
                ModContent.ItemType<GoblinRune>(), 1,
                ModContent.ItemType<RuneRune>(), 1,
                ModContent.ItemType<PredatorGoblin>(), 1,
                ModContent.ItemType<SageBat>(), 1,
                ModContent.ItemType<WardenSpider>(), 1,
                ModContent.ItemType<CorruptionQuarterstaff>(), 1,
                ModContent.ItemType<CrimsonQuarterstaff>(), 1,
                ModContent.ItemType<BeeRune>(), 1,
                ModContent.ItemType<CorruptionWarhammer>(), 1,
                ModContent.ItemType<CrimsonWarhammer>(), 1,
                ModContent.ItemType<DemoniteShield>(), 1,
                ModContent.ItemType<CrimtaneShield>(), 1
            );

            ResonantSoulsUtilities.SetHardmodeSacrifice(
                ModContent.ItemType<PaladinGauntlet>(), 1,
                ModContent.ItemType<PlanteraStandard>(), 1,
                ModContent.ItemType<TempleWarhammer>(), 1,
                ModContent.ItemType<CrystalGauntlet>(), 1,
                ModContent.ItemType<GuardianCrystalNinjaHelm>(), 1
            );
        }
    }
}