using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using OrchidMod.Content.Guardian.Armors.Bamboo;
using OrchidMod.Content.Guardian.Weapons.Gauntlets;
using OrchidMod.Content.Guardian.Weapons.Warhammers;
using OrchidMod.Content.Shapeshifter.Weapons.Warden;

namespace ResonantSouls.OrchidMod.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.OrchidMod.Name)]
    [ExtendsFromMod(ModCompatibility.OrchidMod.Name)]
    public class BambooEnchant : BaseEnchant
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
            .AddIngredient<GuardianBambooHead>()
            .AddIngredient<GuardianBambooChest>()
            .AddIngredient<GuardianBambooLegs>()
            .AddIngredient<BambooWarhammer>()
            .AddIngredient<JungleGauntlet>()
            .AddIngredient<WardenEater>()
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}