using Fargowiltas.Common.Configs;
using Fargowiltas.Common.Systems.Recipes;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using FargowiltasSouls.Content.Items.Summons;
using Redemption.Items;
using Redemption.Items.Accessories.HM;
using Redemption.Items.Accessories.PostML;
using Redemption.Items.Accessories.PreHM;
using Redemption.Items.Donator.Gonk;
using Redemption.Items.Materials.PostML;
using Redemption.Items.Materials.PreHM;
using Redemption.Items.Placeable.Furniture.Lab;
using Redemption.Items.Placeable.Furniture.PetrifiedWood;
using Redemption.Items.Placeable.Trophies;
using Redemption.Items.Usable;
using Redemption.Items.Weapons.HM.Magic;
using Redemption.Items.Weapons.HM.Melee;
using Redemption.Items.Weapons.HM.Ranged;
using Redemption.Items.Weapons.HM.Summon;
using Redemption.Items.Weapons.PostML.Magic;
using Redemption.Items.Weapons.PostML.Melee;
using Redemption.Items.Weapons.PostML.Ranged;
using Redemption.Items.Weapons.PostML.Summon;
using Redemption.Items.Weapons.PreHM.Magic;
using Redemption.Items.Weapons.PreHM.Melee;
using Redemption.Items.Weapons.PreHM.Ranged;
using Redemption.Items.Weapons.PreHM.Summon;
using ResonantSouls.Common.Utilities;
using static ResonantSouls.Common.Systems.ResonantSoulsRecipeHelper;


namespace ResonantSouls.Redemption.Core
{
    [JITWhenModsEnabled(ModCompatibility.Redemption.Name)]
    [ExtendsFromMod(ModCompatibility.Redemption.Name)]
    public class ResonantSoulsRedemptionRecipes : ModSystem
    {
        internal static int AnyLabCrate, AnyPetrifiedCrate, ReinforcedLabCrate;
        Recipe? recipe;
        RecipeGroup? recipeGroup;
        public override void AddRecipes()
        {
            if (FargoServerConfig.Instance.ContainerRecipes)
            {
                AddCrateRecipes();
                AddBossBagRecipes();
            }
            if (FargoServerConfig.Instance.BannerRecipes)
            {
                AddBannerRecipes();
            }
            if (FargoServerConfig.Instance.MiscRecipes)
            {
                AddMiscRecipes();
                AddBossTrophyRecipes();
                AddConversionRecipes();
            }
            ModifyRecipeGroups();
            AddTravellingMerchantNPCRecipes();
            AddFargosRecipes();
        }
        static void AddCrateRecipes()
        {
            CreateCrateRecipe(ModContent.ItemType<GasMask>(), AnyLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<Holoshield>(), AnyLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<MiniWarhead>(), AnyLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<GravityHammer>(), AnyLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<PrototypeAtomRifle>(), AnyLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<LightningRod>(), AnyLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<TeslaGenerator>(), AnyLabCrate, 3);

            CreateCrateRecipe(ModContent.ItemType<HazmatSuit>(), ReinforcedLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<MysteriousXenomiteFragment>(), ReinforcedLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<EmptyMutagen>(), ReinforcedLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<Hacksaw>(), ReinforcedLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<DepletedCrossbow>(), ReinforcedLabCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<TeslaCoil>(), ReinforcedLabCrate, 3);

            CreateCrateRecipe(ModContent.ItemType<GasMask>(), AnyPetrifiedCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<DoubleRifle>(), AnyPetrifiedCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<DAN>(), AnyPetrifiedCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<GeigerMuller>(), AnyPetrifiedCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<HazmatSuit>(), AnyPetrifiedCrate, 3);
            CreateCrateRecipe(ModContent.ItemType<HazmatSuit3>(), AnyPetrifiedCrate, 3);
        }
        static void AddBossBagRecipes()
        {
            CreateTreasureGroupRecipe(ModContent.ItemType<ErhanBag>(),
                ModContent.ItemType<Bindeklinge>(),
                ModContent.ItemType<HolyBible>(),
                ModContent.ItemType<HallowedHandGrenade>(),
                ModContent.ItemType<ErhanMagnifyingGlass>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<KeeperBag>(),
                ModContent.ItemType<SoulScepter>(),
                ModContent.ItemType<KeepersClaw>(),
                ModContent.ItemType<FanOShivs>(),
                ModContent.ItemType<HeartInsignia>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<NebBag>(),
                ModContent.ItemType<StrangeSkull>(),
                ModContent.ItemType<HamSandwich>(),
                ModContent.ItemType<NebWings>(),
                ModContent.ItemType<ThankYouLetter>() // Do I even put this here?
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<OmegaCleaverBag>(),
                ModContent.ItemType<MechanicalSheath>(),
                ModContent.ItemType<GonkPet>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<OmegaGigaporaBag>(),
                ModContent.ItemType<MicroshieldCore>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<OmegaOblitBag>(),
                ModContent.ItemType<BlastBattery>(),
                ModContent.ItemType<OOFingergun>(),
                ModContent.ItemType<SunInThePalm>(),
                ModContent.ItemType<ObliterationDrive>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<PZBag>(),
                ModContent.ItemType<PZGauntlet>(),
                ModContent.ItemType<SwarmerCannon>(),
                ModContent.ItemType<Petridish>(),
                ModContent.ItemType<PortableHoloProjector>(),
                ModContent.ItemType<HeartOfInfection>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<SlayerBag>(),
                ModContent.ItemType<SlayerGun>(),
                ModContent.ItemType<Nanoswarmer>(),
                ModContent.ItemType<SlayerFist>(),
                ModContent.ItemType<SlayerController>(),
                ModContent.ItemType<PocketShieldGenerator>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<SoIBag>(),
                ModContent.ItemType<XenoXyston>(),
                ModContent.ItemType<CystlingSummon>(),
                ModContent.ItemType<ContagionSpreader>(),
                ModContent.ItemType<NecklaceOfSight>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<ThornBag>(),
                ModContent.ItemType<AldersStaff>(),
                ModContent.ItemType<CursedGrassBlade>(),
                ModContent.ItemType<RootTendril>(),
                ModContent.ItemType<CursedThornBow>(),
                ModContent.ItemType<CircletOfBrambles>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<UkkoBag>(),
                ModContent.ItemType<Salamanisku>(),
                ModContent.ItemType<Ukonvasara>(),
                ModContent.ItemType<UkonRuno>(),
                ModContent.ItemType<VasaraPendant>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<AkkaBag>(),
                ModContent.ItemType<PoemOfIlmatar>(),
                ModContent.ItemType<Pihlajasauva>(),
                ModContent.ItemType<WaterfowlEgg>()
            );

        }
        static void AddBossTrophyRecipes()
        {
            CreateTreasureGroupRecipe(ModContent.ItemType<CockatriceTrophy>(),
                ModContent.ItemType<GreneggLauncher>(),
                ModContent.ItemType<Halbirdhouse>(),
                ModContent.ItemType<NestWand>(),
                ModContent.ItemType<ChickendWand>(),
                ModContent.ItemType<DawnHerald>()
            );
            CreateTreasureGroupRecipe(ModContent.ItemType<BasanTrophy>(),
                ModContent.ItemType<EggShield>(),
                ModContent.ItemType<GreneggLauncher>(),
                ModContent.ItemType<Halbirdhouse>(),
                ModContent.ItemType<NestWand>(),
                ModContent.ItemType<ChickendWand>(),
                ModContent.ItemType<DawnHerald>()
            );
        }
        static void AddBannerRecipes()
        {
        //   AddBannerToItemRecipe(ItemID.ElfCopterBanner, ModContent.ItemType<RCRemote>());
        }
        void AddMiscRecipes()
        {
        //    recipe = Recipe.Create(ModContent.ItemType<PresentQuarterstaff>());
        //    recipe.AddIngredient(ItemID.Present, 10);
        //    recipe.AddTile(TileID.Solidifier);
        //    recipe.Register();

        }
        void ModifyRecipeGroups()
        {
            recipeGroup = new RecipeGroup(() => RecipeGroups.ItemXOrY(ModContent.ItemType<LabCrate>(), ModContent.ItemType<LabCrate2>()), ModContent.ItemType<LabCrate>(), ModContent.ItemType<LabCrate2>());
            AnyLabCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyWoodCrate", recipeGroup);

            AnyPetrifiedCrate = ModContent.ItemType<PetrifiedCrate>();

            ReinforcedLabCrate = ModContent.ItemType<LabCrate2>();
        }
        public override void AddRecipeGroups()
        {
        //    recipeGroup = new RecipeGroup(() => RecipeSystem.ItemXOrY(ItemID.CrystalNinjaHelmet, ModContent.ItemType<GuardianCrystalNinjaHelm>()), ItemID.CrystalNinjaHelmet, ModContent.ItemType<GuardianCrystalNinjaHelm>());
        //    RecipeGroup.RegisterGroup("ResonantSouls:AnyCrystalNinjaHelm", recipeGroup);
        }
        void AddTravellingMerchantNPCRecipes()
        {
        //    recipe = Recipe.Create(ModContent.ItemType<Skateboard>());
        //    recipe.AddIngredient(TravellingMerchant);
        //    recipe.AddIngredient(ItemID.GoldCoin, 10);
        //    recipe.AddTile(TileID.TinkerersWorkbench);
        //    recipe.AddCondition(Condition.SmashedShadowOrb);
        //    recipe.DisableDecraft();
        //    recipe.Register();
        }
        static void AddConversionRecipes()
        {
            AddConvertRecipe(ModContent.ItemType<PureIronAlloy>(), ModContent.ItemType<DragonLeadAlloy>());
        }
        static void AddFargosRecipes()
        {
            Recipe recipe;

            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                recipe = Main.recipe[i];

                if (recipe.createItem.ModItem is BaseForce || recipe.createItem.ModItem is SigilOfChampions)
                {
                    recipe.SafeAddToRecipe<RoboBrain>();
                }

                //    if (recipe.HasResult(ModContent.ItemType<VerdantDoomsayerMask>()))
                //    {
                //        recipe.SafeAddToRecipe(ModContent.ItemType<HorizonFragment>());
                //    }
            }
        }
    }
}