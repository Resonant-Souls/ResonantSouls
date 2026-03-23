using System;
using Fargowiltas.Common.Systems.Collections;
using FargowiltasSouls.Content.Items.Accessories.Souls;
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
using ReLogic.Reflection;
using ResonantSouls.Common.Systems;
using ResonantSouls.Common.Utilities;
using ResonantSouls.OrchidMod.Souls;
using Terraria.ID;

namespace ResonantSouls.OrchidMod.Core
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class ResonantSoulsOrchidSystems : ModSystem
    {
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
            ResonantSoulsUtilities.SetSacrifice(types:[
                ModContent.ItemType<GoblinRune>(),
                ModContent.ItemType<RuneRune>(),
                ModContent.ItemType<PredatorGoblin>(),
                ModContent.ItemType<SageBat>(),
                ModContent.ItemType<WardenSpider>(),
                ModContent.ItemType<CorruptionQuarterstaff>(),
                ModContent.ItemType<CrimsonQuarterstaff>(),
                ModContent.ItemType<BeeRune>(),
                ModContent.ItemType<CorruptionWarhammer>(),
                ModContent.ItemType<CrimsonWarhammer>(),
                ModContent.ItemType<DemoniteShield>(),
                ModContent.ItemType<CrimtaneShield>()
            ]);

            ResonantSoulsUtilities.SetHardmodeSacrifice(types: [
                ModContent.ItemType<PaladinGauntlet>(),
                ModContent.ItemType<PlanteraStandard>(),
                ModContent.ItemType<TempleWarhammer>(),
                ModContent.ItemType<CrystalGauntlet>(),
                ModContent.ItemType<GuardianCrystalNinjaHelm>()
            ]);
        }
    }
}