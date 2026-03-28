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
    public class BeeSniperEnchant : BaseEnchant
    {
        public override string Texture => this.BombusTexture();
        public override Color nameColor => new(121, 135, 170);
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 48;
            Item.height = 40;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemType<BeeSniperGoggles>())
            .AddIngredient(ItemType<BeeSniperArmor>())
            .AddIngredient(ItemType<BeeSniperLeggings>())
            .AddIngredient(ItemType<BeekeeperEnchant>())
            .AddIngredient(ItemType<TheStingerSlinger>())
            .AddIngredient(ItemType<TheStarSwarmer>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}