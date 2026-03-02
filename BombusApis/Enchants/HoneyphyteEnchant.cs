using BombusApisBee.Items.Accessories.BeeKeeperDamageClass;
using BombusApisBee.Items.Armor.BeeKeeperDamageClass;
using BombusApisBee.Items.Weapons.BeeKeeperDamageClass;
using Fargowiltas.Content.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Microsoft.Xna.Framework;
using ResonantSouls.BombusApis.Core;

namespace ResonantSouls.BombusApis.Enchants
{
    [JITWhenModsEnabled(ModCompatibility.BombusApisBee.Name)]
    [ExtendsFromMod(ModCompatibility.BombusApisBee.Name)]
    public class HoneyphyteEnchant : BaseEnchant
    {
        public override bool IsLoadingEnabled(Mod mod) => ResonantSoulsBombusApisConfig.Instance?.Enchantments ?? false;
        public override string Texture => this.BombusTexture();
        public override Color nameColor => new(94, 170, 19);
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 44;
            Item.height = 34;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup("ResonantSouls:AnyHoneyphyteMask")
            .AddIngredient(ModContent.ItemType<HoneyphyteChestpiece>())
            .AddIngredient(ModContent.ItemType<HoneyphyteGreaves>())
            .AddIngredient(ModContent.ItemType<LihzardianHornetRelic>())
            .AddIngredient(ModContent.ItemType<TomeOfTheSun>())
            .AddIngredient(ModContent.ItemType<MegaHornet>())
            .AddTile<EnchantedTreeSheet>()
            .Register();
        }
    }
}