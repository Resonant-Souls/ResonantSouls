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
using OrchidMod.Content.Guardian.Armors.Empress;
using System.Collections.Generic;


namespace ResonantSouls.OrchidMod.Core
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class ResonantSoulsOrchidRecipes : ModSystem
    {
        static OrchidServerConfig OrchidServerConfig => GetInstance<OrchidServerConfig>();
        static bool Shapeshifter => OrchidServerConfig.EnableContentShapeshifter;
        Recipe? recipe;
        RecipeGroup? recipeGroup;
        // Treasure bags, grab bags (presents and such), crate, and biome key recipes are in FargoServerConfig.Instance.ContainerRecipes
        // Banners are in FargoServerConfig.Instance.BannerRecipes (wow)
        // Conversions, Statues, npc recipes, travelling merchant, skeleton merchant, and misc recipes are in FargoServerConfig.Instance.MiscRecipes
        public override void AddRecipes()
        {
            if (FargoServerConfig.Instance.ContainerRecipes)
            {
                AddCrateRecipes();
                AddBossBagRecipes();
                AddGrabBagRecipes();
                AddBossTrophyRecipes();
            }
            if (FargoServerConfig.Instance.BannerRecipes)
            {
                AddBannerRecipes();
            }
            if (FargoServerConfig.Instance.MiscRecipes)
            {
                AddMiscRecipes();
                AddConversionRecipes();
                AddTravellingMerchantNPCRecipes();
            }
            ModifyRecipeGroups();
            AddFargosRecipes();
        }
        static void AddCrateRecipes()
        {
            if (Shapeshifter)
            {
                CreateCrateRecipe(ItemType<WardenSnail>(), ResonantSoulsRecipeSystem.AnyWoodCrate, 5);

                CreateCrateRecipe(ItemType<WardenTortoise>(), ResonantSoulsRecipeSystem.AnyJungleCrate, 5);

                CreateCrateRecipe(ItemType<ShawlFeather>(), ResonantSoulsRecipeSystem.AnySkyCrate, 3);

                CreateCrateRecipe(ItemType<WardenSalamortar>(), ResonantSoulsRecipeSystem.AnyLavaCrate, 3, extraItem: ItemID.GoldenKey);

                CreateCrateRecipe(ItemType<PredatorIceFox>(), ResonantSoulsRecipeSystem.AnyFrozenCrate, 3);

                CreateCrateRecipe(ItemType<PredatorUndine>(), ResonantSoulsRecipeSystem.AnyDungeonCrate, 3, extraItem: ItemID.GoldenKey);
            }

            CreateCrateRecipe(ItemType<Quarterstaff>(), ResonantSoulsRecipeSystem.AnyWoodCrate, 5);
            CreateCrateRecipe(ItemType<GuideShield>(), ResonantSoulsRecipeSystem.AnyWoodCrate, 5);

            CreateCrateRecipe(ItemType<Quarterstaff>(), ResonantSoulsRecipeSystem.AnyIronCrate, 5);
            CreateCrateRecipe(ItemType<GuideShield>(), ResonantSoulsRecipeSystem.AnyIronCrate, 5);

            CreateCrateRecipe(ItemType<JungleGauntlet>(), ResonantSoulsRecipeSystem.AnyJungleCrate, 3);

            CreateCrateRecipe(ItemType<SkywareShield>(), ResonantSoulsRecipeSystem.AnySkyCrate, 3);

            CreateCrateRecipe(ItemType<HellRune>(), ResonantSoulsRecipeSystem.AnyLavaCrate, 3, extraItem: ItemID.GoldenKey);
            CreateCrateRecipe(ItemType<NightShield>(), ResonantSoulsRecipeSystem.AnyLavaCrate, 3, extraItem: ItemID.GoldenKey);

            CreateCrateRecipe(ItemType<IceStandard>(), ResonantSoulsRecipeSystem.AnyFrozenCrate, 3);

            CreateCrateRecipe(ItemType<DungeonQuarterstaff>(), ResonantSoulsRecipeSystem.AnyDungeonCrate, 3, extraItem: ItemID.GoldenKey);

            CreateCrateRecipe(ItemType<EnchantedPavise>(), ResonantSoulsRecipeSystem.AnyGoldCrate, 2);
            CreateCrateRecipe(ItemType<EnchantedRune>(), ResonantSoulsRecipeSystem.AnyGoldCrate, 2);

            CreateCrateRecipe(ItemType<DesertStandard>(), ResonantSoulsRecipeSystem.AnySandCrate, 3);

            CreateCrateRecipe(ItemType<CorruptionQuarterstaff>(), ResonantSoulsRecipeSystem.AnyCorruptCrate, 3);

            CreateCrateRecipe(ItemType<CrimsonQuarterstaff>(), ResonantSoulsRecipeSystem.AnyCrimsonCrate, 3);
        }
        static void AddBossBagRecipes()
        {
            if (Shapeshifter)
            {
                CreateTreasureGroupRecipe(ItemID.KingSlimeBossBag, ItemType<WardenSlime>());
            }

            CreateTreasureGroupRecipe(ItemID.QueenBeeBossBag,
                ItemType<BeeRune>()
            );

            CreateTreasureGroupRecipe(ItemID.PlanteraBossBag,
                ItemType<PlanteraStandard>()
            );

            CreateTreasureGroupRecipe(ItemID.GolemBossBag,
                ItemType<TempleWarhammer>()
            );

            CreateTreasureGroupRecipe(ItemID.MoonLordBossBag,
                ItemType<MoonLordShield>(), ItemType<MoonLordRune>()
            );

            if (ModCompatibility.ThoriumMod.Loaded)
            {
                Mod tr = ModCompatibility.ThoriumMod.Mod;

                CreateTreasureGroupRecipe(tr.Find<ModItem>("ThunderBirdBag").Type,
                    ItemType<ThoriumGrandThunderBirdWarhammer>()
                );

                CreateTreasureGroupRecipe(tr.Find<ModItem>("ScouterBag").Type,
                    ItemType<ThoriumStarScouterStandard>()
                );

                CreateTreasureGroupRecipe(tr.Find<ModItem>("CountBag").Type,
                    ItemType<ThoriumViscountQuarterstaff>()
                );
            }
        }
        static void AddBossTrophyRecipes()
        {
            CreateTreasureGroupRecipe(ItemID.EyeofCthulhuTrophy, ItemType<SquareMinecart>(), ItemType<PrototypeSecrecy>());

            CreateTreasureGroupRecipe(ItemID.PlanteraTrophy, ItemType<OrnateOrchid>());

            CreateTreasureGroupRecipe(ItemID.EverscreamTrophy, ItemType<FrostRune>());

            CreateTreasureGroupRecipe(ItemID.FlyingDutchmanTrophy, ItemType<PirateStandard>(), ItemType<PirateWarhammer>());

            CreateTreasureGroupRecipe(ItemID.MartianSaucerTrophy, ItemType<MartianWarhammer>());

            CreateTreasureGroupRecipe(ItemID.PumpkingTrophy, ItemType<PumpkingWarhammer>());
        }
        static void AddBannerRecipes()
        {
            AddBannerToItemRecipe(ItemID.ElfCopterBanner, ItemType<RCRemote>());

            AddBannerToItemRecipe(ItemID.AngryBonesBanner, ItemType<BadgeBattlesPast>());

            AddBannerToItemRecipe(ItemID.DevourerBanner, ItemType<ColossalWormTooth>());

            AddBannerToItemRecipe(ItemID.GoblinWarriorBanner, ItemType<GoblinSpike>());

            AddBannerToItemRecipe(ItemID.GraniteFlyerBanner, ItemType<SturdySlab>());

            AddBannerToItemRecipe(ItemID.GraniteGolemBanner, ItemType<SturdySlab>());

            AddBannerToItemRecipe(ItemID.FaceMonsterBanner, ItemType<TerrifyingMonsterFang>());

            AddBannerToItemRecipe(ItemID.SporeSkeletonBanner, ItemType<GlowingMushroomGauntlet>());

            AddBannerToItemRecipe(ItemID.PaladinBanner, ItemType<PaladinGauntlet>());

            AddBannerToItemRecipe(ItemID.GoblinSorcererBanner, ItemType<GoblinRune>());

            AddBannerToItemRecipe(ItemID.RuneWizardBanner, ItemType<RuneRune>());

            AddBannerToItemRecipe(ItemID.PirateCaptainBanner, ItemType<PirateStandard>());
            AddBannerToItemRecipe(ItemID.PirateCaptainBanner, ItemType<PirateWarhammer>());

            if (Shapeshifter)
            {
                AddBannerToItemRecipe(ItemID.GoblinSorcererBanner, ItemType<PredatorGoblin>());

                AddBannerToItemRecipe(ItemID.SkeletonMageBanner, ItemType<DeepwaterLocket>());

                AddBannerToItemRecipe(ItemID.GoblinThiefBanner, ItemType<GoblinDagger>());

                AddBannerToItemRecipe(ItemID.ManEaterBanner, ItemType<PlantEnzymes>());

                AddBannerToItemRecipe(ItemID.SnatcherBanner, ItemType<PlantEnzymes>());

                AddBannerToItemRecipe(ItemID.SpiderBanner, ItemType<WardenSpider>());

                AddBannerGroupToItemRecipe(ResonantSoulsRecipeSystem.AnyBatBanner, ItemType<SageBat>());
            }
        }
        void AddGrabBagRecipes()
        {
            recipe = Recipe.Create(ItemType<PresentQuarterstaff>());
            recipe.AddIngredient(ItemID.Present, 10);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();
        }
        void AddMiscRecipes()
        {
            recipe = Recipe.Create(ItemType<HellRune>());
            recipe.AddIngredient(ItemID.TreasureMagnet, 2);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            recipe = Recipe.Create(ItemType<NightShield>());
            recipe.AddIngredient(ItemID.TreasureMagnet, 2);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            recipe = Recipe.Create(ItemType<WardenSalamortar>());
            recipe.AddIngredient(ItemID.TreasureMagnet, 2);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();
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
                    recipe.SafeAddRecipeGroup("ResonantSouls:AnyCrystalNinjaHelm");
                    recipe.RemoveIngredient(ItemID.CrystalNinjaHelmet);
                    recipe.ShiftRecipeItems();
                }
            }
        }
        public override void AddRecipeGroups()
        {
            recipeGroup = new(() => RecipeSystem.ItemXOrY(ItemID.CrystalNinjaHelmet, ItemType<GuardianCrystalNinjaHelm>()), ItemID.CrystalNinjaHelmet, ItemType<GuardianCrystalNinjaHelm>());
            RecipeGroup.RegisterGroup("ResonantSouls:AnyCrystalNinjaHelm", recipeGroup);

            recipeGroup = new(() => Language.GetTextValue("Mods.ResonantSouls.RecipeGroups.SturdySlab"), ItemType<SturdySlab>(), ItemType<ParryingMailFeral>(), ItemType<ParryingMailFeral>(), ItemType<ParryingMailMech>(), ItemType<ParryingMailNinja>());
            RecipeGroup.RegisterGroup("ResonantSouls:AnySturdySlab", recipeGroup);

            recipeGroup = new(() => RecipeSystem.ItemXOrY(ItemType<EmpressPlateChest>(), ItemType<GuardianEmpressChestAlt>()), ItemType<EmpressPlateChest>(), ItemType<GuardianEmpressChestAlt>());
            RecipeGroup.RegisterGroup("ResonantSouls:AnyEmpressChest", recipeGroup);
        }
        void AddTravellingMerchantNPCRecipes()
        {
            if (Shapeshifter)
            {
                recipe = Recipe.Create(ItemType<HarnessYouxia>());
                recipe.AddIngredient(TravellingMerchant);
                recipe.AddIngredient(ItemID.GoldCoin, 10);
                recipe.AddTile(TileID.TinkerersWorkbench);
                recipe.AddCondition(Condition.SmashedShadowOrb);
                recipe.DisableDecraft();
                recipe.Register();
            }

            recipe = Recipe.Create(ItemType<Skateboard>());
            recipe.AddIngredient(TravellingMerchant);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.SmashedShadowOrb);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemType<BijouShield>());
            recipe.AddIngredient(TravellingMerchant);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.Hardmode);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = Recipe.Create(ItemType<HockeyQuarterstaff>());
            recipe.AddIngredient(TravellingMerchant);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddCondition(Condition.Hardmode);
            recipe.DisableDecraft();
            recipe.Register();
        }
        static void AddConversionRecipes()
        {
            AddConvertRecipe(ItemType<CorruptionQuarterstaff>(), ItemType<CrimsonQuarterstaff>());
            AddConvertRecipe(ItemType<TerrifyingMonsterFang>(), ItemType<ColossalWormTooth>());
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