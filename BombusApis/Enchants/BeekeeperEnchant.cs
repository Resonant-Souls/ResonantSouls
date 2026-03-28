using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using ResonantSouls.Common.Utilities;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class BeekeeperEnchant : BaseEnchant
    {
        public override string Texture => this.BombusTexture();
        public override Color nameColor => new(164, 179, 193);
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 44;
            Item.height = 32;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemType<BeekeepersVeil>())
            .AddIngredient(ItemType<BeekeepersRobe>())
            .AddIngredient(ItemType<BeekeepersPants>())
            .AddIngredient(ItemType<Beemerang>())
            .AddIngredient(ItemType<FrostedHoneycomb>())
            .AddIngredient(ItemType<HoneyGun>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}