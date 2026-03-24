using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using OrchidMod.Content.Guardian.Armors.Horizon;
using OrchidMod.Content.Guardian.Weapons.Misc;
using OrchidMod.Content.Guardian.Weapons.Shields;

namespace ResonantSouls.OrchidMod.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class HorizonEnchant : BaseEnchant
    {
        public override string Texture => DebugItem.Placeholder;
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
            .AddIngredient<GuardianHorizonHead>()
            .AddIngredient<GuardianHorizonChest>()
            .AddIngredient<GuardianHorizonLegs>()
            .AddIngredient<HorizonShield>()
            .AddIngredient<HorizonLance>()
            .AddIngredient<MoonLordShield>()
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}