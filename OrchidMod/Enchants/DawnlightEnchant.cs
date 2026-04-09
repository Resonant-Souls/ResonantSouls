using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using OrchidMod.Content.Guardian.Armors.Empress;
using OrchidMod.Content.Guardian.Weapons.Gauntlets;
using OrchidMod.Content.Guardian.Weapons.Runes;
using Terraria.ID;

namespace ResonantSouls.OrchidMod.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class DawnlightEnchant : BaseEnchant
    {
        public override string Texture => ResonantSouls.Placeholder;
        public override Color nameColor => Color.White;
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 22;
            Item.height = 24;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient<GuardianEmpressHead>()
            .AddRecipeGroup("ResonantSouls:AnyEmpressChest")
            .AddIngredient<GuardianEmpressLegs>()
            .AddIngredient<EmpressRune>()
            .AddIngredient(ItemID.PiercingStarlight)
            .AddIngredient<CrystalGauntlet>()
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}