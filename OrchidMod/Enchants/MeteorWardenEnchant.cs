using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using OrchidMod.Content.Guardian.Armors.Meteorite;
using OrchidMod.Content.Guardian.Weapons.Shields;
using Terraria.ID;

namespace ResonantSouls.OrchidMod.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class MeteorWardenEnchant : BaseEnchant
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
            .AddIngredient<GuardianMeteoriteHead>()
            .AddIngredient<GuardianMeteoriteChest>()
            .AddIngredient<GuardianMeteoriteLegs>()
            .AddIngredient<MeteoriteShield>()
            .AddRecipeGroup("FargowiltasSouls:AnyPhaseblade")
            .AddIngredient(ItemID.SpaceGun)
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}