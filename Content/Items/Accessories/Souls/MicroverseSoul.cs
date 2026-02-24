using FargowiltasSouls.Content.Items.Materials;
using Terraria.DataStructures;

namespace ResonantSouls.Content.Items.Accessories.Souls
{
    public class MicroverseSoul : BaseSoul
    {
        public override string Texture => "ResonantSouls/Assets/Textures/Content/Items/Accessories/Souls/MicroverseSoul";
        public static readonly List<int> Forces = [ ];
        public override void Load()
        {
            ModContent.TryFind(ModCompatibility.ResonantSouls.Name, "PollinationForce", out ModItem PollinationForce);
            if (ModCompatibility.BombusApisBee.Loaded && PollinationForce != null) Forces.Add(PollinationForce.Type);

            ModContent.TryFind(ModCompatibility.FargoClickers.Name, "ForceOfMatrix", out ModItem ForceOfMatrix);
            if (ModCompatibility.FargoClickers.Loaded && ForceOfMatrix != null) Forces.Add(ForceOfMatrix.Type);
        }
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 40));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 84;
            Item.height = 120;
            Item.expert = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            foreach (int force in Forces)
                recipe.AddIngredient(force);

            recipe.AddIngredient<AbomEnergy>(10)
            .AddTile<CrucibleCosmosSheet>()
            .Register();
        }
    }
}