using BombusApisBee.Items.Accessories.BeeKeeperDamageClass;
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
    public class SkeletalBeeEnchant : BaseEnchant
    {
        public override string Texture => this.BombusTexture();
        public override Color nameColor => new(164, 85, 78);
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 48;
            Item.height = 36;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemType<SkeletalBeeHelmet>())
            .AddIngredient(ItemType<SkeletalBeeChestplate>())
            .AddIngredient(ItemType<SkeletalBeeLeggings>())
            .AddIngredient(ItemType<Beemstick>())
            .AddIngredient(ItemType<HellcombShard>())
            .AddIngredient(ItemType<BeenadeLauncher>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}