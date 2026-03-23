using Fargowiltas.Common.Configs;
using ResonantSouls.Common.Systems;
using OrchidMod.Content.Shapeshifter.Weapons.Warden;
using OrchidMod.Content.Guardian.Weapons.Quarterstaves;
using OrchidMod.Content.Guardian.Accessories;
using OrchidMod.Content.Guardian.Weapons.Gauntlets;
using OrchidMod.Content.Shapeshifter.Accessories;
using OrchidMod.Content.Guardian.Weapons.Shields;
using OrchidMod.Content.Guardian.Weapons.Runes;
using OrchidMod.Content.Shapeshifter.Weapons.Predator;
using OrchidMod.Content.Guardian.Weapons.Standards;
using Terraria.ID;
using static ResonantSouls.Common.Systems.ResonantSoulsRecipeHelper;
using OrchidMod.Content.General.Mounts;
using OrchidMod.Content.General.Melee;
using OrchidMod.Content.General.Armor.Vanity;
using OrchidMod.Content.Guardian.Weapons.Warhammers;
using OrchidMod.Content.General.Pets;
using OrchidMod.Content.Shapeshifter.Weapons.Sage;
using OrchidMod.Content.Guardian.Armors.OreHelms;
using OrchidMod.Content.Guardian.Armors.Misc;
using FargowiltasSouls.Core.Systems;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using ResonantSouls.Common.Utilities;
using OrchidMod.Common;
using Terraria.Localization;
using FargowiltasSouls.Content.Items.Accessories.Eternity;
using OrchidMod.Content.Guardian.Misc;
using FargowiltasSouls.Content.Items.Armor.Eridanus;
using FargowiltasSouls.Content.Items.Armor.Gaia;
using FargowiltasSouls.Content.Items.Dyes;


namespace ResonantSouls.OrchidMod.QoL
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class ResonantSoulsOrchidQoLRecipes : ModSystem
    {
        static OrchidServerConfig OrchidServerConfig => ModContent.GetInstance<OrchidServerConfig>();
        static bool Shapeshifter => OrchidServerConfig.EnableContentShapeshifter;
        public override void AddRecipes()
        {
            if (FargoServerConfig.Instance.ContainerRecipes)
            {
                AddCrateRecipes(Shapeshifter);
                AddBossBagRecipes(Shapeshifter);
            }
            if (FargoServerConfig.Instance.BannerRecipes)
            {
                AddBannerRecipes(Shapeshifter);
            }
            if (FargoServerConfig.Instance.MiscRecipes)
            {
                AddMiscRecipes(Shapeshifter);
                AddBossTrophyRecipes(Shapeshifter);
                AddConversionRecipes(Shapeshifter);
            }
            ModifyRecipeGroups(Shapeshifter);
            AddTravellingMerchantNPCRecipes(Shapeshifter);
            AddFargosRecipes(Shapeshifter);
        }
        static void AddCrateRecipes(bool Shapeshifter)
        {
            if (Shapeshifter)
                CreateCrateRecipe(ModContent.ItemType<WardenSnail>(), ResonantSoulsRecipeSystem.AnyWoodCrate, 5);
            CreateCrateRecipe(ModContent.ItemType<Quarterstaff>(), ResonantSoulsRecipeSystem.AnyWoodCrate, 5);
            CreateCrateRecipe(ModContent.ItemType<GuideShield>(), ResonantSoulsRecipeSystem.AnyWoodCrate, 5);

            CreateCrateRecipe(ModContent.ItemType<Quarterstaff>(), ResonantSoulsRecipeSystem.AnyIronCrate, 5);
            CreateCrateRecipe(ModContent.ItemType<GuideShield>(), ResonantSoulsRecipeSystem.AnyIronCrate, 5);

            if (Shapeshifter)
                CreateCrateRecipe(ModContent.ItemType<WardenTortoise>(), ResonantSoulsRecipeSystem.AnyJungleCrate, 5);
            CreateCrateRecipe(ModContent.ItemType<JungleGauntlet>(), ResonantSoulsRecipeSystem.AnyJungleCrate, 3);

            if (Shapeshifter)
                CreateCrateRecipe(ModContent.ItemType<ShawlFeather>(), ResonantSoulsRecipeSystem.AnySkyCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<SkywareShield>(), ResonantSoulsRecipeSystem.AnySkyCrate, 3);

            if (Shapeshifter)
                CreateCrateRecipe(ModContent.ItemType<WardenSalamortar>(), ResonantSoulsRecipeSystem.AnyLavaCrate, 3, extraItem: ItemID.GoldenKey);
            CreateCrateRecipe(ModContent.ItemType<HellRune>(), ResonantSoulsRecipeSystem.AnyLavaCrate, 3, extraItem: ItemID.GoldenKey);
            CreateCrateRecipe(ModContent.ItemType<NightShield>(), ResonantSoulsRecipeSystem.AnyLavaCrate, 3, extraItem: ItemID.GoldenKey);

            if (Shapeshifter)
                CreateCrateRecipe(ModContent.ItemType<PredatorIceFox>(), ResonantSoulsRecipeSystem.AnyFrozenCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<IceStandard>(), ResonantSoulsRecipeSystem.AnyFrozenCrate, 3);

            if (Shapeshifter)
                CreateCrateRecipe(ModContent.ItemType<PredatorUndine>(), ResonantSoulsRecipeSystem.AnyDungeonCrate, 3, extraItem: ItemID.GoldenKey);

            CreateCrateRecipe(ModContent.ItemType<DungeonQuarterstaff>(), ResonantSoulsRecipeSystem.AnyDungeonCrate, 3, extraItem: ItemID.GoldenKey);

            CreateCrateRecipe(ModContent.ItemType<EnchantedPavise>(), ResonantSoulsRecipeSystem.AnyGoldCrate, 2);
            CreateCrateRecipe(ModContent.ItemType<EnchantedRune>(), ResonantSoulsRecipeSystem.AnyGoldCrate, 2);

            CreateCrateRecipe(ModContent.ItemType<DesertStandard>(), ResonantSoulsRecipeSystem.AnySandCrate, 3);

            CreateCrateRecipe(ModContent.ItemType<CorruptionQuarterstaff>(), ResonantSoulsRecipeSystem.AnyCorruptCrate, 3);

            CreateCrateRecipe(ModContent.ItemType<CrimsonQuarterstaff>(), ResonantSoulsRecipeSystem.AnyCrimsonCrate, 3);

        }
        static void AddBossBagRecipes(bool Shapeshifter)
        {
            if (Shapeshifter)
            {
                CreateTreasureGroupRecipe(ItemID.KingSlimeBossBag, ModContent.ItemType<WardenSlime>());
            }

            CreateTreasureGroupRecipe(ItemID.QueenBeeBossBag, ModContent.ItemType<BeeRune>());

            CreateTreasureGroupRecipe(ItemID.PlanteraBossBag, ModContent.ItemType<PlanteraStandard>());

            CreateTreasureGroupRecipe(ItemID.GolemBossBag, ModContent.ItemType<TempleWarhammer>());

            CreateTreasureGroupRecipe(ItemID.MoonLordBossBag, ModContent.ItemType<MoonLordShield>(), ModContent.ItemType<MoonLordRune>());

            if (ModCompatibility.ThoriumMod.Loaded)
            {
                CreateTreasureGroupRecipe(ModCompatibility.ThoriumMod.Mod.Find<ModItem>("ThunderBirdBag").Type, ModContent.ItemType<ThoriumGrandThunderBirdWarhammer>());

                CreateTreasureGroupRecipe(ModCompatibility.ThoriumMod.Mod.Find<ModItem>("ScouterBag").Type, ModContent.ItemType<ThoriumStarScouterStandard>());

                CreateTreasureGroupRecipe(ModCompatibility.ThoriumMod.Mod.Find<ModItem>("CountBag").Type, ModContent.ItemType<ThoriumViscountQuarterstaff>());
            }
        }
        static void AddBossTrophyRecipes(bool Shapeshifter)
        {
            CreateTreasureGroupRecipe(ItemID.EyeofCthulhuTrophy, ModContent.ItemType<SquareMinecart>(), ModContent.ItemType<PrototypeSecrecy>());

            CreateTreasureGroupRecipe(ItemID.PlanteraTrophy, ModContent.ItemType<OrnateOrchid>());

            CreateTreasureGroupRecipe(ItemID.EverscreamTrophy, ModContent.ItemType<FrostRune>());

            CreateTreasureGroupRecipe(ItemID.FlyingDutchmanTrophy, ModContent.ItemType<PirateStandard>(), ModContent.ItemType<PirateWarhammer>());

            CreateTreasureGroupRecipe(ItemID.MartianSaucerTrophy, ModContent.ItemType<MartianWarhammer>());

            CreateTreasureGroupRecipe(ItemID.PumpkingTrophy, ModContent.ItemType<PumpkingWarhammer>());

        }
        static void AddBannerRecipes(bool Shapeshifter)
        {
            AddBannerToItemRecipe(ItemID.ElfCopterBanner, ModContent.ItemType<RCRemote>());

            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ModContent.ItemType<BadgeBattlesPast>());

            AddBannerToItemRecipe(ItemID.DevourerBanner, ModContent.ItemType<ColossalWormTooth>());

            AddBannerToItemRecipe(ItemID.GoblinWarriorBanner, ModContent.ItemType<GoblinSpike>());

            AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ModContent.ItemType<SturdySlab>());

            AddBannerToItemRecipe(ItemID.GraniteGolemBanner, ModContent.ItemType<SturdySlab>());

            AddBannerToItemRecipe(ItemID.FaceMonsterBanner, ModContent.ItemType<TerrifyingMonsterFang>());

            AddBannerToItemRecipe(ItemID.SporeSkeletonBanner, ModContent.ItemType<GlowingMushroomGauntlet>());

            AddBannerToItemRecipe(ItemID.PaladinBanner, ModContent.ItemType<PaladinGauntlet>());

            AddBannerToItemRecipe(ItemID.GoblinSorcererBanner, ModContent.ItemType<GoblinRune>());

            AddBannerToItemRecipe(ItemID.RuneWizardBanner, ModContent.ItemType<RuneRune>());

            AddBannerToItemRecipe(ItemID.PirateCaptainBanner, ModContent.ItemType<PirateStandard>());
            AddBannerToItemRecipe(ItemID.PirateCaptainBanner, ModContent.ItemType<PirateWarhammer>());

            if (Shapeshifter)
            {
                AddBannerToItemRecipe(ItemID.GoblinSorcererBanner, ModContent.ItemType<PredatorGoblin>());

                AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ModContent.ItemType<DeepwaterLocket>());

                AddBannerToItemRecipe(ItemID.GoblinThiefBanner, ModContent.ItemType<GoblinDagger>());

                AddBannerToItemRecipe(ItemID.ManEaterBanner, ModContent.ItemType<PlantEnzymes>());

                AddBannerToItemRecipe(ItemID.SnatcherBanner, ModContent.ItemType<PlantEnzymes>());

                AddBannerToItemRecipe(ItemID.SpiderBanner, ModContent.ItemType<WardenSpider>());

                AddBannerGroupToItemRecipe(ResonantSoulsRecipeSystem.AnyBatBanner, ModContent.ItemType<SageBat>());
            }
        }
        static void AddMiscRecipes(bool Shapeshifter)
        {
            Recipe recipe;

            recipe = Recipe.Create(ModContent.ItemType<PresentQuarterstaff>());
            recipe.AddIngredient(ItemID.Present, 10);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<HellRune>());
            recipe.AddIngredient(ItemID.TreasureMagnet, 2);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<NightShield>());
            recipe.AddIngredient(ItemID.TreasureMagnet, 2);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<WardenSalamortar>());
            recipe.AddIngredient(ItemID.TreasureMagnet, 2);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();
        }
        static void ModifyRecipeGroups(bool Shapeshifter)
        {
            RecipeGroup recipeGroup;

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyCobaltHead"]];
            recipeGroup.ValidItems.Add(ModContent.ItemType<GuardianCobaltHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyPallaHead"]];
            recipeGroup.ValidItems.Add(ModContent.ItemType<GuardianPalladiumHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyMythrilHead"]];
            recipeGroup.ValidItems.Add(ModContent.ItemType<GuardianMythrilHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyOriHead"]];
            recipeGroup.ValidItems.Add(ModContent.ItemType<GuardianOrichalcumHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyAdamHead"]];
            recipeGroup.ValidItems.Add(ModContent.ItemType<GuardianAdamantiteHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyTitaHead"]];
            recipeGroup.ValidItems.Add(ModContent.ItemType<GuardianTitaniumHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyHallowHead"]];
            recipeGroup.ValidItems.Add(ModContent.ItemType<GuardianHallowedHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyAncientHallowHead"]];
            recipeGroup.ValidItems.Add(ModContent.ItemType<GuardianAncientHallowedHead>());

            recipeGroup = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["FargowiltasSouls:AnyChloroHead"]];
            recipeGroup.ValidItems.Add(ModContent.ItemType<GuardianChlorophyteHead>());

            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ModContent.ItemType<CrystalAssassinEnchant>()) && recipe.HasIngredient(ItemID.CrystalNinjaHelmet))
                {
                    recipe.SafeAddRecipeGroup("ResonantSouls:AnyCrystalNinjaHelm");
                    recipe.RemoveIngredient(ItemID.CrystalNinjaHelmet);
                    recipe.ShiftRecipeItems();
                }
            }
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup group;

            group = new RecipeGroup(() => RecipeSystem.ItemXOrY(ItemID.CrystalNinjaHelmet, ModContent.ItemType<GuardianCrystalNinjaHelm>()), ItemID.CrystalNinjaHelmet, ModContent.ItemType<GuardianCrystalNinjaHelm>());
            RecipeGroup.RegisterGroup("ResonantSouls:AnyCrystalNinjaHelm", group);

            group = new RecipeGroup(() => Language.GetTextValue("Mods.ResonantSouls.RecipeGroups.SturdySlab"), ModContent.ItemType<SturdySlab>(), ModContent.ItemType<ParryingMailFeral>(), ModContent.ItemType<ParryingMailFeral>(), ModContent.ItemType<ParryingMailMech>(), ModContent.ItemType<ParryingMailNinja>());
            RecipeGroup.RegisterGroup("ResonantSouls:AnySturdySlab", group);

        }
        static void AddTravellingMerchantNPCRecipes(bool Shapeshifter)
        {
            Recipe recipe;

            if (Shapeshifter)
            {
                recipe = Recipe.Create(ModContent.ItemType<HarnessYouxia>());
                recipe.AddIngredient(TravellingMerchant);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.TinkerersWorkbench);
                recipe.AddCondition(Condition.SmashedShadowOrb);
                recipe.DisableDecraft();
                recipe.Register();
            }

            recipe = Recipe.Create(ModContent.ItemType<Skateboard>());
            recipe.AddIngredient(TravellingMerchant);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.SmashedShadowOrb);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<BijouShield>());
            recipe.AddIngredient(TravellingMerchant);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.Hardmode);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<HockeyQuarterstaff>());
            recipe.AddIngredient(TravellingMerchant);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.Hardmode);
            recipe.DisableDecraft();
            recipe.Register();
        }
        static void AddConversionRecipes(bool Shapeshifter)
        {
            AddConvertRecipe(ModContent.ItemType<CorruptionQuarterstaff>(), ModContent.ItemType<CrimsonQuarterstaff>());
            AddConvertRecipe(ModContent.ItemType<TerrifyingMonsterFang>(), ModContent.ItemType<ColossalWormTooth>());
        }
        static void AddFargosRecipes(bool Shapeshifter)
        {
            Recipe recipe;

            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];

                if (recipe.HasResult(ModContent.ItemType<VerdantDoomsayerMask>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<HorizonFragment>());
                }
                if (recipe.HasResult(ModContent.ItemType<EridanusHat>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<HorizonFragment>(), 5);
                }
                if (recipe.HasResult(ModContent.ItemType<EridanusBattleplate>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<HorizonFragment>(), 5);
                }
                if (recipe.HasResult(ModContent.ItemType<EridanusLegwear>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<HorizonFragment>(), 5);
                }
                if (recipe.HasResult(ModContent.ItemType<GaiaHelmet>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<GuardianEmpressMaterial>(), 5);
                }
                if (recipe.HasResult(ModContent.ItemType<GaiaPlate>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<GuardianEmpressMaterial>(), 8);
                }
                if (recipe.HasResult(ModContent.ItemType<GaiaGreaves>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<GuardianEmpressMaterial>(), 5);
                }
                if (recipe.HasResult(ModContent.ItemType<GaiaDye>()))
                {
                    recipe.SafeAddToRecipe(ModContent.ItemType<GuardianEmpressMaterial>(), 1);
                }
            }
        }
    }
}