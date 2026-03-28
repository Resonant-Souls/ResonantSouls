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
        Recipe? recipe;
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
        public override void PostSetupContent()
        {
            ResonantSoulsUtilities.SetSacrifice(
                ItemType<GoblinRune>(), 1,
                ItemType<RuneRune>(), 1,
                ItemType<PredatorGoblin>(), 1,
                ItemType<SageBat>(), 1,
                ItemType<WardenSpider>(), 1,
                ItemType<CorruptionQuarterstaff>(), 1,
                ItemType<CrimsonQuarterstaff>(), 1,
                ItemType<BeeRune>(), 1,
                ItemType<CorruptionWarhammer>(), 1,
                ItemType<CrimsonWarhammer>(), 1,
                ItemType<DemoniteShield>(), 1,
                ItemType<CrimtaneShield>(), 1
            );

            ResonantSoulsUtilities.SetHardmodeSacrifice(
                ItemType<PaladinGauntlet>(), 1,
                ItemType<PlanteraStandard>(), 1,
                ItemType<TempleWarhammer>(), 1,
                ItemType<CrystalGauntlet>(), 1,
                ItemType<GuardianCrystalNinjaHelm>(), 1
            );
        }
    }
}