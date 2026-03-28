using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Content.Rarities;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.ModPlayers;
using ResonantSouls.OrchidMod.Forces;
using System.Collections.Generic;
using Terraria.ID;

namespace ResonantSouls.OrchidMod.Souls
{
    public class BloomingPathsSoul : BaseSoul
    {
        public override bool IsLoadingEnabled(Mod mod) => false;
        public override string Texture => DebugItem.Placeholder;
        public override List<AccessoryEffect> ActiveSkillTooltips =>
        [
        //    AccessoryEffectLoader.GetEffect<Effect>(),
        ];
        public static List<ModItem> Forces =
        [
            GetInstance<BloomForce>(),
        ];
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            //    Main.RegisterItemAnimation(Item.type, new DrawAnimationRectangularV(6, 6, 8));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.rare = RarityType<AbominableRarity>();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoSoulsPlayer mp = player.FargoSouls();
            // FargoSoulsPlayer modPlayer = player.FargoSouls();

            foreach (ModItem force in Forces)
                mp.ForceEffects.Add(force.Type);

            mp.TerrariaSoul = true;
            mp.WizardEnchantActive = true;

            foreach (ModItem force in Forces)
            {
                force.UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            foreach (ModItem force in Forces)
                recipe.AddIngredient(force);

            recipe.AddIngredient<AbomEnergy>(10)
            .AddTile<CrucibleCosmosSheet>()
            .Register();
        }
    }
}
