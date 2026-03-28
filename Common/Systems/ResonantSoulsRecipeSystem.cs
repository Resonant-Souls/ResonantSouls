using Fargowiltas.Common.Systems.Recipes;
using Terraria.ID;

namespace ResonantSouls.Common.Systems
{
    public class ResonantSoulsRecipeSystem : ModSystem
    {
        // Used from Fargos, why make this private...
        internal static int AnyWoodCrate, AnyIronCrate, AnyGoldCrate, AnyJungleCrate, AnySkyCrate, AnyCorruptCrate, AnyCrimsonCrate, AnyHallowedCrate, AnyDungeonCrate, AnyFrozenCrate, AnySandCrate, AnyLavaCrate, AnyOceanCrate;
        internal static int AnyBatBanner;
        RecipeGroup? group;
        public override void SetStaticDefaults()
        {
            ResonantSoulsRecipeHelper.TravellingMerchant = ModCompatibility.Fargowiltas.Mod.Find<ModItem>("TravellingMerchant").Type;
        }
        public override void AddRecipeGroups()
        {
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.WoodenCrate, ItemID.WoodenCrateHard), ItemID.WoodenCrate, ItemID.WoodenCrateHard);
            AnyWoodCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyWoodCrate", group);

            //iron crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.IronCrate, ItemID.IronCrateHard), ItemID.IronCrate, ItemID.IronCrateHard);
            AnyIronCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyIronCrate", group);

            //gold crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.GoldenCrate, ItemID.GoldenCrateHard), ItemID.GoldenCrate, ItemID.GoldenCrateHard);
            AnyGoldCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyGoldCrate", group);

            //jungle crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard), ItemID.JungleFishingCrate, ItemID.JungleFishingCrateHard);
            AnyJungleCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyJunglCrate", group);

            //sky crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard), ItemID.FloatingIslandFishingCrate, ItemID.FloatingIslandFishingCrateHard);
            AnySkyCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnySkyCrate", group);

            //corrupt crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard), ItemID.CorruptFishingCrate, ItemID.CorruptFishingCrateHard);
            AnyCorruptCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyCorruptCrate", group);

            //crimson crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard), ItemID.CrimsonFishingCrate, ItemID.CrimsonFishingCrateHard);
            AnyCrimsonCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyCrimsonCrate", group);

            //hallowed crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.HallowedFishingCrate, ItemID.HallowedFishingCrateHard), ItemID.HallowedFishingCrate, ItemID.HallowedFishingCrateHard);
            AnyHallowedCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyHallowedCrate", group);

            //dungeon crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard), ItemID.DungeonFishingCrate, ItemID.DungeonFishingCrateHard);
            AnyDungeonCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyDungeonCrate", group);

            //frozen crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.FrozenCrate, ItemID.FrozenCrateHard), ItemID.FrozenCrate, ItemID.FrozenCrateHard);
            AnyFrozenCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyFrozenCrate", group);

            //oasis crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.OasisCrate, ItemID.OasisCrateHard), ItemID.OasisCrate, ItemID.OasisCrateHard);
            AnySandCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnySandCrate", group);

            //lava crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.LavaCrate, ItemID.LavaCrateHard), ItemID.LavaCrate, ItemID.LavaCrateHard);
            AnyLavaCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyLavaCrate", group);

            //ocean crates
            group = new RecipeGroup(() => RecipeGroups.ItemXOrY(ItemID.OceanCrate, ItemID.OceanCrateHard), ItemID.OceanCrate, ItemID.OceanCrateHard);
            AnyOceanCrate = RecipeGroup.RegisterGroup("Fargowiltas:AnyOceanCrate", group);

            AnyBatBanner = RecipeGroup.RegisterGroup("Fargowiltas:AnyBats", group);
        }
    }
}